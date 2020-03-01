using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.ViewModels
{
    public class UserContractVM
    {
        public string Agreement { get; set; }
        public decimal Amount { get; set; }
        public int requestId { get; set; }
        public decimal MonthCount { get; set; }

    }
}
