using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public List<Claim> Claims { get; set; }
        public List<AppUser> AppUsers { get; set; }
        public List<MonthlyAmount> MonthlyAmounts { get; set; }

    }
}
