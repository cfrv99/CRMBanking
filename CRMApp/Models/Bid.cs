using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AnnouncmentWorkId { get; set; }
        public bool IsAccepted { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public AnnouncementWork AnnouncmentWork { get; set; }
    }
}
