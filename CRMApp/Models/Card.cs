using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRMApp.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Expire { get; set; }
        public decimal Amount { get; set; }
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
