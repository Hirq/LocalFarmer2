using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LocalFarmer2.Shared.Utilities
{
    public record PaymentMethodDefinition(string PropertyName, string LocalizationKey, string FallbackLabel, bool SelectedByDefault = false);

    public static class PaymentMethodInfo
    {
        public static readonly IReadOnlyList<PaymentMethodDefinition> PaymentMethods = new List<PaymentMethodDefinition>
        {
            new("IsPaymentCash", "PaymentMethod_Cash", "Cash", true),
            new("IsPaymentCard", "PaymentMethod_Card", "Card"),
            new("IsPaymentBankTransfer", "PaymentMethod_BankTransfer", "Bank transfer"),
            new("IsPaymentTransferOnPhone", "PaymentMethod_TransferOnPhone", "Transfer on phone"),
            new("IsPaymentOther", "PaymentMethod_OtherInDescribe", "Other in describe")
        };

        public static IReadOnlyCollection<string> DefaultSelectionKeys =>
            PaymentMethods.Where(x => x.SelectedByDefault)
                .Select(x => x.PropertyName)
                .ToArray();

        public static void ApplyDefaults(object target)
        {
            if (target == null)
            {
                return;
            }

            foreach (var method in PaymentMethods.Where(x => x.SelectedByDefault))
            {
                SetValue(target, method.PropertyName, true);
            }
        }

        public static bool HasAnySelection(object source)
        {
            return PaymentMethods.Any(method => TryGetValue(source, method.PropertyName, out var value) && value);
        }

        public static IEnumerable<string> GetSelectedKeys(object source)
        {
            if (source == null)
            {
                yield break;
            }

            foreach (var method in PaymentMethods)
            {
                if (TryGetValue(source, method, out var value) && value)
                {
                    yield return method.PropertyName;
                }
            }
        }

        public static void ApplySelection(object target, IEnumerable<string> selectedKeys)
        {
            if (target == null)
            {
                return;
            }

            var selection = new HashSet<string>(selectedKeys ?? Enumerable.Empty<string>());

            foreach (var method in PaymentMethods)
            {
                SetValue(target, method, selection.Contains(method.PropertyName));
            }
        }

        public static bool TryGetValue(object source, PaymentMethodDefinition method, out bool value)
            => TryGetValue(source, method?.PropertyName, out value);

        public static bool TryGetValue(object source, string propertyName, out bool value)
        {
            value = false;

            if (source == null || string.IsNullOrWhiteSpace(propertyName))
            {
                return false;
            }

            var property = GetBoolProperty(source, propertyName);
            if (property == null)
            {
                return false;
            }

            value = (bool)(property.GetValue(source) ?? false);
            return true;
        }

        public static void SetValue(object target, PaymentMethodDefinition method, bool value)
            => SetValue(target, method?.PropertyName, value);

        public static void SetValue(object target, string propertyName, bool value)
        {
            if (target == null || string.IsNullOrWhiteSpace(propertyName))
            {
                return;
            }

            var property = GetBoolProperty(target, propertyName);
            property?.SetValue(target, value);
        }

        private static PropertyInfo GetBoolProperty(object source, string propertyName)
        {
            var property = source.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);

            if (property == null || property.PropertyType != typeof(bool))
            {
                return null;
            }

            return property;
        }
    }
}
