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
        public int LocationID { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public int date { get; set; }
        public int time { get; set; }


        //public string GetFullAddress()
        //{
        //    return $"{StreetName,HouseNumber, City, PostalCode}";
        //}

    }
}