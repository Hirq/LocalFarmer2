using Microsoft.Extensions.Localization;
using System;
using System.Globalization;

namespace LocalFarmer2.Shared.Resources
{
    public class SharedResources
    {
        private readonly IStringLocalizer<SharedResources> _localizer;

        public SharedResources(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        public string this[string key]
        {
            get
            {
                var value = _localizer[key];
                var currentCulture = CultureInfo.CurrentCulture.Name;
                var currentUICulture = CultureInfo.CurrentUICulture.Name;

                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine($"Key '{key}' not found in resources for culture '{currentCulture}' and UI culture '{currentUICulture}'.");
                    return $"[{key}]";
                }
                else
                {
                    Console.WriteLine($"Key: {key}, Value: {value}, Culture: {currentCulture}, UI Culture: {currentUICulture}");
                    return value;
                }
            }
        }
    }
}
