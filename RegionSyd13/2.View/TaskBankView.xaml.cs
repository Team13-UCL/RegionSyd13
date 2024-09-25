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
using RegionSyd13._3.ViewModel;
using System.Diagnostics;
using RegionSyd13.Repository;

namespace RegionSyd13._2.View
{
    /// <summary>
    /// Interaction logic for TaskBankView.xaml
    /// </summary>
    public partial class TaskBankView : Window
    {
        private TaskBankViewModel taskBankViewModel = new TaskBankViewModel(TaskRepo.GetInstance());

        public TaskBankView()
        {
            InitializeComponent();
            
            DataContext = taskBankViewModel;
        }

        public TaskBankView(TaskBankViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var taskRepo = new TaskRepo();
            //var taskListViewModel = new TaskBankViewModel(taskRepo);
            //TaskListView taskListView = new TaskListView(taskBankViewModel);
            //taskListView.Show();
            //this.Close();
            TaskListView taskListView = new TaskListView(taskBankViewModel);
            taskListView.Show();
            this.Close();
        }
        }
    }
