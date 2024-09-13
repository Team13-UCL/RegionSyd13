using System;
using System.Collections.Generic;
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
            return Tasks;
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