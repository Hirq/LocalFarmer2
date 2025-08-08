using LocalFarmer2.Client.Utilities;
using MudBlazor;
using System.Globalization;

namespace LocalFarmer2.Client.Services
{
    public class ValidateService
    {

        public bool ValidateMudTextFields(params FieldToValidate[] fieldsToValidate)
        {
            return ValidateMudTextFields(fieldsToValidate.ToList());
        }

        public bool ValidateMudTextFields(List<FieldToValidate> fieldsToValidate)
        {
            bool validationFailed = false;

            foreach (var field in fieldsToValidate)
            {
                switch (field.Field)
                {
                    case MudTextField<string> textField:
                        if (string.IsNullOrEmpty(field.Value))
                        {
                            textField.Validate();
                            validationFailed = true;
                        }
                        else
                        {
                            textField.ResetValidation();
                        }
                        break;

                    case MudSelect<string> selectField:
                        if (string.IsNullOrEmpty(field.Value))
                        {
                            selectField.Validate();
                            validationFailed = true;
                        }
                        else
                        {
                            selectField.ResetValidation();
                        }
                        break;

                    default:
                        throw new InvalidOperationException("Unsupported field type.");
                }

                if (validationFailed)
                    break;
            }

            return validationFailed;
        }

        public bool IsValidLatitude(string latStr)
        {
            if (double.TryParse(latStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double lat))
            {
                return lat >= -90 && lat <= 90;
            }
            return false;
        }

        public bool IsValidLongitude(string lonStr)
        {
            if (double.TryParse(lonStr, NumberStyles.Float, CultureInfo.InvariantCulture, out double lon))
            {
                return lon >= -180 && lon <= 180;
            }
            return false;
        }

    }
}
