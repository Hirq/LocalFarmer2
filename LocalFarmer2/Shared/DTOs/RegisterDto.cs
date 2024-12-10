using LocalFarmer2.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class RegisterDto
    {
        [LocalizedRequired("ErrorRequired", "Email")]
        [EmailAddress(ErrorMessage = "Podaj poprawny adres email.")]
        public string Email { get; set; }

        [LocalizedRequired("ErrorRequired", "Account_Password")]
        [LocalizedStringLengthAttribute(100, 6, "ErrorMinimum6Chars", "Account_Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [LocalizedRequired("ErrorRequired", "Account_Password_Confirm")]
        [DataType(DataType.Password)]
        [LocalizedCompareAttribute("Password", "ErrorPasswordsTheSame", "Account_Passwords")]
        public string ConfirmPassword { get; set; }

    }
}