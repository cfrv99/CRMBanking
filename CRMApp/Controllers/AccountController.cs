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
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;
        private readonly AppDbContext context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
        }



        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            AppUser appUser = new AppUser
            {
                Name = viewModel.Name,
                UserName = viewModel.UserName,
                Email = viewModel.Email,
                Role = Role.Customer
            };

            var isUserHas = await userManager.FindByEmailAsync(viewModel.Email);
            if (isUserHas != null)
            {
                return BadRequest("User already exist");
            }

            var result = await userManager.CreateAsync(appUser, viewModel.Password);
            if (result.Succeeded)
            {
                await signInManager.PasswordSignInAsync(appUser, viewModel.Password, false, false);
                return RedirectToAction("RequestTo", "Account");
            }
            ModelState.AddModelError("", "User Can not be created");
            return View(viewModel);
        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vM)
        {
            if (ModelState.IsValid)
            {
                var userExist = await userManager.FindByEmailAsync(vM.Email);
                if (userExist != null)
                {
                    var result = await signInManager.PasswordSignInAsync(userExist, vM.Password, false, false);
                    if (result.Succeeded)
                    {
                        if (userExist.Role == Role.Customer)
                        {
                            return RedirectToAction("Companies", "Home");
                        }
                        return RedirectToAction("Dashboard", "Company");
                    }
                    ModelState.AddModelError("", "user password or username incorrect");
                }
            }

            return View(vM);
        }

        public IActionResult RequestTo()
        {
            return View(new RequestViewModel());
        }
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();

            return RedirectToAction("Dashboard", "Company");
        }
        [HttpPost]
        public async Task<IActionResult> RequestTo(RequestViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
                    Request request = new Request
                    {
                        RequestTitle = model.Title,
                        RequestDescription = model.Description,
                        AppUserId = currentUser.Id
                    };
                    context.Requests.Add(request);
                    context.SaveChanges();
                    return Redirect("/Home/Companies");
                }
                return Unauthorized();
            }
            return View(model);
        }
    }
}