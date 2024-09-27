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
        public Location[] locations = new Location[2];
        public Patient Patient { get; set; }

        public int TaskID { get; set; }
        public int PatientID { get; set; }
        public string RegTaskID { get; set; }

        public string TaskType { get; set; }

        public string TaskDescription { get; set; }

        public string Destination { get; set; }

        public string ServiceGoal { get; set; }

        public void SetStart(Location start) { locations[0] = start; }
        public void SetEnd(Location end) { locations[1] = end; }

    }
}