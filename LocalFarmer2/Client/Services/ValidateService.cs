using LocalFarmer2.Shared.DTOs;
using MudBlazor;
using System.Globalization;

namespace LocalFarmer2.Client.Services
{
    public class ValidateService
    {
        public bool ValidateMudTextFields(List<(object Field, string Value)> mudTextValues)
        {
            bool validationFailed = false;

            foreach (var (field, value) in mudTextValues)
            {
                switch (field)
                {
                    case MudTextField<string> textField:
                        if (string.IsNullOrEmpty(value))
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
                        if (string.IsNullOrEmpty(value))
                        {
                            selectField.Validate();
                            validationFailed = true;
                        }
                        else
                        {
                            selectField.ResetValidation();
                        }
                        break;

                    // Dodaj obsługę innych typów pól tutaj, jeśli jest to potrzebne

                    default:
                        throw new InvalidOperationException("Nieobsługiwany typ pola.");
                }

                if (validationFailed)
                    break;
                    //return validationFailed; // Zakończ walidację, jeśli wystąpił błąd
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
