using System.Globalization;

namespace LocalFarmer2.Shared.Utilities
{
    public static class StringHelper
    {
        public static string CapitalizeFirst(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            var first = char.ToUpper(value[0], CultureInfo.CurrentCulture);
            return value.Length == 1 ? first.ToString() : first + value[1..];
        }
    }
}
