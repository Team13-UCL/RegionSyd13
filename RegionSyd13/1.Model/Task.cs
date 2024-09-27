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
        private readonly PatientRepo patientRepo;
        private readonly LocationRepo locationRepo;
        public Task(int taskID, int patientID, string regtaskID, string Type, string Description)
        {
            TaskID = taskID;
            TaskType = Type;
            TaskDescription = Description;
            RegTaskID = regtaskID;
            var patientRepo = new PatientRepo();
            Patient = patientRepo.GetPatient(patientID);
            var locationRepo = new LocationRepo();


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

        public string TaskType { get; set; }

        public string TaskDescription { get; set; }

        public string ServiceGoals { get; set; }
        public void GetLocations()
        {
            var locations = new List<Location>(locationRepo.GetAll());
            foreach (var location in locations) {
                if (location.TaskID == this.TaskID)
                {
                    if(location.Destsination == "start")
                        Start = location;
                    else Stop = location;
                }
                  

    }
}