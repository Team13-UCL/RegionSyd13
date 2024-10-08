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
        private TaskRepo tRepo;
        private readonly IRepo<Task> _taskRepo;
        private PatientRepo pRepo;
        private readonly IRepo<Patient> _patientRepo;
        private LocationRepo lRepo;
        private readonly IRepo<Location> _locationRepo;

        public ObservableCollection<Task> _tasks { get; set; }
        private Task selectedTask;
        public Task SelectedTask
        {
            get => selectedTask;
            set
            {
                selectedTask = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand DeleteTaskCommand => new RelayCommand(Execute => DeleteTask(), CanExecute => SelectedTask != null);
        public RelayCommand UpdateTaskCommand => new RelayCommand(Execute => Junk(), CanExecute => SelectedTask != null);

        public TaskListViewModel(IRepo<Task> repository)
        {
            this._taskRepo = repository ?? throw new ArgumentNullException(nameof(repository));
            _tasks = new ObservableCollection<Task>(repository.GetAll());
            _patientRepo = (pRepo = new PatientRepo());
            _locationRepo = (lRepo = new LocationRepo());

            
        }
        public void Junk() { for (int i = 0; i < 100; i++) ; }

        public void DeleteTask()
        {
            
            _taskRepo.Delete(SelectedTask.TaskID);
            _patientRepo.Delete(SelectedTask.PatientID);
            if (SelectedTask.LocationStart != null) _locationRepo.Delete(SelectedTask.LocationStart.LocationID);
            if (SelectedTask.LocationStop != null) _locationRepo.Delete(SelectedTask.LocationStop.LocationID);
            _tasks.Remove(SelectedTask);
        }
        
    }

}
