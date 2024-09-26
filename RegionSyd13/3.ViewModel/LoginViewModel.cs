using RegionSyd13._1.Model;
using RegionSyd13._2.View;
using RegionSyd13.MVVM;
using RegionSyd13.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace RegionSyd13._3.ViewModel
{
    public class LoginViewModel : CurrentUser
    {
        public LoginViewModel()
        {
            this._userRepo = _userRepo ?? throw new ArgumentNullException(nameof(_userRepo));
            _users = new List<User>(RegionUsers(CurrentRegion));
        }
        private readonly IRepo<User> _userRepo;
        private List<User> _users;
        public string Username { get; set; }
        public string Password { get; set; }
        public List<User> RegionUsers(Region reg)
        {
            List<User> users = new List<User>(_userRepo.GetAll());
            foreach (var user in _users)
            {
                if (user.RegionID != reg.RegID)
                    users.Remove(user);
            }
            return users;
        }
        public void Login(string username, string password)
        {
            User User = null;
            foreach (var user in _users)
                if (username == user.UserName)
                    if (password == user.Password)
                    {
                        User = user;
                        break;
                    }

            base.User = User;
        }
        public bool Authenticate()
        {
            bool authentication = false;
            Login(Username, Password);
            if(base.User != null)
                authentication = true;
            return authentication;
        }
        public RelayCommand LoginCommand => new RelayCommand(execute => Authenticate(), CanExecute => (Username != null && Password != null));
        
    }
}
