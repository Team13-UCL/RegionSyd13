using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._1.Model
{
    interface ITaskRepo
    {
        List<Task> GetAllTasks();
        Task GetTaskByID(string taskID);
        void AddTask(Task newTask);
        void EditTask(Task updatedTask);
        void DeleteTask(string taskID);
    }
}
