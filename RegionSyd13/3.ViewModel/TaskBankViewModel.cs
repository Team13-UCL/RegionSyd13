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
using RegionSyd13.MVVM;
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

        


        private  ITaskRepo taskRepo;

        public ICommand AddTaskCommand { get; private set; }



       

        public TaskBankViewModel(ITaskRepo taskRepo)
        {
            this.taskRepo = taskRepo;
            Tasks = new ObservableCollection<Task>(taskRepo.GetAllTasks());
            AddTaskCommand = new RelayCommand(AddTask);
        }

        
      
        public void AddTask(object obj)
        {
            var newTask = new Task
            {
                RegionalTaskID = RegionalTaskID,
                TaskType = TaskType,
                TaskDescription = TaskDescription,
                PatientNotes = PatientNotes,
                StartLocation = StartLocation,
                Destination = Destination,
                DateAndTimeForPickup = DateAndTimeForPickup,
                DateAndTimeForDestination = DateAndTimeForDestination,
                ServiceTarget = ServiceTarget,
            };

            taskRepo.AddTask(newTask); // Ensure the task is added to the repository first
            Tasks.Add(newTask); // Then add it to the observable collection

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
