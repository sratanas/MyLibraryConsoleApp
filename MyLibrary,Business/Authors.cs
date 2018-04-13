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

            if (result.Count == 0)
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
                };
            }



            
        }






        
    }
}
