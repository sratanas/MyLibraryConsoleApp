using MyLibrary.Common;
using MyLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Business
{
    public class Locations
    {

        public void AddLoanedTo()
        {
            var bookOnLoan = new BookOnLoan();

            new Books().SearchTitles();
            Console.WriteLine("Enter the number of the book you want to mark as out on loan.");
            var selection = Console.ReadLine();
            var parsedSelection = Int32.Parse(selection);
            var outOnLoanList = new LocationRepository().GetAllBooksOutOnLoan();

            var IdList = new List<int>();
            foreach (var book in outOnLoanList)
            {
                IdList.Add(book.BookId);
            }

            if (IdList.Contains(parsedSelection))
            {
                Console.WriteLine("That book is already out on loan.\n");
                AddLoanedTo();
            }
            else
            {
                bookOnLoan.BookId = parsedSelection;

            }


            Console.WriteLine("Who did you loan this book to?");
            bookOnLoan.LoanedTo = Console.ReadLine();

            Console.WriteLine("When did you loan this book? Please enter like MM/DD/YYYY");
            var dateLoaned = DateTime.Parse(Console.ReadLine());
            bookOnLoan.DateLoaned = dateLoaned;

            Console.WriteLine("Ready to add?");
            var answer = Console.ReadLine();

            if (Answers.commonYesArr.Contains(answer))
            {
                new LocationRepository().AddBookOutOnLoan(bookOnLoan);
                Console.WriteLine();
                Searches.Welcome();
            }
            else
            {
                AddLoanedTo();
            }


        }

    }
}
