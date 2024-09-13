using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._3.ViewModel
{
    public class UserAutheticationViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool Authenticate(string username, string password)
        {
            return true;
        }

        public void Logout()
        {
        }
    }
}
