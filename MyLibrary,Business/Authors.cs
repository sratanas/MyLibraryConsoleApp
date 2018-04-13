using MyLibrary.Common;
using MyLibrary.Data;
using MyLibrary_Business;
using System;
using System.Linq;

namespace MyLibrary.Business
{
    public class Authors
    {
        public void SearchAuthors()
        {

            Console.WriteLine("Enter the name of the Author you're looking for:");
            var repo = new AuthorRepository();
            var input = Console.ReadLine();
            var result = repo.GetAuthorSearchResults(input);

            if (input == "exit")
            {
                new Searches().Exit();
            }
            else if (result.Count == 0)
            {
                Console.WriteLine("I couldn't find that author, please be more specific.");
                SearchAuthors();
  
            }

            else
            {
                Console.WriteLine("Were you looking for ");

                foreach (var author in result)
                {
                    Console.WriteLine(string.Format("{0} {1}?", author.FirstName, author.LastName));
                    var answer = Console.ReadLine();
                    var answerList = new Answers().commonYesArr;
                    if (answerList.Contains(answer))
                    {
                        Console.WriteLine("Here are all the books you own by " + author.FirstName +" "+ author.LastName+":");
                        var bookRepo = new BookRepository();
                        var authorBookList = bookRepo.GetBooksByAuthor(author.Id);
                        foreach(var book in authorBookList)
                        {
                            Console.WriteLine(string.Format("{0}, published {1}", book.Title, book.YearPublished));
                        }
                    }
                    else if(answer == "exit")
                    {
                        new Searches().Exit();
                    }
                    else
                    {
                        Console.WriteLine("Try another search.");
                        SearchAuthors();
                    }

                };

            }



            
        }






        
    }
}
