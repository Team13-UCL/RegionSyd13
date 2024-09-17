using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using RegionSyd13._1.Model;
using RegionSyd13._3.ViewModel;

namespace RegionSyd13._2.View
{
    /// <summary>
    /// Interaction logic for TaskListView.xaml
    /// </summary>
    public partial class TaskListView : Window
    {
        public TaskListView()
        {
        }

        public TaskListView(TaskBankViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskBankView taskBankView = new TaskBankView();
            taskBankView.Show();
            this.Close();

        }
    }
}
