using MyLibrary.Data;
using System;

namespace MyLibrary_Business
{
    public class Books
    {

        public void Welcome()
        {
            var books = new Books();

            Console.WriteLine("Welcome to the Library, what would you like to do? (Type a number.)");
            Console.WriteLine();
            Console.WriteLine("[1] Look for a Book");
            Console.WriteLine("[2] See All Books");
            Console.WriteLine();
            Console.WriteLine("(Type exit at any time to start over.)");
            books.SearchChoice(Console.ReadLine());
        }


        public void GetAllBooks()
        {
            var repo = new BookRepository();

            var bookList = repo.GetBooks();

           
            foreach (var book in bookList)
            {
                Console.WriteLine(string.Format("{0} by {1} {2}", book.Title, book.AuthorFirstName, book.AuthorLastName));
            }


        }

        public void SearchChoice(string choice)
        {
            if (choice == "1")
            {
                Console.WriteLine("How do you want to search?");
                Console.WriteLine("1-Title");
                Console.WriteLine("2-Author");
                Console.WriteLine("3-Location");
                var searchChoice = Console.ReadLine();
                if (searchChoice == "1")
                {
                    
                }
                else if (searchChoice == "2")
                {
                    var repo = new Authors();
                    repo.SearchAuthors();

                }

            }
            else if (choice == "2")
            {
                GetAllBooks();
            }
            else if(choice == "exit")
            {
                Welcome();
            }
            else
            {
                Console.WriteLine("Please choose 1 or 2");
                SearchChoice(Console.ReadLine());
            }
        }

       


    }
}
