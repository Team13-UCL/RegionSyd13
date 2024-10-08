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
using RegionSyd13.Repository;

namespace RegionSyd13._2.View
{
    /// <summary>
    /// Interaction logic for AddTaskView.xaml
    /// </summary>
    public partial class AddTaskView : Window
    {
        AddTaskViewModel vm;
        public AddTaskView()
        {
            
            InitializeComponent();
            vm = new AddTaskViewModel();
            DataContext = vm;
        }
        public AddTaskView(object selectedTask)
        {
            InitializeComponent();
            vm = new AddTaskViewModel(selectedTask);
            DataContext = vm;
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            vm.UpdateTask();
            TaskListView taskListView = new TaskListView();
            taskListView.Show();
            this.Close();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            //vm.AddTask();
            TaskListView taskListView = new TaskListView();
            taskListView.Show();
            this.Close();
        }

        private void Cancelbtn_Click(object sender, RoutedEventArgs e)
        {
            TaskListView taskListView = new TaskListView();
            taskListView.Show();
            this.Close();
        }
    }
}
