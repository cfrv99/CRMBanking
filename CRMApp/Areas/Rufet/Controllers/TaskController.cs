using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMApp.Areas.Rufet.Models;
using CRMApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRMApp.Areas.Rufet.Controllers
{
    [Area("Rufet")]
    public class TaskController : Controller
    {

        private readonly AppDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;

        public TaskController(AppDbContext _appDbContext, UserManager<AppUser> _userManager)
        {

            appDbContext = _appDbContext;
            userManager = _userManager;

        }

        [HttpGet]
        public IActionResult Index()
        {

            ListOfTasksVM listOfTasksVM = new ListOfTasksVM(appDbContext);

            return View(listOfTasksVM.Tasks.FindAll(i=> i.Status != Status.Finished));
        }

        [HttpGet]
        public IActionResult CreateTask()
        {
            ViewBag.Claims = new SelectList(appDbContext.Claims, "Id", "Name");

            var taskVM = new TaskVM();
            taskVM.Claims = appDbContext.Claims.ToList();


            return View(taskVM);
        }


        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskVM taskVM)
        {
            ViewBag.Claims = new SelectList(appDbContext.Claims, "Id", "Name");

            

            var newAnnouncment = new JobTask()
            {

                Amount = taskVM.JobTask.Amount,
                Claim = appDbContext.Claims.ToList().Find(i => i.Id == taskVM.ClaimId),
                CreatedAt = DateTime.Now,
                DeadLine = taskVM.JobTask.DeadLine,
                Description = taskVM.JobTask.Description,
                Name = taskVM.JobTask.Name,
                Status = Status.IsNotStarted

            };

            appDbContext.JobTasks.Add(newAnnouncment);
            appDbContext.SaveChanges();

            return View();
        }

        [HttpGet]
        public IActionResult TakeTask()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TakeTask(int taskId)
        {

            appDbContext.JobTasks.ToList().Find(i => i.Id == taskId).AppUser = await userManager.FindByNameAsync(User.Identity.Name);
            appDbContext.JobTasks.ToList().Find(i => i.Id == taskId).Status = Status.Waiting;
            appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetTakenTasks()
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            var takenTasks = appDbContext.JobTasks.ToList().FindAll(i => i.AppUserId == currentUser.Id);


            return View(takenTasks);
        }

        [HttpPost]
        public async Task<IActionResult> FinishTask(int taskId)
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            var currentTask = appDbContext.JobTasks.ToList().Find(i => i.Id == taskId);

            appDbContext.JobTasks.ToList().Find(i => i.Id == taskId).Status = Status.Finished;

            appDbContext.Users.ToList().Find(i => i.Id == currentUser.Id).Amount += currentTask.Amount;
            appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CancelTask(int taskId)
        {
            appDbContext.JobTasks.ToList().Find(i => i.Id == taskId).Status = Status.IsNotStarted;
            appDbContext.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}