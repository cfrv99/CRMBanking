using CRMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Areas.Rufet.Models
{
    public class TakeTaskVM
    {
        public List<JobTask> Tasks { get; set; }
        public AppUser AppUser { get; set; }
        public JobTask JobTask { get; set; }
    }
}
