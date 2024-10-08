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

        // Local properties for the task
        private int _taskID;
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

        // Properties for Patient object.
        int _patientID;
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        private string _handlingNote;

        public string HandlingNote
        {
            get { return _handlingNote; }
            set
            {
                _handlingNote = value;
                OnPropertyChanged();
            }
        }
        private string _patientType;

        public string PatientType
        {
            get { return _patientType; }
            set { _patientType = value; }
        }

        // Locations
        int _startID;
        private string _startDestination;

        public string StartDestination
        {
            get { return _startDestination; }
            set
            {
                _startDestination = value;
                OnPropertyChanged();
            }
        }
        private string _startCity;
        public string StartCity
        {
            get { return _startCity; }
            set
            {
                _startCity = value;
                OnPropertyChanged();
            }
        }
        private string _startPostalCode;
        public string StartPostalCode
        {
            get { return _startPostalCode; }
            set
            {
                _startPostalCode = value;
                OnPropertyChanged();
            }
        }
        private string _startStreet;
        public string StartStreet
        {
            get { return _startStreet; }
            set
            {
                _startStreet = value;
                OnPropertyChanged();
            }

        }
        private DateTime _startDateAndTime = DateTime.Now;
        public DateTime StartDateAndTime
        {
            get { return _startDateAndTime; }
            set
            {
                _startDateAndTime = value;
                OnPropertyChanged();
            }
        }


        int _endID;
        private string _endDestination;

        public string EndDestination
        {
            get { return _endDestination; }
            set
            {
                _endDestination = value;
                OnPropertyChanged();
            }
        }
        private string _endCity;
        public string EndCity
        {
            get { return _endCity; }
            set
            {
                _endCity = value;
                OnPropertyChanged();
            }
        }
        private string _endPostalCode;
        public string EndPostalCode
        {
            get { return _endPostalCode; }
            set
            {
                _endPostalCode = value;
                OnPropertyChanged();
            }
        }
        private string _endStreet;
        public string EndStreet
        {
            get { return _endStreet; }
            set
            {
                _endStreet = value;
                OnPropertyChanged();
            }

        }
        private DateTime _endDateAndTime = DateTime.Now;
        public DateTime EndDateAndTime
        {
            get { return _endDateAndTime; }
            set
            {
                _endDateAndTime = value;
                OnPropertyChanged();
            }
        }
        bool _newTask = false;

        public AddTaskViewModel(object task)
        {
            _taskRepo = (tRepo = new TaskRepo());
            _patientRepo = (pRepo = new PatientRepo());
            _locationRepo = (lRepo = new LocationRepo());
            Task SelectedTask = (Task)task;
            _taskID = SelectedTask.TaskID;
            RegTaskID = SelectedTask.RegTaskID;
            TaskType = SelectedTask.TaskType;
            TaskDescription = SelectedTask.TaskDescription;
            ServiceGoal = SelectedTask.ServiceGoals;
            // Patient info
            Getpatient((Task)task);
            GetLocations(_taskID);
            _newTask = false;
        }
        public AddTaskViewModel()
        {
            _taskRepo = (tRepo = new TaskRepo());
            _patientRepo = (pRepo = new PatientRepo());
            _locationRepo = (lRepo = new LocationRepo());
            _newTask = true;
        }
        private void Getpatient(Task task)
        {
            Patient patient = null;
            if(task.Patient != null) patient = task.Patient;
            else if(task.PatientID != null) patient = _patientRepo.GetById(task.PatientID);
            else patient = _patientRepo.Add(new Patient());
            _patientID = patient.PatientID;
            FirstName = patient.FirstName;
            LastName = patient.LastName;
            HandlingNote = patient.HandlingNote;
            PatientType = patient.Type;
        }
        private void GetLocations(int TaskID)
        {
            lRepo = new LocationRepo();
            List<Location> locations = new List<Location>(lRepo.GetLocations(TaskID));
            foreach (Location location in locations)
            {
                if (location.Arrival == false) 
                { 
                    _startID = location.LocationID;
                    StartDestination = location.Destination;
                    StartCity = location.City;
                    StartPostalCode = location.PostalCode;
                    StartStreet = location.Street;
                    StartDateAndTime = location.DateAndTime;
                }
                else 
                {
                    _endID = location.LocationID;
                    EndDestination = location.Destination;
                    EndCity = location.City;
                    EndPostalCode = location.PostalCode;
                    EndStreet = location.Street;
                    EndDateAndTime = location.DateAndTime;
                }
            }  
        
        }
        public Task SaveTask()
        {
            Task task = new Task() 
            {
                TaskID = _taskID,
                RegionID = CurrentRegion.RegID,
                PatientID = _patientID,
                RegTaskID = this.RegTaskID,
                TaskType = this.TaskType,
                TaskDescription = this.TaskDescription,
                ServiceGoals = this.ServiceGoal
            };
            return task;
        }
        public Patient SavePatient()
        {
            Patient patient = new Patient()
            {
                PatientID = this._patientID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                HandlingNote = this.HandlingNote,
                Type = PatientType
            };
            return patient;
        }
        public Location SaveStartLocation()
        {
            Location location = new Location()
            {
                LocationID = _startID,
                TaskID = _taskID,
                Destination = StartDestination,
                City = StartCity,
                PostalCode = StartPostalCode,
                Street = StartStreet,
                DateAndTime = StartDateAndTime,
                Arrival = false
            };
            return location;
        }
        public Location SaveEndLocation()
        {
            Location location = new Location()
            {
                LocationID = _endID,
                TaskID = _taskID,
                Destination = EndDestination,
                City = EndCity,
                PostalCode = EndPostalCode,
                Street = EndStreet,
                DateAndTime = EndDateAndTime,
                Arrival = true
            };
            return location;
        }

        public void UpdateTask() 
        {
            // Rækkefølge for opdatering: Patient, Task, Lokationer.
            _patientRepo.Update(SavePatient());
            _taskRepo.Update(SaveTask());
            _locationRepo.Update(SaveStartLocation());
            _locationRepo.Update(SaveEndLocation());
        }
        public void AddTask()
        {
            Patient patient = _patientRepo.Add(SavePatient());
            _patientID = patient.PatientID;
            Task task = _taskRepo.Add(SaveTask());
            _taskID = task.TaskID;
            _locationRepo.Add(SaveStartLocation());
            _locationRepo.Add(SaveEndLocation());

            // Tilføjet til Add() metoden i et par af repoerne, at en tilføjer objektet i databasen, 
            // og så returnerer det nye objekt, så man kan få objektets ID, til at kunne tilføje som FK i de andre.
        }
        public RelayCommand UpdateCommand => new RelayCommand(Execute => UpdateTask(), CanExecute => _newTask == false);
        public RelayCommand AddCommand => new RelayCommand(Execute => AddTask(), CanExecute => _newTask == true);


    }

}
