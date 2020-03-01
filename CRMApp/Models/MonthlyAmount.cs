﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class MonthlyAmount
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime SalaryDate { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
