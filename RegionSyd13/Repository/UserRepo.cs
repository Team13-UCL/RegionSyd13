using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RegionSyd13._1.Model;

namespace RegionSyd13.Repository
{
    internal class UserRepo : IRepo<User>
    {

        private readonly string _connectionString;
        public UserRepo()
        {
            _connectionString = Connection.ConnectionString;
        }
        public void Add(User entity)
        {
            string query = "INSERT INTO User (UserID, Username, Password) " +
                           "VALUES (@UserID, @Username, @Password)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", entity.UserID);
                command.Parameters.AddWithValue("@Username", entity.UserName);
                command.Parameters.AddWithValue("@Password", entity.Password);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM User WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            string query = "SELECT * FROM [User]";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserID = (int)reader["UserID"],
                            UserName = (string)reader["UserName"],
                            Password = (string)reader["Password"],
                            RegionID = (int)reader["RegionID"]
                        });
                    }
                }
            }

            return users;
        }

        public User GetById(int id)
        {
            User user = null;
            string query = "SELECT * FROM User WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new User
                        {
                            UserID = (int)reader["UserID"],
                            UserName = (string)reader["Username"],
                            Password = (string)reader["Password"]
                        };
                    }
                }
            }

            return user;
        }

        public void Update(User entity)
        {
            string query = "UPDATE User " +
                           "SET Username = @Username, Password = @Password " +
                           "WHERE UserID = @UserID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", entity.UserID);
                command.Parameters.AddWithValue("@Username", entity.UserName);
                command.Parameters.AddWithValue("@Password", entity.Password);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}