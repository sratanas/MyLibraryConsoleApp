﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace MyLibrary.Data
{
    public class AuthorRepository
    {
        public List<Author> GetAuthorSearchResults(string searchParam)
        {

            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                List<Author> authorList = new List<Author>();

                string query = @"SearchAuthors";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@AuthorSearchParam", searchParam);

                command.ExecuteNonQuery();
                SqlDataReader reader = command.ExecuteReader();



                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        var author = new Author();

                        author.Id = Int32.Parse(reader["Id"].ToString());
                        author.FirstName = reader["FirstName"].ToString();
                        author.LastName = reader["LastName"].ToString();


                        authorList.Add(author);
                    }

                }

                return authorList;
            }
        }
    }
}
