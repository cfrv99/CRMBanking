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
    public class ManagmentController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public ManagmentController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
 

        public async Task<IActionResult> Index()
        {
            var user = new AppUser() { Name = "Rufat", UserName = "ismayilov449", Email = "rufet.simayilov.1999@gmail.com" };

           
            var result = await userManager.CreateAsync(user, "1357900");
            
                await signInManager.PasswordSignInAsync(user, "1357900", false, false);
               
            return View();
        }
    }
}