using RegionSyd13._1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._3.ViewModel
{
    public class TaskViewModel
    {
        public string RegionalTaskID { get; set; }
        public string Region { get; set; }
        public string TaskType { get; set; }
        public Patient Patient { get; set; }
        
    }
}
