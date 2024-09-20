using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using RegionSyd13._1.Model;
using RegionSyd13._2.View;
using RegionSyd13.MVVM;
using Task = RegionSyd13._1.Model.Task;

namespace RegionSyd13._3.ViewModel
{
    public class TaskListViewModel : ViewModelBase
    {
        private ObservableCollection<Task> tasks;
        public ObservableCollection<Task> Tasks
        {
            get => tasks;
            set
            {
                tasks = value;
                OnPropertyChanged();
            }
        }

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

        private ITaskRepo taskRepo;

        public ICommand EditTaskCommand { get; private set; }
        public ICommand DeleteTaskCommand { get; private set; }

        public TaskListViewModel(ITaskRepo taskRepo)
        {
            this.taskRepo = taskRepo;
            Tasks = new ObservableCollection<Task>(taskRepo.GetAllTasks());
            EditTaskCommand = new RelayCommand(EditTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
        }

        public void EditTask(object obj)
        {
            if (obj is Task editedTask)
            {
                // Open TaskBankView for editing
                TaskBankView taskBankView = new TaskBankView();
                TaskBankViewModel taskBankViewModel = (TaskBankViewModel)taskBankView.DataContext;

                // Populate TaskBankViewModel with the selected task details
                taskBankViewModel.RegionalTaskID = editedTask.RegionalTaskID;
                taskBankViewModel.TaskType = editedTask.TaskType;
                taskBankViewModel.TaskDescription = editedTask.TaskDescription;
                taskBankViewModel.PatientNotes = editedTask.PatientNotes;
                taskBankViewModel.StartLocation = editedTask.StartLocation;
                taskBankViewModel.Destination = editedTask.Destination;
                taskBankViewModel.DateAndTimeForPickup = editedTask.DateAndTimeForPickup;
                taskBankViewModel.DateAndTimeForDestination = editedTask.DateAndTimeForDestination;
                taskBankViewModel.ServiceTarget = editedTask.ServiceTarget;

                taskBankView.Show();
            }
        }

        public void DeleteTask(object obj)
        {
            if (obj is Task taskToDelete)
            {
                taskRepo.DeleteTask(taskToDelete.RegionalTaskID);
                Tasks.Remove(taskToDelete);
            }
        }
    }

}
