using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class UserContract
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Agreement { get; set; }
        public decimal Amount { get; set; }
        public decimal MonthCount { get; set; }

    }
}
