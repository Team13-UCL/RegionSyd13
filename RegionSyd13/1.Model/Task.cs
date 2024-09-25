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

        public string RegTaskID { get; set; }

        public string TaskType { get; set; }

        public string TaskDescription { get; set; }

        public string Destination { get; set; }

        public string ServiceGoals { get; set; }
    }
}