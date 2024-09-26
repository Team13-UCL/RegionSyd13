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
        public LoginViewModel(IRepo<User> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _users = new List<User>(RegionUsers(CurrentRegion));
        }
        private readonly IRepo<User> repository;
        private List<User> _users;
        private string _username;
        public string Username 
        { 
            get { return _username; }
            set 
            { 
                _username = value;
                OnPropertyChanged();
            }
        }
        private string _password;
        public string Password 
        { 
            get { return _password; }
            set 
            { 
                _password = value; 
                OnPropertyChanged(); 
            }
        }
        public List<User> RegionUsers(Region reg)
        {
            List<User> users = new List<User>(repository.GetAll());
            //foreach (var user in users)
            //{
            //    if (user.RegionID != reg.RegID)
            //        users.Remove(user);
            //}
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
        private bool filled()
        {
            if (Password != null && Username != null) { return true; }
            else return false;
        }
        public RelayCommand LoginCommand => new RelayCommand(execute => Authenticate(), CanExecute => filled() == true);
        
    }
}
