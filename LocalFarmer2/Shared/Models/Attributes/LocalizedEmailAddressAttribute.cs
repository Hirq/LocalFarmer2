using LocalFarmer2.Shared.Resources;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LocalFarmer2.Shared.Models
{
    public class LocalizedEmailAddressAttribute : DataTypeAttribute
    {
        private readonly string _errorMessageKey;

        public LocalizedEmailAddressAttribute(string errorMessageKey) : base(DataType.EmailAddress)
        {
            _errorMessageKey = errorMessageKey;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var localizer = (IStringLocalizer)validationContext.GetService(typeof(IStringLocalizer<SharedResources>));
            var errorMessage = localizer[_errorMessageKey];

            if (!IsValid(value))
            {
                var formattedMessage = string.Format(errorMessage);
                return new ValidationResult(formattedMessage);
            }

            return ValidationResult.Success;
        }


        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }

            if (!(value is string valueAsString))
            {
                return false;
            }

            // only return true if there is only 1 '@' character
            // and it is neither the first nor the last character
            int index = valueAsString.IndexOf('@');

            return
                index > 0 &&
                index != valueAsString.Length - 1 &&
                index == valueAsString.LastIndexOf('@');
        }
    }
}
