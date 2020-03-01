using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class CreateStaffForCompanyVM
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public string Signature { get; set; }
        public int ClaimId { get; set; }

    }
}
