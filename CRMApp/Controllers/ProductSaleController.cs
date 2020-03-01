using CRMApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Controllers
{
    public class ProductSaleController:Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly UserManager<AppUser> userManager;

        public ProductSaleController(AppDbContext appDbContext,UserManager<AppUser> userManager)
        {
            this.appDbContext = appDbContext;
            this.userManager = userManager;
        }

        public IActionResult CreateProduct()
        {
            return View(new Product());
        }

        public async Task<IActionResult> Sale()
        {
            var product = appDbContext.Products.FirstOrDefault();
            var currentUser =await userManager.FindByNameAsync(User.Identity.Name);
            var companyId = currentUser.CompanyId;
            var company = appDbContext.Companies.Where(i => i.Id == companyId).FirstOrDefault();

            var bank = appDbContext.Banks.FirstOrDefault();
            bank.Amount += (product.Price * 5) / 100;

            appDbContext.Products.Remove(product);
            appDbContext.SaveChanges();
            return View();
        }
    }
}
