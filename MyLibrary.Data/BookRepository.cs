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

                        book.Id = Int32.Parse(reader["Id"].ToString());
                        book.Title = reader["Title"].ToString();
                        book.AuthorFirstName = reader["FirstName"].ToString();
                        book.AuthorLastName = reader["LastName"].ToString();
                        book.GenreName = reader["GenreName"].ToString();
                        book.YearPublished = Int32.Parse(reader["YearPublished"].ToString());
                        book.LocationName = reader["LocationName"].ToString();

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
                        book.AuthorFirstName = reader["FirstName"].ToString();
                        book.AuthorLastName = reader["LastName"].ToString();

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
                command.Parameters.AddWithValue("@Author", book.AuthorId);
                command.Parameters.AddWithValue("@Genre", book.GenreId);
                command.Parameters.AddWithValue("@Location", book.LocationId);



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

                    book.Title = reader["Title"].ToString();
                    book.AuthorFirstName = reader["FirstName"].ToString();
                    book.AuthorLastName = reader["LastName"].ToString();
                    book.GenreName = reader["GenreName"].ToString();
                    book.YearPublished = Int32.Parse(reader["YearPublished"].ToString());
                    book.LocationName = reader["LocationName"].ToString();

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
