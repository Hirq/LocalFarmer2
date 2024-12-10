using LocalFarmer2.Shared.Resources;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LocalFarmer2.Shared.Models
{
    public class LocalizedCompareAttribute : CompareAttribute
    {
        private readonly string _errorMessageKey;
        private readonly string _field;

        public LocalizedCompareAttribute(string otherProperty, string errorMessageKey, string field) : base(otherProperty)
        {
            _errorMessageKey = errorMessageKey;
            _field = field;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var localizer = (IStringLocalizer)validationContext.GetService(typeof(IStringLocalizer<SharedResources>));

            var errorMessage = localizer[_errorMessageKey];
            var field = localizer[_field];
            var otherPropertyInfo = validationContext.ObjectType.GetRuntimeProperty(OtherProperty);

            object? otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (!Equals(value, otherPropertyValue))
            {
                return new ValidationResult(field + " " + errorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
