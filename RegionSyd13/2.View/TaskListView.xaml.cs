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
using System.Windows.Shapes;
using RegionSyd13._3.ViewModel;
using RegionSyd13.Repository;

namespace RegionSyd13._2.View
{
    /// <summary>
    /// Interaction logic for TaskListView.xaml
    /// </summary>
    public partial class TaskListView : Window
    {
        private TaskBankViewModel taskBankViewModel = new TaskBankViewModel();

        public TaskListView()
        {
            InitializeComponent();
            DataContext = taskBankViewModel;
        }

        public TaskListView(TaskBankViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddTaskView taskBankView = new AddTaskView();
            taskBankView.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            AddTaskView taskBankView = new AddTaskView();
            taskBankView.Show();
            this.Close();
        }

    }
}
