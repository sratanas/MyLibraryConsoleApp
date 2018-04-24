using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }


    }

    public class Visit
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }


    public class UserRepository
    {
        public List<string> GetUserList()
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                List<string> UserNameList = new List<string>();
                
                string query = @"GetAllUsers";

                SqlCommand command = new SqlCommand(query, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        var user = new User();

                        //user.Id = Int32.Parse(reader["Id"].ToString());
                        user.UserName = reader["UserName"].ToString().ToLower();

                        UserNameList.Add(user.UserName);
                    }

                }


                return UserNameList;
            }
        }

        public void AddUserAndRecordVisit(string user)
        {
            using (SqlConnection connection = DBConnection.GetSqlConnection())
            {
                SqlTransaction tx = connection.BeginTransaction();

                //var user = new User();
                string query = @"AddUser";

                SqlCommand command = new SqlCommand(query, connection, tx);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserName", user);

                object id = command.ExecuteScalar();
                var intId = Convert.ToInt32(id);
                var stringId = id.ToString();

                var visit = new Visit();

                string query2 = @"AddVisitToNewUser";

                SqlCommand command2 = new SqlCommand(query2, connection, tx);
                command2.CommandType = System.Data.CommandType.StoredProcedure;

                command2.Parameters.AddWithValue("@Id", intId);
                command2.Parameters.AddWithValue("@Date", DateTime.Now.ToString());


                command2.ExecuteNonQuery();

                tx.Commit();

            }

        }

        public void RecordVisit()
        {

        }
    }
}
