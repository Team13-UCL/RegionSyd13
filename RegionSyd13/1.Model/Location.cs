using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace RegionSyd13._1.Model
{
    public class Location
    {
        public string City { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public bool TimeIsCritical { get; set; }

        //public string GetFullAddress()
        //{
        //    return $"{StreetName,HouseNumber, City}";
        //}

    }
}
