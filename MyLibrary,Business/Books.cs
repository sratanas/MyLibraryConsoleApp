using MyLibrary.Common;
using MyLibrary.Data;
using System;
using System.Linq;

namespace MyLibrary.Business
{
    public class Books
    {

        //Gets all books in the database
        public void GetAllBooks()
        {
            var repo = new BookRepository();

            var bookList = repo.GetBooks();

            foreach (var book in bookList)
            {

                Console.WriteLine($"[{book.Id}] \"{book.Title}\" by {book.AuthorFirstName} {book.AuthorLastName}");
            }
            Console.WriteLine("If you would like to see details of a book, type the Id number and hit enter.");
            var answer = Console.ReadLine();
            var parsedAnswer = Int32.Parse(answer);
            SeeBookDetails(parsedAnswer);

        }


        public void SearchTitles()
        {
            Console.WriteLine("Enter the title of the book you're looking for:");
            var repo = new BookRepository();
            var input = Console.ReadLine();
            var result = repo.SearchTitles(input);

            if (input == "exit")
            {
                new Searches().Exit();
            }
            else if (result.Count == 0)
            {
                Console.WriteLine("I couldn't find that book, please be more specific.");
                SearchTitles();

            }

            else
            {
  
                    if (result.Count != 0)
                    {
                    Console.WriteLine("Here are the books that match your search: ");
                        foreach (var book in result)
                        {
                        Console.WriteLine($"{book.Title} by {book.AuthorFirstName} {book.AuthorLastName}");
                        }
                    new Searches().Welcome();
                    }
                    
                    else if (input == "exit")
                    {
                        new Searches().Exit();
                    }
                    else
                    {
                        Console.WriteLine("Try another search.");
                        SearchTitles();
                    }

                };

            }

        
        public void AddBook()
        {
            var book = new Book();

            //Asks user for parameters
            Console.WriteLine("Enter the title of the book:");
            book.Title = Console.ReadLine();

            Console.WriteLine("Enter the year the book was published:");
            book.YearPublished = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the LAST name of the author: ");
            var repo = new AuthorRepository();
            var input = Console.ReadLine();
            var result = repo.GetAuthorSearchResults(input);

            if (result.LastName != null)
            {
                //Returns search from author search
                Console.WriteLine("Were you looking for: {0} {1}? ", result.FirstName, result.LastName);
                var answer = Console.ReadLine();
                var answerList = new Answers().commonYesArr;
                if (answerList.Contains(answer))
                {
                    book.AuthorId = Convert.ToInt32(result.Id);
                }
            }

            else if (result.LastName == null)
            {
                //Directs user to the add author method
                Console.WriteLine("I couldn't find that author, would you like to add them?");
                var addAuthorAnswer = Console.ReadLine();

                if (new Answers().commonYesArr.Contains(addAuthorAnswer))
                {
                    new Authors().AddAuthor();
                }
                else
                {
                    Console.WriteLine("You'll have to add this author before you can add one of their books. I'll return you home for now.");
                    new Searches().Welcome();
                }
            }

            else
            {
                Console.WriteLine("Sorry, you have to start over!");
                AddBook();
            }

            //Displays Genres and enters chosen genre Id
            Console.WriteLine("What genre would you say this book is?");
            var genreList = new GenreRepository().GetAllGenres();
            foreach (var genre in genreList)
            {
                Console.WriteLine("["+genre.Id+"] " + genre.GenreName);
            }
            var chosenGenreId = Console.ReadLine();
            var parsedId = Int32.Parse(chosenGenreId);
            var chosenGenreName = new GenreRepository().GetGenreById(parsedId).GenreName;
            book.GenreId = parsedId;

            //Displays locations and enters chosen location Id
            Console.WriteLine("Where is this book located?");
            foreach (var location in new LocationRepository().GetAllLocations())
            {
                    Console.WriteLine("[" + location.Id + "] " + location.LocationName);  
            }
            var chosenLocationId = Console.ReadLine();
            var parsedLocationId = Int32.Parse(chosenLocationId);
            var chosenLocationName = new LocationRepository().GetLocationById(parsedLocationId).LocationName;
            book.LocationId = parsedLocationId;

            //Displays entry before executing
            Console.WriteLine("Here is the information you entered:");
            Console.WriteLine(book.Title);
            Console.WriteLine("Published: " + book.YearPublished);
            Console.WriteLine("By " + result.FirstName +" " + result.LastName);
            Console.WriteLine("Genre: " + chosenGenreName);
            Console.WriteLine("Location: "+ chosenLocationName);
            Console.WriteLine();
            Console.WriteLine("Is this all correct?");
            var finalAnswer = Console.ReadLine();
            if (new Answers().commonYesArr.Contains(finalAnswer))
            {
                new BookRepository().AddBook(book);
                Console.WriteLine(book.Title + " has been added to your library!");
            }
            else
            {
                Console.WriteLine("Woops. Guess you have to start over.");
                AddBook();
            }

        }

        //Lists details for one book
        public Book SeeBookDetails(int bookId)
        {

            var book = new BookRepository().GetBookById(bookId);


                Console.WriteLine("Title: " + book.Title + 
                                  "\nAuthor: " + book.FullAuthorName +
                                  "\nYear Published: " + book.YearPublished+
                                  "\nGenre: " + book.GenreName +
                                  "\nLocation: " + book.LocationName +
                                  "\n\nWould you like to: \n[1] Update book information." +
                                  "\n[2] Add notes about this book." +
                                  "\n[3] Delete this book."+
                                  "\n[4] Return to book list.");
                
                var next = Console.ReadLine();
                if (next == "1")
                {
                    EditBookDetails(bookId);
                }
                else if (next == "exit")
                {
                    new Searches().Exit();
                }


            return book;

        }


        public void EditBookDetails(int bookId)
        {
            Console.WriteLine("What would you like to update for this book?");
            Console.WriteLine("[1]Title [2]Author [3]Year Published [4]Genre [5]Location");
            var howToEdit = Console.ReadLine();
            var book = new Book();
            var repo = new BookRepository();
            Console.WriteLine();
            switch (howToEdit)
            {
                case "1":
                    Console.WriteLine("Please enter what you would like to change the title to: ");
                    var updatedInfo = Console.ReadLine();
                    repo.EditBookInformation(bookId, howToEdit, updatedInfo);
                    break;
                case "2":
                    Console.WriteLine("Search for the author you'd like to change to.");
                    var authorToChangeTo = new Authors().SearchAuthorsNoBookList().Id.ToString();
                    repo.EditBookInformation(bookId, howToEdit, authorToChangeTo);   
                    break;
                case "3":
                    Console.WriteLine("What would you like to change the year to?");
                    var yearToChange = Console.ReadLine();
                    repo.EditBookInformation(bookId, howToEdit, yearToChange);
                    break;
                case "4":
                    Console.WriteLine("What would you like to change the genre to?");
                    var genreList = new GenreRepository().GetAllGenres();
                    foreach (var genre in genreList)
                    {
                        Console.WriteLine($"[{genre.Id}] {genre.GenreName}");
                    }
                    var genreToChange = Console.ReadLine();
                    repo.EditBookInformation(bookId, howToEdit, genreToChange);
                    break;
                case "5":
                    Console.WriteLine("Where is the book's new location?");
                    var locationList = new LocationRepository().GetAllLocations();
                    foreach (var location in locationList)
                    {
                        Console.WriteLine($"[{location.Id}] {location.LocationName}");
                    }
                    var locationToChange = Console.ReadLine();
                    repo.EditBookInformation(bookId, howToEdit, locationToChange);
                    Console.WriteLine("Update successful!\n");
                    SeeBookDetails(bookId);
                    break;

            }
        }

    }
}
