﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RegionSyd13._1.Model;
using Task = RegionSyd13._1.Model.Task;


namespace RegionSyd13.Repository
{
    internal class TaskRepo : IRepo<Task>
    {

        private readonly string _connectionString;
        public TaskRepo()
        {
            _connectionString = Connection.ConnectionString;
        }

        // Add a new Task
        public void Add(Task entity)
        {
            string query = "INSERT INTO Task (TaskID, RegTaskID, Type, Description, ServiceGoal, PatientID, LocationID, RegionID) " +
                           "VALUES (@TaskID, @RegTaskID, @Type, @Description, @ServiceGoal, @PatientID, @LocationID, @RegionID)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TaskID", entity.TaskID);
                command.Parameters.AddWithValue("@RegTaskID", entity.RegTaskID);
                command.Parameters.AddWithValue("@Type", entity.TaskType);
                command.Parameters.AddWithValue("@Description", entity.TaskDescription);
                command.Parameters.AddWithValue("@ServiceGoal", entity.ServiceGoal);                

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Delete Task by ID
        public void Delete(int id)
        {
            string query = "DELETE FROM Task WHERE TaskID = @TaskID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TaskID", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Get all Tasks
        public IEnumerable<Task> GetAll()
        {
            var tasks = new List<Task>();
            string query = "SELECT * FROM Task";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new Task
                        {
                            TaskID = (int)reader["TaskID"],
                            RegTaskID = (string)reader["RegTaskID"],
                            TaskType = (string)reader["Type"],
                            TaskDescription = (string)reader["Description"],
                            ServiceGoal = (string)reader["ServiceGoal"],
                            
                        });
                    }
                }
            }

            return tasks;
        }

        // Get Task by ID
        public Task GetById(int id)
        {
            Task task = null;
            string query = "SELECT * FROM Task WHERE TaskID = @TaskID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TaskID", id);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        task = new Task
                        {
                            TaskID = (int)reader["TaskID"],
                            RegTaskID = (string)reader["RegTaskID"],
                            TaskType = (string)reader["Type"],
                            TaskDescription = (string)reader["Description"]

                        };
                    }
                }
            }

            return task;
        }

        // Update an existing Task
        public void Update(Task entity)
        {
            string query = "UPDATE Task SET RegTaskID = @RegTaskID, Type = @Type, Description = @Description, " +
                           "ServiceGoal = @ServiceGoal" +
                           "WHERE TaskID = @TaskID";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TaskID", entity.TaskID);
                command.Parameters.AddWithValue("@RegTaskID", entity.RegTaskID);
                command.Parameters.AddWithValue("@Type", entity.TaskType);
                command.Parameters.AddWithValue("@Description", entity.TaskDescription);            

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
