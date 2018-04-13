using MyLibrary.Common;
using MyLibrary.Data;
using MyLibrary_Business;
using System;
using System.Linq;

namespace MyLibrary.Business
{
    public class Books
    {


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



        



    }
}
