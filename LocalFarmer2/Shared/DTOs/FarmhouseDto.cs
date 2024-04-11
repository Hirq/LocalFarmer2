using LocalFarmer2.Shared.Utilities;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class FarmhouseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool IsOpen { get; set; }
        public string PaymentMethods { get; set; }
    }
}
