using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RegionSyd13._1.Model;

namespace RegionSyd13.Repository
{
    internal class LocationRepo : IRepo<Location>
    {
        private readonly string _connectionString;

        public LocationRepo(string connectionString)
        {
            _connectionString = Connection.ConnectionString;
        }

        public void Add(Location entity)
        {
            string query = "INSERT INTO Location (LocationID, City, PostalCode, Street, HouseNumber, Date, Time) " +
                           "VALUES (@LocationID, @City, @PostalCode, @Street, @HouseNumber, @Date, @Time)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocationID", entity.LocationID);
                command.Parameters.AddWithValue("@City", entity.City);
                command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
                command.Parameters.AddWithValue("@Street", entity.Street);
                command.Parameters.AddWithValue("@HouseNumber", entity.HouseNumber);
                command.Parameters.AddWithValue("@Date", entity.date);
                command.Parameters.AddWithValue("@Time", entity.time);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Location WHERE LocationID = @LocationID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocationID", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Location> GetAll()
        {
            var locations = new List<Location>();
            string query = "SELECT * FROM Location";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        locations.Add(new Location
                        {
                            LocationID = (int)reader["LocationID"],
                            City = (string)reader["City"],
                            PostalCode = (string)reader["PostalCode"],
                            Street = (string)reader["Street"],
                            HouseNumber = (string)reader["HouseNumber"],
                            date = (int)reader["Date"],
                            time = (int)reader["Time"]
                        });
                    }
                }
            }

            return locations;
        }

        public Location GetById(int id)
        {
            Location location = null;
            string query = "SELECT * FROM Location WHERE LocationID = @LocationID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocationID", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        location = new Location
                        {
                            LocationID = (int)reader["LocationID"],
                            City = (string)reader["City"],
                            PostalCode = (string)reader["PostalCode"],
                            Street = (string)reader["Street"],
                            HouseNumber = (string)reader["HouseNumber"],
                            date = (int)reader["Date"],
                            time = (int)reader["Time"]
                        };
                    }
                }
            }

            return location;
        }

        public void Update(Location entity)
        {
            string query = "UPDATE Location " +
                           "SET City = @City, PostalCode = @PostalCode, Street = @Street, HouseNumber = @HouseNumber, Date = @Date, Time = @Time " +
                           "WHERE LocationID = @LocationID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocationID", entity.LocationID);
                command.Parameters.AddWithValue("@City", entity.City);
                command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
                command.Parameters.AddWithValue("@Street", entity.Street);
                command.Parameters.AddWithValue("@HouseNumber", entity.HouseNumber);
                command.Parameters.AddWithValue("@Date", entity.date);
                command.Parameters.AddWithValue("@Time", entity.time);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}