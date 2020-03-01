using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRMApp.Models;
using Microsoft.AspNetCore.Identity;
using CRMApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CRMApp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly AppDbContext context;
        private readonly UserManager<AppUser> userManager;

        public HomeController(AppDbContext context,UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetContarcts()
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);

            var companyContract = context.CompanyContracts.Include(i=>i.Company).Where(i => i.CompanyId == currentUser.CompanyId).ToList();
            var userContracts = context.StaffContracts.Where(i => i.AppUserId == currentUser.Id).ToList();
            ContractsVM vm = new ContractsVM
            {
                CompanyContracts = companyContract,

                StaffContracts = userContracts
            };

            return View(vm);
        }


        [HttpGet]
        public IActionResult Companies()
        {
            var companies = context.Companies.ToList();
            
            return View(companies);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
