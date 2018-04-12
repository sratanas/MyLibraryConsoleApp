using MyLibrary.Data;
using System;

namespace MyLibrary_Business
{
    public class Authors
    {
        public void SearchAuthors()
        {

            Console.WriteLine("Enter the name of the Author you're looking for:");
            var repo = new AuthorRepository();
            var result = repo.GetAuthorSearchResults(Console.ReadLine());

                Console.WriteLine("Were you looking for ");

                foreach (var author in result)
                {
                    Console.WriteLine(string.Format("{0} {1}?", author.FirstName, author.LastName));
                };
        }





        
    }
}
