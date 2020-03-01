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
    public class AnnouncmentController : Controller
    {

        private readonly AppDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;

        public AnnouncmentController(AppDbContext _appDbContext, UserManager<AppUser> _userManager)
        {
            appDbContext = _appDbContext;
            userManager = _userManager;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAnnouncments()
        {
            var announcments = appDbContext.AnnouncementWorks.ToList();


            return View(announcments);
        }

        [HttpGet]
        public IActionResult CreateAnnouncment()
        {


            var announcmentVM = new AnnouncmentVM();
            announcmentVM.Claims = appDbContext.Claims.ToList();

            ViewBag.Claims = new SelectList(appDbContext.Claims, "Id", "Name");


            return View(announcmentVM);
        }


        [HttpPost]
        public IActionResult CreateAnnouncment(AnnouncmentVM announcmentVM)
        {
            ViewBag.Claims = new SelectList(appDbContext.Claims, "Id", "Name");
            var newAnnouncment = new AnnouncementWork();
            newAnnouncment = new AnnouncementWork()
            {

                Title = announcmentVM.Announcement.Title,
                Description = announcmentVM.Announcement.Description,
                Claim = appDbContext.Claims.ToList().Find(i => i.Id == announcmentVM.ClaimId),
                MinSalary = announcmentVM.Announcement.MinSalary,
                ClaimId = announcmentVM.ClaimId

            };


            appDbContext.AnnouncementWorks.Add(newAnnouncment);
            appDbContext.SaveChanges();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendBidToAnnouncment(int announcmentId)
        {
            var currentAnnouncment = appDbContext.AnnouncementWorks.ToList().Find(i => i.Id == announcmentId);
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);

            var currentBid = new Bid()
            {
                AnnouncmentWork = currentAnnouncment,
                AppUser = currentUser,
                Description = currentAnnouncment.Description,
                IsAccepted = false,
                Name = "Nameeeeee"

            };

            appDbContext.Bids.Add(currentBid);
            appDbContext.SaveChanges();

            var thisBid = appDbContext.Bids.Find(currentBid).Id;

            return RedirectToAction("GetBid", thisBid);
        }

        [HttpGet]
        public IActionResult GetBid(int bidId)
        {
            var currentBid = appDbContext.Bids.ToList().Find(i => i.Id == bidId);
            

            return View(currentBid);
        }
         
        [HttpGet]
        public IActionResult ApplyBid(int announcmentId)
        {
             
            appDbContext.Bids.ToList().Find(i => i.AnnouncmentWorkId == announcmentId).IsAccepted = true;
            appDbContext.SaveChanges();
             
            return RedirectToAction("GetAnnouncments");
        }


        [HttpGet]
        public IActionResult RejectBid(int announcmentId)
        {
            appDbContext.Bids.ToList().Find(i => i.AnnouncmentWorkId == announcmentId).IsAccepted = false;
            appDbContext.SaveChanges();

            return RedirectToAction("GetAnnouncments");

        }


    }
}