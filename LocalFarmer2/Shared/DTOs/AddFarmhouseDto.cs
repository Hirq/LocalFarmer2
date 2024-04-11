using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class AddFarmhouseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string IdUser { get; set; }
        public bool IsOpen { get; set; } = true;
        public string PaymentMethods { get; set; }

    }
}
