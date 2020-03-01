using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRMApp.Models;
using CRMApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRMApp.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private AppDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public CompanyController(AppDbContext context,UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Dashboard()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var companyId = user.CompanyId;
            var usersCount = userManager.Users.Where(i => i.CompanyId == companyId).ToList().Count();
            var taskCount = context.JobTasks.Where(i => i.CompanyId == companyId).ToList().Count();
            var ongoingTask = context.JobTasks.Where(i => i.CompanyId == companyId && i.Status == Status.Waiting).ToList().Count();
            DashboardViewModel viewModel = new DashboardViewModel
            {
                UserCount=usersCount,
                Tasks=taskCount,
                OnGoingTask=ongoingTask
            };
            return View(viewModel);
        }

        public IActionResult CreateClaim()
        {
            return View(new CreateClaimVM());
        }
        [HttpPost]
        public IActionResult CreateClaim(CreateClaimVM vM)
        {
            if (ModelState.IsValid)
            {
                Claim claim = new Claim
                {
                    Name=vM.Name
                };
                context.Claims.Add(claim);
                context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpGet]
        public IActionResult CompanyCreate()
        {
            return View(new CompanyCreateVM());
        }
        [HttpPost]
        public async Task<IActionResult> CompanyCreate(CompanyCreateVM vM)
        {
            if (ModelState.IsValid)
            {
                var company = new Company
                {
                    Address = vM.Address,
                    Name = vM.Name,
                    Description = vM.Description
                };
                var comp= context.Companies.Add(company).Entity;

                var currentUser = await userManager.FindByNameAsync(User.Identity.Name);
                currentUser.CompanyId = comp.Id;
                await context.SaveChangesAsync();
                var forbankPers = (currentUser.Amount * 3) / 100;
                Random rnd = new Random();

                Card card = new Card
                {
                    Amount = currentUser.Amount - forbankPers,
                    AppUserId = currentUser.Id,
                    Expire = DateTime.Now.AddDays(20),
                    Number = rnd.Next(100000000, 1000000000).ToString()
                };
                context.Cards.Add(card);
                var bank = context.Banks.FirstOrDefault();
                bank.Amount += forbankPers;
                context.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            return View(vM);
        }
        public IActionResult MonthlySalary()
        {
            return View();
        }
        public IActionResult AddToCompanyUser()
        {
            ViewBag.Claims = new SelectList(context.Claims, "Id", "Name");
            return View(new CreateStaffForCompanyVM());
        }

        [HttpPost]
        public async Task<IActionResult> AddToCompanyUser(CreateStaffForCompanyVM vM)
        {
            var cureentUser = await userManager.FindByNameAsync(User.Identity.Name); 
            if (ModelState.IsValid)
            {
                var persatnatgeToBank = (vM.Amount * 3) / 100;
                vM.Amount=vM.Amount- (vM.Amount * 3) / 100;
                AppUser user = new AppUser
                {
                    Amount = vM.Amount,
                    Email=vM.Email,
                    Tel=vM.Tel,
                    UserName=vM.UserName,
                    CompanyId=cureentUser.CompanyId,
                    Address=vM.Address,
                    Name=vM.FirstName,
                    Signature=vM.Signature,
                    ClaimId=vM.ClaimId                   
                };

                var userExist = await userManager.FindByEmailAsync(vM.Email);
                Random rnd = new Random();
                string password = rnd.Next(1000000, 100000000).ToString();
                if (userExist == null) {
                    var result = await userManager.CreateAsync(user, password);
                    TempData["Password"] = password;
                    if (result.Succeeded)
                    {
                        cureentUser.Amount = vM.Amount;
                        context.SaveChanges();
                        var bank = context.Banks.First();
                        bank.Amount += persatnatgeToBank;
                        context.SaveChanges();
                        
                        return RedirectToAction("Dashboard");
                    }
                    ModelState.AddModelError("", "User can not create");
                }
                ModelState.AddModelError("", "User already exist");
            }
            ViewBag.Claims = new SelectList(context.Claims, "Id", "Name");
            return View(vM);
        }
    }
}