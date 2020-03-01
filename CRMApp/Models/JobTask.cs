using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class JobTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; } = Status.IsNotStarted;
        public decimal Amount { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DeadLine { get; set; }
        public int? ClaimId { get; set; }
        public Claim Claim { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
    public enum Status
    {
        Waiting,
        IsNotStarted,
        Finished

    }
}
