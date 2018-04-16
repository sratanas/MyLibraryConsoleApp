using MyLibrary.Common;
using MyLibrary.Data;
using MyLibrary.Business;
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
                Console.WriteLine(string.Format("{0} by {1} {2}", book.Title, book.AuthorFirstName, book.AuthorLastName));
            }
            var answer = Console.ReadLine();
            if(answer == "exit")
            {
                new Searches().Exit();
            }
            else
            {
                new Searches().SearchChoice("exit");
            }


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
                        Console.WriteLine(string.Format("{0} by {1} {2}", book.Title, book.AuthorFirstName, book.AuthorLastName));
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



    }
}
