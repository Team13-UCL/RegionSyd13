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

    public class AddTaskViewModel : CurrentUser
    {
        public ICommand AddOrEditTaskCommand { get; private set; }   
        

        private readonly IRepo<Task> repository;
        public ObservableCollection<Task> _tasks { get; set; }

        private Task selectedTask;
        public Task SelectedTask
        {
            get => selectedTask;
            set
            {
               
                    selectedTask = value;
                    
                if (selectedTask != null)
                {
                    // fyld felterne ud med de valgte tasks værdier
                    TaskType = selectedTask.TaskType;
                    TaskDescription = selectedTask.TaskDescription;
                    RegTaskID = selectedTask.RegTaskID;
                    ServiceGoals = selectedTask.ServiceGoals;
                    LocationStart = selectedTask.LocationStart;
                    LocationStop = selectedTask.LocationStop;
                }
                OnPropertyChanged();


            }
        }


        public AddTaskViewModel(IRepo<Task> repository)
        {
            
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _tasks = new ObservableCollection<Task>(repository.GetAll());

            AddOrEditTaskCommand = new RelayCommand(AddOrEditTask);
            
            

        }



        public void AddOrEditTask(object obj)
        {
            if (SelectedTask == null) //hvis der ikke er valgt en task, så er det en ny task
            {
                
                Task newTask = new Task
                {
                    TaskType = this.TaskType,
                    TaskDescription = this.TaskDescription,
                    RegTaskID = this.RegTaskID,
                    ServiceGoals = this.ServiceGoals,
                    LocationStart = this.LocationStart,
                    LocationStop = this.LocationStop,
                    //mangler flere dataer fra patient og location
                };

                repository.Add(newTask);
                _tasks.Add(newTask);
            }
            else //hvis der er valgt en task, så er det en eksisterende task der skal opdateres
            {
                
                SelectedTask.TaskType = this.TaskType;
                SelectedTask.TaskDescription = this.TaskDescription;
                SelectedTask.RegTaskID = this.RegTaskID;
                SelectedTask.ServiceGoals = this.ServiceGoals;
                SelectedTask.LocationStart = this.LocationStart;
                SelectedTask.LocationStop = this.LocationStop;
                //mangler flere dataer fra patient og location

                repository.Update(SelectedTask);
            }

            OnPropertyChanged(nameof(_tasks));
        }



        


        private string _taskType;
        private string _taskDescription;
        private string _regTaskID;
        private string _serviceGoals;
        private int _patientID;
        private Location _locationStart;
        private Location _locationStop;
        private Patient _patient;
        private int _regionID;

        
        public string TaskType
        {
            get => _taskType;
            set { _taskType = value; OnPropertyChanged(); }
        }

        public string TaskDescription
        {
            get => _taskDescription;
            set { _taskDescription = value; OnPropertyChanged(); }
        }

        public string RegTaskID
        {
            get => _regTaskID;
            set { _regTaskID = value; OnPropertyChanged(); }
        }

        public string ServiceGoals
        {
            get => _serviceGoals;
            set { _serviceGoals = value; OnPropertyChanged(); }
        }

        public int PatientID
        {
            get => _patientID;
            set { _patientID = value; OnPropertyChanged(); }
        }

        public Location LocationStart
        {
            get => _locationStart;
            set { _locationStart = value; OnPropertyChanged(); }
        }

        public Location LocationStop
        {
            get => _locationStop;
            set { _locationStop = value; OnPropertyChanged(); }
        }

        public int RegionID
        {
            get => _regionID;
            set { _regionID = value; OnPropertyChanged(); }
        }

        public Patient Patient
        {
            get => _patient;
            set { _patient = value; OnPropertyChanged(); }
        }

    }

}
