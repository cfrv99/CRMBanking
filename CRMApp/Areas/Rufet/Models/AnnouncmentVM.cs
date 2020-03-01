using CRMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Areas.Rufet.Models
{
    public class AnnouncmentVM
    {
        public AnnouncementWork Announcement { get; set; }

        public List<Claim> Claims { get; set; }

        public int ClaimId { get; set; }

    }
}
