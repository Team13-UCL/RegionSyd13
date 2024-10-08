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
        private TaskRepo tRepo;
        private readonly IRepo<Task> _taskRepo;
        private PatientRepo pRepo;
        private readonly IRepo<Patient> _patientRepo;
        private LocationRepo lRepo;
        private readonly IRepo<Location> _locationRepo;
        //public ObservableCollection<Task> _tasks { get; set; }
        public AddTaskViewModel(object task)
        {
            _taskRepo = (tRepo = new TaskRepo());
            _patientRepo = (pRepo = new PatientRepo());
            _locationRepo = (lRepo = new LocationRepo());
            Task SelectedTask = (Task)task;
            _taskID = SelectedTask.TaskID;
            RegTaskID = SelectedTask.RegTaskID.ToString();
            TaskType = SelectedTask.TaskType;
            TaskDescription = SelectedTask.TaskDescription;
            ServiceGoal = SelectedTask.ServiceGoals;
            //Getpatient((Task)SelectedTask);
        }
        public AddTaskViewModel()
        {
            _taskRepo = (tRepo = new TaskRepo());
            _patientRepo = (pRepo = new PatientRepo());
            _locationRepo = (lRepo = new LocationRepo());
        }
        //private Patient Getpatient(Task task)
        //{
        //    Patient patient = null;
        //    if(task.PatientID != null) patient = _patientRepo.GetById(task.PatientID);
        //    else 
        //    { 
        //        patient = _patientRepo.Add(new Patient());
        //    }
        //    return patient;
        //}
        //private void GetLocations()
        //{
        //    List<Location> locations = new List<Location>(_locationRepo.GetAll());
        //    foreach (Location location in locations) 
        //    {
        //        if(location.TaskID == SelectedTask.TaskID)
        //        {
        //            if(StartLocation == null && location.Arrival == false) StartLocation = location;
        //            else if(EndLocation == null && location.Arrival == true) EndLocation = location;
        //        }
        //    }
        //    if (StartLocation == null) StartLocation = _locationRepo.Add(new Location(false));
        //    if(EndLocation == null) EndLocation = _locationRepo.Add(new Location(true));
        //}

        // Local properties for the task
        private int _taskID 
        { 
            set 
            { 
                _taskID = value;
                CanUpdate(); 
            }  
            get 
            { 
                return _taskID;
            }
        }
        private string _regTaskID;

        public string RegTaskID
        {
            get { return _regTaskID; }
            set 
            { 
                _regTaskID = value; 
                OnPropertyChanged();
            }
        }
        private string _taskType;

        public string TaskType
        {
            get { return _taskType; }
            set 
            { 
                _taskType = value;
                OnPropertyChanged();
            }
        }
        private string _taskDescription;

        public string TaskDescription
        {
            get { return _taskDescription; }
            set 
            { 
                _taskDescription = value; 
                OnPropertyChanged();
            }
        }
        private string _serviceGoal;

        public string ServiceGoal
        {
            get 
            {
                if (_serviceGoal != null)
                    return _serviceGoal;
                else return "ServiceGoal";

            }
            set 
            { 
                _serviceGoal = value;
                OnPropertyChanged();
            }
        }
        int _patientID;
        int _startID;
        int _endID;

        bool _canUpdate = false;
        private bool CanUpdate() // Placeres ved hver af de private PK'er.
        {
            if (_taskID != 0 && _patientID != 0 && _startID != 0 && _endID != 0)
            {
                return true;
            }
            else return false;
        }
        public Task SaveTask()
        {
            Task task = new Task()
            {
                TaskID = _taskID,
                RegTaskID = this.RegTaskID,
                TaskType = this.TaskType,
                TaskDescription = this.TaskDescription,
                ServiceGoals = this.ServiceGoal,
                PatientID = _patientID,
                RegionID = User.RegionID

            };
            return task;
        }
        public Patient SavePatient() { return null; }
        public void UpdateTask() 
        {
            //Rækkefølge for opdatering: Patient, Task, Lokationer.
            _taskRepo.Update(SaveTask());
        }
        public void AddTask()
        {
            Patient patient = _patientRepo.Add(SavePatient());
            Task task = new Task(patient.PatientID);
            task = _taskRepo.Add(SaveTask()); 
            // Tilføjet til Add() metoden i et par af repoerne, at en tilføjer objektet i databasen, 
            // og så returnerer det nye objekt, så man kan få objektets ID, til at kunne tilføje som FK i de andre.
        }
        public RelayCommand Update => new RelayCommand(Execute => UpdateTask(), CanExecute => _canUpdate != false);


    }

}
