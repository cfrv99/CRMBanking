using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public bool PermissionCompany { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        [ForeignKey("Card")]
        public int? CardId { get; set; }
        public string Signature { get; set; }
        public string Tel { get; set; }
        public Role Role { get; set; }
        public string Address { get; set; }
        public Card Card { get; set; }
        public int? ClaimId { get; set; }
        public Claim Claim { get; set; }
        public List<MonthlySalary> MonthlySalaries { get; set; }
        public List<MonthlyAmount> MonthlyAmounts { get; set; }
        public int? StaffContractId { get; set; }
        public StaffContract StaffContract { get; set; }
        public List<Product> Products { get; set; }

    }
    public enum Role
    {
        Staff=0,
        Customer=1,
        SuperAdmin=2
    }

}
