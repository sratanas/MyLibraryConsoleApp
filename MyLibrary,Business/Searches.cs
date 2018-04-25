using MyLibrary.Data;
using System;

namespace MyLibrary.Business
{
    public static class Searches
    {
        //Starting point for the application
        public static void Welcome()
        {

            Console.WriteLine("Welcome to the Library, who are you?");
            var user = Console.ReadLine().ToLower();
            var userList = new UserRepository().GetUserList();

            if (userList.Contains(user))
            {
                Console.WriteLine($"Welcome back {user}! What would you like to do? (Type a number.)");

            }
            else
            {
                Console.WriteLine($"Hi {user}! Looks like you're new here.");

                new UserRepository().AddUserAndRecordVisit(user);

            }


            Console.WriteLine("What would you like to do? (Type a number.)\n[1] Look for a Book\n[2] See All Books\n[3] See more options\n");
            Console.WriteLine("(Type exit at any time to start over.)");
            var choice = Console.ReadLine().ToString();
            SearchChoice(choice);
        }

        //First set of choices
        public static void SearchChoice(string choice)
        {

            switch (choice)
            {
                case "1":
                    Console.WriteLine("How do you want to search?\n[1] Title\n[2] Author\n[3] Location");

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
                    Welcome();
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

        //pulls up second set of options that lead to more methods
        public static void MoreOptions()
        {
            Console.WriteLine("Here are some other things you can do. Please choose:");
            Console.WriteLine("[1] Add an author\n[2] Add a book\n[3] Mark a book out on loan.\n[4] Get a random book\n");
    
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    new Authors().AddAuthor();
                    break;
                case "2":
                    new Books().AddBook();
                    break;
                case "3":
                    new Locations().AddLoanedTo();
                    break;
                case "4":
                    new Books().GetARandomBookId();
                    break;
            }

        }


        public static void Exit()
        {

            Console.WriteLine("\nBye, bye!\n");
            Welcome();


        }

        

    }


    

}
