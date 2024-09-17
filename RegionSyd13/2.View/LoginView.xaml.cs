using System;
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
using RegionSyd13._1.Model;
using RegionSyd13._3.ViewModel;

namespace RegionSyd13._2.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private TaskBankViewModel taskBankViewModel;

        public LoginView()
        {
            InitializeComponent();
            taskBankViewModel = new TaskBankViewModel(new TaskRepo());
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            TaskListView taskListView = new TaskListView(taskBankViewModel);
            taskListView.Show();
            this.Close();
        }
    }
}
