using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class AnnouncementWork
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal MinSalary { get; set; }
        public int ClaimId { get; set; }
        public Claim Claim { get; set; }

    }
}
 