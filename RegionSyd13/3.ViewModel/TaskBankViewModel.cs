using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._3.ViewModel
{
    public class TaskBankViewModel
    {
        public ObservableCollection<Task> Tasks { get; set; }
        public Task SelectedTask { get; set; }

        public void Login()
        {
        }
    }
}
