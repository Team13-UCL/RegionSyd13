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
       
        private TaskBankViewModel taskBankViewModel;

        public LoginView()
        {
            InitializeComponent();
            taskBankViewModel = new TaskBankViewModel(TaskRepo.GetInstance());
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //Database connection
            using (SqlConnection con = new SqlConnection(@"Data Source=hedhed.database.windows.net;Initial Catalog=Login_RegionSyd13;User ID=Featherlance;Password=Nisse197512"))
            {
                con.Open();

                // Prepare query using parameters
                string query = "SELECT Username, Password FROM UserTable WHERE Username = @username AND Password = @password";

                // Create SQL command with parameters to prevent SQL injection
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", UserIdTextBox.Text);
                    cmd.Parameters.AddWithValue("@password", PasswordBox.Password);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login Success");
                        // Proceed to the next view, for example:
                        TaskListView taskListView = new TaskListView(taskBankViewModel);
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
    }
}
