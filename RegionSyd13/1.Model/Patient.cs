using RegionSyd13.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._1.Model
{
    public class Patient
    {
        private readonly IRepo<Patient> _repo;
        public int PatientID { get; set; }
        private string _firstName;
        public string FirstName 
        {
            get => _firstName;
            set 
            { 
                _firstName = value;
                _repo.UpdateSpecific("FirstName", "'" + value + "'", PatientID);
            }
        }
        public string LastName { get; set; }
        public string HandlingNote { get; set; }

        public string Type { get; set; }
        public Patient()
        {
            var PatientRepo = new PatientRepo();
            _repo = PatientRepo;
        }
    }
}