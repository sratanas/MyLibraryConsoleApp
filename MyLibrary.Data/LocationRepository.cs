using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyLibrary.Data
{
    public class LocationRepository
    {
        public List<Location> GetAllLocations()
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                List<Location> locationList = new List<Location>();

                string query = @"GetAllLocations";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        var location = new Location();

                        location.Id = Int32.Parse(reader["Id"].ToString());
                        location.LocationName = reader["LocationName"].ToString();

                        locationList.Add(location);
                    }

                }


                return locationList;
            }
        }

        public Location GetLocationById(int locationId)
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {

                string query = @"GetLocationById";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LocationId", locationId);

                SqlDataReader reader = command.ExecuteReader();


                var location = new Location();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        location.Id = Int32.Parse(reader["Id"].ToString());
                        location.LocationName = reader["LocationName"].ToString();


                    }
                }


                return location;
            }
        }

        public List<BookOnLoan> GetAllBooksOutOnLoan()
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                List<BookOnLoan> loanList = new List<BookOnLoan>();

                string query = @"GetAllBooksOutOnLoan";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        var bookOnLoan = new BookOnLoan();

                        bookOnLoan.Id = Int32.Parse(reader["Id"].ToString());
                        bookOnLoan.BookId = Int32.Parse(reader["BookId"].ToString());
                        bookOnLoan.LoanedTo = reader["LoanedTo"].ToString();
                        bookOnLoan.DateLoaned = DateTime.Parse(reader["DateLoaned"].ToString());

                        loanList.Add(bookOnLoan);
                    }

                }


                return loanList;
            }
        }

        public void AddBookOutOnLoan(BookOnLoan bookOnLoan)
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                
                string query = @"AddBookOutOnLoan";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@BookId", bookOnLoan.BookId);
                command.Parameters.AddWithValue("@LoanedTo", bookOnLoan.LoanedTo);
                command.Parameters.AddWithValue("@DateLoaned", bookOnLoan.DateLoaned);

                command.ExecuteNonQuery();

            }
        }

    }
}
