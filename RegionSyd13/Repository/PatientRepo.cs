using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RegionSyd13._1.Model;

namespace RegionSyd13.Repository
{
    public class PatientRepo : IRepo<Patient>
    {
        private readonly string _connectionString;

        public PatientRepo()
        {
            _connectionString = Connection.ConnectionString;
            
        }

        // Add a new Patient
        public void Add(Patient entity)
        {
            string query = "INSERT INTO Patient (FirstName, LastName, Type, HandlingNote) " +
                           "VALUES (@FirstName, @LastName, @Type, @HandlingNote)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@PatientID", entity.PatientID); // patientid er en identity kolonne, så den skal ikke med
                command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                command.Parameters.AddWithValue("@LastName", entity.LastName);
                command.Parameters.AddWithValue("@Type", entity.Type);
                command.Parameters.AddWithValue("@HandlingNote", entity.HandlingNote);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Delete Patient by ID
        public void Delete(int id)
        {
            string query = "DELETE FROM Patient WHERE PatientID = @PatientID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PatientID", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Get all Patients
        public IEnumerable<Patient> GetAll()
        {
            var patients = new List<Patient>();
            string query = "SELECT * FROM Patient";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        patients.Add(new Patient
                        {
                            PatientID = (int)reader["PatientID"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Type = (string)reader["Type"],
                            HandlingNote = (string)reader["HandlingNote"]
                        });
                    }
                }
            }

            return patients;
        }

        // Get Patient by ID
        public Patient GetById(int id)
        {
            Patient patient = null;
            string query = "SELECT * FROM Patient WHERE PatientID = @PatientID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PatientID", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        patient = new Patient
                        {
                            PatientID = (int)reader["PatientID"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Type = (string)reader["Type"],
                            HandlingNote = (string)reader["HandlingNote"]
                        };
                    }
                }
            }

            return patient;
        }

        // Update an existing Patient
        public void Update(Patient entity)
        {
            string query = "UPDATE Patient SET FirstName = @FirstName, LastName = @LastName, Type = @Type, HandlingNote = @HandlingNote " +
                           "WHERE PatientID = @PatientID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PatientID", entity.PatientID);
                command.Parameters.AddWithValue("@FirstName", entity.FirstName);
                command.Parameters.AddWithValue("@LastName", entity.LastName);
                command.Parameters.AddWithValue("@Type", entity.Type);
                command.Parameters.AddWithValue("@HandlingNote", entity.HandlingNote);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
