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
        public RegionRepo()
        {
            _connectionString = Connection.ConnectionString;
        }
        public void Add(Region entity)
            {
                string query = "INSERT INTO Region (RegID, RegName)\n" +
                    "VALUES (@RegID, @RegName)";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Firstname", entity.RegID);
                    command.Parameters.AddWithValue("@LastName", entity.RegName);
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
                var regions = new List<Region>();
                string query = "SELECT * FROM Region";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            regions.Add(new Region
                            {
                                
                                RegID = (int)reader["RegionID"],
                                RegName = (string)reader["RegionName"]
                                
                            });
                        }
                    }
                }

                return regions;
            }

            public Region GetById(int id)
            {
                Region region = null;
                string query = "SELECT * FROM Region WHERE RegID = @RegID";

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RegID", id);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            region = new Region
                            {
                                RegID = (int)reader["RegionID"],
                                RegName = (string)reader["RegionName"]
                            };
                        }
                    }
                }

                return region;
            }

            public void Update(Region entity)
            {
            string query = "UPDATE Region \n " +
            "SET RegName = @RegName, RegID = @RegID\n" +
            "WHERE RegID = @RegID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegID", entity.RegID);
                command.Parameters.AddWithValue("@RegName", entity.RegName);                                
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        }
    
}
