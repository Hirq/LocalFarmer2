using LocalFarmer2.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class LoginDto
    {
        [LocalizedRequired("ErrorRequired", "Email")]
        [LocalizedEmailAddressAttribute("ErrorEmailValid")]
        public string Email { get; set; }

        [LocalizedRequired("ErrorRequired", "Account_Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
