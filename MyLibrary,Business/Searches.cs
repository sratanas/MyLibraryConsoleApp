using MyLibrary.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary_Business
{
    public class Searches
    {

        public void Welcome()
        {

            Console.WriteLine("Welcome to the Library, what would you like to do? (Type a number.)");
            Console.WriteLine();
            Console.WriteLine("[1] Look for a Book");
            Console.WriteLine("[2] See All Books");
            Console.WriteLine();
            Console.WriteLine("(Type exit at any time to start over.)");
            var choice = Console.ReadLine().ToString();
            new Searches().SearchChoice(choice);
        }

        public void SearchChoice(string choice)
        {
            if (choice == "1")
            {
                Console.WriteLine("How do you want to search?");
                Console.WriteLine("[1] Title");
                Console.WriteLine("[2] Author");
                Console.WriteLine("[3] Location");
                var searchChoice = Console.ReadLine();
                if (searchChoice == "1")
                {
                    new Books().SearchTitles();

                }
                else if (searchChoice == "2")
                {
                    var repo = new Authors();
                    repo.SearchAuthors();

                }

            }
            else if (choice == "2")
            {
                new Books().GetAllBooks();
            }
            else if (choice == "exit")
            {
                Exit();
            }
            else
            {
                Console.WriteLine("Please choose 1 or 2");
                SearchChoice(Console.ReadLine());
            }
        }

        public void Exit()
        {

            Console.WriteLine("Bye, bye!");
            Welcome();


        }
    }
}
