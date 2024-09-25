using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd13._1.Model;

namespace RegionSyd13.Repository
{

    internal class RegionRepo : IRepo<Region>
        {
            private readonly string _connectionString;
            public RegionRepo(string connectionString)
            {
                _connectionString = connectionString;
            }
            public void Add(Region entity)
            {
                string query = "INSERT INTO Region (RegID, Name)\n" +
                    "VALUES (@RegID, @Name)";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Firstname", entity.RegID);
                    command.Parameters.AddWithValue("@LastName", entity.Name);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void Delete(int id)
            {
            string query = "DELETE FROM PRODUCT WHERE RegID = @RegID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("RegID", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

            public IEnumerable<Region> GetAll()
            {
                var Regions = new List<Region>();
                string query = "SELECT * FROM CUSTOMER";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Regions.Add(new Region
                            {
                                
                                RegID = (string)reader["FirstName"],
                                Name = (string)reader["LastName"]
                                
                            });
                        }
                    }
                }

                return Regions;
            }

            public Region GetById(int id)
            {
                Region customer = null;
                string query = "SELECT * FROM CUSTOMER WHERE CustomerID = @CustomerID";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RegID", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Region
                            {
                                RegID = (string)reader["FirstName"],
                                Name = (string)reader["LastName"]
                            };
                        }
                    }
                }

                return customer;
            }

            public void Update(Region entity)
            {
            string query = "UPDATE Region \n " +
            "SET Name = @Name, RegID = @RegID\n" +
            "WHERE RegID = @RegID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegID", entity.RegID);
                command.Parameters.AddWithValue("@Name", entity.Name);                                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        }
    
}
