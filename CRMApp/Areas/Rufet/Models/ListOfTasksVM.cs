using CRMApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Areas.Rufet.Models
{
    public class ListOfTasksVM
    {
        private readonly AppDbContext appDbContext;
        public ListOfTasksVM(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        public List<JobTask> Tasks { get { return appDbContext.JobTasks.ToList(); } }


    }
}
