using MyLibrary.Business;
using System;

namespace MyLibrary.Business
{
    public class Searches
    {
        //Starting point for the application
        public void Welcome()
        {

            Console.WriteLine("Welcome to the Library, what would you like to do? (Type a number.)");
            Console.WriteLine();
            Console.WriteLine("[1] Look for a Book");
            Console.WriteLine("[2] See All Books");
            Console.WriteLine("[3] See more options");
            Console.WriteLine();
            Console.WriteLine("(Type exit at any time to start over.)");
            var choice = Console.ReadLine().ToString();
            new Searches().SearchChoice(choice);
        }

        //First set of choices
        public void SearchChoice(string choice)
        {

            switch (choice)
            {
                case "1":
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
                    break;
                case "2":
                    new Books().GetAllBooks();
                    break;
                case "3":
                    MoreOptions();
                    break;
                case "exit":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Please choose one of the numbers.");
                    SearchChoice(Console.ReadLine());
                    break;

            } 
        }

        
        public void MoreOptions()
        {
            Console.WriteLine("Here are some other things you can do. Please choose:");
            Console.WriteLine("[1] Add an author");
            Console.WriteLine("[2] Add a book");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    new Authors().AddAuthor();
                    break;
                case "2":
                    new Books().AddBook();
                    break;
            }

        }


        public void Exit()
        {

            Console.WriteLine("Bye, bye!");
            Welcome();


        }
    }
}
