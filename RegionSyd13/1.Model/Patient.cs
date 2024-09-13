using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._1.Model
{
    public class Patient
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HandlingTime { get; set; }
        public ConditionCode ConditionCode { get; set; }
    }
}
