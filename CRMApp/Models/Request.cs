using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string RequestTitle { get; set; }
        public bool IsAccepted { get; set; }
        public string RequestDescription { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
