using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Server.Utilities
{
    public class CustomValidationMetadataProvider : IValidationMetadataProvider
    {
        public void CreateValidationMetadata(ValidationMetadataProviderContext context)
        {
            foreach (var attribute in context.ValidationMetadata.ValidatorMetadata)
            {
                switch (attribute)
                {
                    case RequiredAttribute requiredAttribute:
                        requiredAttribute.ErrorMessage = "Pole {0} jest wymagane."; // Możesz pobrać z lokalizatora
                        break;

                    case StringLengthAttribute stringLengthAttribute:
                        stringLengthAttribute.ErrorMessage = "Hasło musi mieć od {2} do {1} znaków.";
                        break;

                    case CompareAttribute compareAttribute:
                        compareAttribute.ErrorMessage = "Hasła muszą być takie same.";
                        break;
                }
            }
        }
    }
}
