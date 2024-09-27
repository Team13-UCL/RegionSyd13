using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using RegionSyd13.Repository;

namespace RegionSyd13._1.Model
{
    public class Task
    {
        PatientRepo PatientRepo = new PatientRepo();
        private readonly IRepo<Patient> patientRepo;
        private readonly LocationRepo locationRepo;
        public Task(int taskID, int patientID, string regtaskID, string Type, string Description)
        {
            TaskID = taskID;
            TaskType = Type;
            TaskDescription = Description;
            RegTaskID = regtaskID;
            var patientRepo = PatientRepo ?? throw new ArgumentNullException(nameof(PatientRepo));
            Patient = patientRepo.GetById(patientID);
            var locationRepo = new LocationRepo();


        }
        public Task()
        {
            
        }
        public Location Start {  get; set; }
        public Location Stop { get; set; }
        public Patient Patient 
        {
            get { return Patient; }
            set 
            {
                if (Patient == null)
                {
                    Patient = value;
                    patientRepo.Add(Patient);
                }
                else
                {
                    Patient = value;
                    patientRepo.Update(Patient);
                }
            }
        }
        public string RegTaskID {  get; set; }
        public int TaskID { get; set; }
        public int PatientID { get; set; }

        public string TaskType { get; set; }

        public string TaskDescription { get; set; }

        public string ServiceGoals { get; set; }
        public void GetLocations()
        {
            var locations = new List<Location>(locationRepo.GetAll());
            foreach (var location in locations)
            {
                if (location.TaskID == this.TaskID)
                {
                    if (location.Destination == "start")
                        Start = location;
                    else Stop = location;
                }
            }
        }

    }
}