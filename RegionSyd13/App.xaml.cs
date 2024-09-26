using RegionSyd13.Repository;
using System.Windows;
using Microsoft.Extensions.Configuration;
using RegionSyd13._3.ViewModel;

namespace RegionSyd13
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var configuration = LoadConfiguration();


            string ConnectionString = configuration.GetConnectionString("DefaultConnection");
            Connection.Initialize(ConnectionString);

            var regionRepo = new RegionRepo();
            var CurrentUser = new CurrentUser();
            CurrentUser.Initialize("Region Syd", regionRepo);
        }
        private IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }

}
