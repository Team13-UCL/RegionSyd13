using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._1.Model
{
    public interface ITaskRepo
    {
        List<Task> GetAllTasks();
        Task GetTaskByID(int taskID);
        void AddTask(Task newTask);
        void EditTask(Task updatedTask);
        void DeleteTask(int taskID);

        
    }
}
