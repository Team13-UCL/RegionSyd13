using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._1.Model
{
     public class Task
    {
        public string RegionalTaskID { get; set; }
        public string TaskType { get; set; }
        public string TaskStatus { get; set; }
        public Location StartLocation { get; set; }
        public Location Destination { get; set; }
        public Patient TaskPatient { get; set; }

        public void GetTaskDetails() 
        {
        }

        public void SetTaskDetails(string details)
        {
        }
    }
}
