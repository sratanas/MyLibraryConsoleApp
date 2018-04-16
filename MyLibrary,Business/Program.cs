using System;

namespace MyLibrary.Business
{
    class Program

    {
        static void Main(string[] args)
        {
            Console.Title = "My Awesome Home Library!";

            new Searches().Welcome();
            Console.ReadKey();

          
           
        }
    }
}
