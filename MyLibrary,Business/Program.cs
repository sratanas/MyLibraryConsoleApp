using MyLibrary.Business;
using MyLibrary.Common;
using MyLibrary_Business;
using System;

namespace MyLibrary.Business
{
    class Program

    {
        static void Main(string[] args)
        {
            Console.Title = "My Awesome Home Library!";

            //var books = new Books();
            new Searches().Welcome();
            Console.ReadKey();

          
           
        }
    }
}
