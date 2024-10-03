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
        private readonly IRepo<Task> repository;
        
        public ObservableCollection<Task> _tasks { get; set; }
        private Task selectedTask;
        public Task SelectedTask
        {
            get => selectedTask;
            set
            {
                if (selectedTask != value)
                {
                    selectedTask = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand DeleteTaskCommand { get; private set; }
        
        public TaskListViewModel(IRepo<Task> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _tasks = new ObservableCollection<Task>(repository.GetAll());            
            DeleteTaskCommand = new RelayCommand(DeleteTask);

            
        }


        public void DeleteTask(object obj)
        {
            if (obj is Task taskToDelete)
            {
                repository.Delete(taskToDelete.TaskID);
                _tasks.Remove(taskToDelete);
            }
        }
        
    }

}
