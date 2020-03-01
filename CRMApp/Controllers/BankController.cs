using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMApp.Models;
using CRMApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRMApp.Controllers
{
    public class BankController : Controller
    {
        AppDbContext context;
        private readonly UserManager<AppUser> userManager;

        public BankController(AppDbContext context, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var data = context.Requests.ToList();
            return View(data);
        }


        //[HttpGet]
        //public IActionResult Accept(int requestId)
        //{
        //    var request = context.Requests.FirstOrDefault(i => i.Id == requestId);
        //    request.IsAccepted = true;


        //    context.SaveChanges();
        //    return View();
        //}

        [HttpGet]
        public IActionResult Accept(int requestId)
        {
            return View(new UserContractVM()
            {
                requestId = requestId
            });
        }

        [HttpPost]
        public async Task<IActionResult> Accept(UserContractVM vM)
        {
            if (ModelState.IsValid)
            {

                var request = context.Requests.FirstOrDefault(i => i.Id == vM.requestId);
                request.IsAccepted = true;
                context.SaveChanges();
                var userId = request.AppUserId;
                var userContarct = new UserContract
                {
                    AppUserId = userId,
                    Agreement = vM.Agreement,
                    Amount = vM.Amount,
                    MonthCount = vM.MonthCount
                };
                context.UserContracts.Add(userContarct);
                context.SaveChanges();
                var user = await userManager.FindByIdAsync(userId);
                user.Amount = vM.Amount;
                context.SaveChanges();
                return RedirectToAction("Accept", "Bank");
            }
            return View(vM);
        }
    }
}