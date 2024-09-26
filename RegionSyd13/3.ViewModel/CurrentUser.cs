using RegionSyd13._1.Model;
using RegionSyd13.MVVM;
using RegionSyd13.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd13._3.ViewModel
{
    public class CurrentUser : ViewModelBase
    {
        public static void Initialize(string regionName, IRepo<Region> repository)
        {
            IRepo<Region> repo = repository ?? throw new ArgumentNullException(nameof(repository));
            _regions = new List<Region>(repo.GetAll());
            foreach (var region in _regions)
            {
                if (region.RegName == regionName)
                    CurrentRegion = region;
            }

        }
        public static Region CurrentRegion { get; set; }
        public User User { get; set; }
        
        private readonly IRepo<Region> _regionRepo;
        static List<Region> _regions;
        
        
    }
}
