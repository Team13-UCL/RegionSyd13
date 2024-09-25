using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.VisualBasic;
using RegionSyd13._1.Model;
using RegionSyd13._2.View;
using RegionSyd13.MVVM;
using RegionSyd13.Repository;
using Task = RegionSyd13._1.Model.Task;

namespace RegionSyd13._3.ViewModel
{

    public class TaskBankViewModel : ViewModelBase
    {

        private string regionalTaskID;
        private string taskType;
        private string taskDescription;
        private string patientNotes;
        private string taskStatus;
        private string startLocation;
        private string destination;
        private Patient taskPatient;
        private string dateAndTimeForPickup;
        private string dateAndTimeForDestination;
        private string serviceTarget;
        public ICommand AddTaskCommand { get; private set; }
        public ICommand EditTaskCommand { get; private set; }
        public ICommand DeleteTaskCommand { get; private set; }
        public ObservableCollection<Task> Tasks { get; set; }





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
                    Debug.WriteLine($"SelectedTask set to: {selectedTask}");
                }
            }
        }

        private IRepo taskRepo;





        public TaskBankViewModel(IRepo taskRepo)
        {
            this.taskRepo = taskRepo;

            AddTaskCommand = new RelayCommand(AddTask);
            EditTaskCommand = new RelayCommand(EditTask);
            DeleteTaskCommand = new RelayCommand(DeleteTask);
            Tasks = new ObservableCollection<Task>(taskRepo.GetAllTasks());
        }






        public void AddTask(object obj)
        {
            if (SelectedTask == null)
            {

                int newTaskID = Tasks.Count + 1; 

                var newTask = new Task
                {
                    TaskID = newTaskID, 
                    RegionalTaskID = RegionalTaskID, 
                    TaskType = TaskType,
                    TaskDescription = TaskDescription,
                    PatientNotes = PatientNotes,
                    StartLocation = StartLocation,
                    Destination = Destination,
                    DateAndTimeForPickup = DateAndTimeForPickup,
                    DateAndTimeForDestination = DateAndTimeForDestination,
                    ServiceGoals = ServiceTarget,
                };

                if (!Tasks.Any(t => t.TaskID == newTask.TaskID)) 
                {
                    Tasks.Add(newTask);
                    taskRepo.AddTask(newTask); 
                }

            }
        }





        public void EditTask(object obj)
        {
            if (SelectedTask == null)
            {
                MessageBox.Show("Please select a task to edit.");
                return;
            }
            if (SelectedTask != null)
            {
                taskRepo.EditTask(SelectedTask);
                
                OnPropertyChanged(nameof(Tasks));
            }
            
            
        }



        public void DeleteTask(object obj)
        {
            if (obj is Task taskToDelete)
            {
                taskRepo.DeleteTask(taskToDelete.TaskID);
                Tasks.Remove(taskToDelete);
            }
        }
        

        public void Login()
        {
        }




        public string RegionalTaskID
        {
            get => regionalTaskID;
            set
            {
                if (regionalTaskID != value)
                {
                    regionalTaskID = value;
                    OnPropertyChanged();
                    
                }
            }
        }

        public string TaskType
        {
            get => taskType;
            set
            {
                taskType = value;
                OnPropertyChanged();
            }
        }

        public string TaskDescription
        {
            get => taskDescription;
            set
            {
                taskDescription = value;
                OnPropertyChanged();
            }
        }

        public string PatientNotes
        {
            get => patientNotes;
            set
            {
                patientNotes = value;
                OnPropertyChanged();
            }
        }

        public string TaskStatus
        {
            get => taskStatus;
            set
            {
                taskStatus = value;
                OnPropertyChanged();
            }
        }

        public string StartLocation
        {
            get => startLocation;
            set
            {
                startLocation = value;
                OnPropertyChanged();
            }
        }

        public string Destination
        {
            get => destination;
            set
            {
                destination = value;
                OnPropertyChanged();
            }
        }

        public Patient TaskPatient
        {
            get => taskPatient;
            set
            {
                taskPatient = value;
                OnPropertyChanged();
            }
        }

        public string DateAndTimeForPickup
        {
            get => dateAndTimeForPickup;
            set
            {
                dateAndTimeForPickup = value;
                OnPropertyChanged();
            }
        }

        public string DateAndTimeForDestination
        {
            get => dateAndTimeForDestination;
            set
            {
                dateAndTimeForDestination = value;
                OnPropertyChanged();
            }
        }

        public string ServiceTarget
        {
            get => serviceTarget;
            set
            {
                serviceTarget = value;
                OnPropertyChanged();
            }
        }


    }

}
