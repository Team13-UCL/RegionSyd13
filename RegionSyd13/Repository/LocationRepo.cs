using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RegionSyd13._1.Model;

namespace RegionSyd13.Repository
{
    internal class LocationRepo : IRepo<Location>
    {
        private readonly string _connectionString;
        public LocationRepo()
        {
            _connectionString = Connection.ConnectionString;
            locations = new List<Location>(GetAll());
        }
        List<Location> locations;
        public List<Location> GetLocations(int id)
        {
            List<Location> taskLocations = new List<Location>();
            foreach (var location in locations)
            {
                if (location.TaskID == id)
                {
                    taskLocations.Add(location);
                }
            }
            return taskLocations; 
        }
        public Location Add(Location entity)
        {
            string query = "INSERT INTO Location (Destination, City, PostalCode, Street, Date, Time, TaskID) " +
                           "VALUES (@Destination, @City, @PostalCode, @Street, @Date, @Time, @TaskID)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Destination", entity.Destination);
                command.Parameters.AddWithValue("@City", entity.City);
                command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
                command.Parameters.AddWithValue("@Street", entity.Street);                
                command.Parameters.AddWithValue("@Date", entity.DateAndTime.Date);        
                command.Parameters.AddWithValue("@Time", entity.DateAndTime.TimeOfDay);
                command.Parameters.AddWithValue("@TaskID", entity.TaskID);
                connection.Open();
                command.ExecuteNonQuery();
            }
            
            return null;
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
                        var date = (DateTime)reader["Date"];
                        var time = (TimeSpan)reader["Time"];
                        locations.Add(new Location
                        {
                            LocationID = reader["LocationID"] is DBNull ? 0 : (int)reader["LocationID"], // Default to 0 if DBNull
                            TaskID = reader["TaskID"] is DBNull ? 0 : (int)reader["TaskID"], // Default to 0 if DBNull
                            City = reader["City"] is DBNull ? string.Empty : (string)reader["City"], // Default to empty string if DBNull
                            PostalCode = reader["PostalCode"] is DBNull ? string.Empty : (string)reader["PostalCode"], // Default to empty string if DBNull
                            Street = reader["Street"] is DBNull ? string.Empty : (string)reader["Street"], // Default to empty string if DBNull
                            DateAndTime = date.Add(time), // Combine date and time
                            Destination = reader["Destination"] is DBNull ? string.Empty : (string)reader["Destination"], // Default to empty string if DBNull
                            Arrival = reader["Arrival"] is DBNull ? false : Convert.ToBoolean(reader["Arrival"]) // Default to false if DBNull
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

                        var date = (DateTime)reader["Date"];
                        var time = (TimeSpan)reader["Time"];

                        location = new Location
                        {
                            LocationID = (int)reader["LocationID"],
                            City = (string)reader["City"],
                            PostalCode = (string)reader["PostalCode"],
                            Street = (string)reader["Street"],
                            //HouseNumber = (string)reader["HouseNumber"],
                            DateAndTime = date.Add(time)
                        };
                    }
                }
            }

            return location;
        }

        public void Update(Location entity)
        {
            string query = "UPDATE Location " +
                           "SET City = @City, PostalCode = @PostalCode, Street = @Street, Date = @Date, Time = @Time " +
                           "WHERE LocationID = @LocationID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocationID", entity.LocationID);
                command.Parameters.AddWithValue("@City", entity.City);
                command.Parameters.AddWithValue("@PostalCode", entity.PostalCode);
                command.Parameters.AddWithValue("@Street", entity.Street);
                command.Parameters.AddWithValue("@Date", entity.DateAndTime.Date);
                command.Parameters.AddWithValue("@Time", entity.DateAndTime.TimeOfDay);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateSpecific(string column, string value, int ID)
        {
            throw new NotImplementedException();
        }

        public void AddSpecific(string columns, string values)
        {
            throw new NotImplementedException();
        }
    }
}