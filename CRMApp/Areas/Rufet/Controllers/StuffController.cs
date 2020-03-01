using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CRMApp.Areas.Rufet.Controllers
{
    [Area("Rufet")]
    public class StuffController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly AppDbContext context;

        public StuffController(UserManager<AppUser> userManager,AppDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateStuff(int companyId)
        {
            var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
            if (currentUser.Role == Role.Customer)
            {

            }
            return View();
        }



    }
}