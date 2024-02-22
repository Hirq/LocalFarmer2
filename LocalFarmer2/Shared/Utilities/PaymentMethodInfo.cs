namespace LocalFarmer2.Shared.Utilities
{
    public class PaymentMethodInfo
    {
        public PaymentMethod Method { get; set; }
        public string DisplayName { get; set; }
    }

    public enum PaymentMethod
    {
        Cash,
        Card,
        BankTransfer,
        TransferOnPhone,
        Other
    }
}
