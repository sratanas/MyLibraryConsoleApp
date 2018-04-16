using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyLibrary.Data
{
    public class GenreRepository
    {

        public List<Genre> GetAllGenres()
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                List<Genre> genreList = new List<Genre>();

                string query = @"GetAllGenres";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        var genre = new Genre();

                        genre.Id = Int32.Parse(reader["Id"].ToString());
                        genre.GenreName = reader["GenreName"].ToString();

                        genreList.Add(genre);
                    }

                }


                return genreList;
            }
        }

        public Genre GetGenreById(int genreId)
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {


                string query = @"GetGenreById";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GenreId", genreId);

                SqlDataReader reader = command.ExecuteReader();

                var genre = new Genre();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        genre.Id = Int32.Parse(reader["Id"].ToString());
                        genre.GenreName = reader["GenreName"].ToString();


                    }
                }


                return genre;
            }
        }
       
    }
}
