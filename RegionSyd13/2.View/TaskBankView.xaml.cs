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
using RegionSyd13._1.Model;
using System.Diagnostics;

namespace RegionSyd13._2.View
{
    /// <summary>
    /// Interaction logic for TaskBankView.xaml
    /// </summary>
    public partial class TaskBankView : Window
    {
        private TaskBankViewModel taskBankViewModel;
        public TaskBankView()
        {
            InitializeComponent();
            taskBankViewModel = new TaskBankViewModel(new TaskRepo());
            DataContext = taskBankViewModel;



        }

        //public void Show()
        //{
        //}

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TaskListView taskListView = new TaskListView(taskBankViewModel);
            taskListView.Show();



            this.Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
