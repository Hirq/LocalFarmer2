using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Do zmiany"), MinLength(6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Hasla msuza być takei same")]
        public string ConfirmPassword { get; set; }

    }
}
