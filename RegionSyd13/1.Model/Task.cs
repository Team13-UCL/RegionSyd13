using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Microsoft.VisualBasic;
using RegionSyd13.Repository;

namespace RegionSyd13._1.Model
{
    public class Task
    {
        PatientRepo PatientRepo = new PatientRepo();
        private readonly IRepo<Patient> _patientRepo;
        LocationRepo LocationRepo = new LocationRepo();
        private bool _isPatient = false; // brugt til at sikre at Patient kun bliver opdateret når Task er blevet initialiseret
        private bool _isLocation = false;
        public Task(int taskID, int patientID, string regtaskID, string Type, string Description, string Goals)
        {
            TaskID = taskID;
            TaskType = Type;
            TaskDescription = Description;
            RegTaskID = regtaskID;
            ServiceGoals = Goals;
            var patientRepo = PatientRepo ?? throw new ArgumentNullException(nameof(PatientRepo));
            Patient = patientRepo.GetById(patientID);
            _isPatient = true; // sættes til true når Task er blevet initialiseret
            var _locationRepo = LocationRepo ?? throw new ArgumentNullException(nameof(LocationRepo));
            AddLocations();
            _isLocation = true;
            


        }
        public void AddLocations()
        {
            LocationRepo.GetLocations(TaskID).ForEach(location =>
            {
                if(location != null)
                {
                    if (location.Arrival != true) LocationStop = location;
                    else LocationStart = location;
                }
                
            });
        }
        public Task()
        {
            
        }
        private Location _locationStart;
        public Location LocationStart 
        {  get 
            {
                return _locationStart;
            }
            set
            {
                if (_isLocation)
                {
                    if(_locationStart == null)
                    {
                        _locationStart = value;
                        _locationStart.Arrival = false;
                        LocationRepo.Add(LocationStart);
                    }
                    else
                    {
                        _locationStart = value;
                        LocationRepo.Update(_locationStart);
                    }
                }
                else { _locationStart = value; }
            }
        }
        private Location _locationStop;
        public Location LocationStop 
        {
            get
            {
                return _locationStop;
            }
            set
            {
                if (_isLocation)
                {
                    if(_locationStop == null)
                    {
                        _locationStop = value;
                        _locationStop.Arrival = true;
                        LocationRepo.Add(LocationStop);
                    }
                    else
                    {
                        _locationStop = value;
                        LocationRepo.Update(_locationStop);
                    }
                }
                else
                {
                    _locationStop = value;
                }
            }
        }

        private Patient _patient;
        public Patient Patient 
        {
            get { return _patient; }
            set
            {
                if (_isPatient) // sikrer at Patient kun bliver opdateret når Task er blevet initialiseret
                {
                    if (_patient == null)
                    {
                        _patient = value;
                        _patientRepo.Add(_patient);
                    }
                    else if (_patient != value)
                    {
                        _patient = value;
                        _patientRepo.Update(_patient);
                    }
                }
                else
                {
                    _patient = value;
                }
            }
        }
        public string RegTaskID {  get; set; }
        public int TaskID { get; set; }
        public int PatientID { get; set; }

        public string TaskType { get; set; }

        public string TaskDescription { get; set; }

        public string ServiceGoals { get; set; }

    }
}