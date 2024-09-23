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
        private static TaskRepo _instance;  // Singleton instance
        public static TaskRepo GetInstance()
        {
            if (_instance == null)
            {
                _instance = new TaskRepo();
            }
            return _instance;
        }

        public TaskRepo()
        {
            // Initialize the Tasks list with some default tasks
            Tasks = new List<Task>
            {
                new Task { RegionalTaskID = "1", TaskType = "Type1", TaskDescription = "Description1", PatientNotes = "Notes1", StartLocation = "Location1", Destination = "Destination1", DateAndTimeForPickup = "2023-10-01 10:00", DateAndTimeForDestination = "2023-10-01 12:00", ServiceTarget = "Target1" },
                new Task { RegionalTaskID = "2", TaskType = "Type2", TaskDescription = "Description2", PatientNotes = "Notes2", StartLocation = "Location2", Destination = "Destination2", DateAndTimeForPickup = "2023-10-02 10:00", DateAndTimeForDestination = "2023-10-02 12:00", ServiceTarget = "Target2" }
            };
        }

        public List<Task> GetAllTasks()
        {
            return Tasks;
        }

        public Task GetTaskByID(int taskID)
        {
            return Tasks.FirstOrDefault(t => t.TaskID == taskID);
        }

        public void AddTask(Task newTask) //Adder en task
        {
            Tasks.Add(newTask);
        }

        public void EditTask(Task editedTask)
        {
            var task = GetTaskByID(editedTask.TaskID);
            if (task != null)
            {
                task.RegionalTaskID = editedTask.RegionalTaskID;
                task.TaskType = editedTask.TaskType;
                task.TaskDescription = editedTask.TaskDescription;
                task.PatientNotes = editedTask.PatientNotes;
                task.StartLocation = editedTask.StartLocation;
                task.Destination = editedTask.Destination;
                task.DateAndTimeForPickup = editedTask.DateAndTimeForPickup;
                task.DateAndTimeForDestination = editedTask.DateAndTimeForDestination;
                task.ServiceTarget = editedTask.ServiceTarget;
            }
        }

        public void DeleteTask(int taskID) //Deletes tasks :D
        {
            var task = GetTaskByID(taskID);
            if (task != null)
            {
                Tasks.Remove(task);
            }
        }
    }
}