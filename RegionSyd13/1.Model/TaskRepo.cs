using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._1.Model
{
    public class TaskRepo : ITaskRepo //Tager fra ITaskRepo
    {
        private List<Task> Tasks = new List<Task>();

        public List<Task> GetAllTasks()
        {
            return new List<Task>
            {
            new Task { RegionalTaskID = "1", TaskType = "Type1", TaskDescription = "Description1", PatientNotes = "Notes1", StartLocation = "Location1", Destination = "Destination1", DateAndTimeForPickup = "2023-10-01 10:00", DateAndTimeForDestination = "2023-10-01 12:00", ServiceTarget = "Target1" },
            new Task { RegionalTaskID = "2", TaskType = "Type2", TaskDescription = "Description2", PatientNotes = "Notes2", StartLocation = "Location2", Destination = "Destination2", DateAndTimeForPickup = "2023-10-02 10:00", DateAndTimeForDestination = "2023-10-02 12:00", ServiceTarget = "Target2" }
            };

        }

        public Task GetTaskByID(string taskID)
        {
            return Tasks.FirstOrDefault(t => t.RegionalTaskID == taskID);
        }

        public void AddTask(Task newTask) //Adder en task
        {
            Tasks.Add(newTask);
        }

        public void EditTask(Task editedTask) //Ændre tasks
        {
            var task = GetTaskByID(editedTask.RegionalTaskID);
            if (task != null)
            {

            }
        }

        public void DeleteTask(string taskID) //Deletes tasks :D
        {
            var task = GetTaskByID(taskID);
            if (task != null)
            {
                Tasks.Remove(task);
            }
        }
    }
}