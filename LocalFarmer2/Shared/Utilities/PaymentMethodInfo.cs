namespace LocalFarmer2.Shared.Utilities
{
    public class PaymentMethodInfo
    {
        public static readonly string[] PaymentMethods =
        {
            "Cash",
            "Card",
            "Bank transfer",
            "Transfer on phone",
            "Other in describe"
        };

        public static IEnumerable<string> DefaultPayment { get; set; } = new HashSet<string>() { "Cash" };
    };
}
