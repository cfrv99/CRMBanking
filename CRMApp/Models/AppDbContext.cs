using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class AppDbContext : IdentityDbContext<AppUser,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<MonthlyAmount> MonthlyAmounts { get; set; }
        public DbSet<MonthlySalary> MonthlySalaries { get; set; }
        public DbSet<UserContract> UserContracts { get; set; }
        public DbSet<StaffRequest> StaffRequests { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<JobTask> JobTasks { get; set; }
        public DbSet<AnnouncementWork> AnnouncementWorks { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<CompanyContract> CompanyContracts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StaffContract> StaffContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Company>().HasOne(x => x.Creator).WithOne().HasForeignKey<Company>(p => p.CreatorId);
            builder.Entity<Company>().HasMany(x => x.AppUsers);
        }
    }
}
