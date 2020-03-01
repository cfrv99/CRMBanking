using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class CompanyContract
    {
        public int Id { get; set; }
        public string Agreements { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public decimal MonthCount { get; set; }
        public decimal Amount { get; set; }
        public decimal MonthlyLoan
        {
            get
            {
                return Math.Floor(Amount / MonthCount);
            }
        }

    }
}
