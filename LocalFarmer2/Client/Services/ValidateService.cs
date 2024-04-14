using MudBlazor;

namespace LocalFarmer2.Client.Services
{
    public class ValidateService
    {
        public async Task<bool> ValidateMudTextFields((object Field, string Value)[] mudTextValues)
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
    }
}
