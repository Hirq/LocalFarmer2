using LocalFarmer2.Shared.Resources;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.Models
{
    public class LocalizedRequiredAttribute : ValidationAttribute
    {
        private readonly string _errorMessageKey;

        public LocalizedRequiredAttribute(string errorMessageKey)
        {
            _errorMessageKey = errorMessageKey;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var localizer = (IStringLocalizer)validationContext.GetService(typeof(IStringLocalizer<SharedResources>));

            var errorMessage = localizer[_errorMessageKey];
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
