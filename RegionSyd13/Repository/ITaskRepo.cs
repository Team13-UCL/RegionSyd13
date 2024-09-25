using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionSyd13._1.Model;

namespace RegionSyd13.Repository
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
