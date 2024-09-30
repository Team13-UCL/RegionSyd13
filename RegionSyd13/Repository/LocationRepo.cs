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
        public void Add(Location entity)
        {
            string query = "INSERT INTO Location (LocationID, City, PostalCode, Street, Date, Time) " +
                           "VALUES (@LocationID, @City, @PostalCode, @Street, @Date, @Time)";

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
                            LocationID = (int)reader["LocationID"],
                            TaskID = (int)reader["TaskID"],
                            City = (string)reader["City"],
                            PostalCode = (string)reader["PostalCode"],
                            Street = (string)reader["Street"],
                            //HouseNumber = (string)reader["HouseNumber"],
                            DateAndTime = date.Add(time),
                            Destination = (string)reader["Destination"],
                            Arrival = Convert.ToBoolean(reader["Arrival"])
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
    }
}