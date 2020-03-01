using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class StaffRequest
    {
        public int Id { get; set; }
        public string About { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public decimal MinSalary { get; set; }
        public string Ability { get; set; }


    }

}
