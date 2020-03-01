using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.ViewModels
{
    public class DashboardViewModel
    {
        public int UserCount { get; set; }
        public int Products { get; set; }
        public int Tasks { get; set; }
        public int OnGoingTask { get; set; }
    }
}
