using LocalFarmer2.Shared.Resources;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.Models
{
    public class LocalizedRequiredAttribute : ValidationAttribute
    {
        private readonly string _errorMessageKey;
        private readonly string _field;

        public LocalizedRequiredAttribute(string errorMessageKey, string field)
        {
            _errorMessageKey = errorMessageKey;
            _field = field;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var localizer = (IStringLocalizer)validationContext.GetService(typeof(IStringLocalizer<SharedResources>));

            var errorMessage = localizer[_errorMessageKey];
            var field = localizer[_field];
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult(field + " " + errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
