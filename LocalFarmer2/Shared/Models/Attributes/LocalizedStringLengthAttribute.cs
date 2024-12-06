using LocalFarmer2.Shared.Resources;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.Models
{
    public class LocalizedStringLengthAttribute : StringLengthAttribute
    {
        private readonly string _errorMessageKey;
        private readonly string _field;

        public LocalizedStringLengthAttribute(int maximumLength, int minimumLength, string errorMessageKey, string field) : base(maximumLength)
        {
            _errorMessageKey = errorMessageKey;
            _field = field;
            base.MinimumLength = minimumLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var localizer = (IStringLocalizer)validationContext.GetService(typeof(IStringLocalizer<SharedResources>));
            var errorMessage = localizer[_errorMessageKey];
            var field = localizer[_field];

            if (value == null || value.ToString().Length < MinimumLength || value.ToString().Length > MaximumLength)
            {
                var formattedMessage = string.Format(errorMessage, field, MinimumLength, MaximumLength);
                return new ValidationResult(formattedMessage);
            }

            return ValidationResult.Success;
        }
    }
}
