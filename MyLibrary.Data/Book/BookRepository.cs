using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyLibrary.Data
{
    public class BookRepository 
    {

        public List<Book>GetBooks()
        {

            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                connection.InfoMessage += (sender, e) =>
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"warning or info {e.Message}");
                    Console.ResetColor();

                };

                connection.StateChange += (sender, e) =>
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"curent state: {e.CurrentState}, before: {e.OriginalState}");
                    Console.ResetColor();

                };
                try
                {
                    connection.StatisticsEnabled = true;
                    connection.FireInfoMessageEventOnUserErrors = true;
                    connection.Open();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                List<Book> bookList = new List<Book>();

                string query = @"GetAllBookInfo";
                
                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        var book = new Book();
                        var author = new Author();
                        var genre = new Genre();
                        var location = new Location();

                        book.Id = Int32.Parse(reader["Id"].ToString());
                        book.Title = reader["Title"].ToString();
                        book.YearPublished = Int32.Parse(reader["YearPublished"].ToString());

                        author.Id = Int32.Parse(reader["AuthorId"].ToString());
                        author.FirstName = reader["FirstName"].ToString();
                        author.LastName = reader["LastName"].ToString();

                        genre.Id = Int32.Parse(reader["Id"].ToString());
                        genre.GenreName = reader["GenreName"].ToString();

                        location.Id = Int32.Parse(reader["Id"].ToString());
                        location.LocationName = reader["LocationName"].ToString();

                        book.Genre = genre;
                        book.Author = author;
                        book.Location = location;
                        bookList.Add(book);
                    }

                }


                return bookList;
            }
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                List<Book> authorBookList = new List<Book>();

                string query = @"GetBooksByAuthor";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AuthorId", authorId);

                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        var book = new Book();

                        book.Title = reader["Title"].ToString();
                        book.YearPublished = Int32.Parse(reader["YearPublished"].ToString());

                        authorBookList.Add(book);
                    }

                }


                return authorBookList;
            }
        }

        public List<Book> SearchTitles(string title)
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                List<Book> titleList = new List<Book>();

                string query = @"TitleSearch";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@TitleSearchParam", title);

                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        var book = new Book();

                        book.Id = Int32.Parse(reader["Id"].ToString());
                        book.Title = reader["Title"].ToString();
                        book.Author.FirstName = reader["FirstName"].ToString();
                        book.Author.LastName = reader["LastName"].ToString();

                        titleList.Add(book);
                    }

                }


                return titleList;
            }
        }

        public void AddBook(Book book)
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                //var newBook = new Book();
                string query = @"AddBook";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@YearPublished", book.YearPublished);
                command.Parameters.AddWithValue("@Author", book.Author.Id);
                command.Parameters.AddWithValue("@Genre", book.Genre);
                command.Parameters.AddWithValue("@Location", book.Location.Id);



                command.ExecuteNonQuery();

            }
        }

        public Book GetBookById(int bookId)
        {

            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                var book = new Book();

                string query = @"GetBookDetailsById";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", bookId);

                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {

                    var author = new Author();
                    var genre = new Genre();
                    var location = new Location();

                    book.Id = Int32.Parse(reader["Id"].ToString());
                    book.Title = reader["Title"].ToString();
                    book.YearPublished = Int32.Parse(reader["YearPublished"].ToString());

                    author.Id = Int32.Parse(reader["AuthorId"].ToString());
                    author.FirstName = reader["FirstName"].ToString();
                    author.LastName = reader["LastName"].ToString();

                    genre.Id = Int32.Parse(reader["Id"].ToString());
                    genre.GenreName = reader["GenreName"].ToString();

                    location.Id = Int32.Parse(reader["Id"].ToString());
                    location.LocationName = reader["LocationName"].ToString();

                    book.Location = location;
                    book.Genre = genre;
                    book.Author = author;

                }
                return book;

            }

        }

        public void EditBookInformation(int bookId, string updateType, string newInput)
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
            
              
                string query = @"UpdateBookInformation";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BookId", bookId);
                command.Parameters.AddWithValue("@UpdateType", updateType);
                command.Parameters.AddWithValue("@NewInput", newInput);

                command.ExecuteNonQuery();



            }
        }

    }
}
