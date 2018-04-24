using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Common
{
    public class Alerts
    {

        public void BookMessage(string message)
        {
            //var bookCount = new BookRepository();
            //var bookTotal = bookCount.GetBooks().Count;

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            //Console.WriteLine($"You now have {bookTotal} books in your database!");
            Console.ResetColor();
        }


        
        
        



    }
}
