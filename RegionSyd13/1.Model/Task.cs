using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace RegionSyd13._1.Model
{
     public class Task
    {

        public int TaskID { get; set; }
        public string RegionalTaskID { get; set; }
        public string TaskType { get; set; }

        public string TaskDescription { get; set; }
        public string PatientNotes { get; set; }
        //public string TaskStatus { get; set; }
        public string StartLocation { get; set; }
        public string Destination { get; set; }
        //public Patient TaskPatient { get; set; }

        public string ServiceTarget { get; set; }

        public string DateAndTimeForPickup { get; set; }
        public string DateAndTimeForDestination { get; set; }

        

        public void GetTaskDetails() 
        {
        }

        public void SetTaskDetails(string details)
        {
        }
    }
}
