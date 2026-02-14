using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalFarmer2.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey(nameof(Farmhouse))]
        public int? IdFarmhouse { get; set; }

        public string FullName { get; set; } 
        public bool IsPremium { get; set; } 
        public DateTime DatePremium { get; set; } 
        
        public Farmhouse Farmhouse { get; set; }

    }
}
