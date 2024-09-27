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
            var TaskRepo = new Repository.TaskRepo();
            vm = new TaskListViewModel(TaskRepo);
            InitializeComponent();
            DataContext = vm;
        }

        public TaskListView(TaskBankViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
        

        private void AddTaskClick(object sender, RoutedEventArgs e)
        {
            AddTaskView taskBankView = new AddTaskView();
            taskBankView.Show();
            this.Close();

        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            
            AddTaskView taskBankView = new AddTaskView();
            taskBankView.Show();
            this.Close();
        }

    }
}
