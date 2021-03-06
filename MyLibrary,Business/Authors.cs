﻿using MyLibrary.Common;
using MyLibrary.Data;
using System;
using System.Linq;

namespace MyLibrary.Business
{
    public class Authors
    {
        public void SearchAuthors()
        {

                    var authorResult = SearchAuthorsNoBookList();

                    var answer = Console.ReadLine();
                    var answerList = Answers.commonYesArr;
                    if (answerList.Contains(answer))
                    {
                        Console.WriteLine($"Here are all the books you own by {authorResult.FirstName} {authorResult.LastName}");
                        var bookRepo = new BookRepository();
                        var authorBookList = bookRepo.GetBooksByAuthor(authorResult.Id);
                        foreach(var book in authorBookList)
                        {
                            Console.WriteLine($"{book.Title}, published {book.YearPublished}");
                        }
                    Searches.Welcome();
                    Console.WriteLine();
                    }
                    else if(answer == "exit")
                    {
                        Searches.Exit();
                    }
                    else
                    {
                        Console.WriteLine("Try another search.");
                        SearchAuthors();
                    }

            
        }

        public Author SearchAuthorsNoBookList()
        {
            Console.WriteLine("Enter the name of the Author you're looking for:");
            var repo = new AuthorRepository();
            var input = Console.ReadLine();
            var result = repo.GetAuthorSearchResults(input);

            if (input == "exit")
            {
                Searches.Exit();
            }
            else if (result == null)
            {
                Console.WriteLine("I couldn't find that author, please be more specific.");
                SearchAuthors();

            }

            else
            {
                Console.WriteLine("Were you looking for ");


                Console.WriteLine($"{result.FirstName} {result.LastName}?");
            }

            return result;

        }


        public void AddAuthor()
        {

            var author = new Author();

            Console.WriteLine("Enter the author's LAST name:");
            author.LastName = Console.ReadLine();
            Console.WriteLine("Enter the author's FIRST name:");
            author.FirstName = Console.ReadLine();
            Console.WriteLine("Is this author female?");
            var answerList = Answers.commonYesArr;
            var answer = Console.ReadLine();
            if (answerList.Contains(answer))
            {
                author.IsFemale = "Yes";

            }
            else
            {
                author.IsFemale = "No";
            }
            Console.WriteLine($"You entered {author.FirstName} {author.LastName} as an author.");

            new AuthorRepository().AddAuthor(author);
            Searches.Welcome();

        }




        
    }
}
