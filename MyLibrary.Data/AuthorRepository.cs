using System;
using System.Data.SqlClient;


namespace MyLibrary.Data
{
    public class AuthorRepository
    {
        public Author GetAuthorSearchResults(string searchParam)
        {

            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                //List<Author> authorList = new List<Author>();
                var author = new Author();

                string query = @"SearchAuthors";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AuthorSearchParam", searchParam);

                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();



               

                    while (reader.Read())
                    {
                        //var author = new Author();

                        author.Id = Int32.Parse(reader["Id"].ToString());
                        author.FirstName = reader["FirstName"].ToString();
                        author.LastName = reader["LastName"].ToString();


                        //authorList.Add(author);
                    }

                

                return author;
            }
        }


        public void AddAuthor(Author author)
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                var newAuthor = new Author();
                string query = @"AddAuthor";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@AuthorFirstName", author.FirstName);
                command.Parameters.AddWithValue("@AuthorLastName", author.LastName);
                command.Parameters.AddWithValue("@IsFemale", author.IsFemale);


                command.ExecuteNonQuery();

            }
        }
    }
}
