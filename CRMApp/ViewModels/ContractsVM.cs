using CRMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.ViewModels
{
    public class ContractsVM
    {
        public List<CompanyContract> CompanyContracts { get; set; }
        public List<StaffContract> StaffContracts { get; set; }
    }
}
