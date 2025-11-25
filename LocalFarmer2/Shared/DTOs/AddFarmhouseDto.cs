using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class AddFarmhouseDto : IDtoWithImage
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        [RegularExpression(@"^$|^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        public string Latitude { get; set; } = string.Empty;
        public string Longitude { get; set; } = string.Empty;
        public string IdUser { get; set; } = string.Empty;
        public bool IsOpen { get; set; } = true;
        public bool IsPaymentCash { get; set; }
        public bool IsPaymentCard { get; set; }
        public bool IsPaymentBankTransfer { get; set; }
        public bool IsPaymentTransferOnPhone { get; set; }
        public bool IsPaymentOther { get; set; }
        public byte[]? ImageData { get; set; } = null;
        public string ImageMimeType { get; set; } = string.Empty;
    }
}
