using MyLibrary.Data;
using System;

namespace MyLibrary.Business
{
    class Program

    {
        static void Main(string[] args)
        {
            var repo = new BookRepository();
            
            var bookList = repo.GetBooks();
            

            foreach (var book in bookList)
            {
                Console.WriteLine(book.Title);
            }
            

            Console.ReadKey();
           
        }
    }
}
