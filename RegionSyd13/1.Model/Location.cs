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
        public int TaskID {  get; set; }
        public string Destination { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
       // public string HouseNumber { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool Arrival { get; set; }


        public string GetAdress()
        {
            return $"{Street}, {PostalCode}, {City}";
        }
        public Location(bool arrival)
        {
            Arrival = arrival;
        }
        public Location()
        {
            
        }
    }
}