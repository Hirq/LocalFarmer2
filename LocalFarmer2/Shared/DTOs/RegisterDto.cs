using LocalFarmer2.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class RegisterDto
    {
        [LocalizedRequired("ErrorRequired", "Email")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres email.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [LocalizedRequired("ErrorRequired", "Account_Password")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Hasło musi mieć od {2} do {1} znaków.")]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [LocalizedRequired("ErrorRequired", "Account_Password_Confirm")]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdzenie hasła")]
        [Compare("Password", ErrorMessage = "Hasła muszą być takie same.")]
        public string ConfirmPassword { get; set; }

    }
}