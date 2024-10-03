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
        TaskListViewModel vm;
        public TaskListView()
        {
            var taskRepo = new Repository.TaskRepo();
            vm = new TaskListViewModel(taskRepo);
            InitializeComponent();
            DataContext = vm;
        }
               

        private void AddTaskClick(object sender, RoutedEventArgs e)
        {
            AddTaskView addTaskView = new AddTaskView();
            var addTaskViewModel = (AddTaskViewModel)addTaskView.DataContext;
            addTaskView.Show();
            this.Close();

        }

        private void EditClick(object sender, RoutedEventArgs e)
        {

            if (vm.SelectedTask != null)
            {
                var addTaskView = new AddTaskView();
                var addTaskViewModel = (AddTaskViewModel)
                addTaskView.DataContext;
                addTaskViewModel.SelectedTask = vm.SelectedTask;
                addTaskView.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a task to edit.");
            }
        }

    }
}
