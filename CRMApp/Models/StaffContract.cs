using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class StaffContract
    {
        public int Id { get; set; }
        public string Agreement { get; set; }
        public DateTime Expire { get; set; }
        public DateTime StartDate { get; set; }
        public decimal MonthlySalary { get; set; }

        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
