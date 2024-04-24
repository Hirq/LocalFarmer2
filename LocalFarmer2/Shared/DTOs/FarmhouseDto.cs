using LocalFarmer2.Shared.Utilities;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class FarmhouseDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [RegularExpression(@"^$|^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }
        public bool IsOpen { get; set; }
        public string PaymentMethods { get; set; }
        public byte[]? ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}
