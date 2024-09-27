using System;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Windows.Input;
using RegionSyd13._1.Model;
using RegionSyd13._2.View;
using RegionSyd13.MVVM;
using RegionSyd13.Repository;
using Task = RegionSyd13._1.Model.Task;

namespace RegionSyd13._3.ViewModel
{
    public class TaskListViewModel : CurrentUser
    {
        private readonly IRepo<Task> taskRepo;
        public ObservableCollection<Task> Tasks { get; set; }
        public Task SelectedTask { get; set; }
        public TaskListViewModel(IRepo<Task> repository)
        {
            this.taskRepo = taskRepo ?? throw new ArgumentNullException(nameof(taskRepo));
            Tasks = new ObservableCollection<Task>(taskRepo.GetAll());
        }
    }

}
