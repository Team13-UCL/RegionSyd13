﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegionSyd13._3.ViewModel;
using System.Data.SqlClient;
using System.Data;
using RegionSyd13.Repository;

namespace RegionSyd13._2.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        LoginViewModel vm;
        
        public LoginView()
        {
            var UserRepo = new Repository.UserRepo();
            vm = new LoginViewModel(UserRepo);
            InitializeComponent();
            DataContext = vm;
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (vm.Authenticate() == true)
            {
                MessageBox.Show("Login Success");
                TaskListView taskListView = new TaskListView();
                taskListView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }
    }
}
