namespace LocalFarmer2.Client.Utilities
{
    public class FieldToValidate
    {
        public object Field { get; }
        public string Value { get; }

        public FieldToValidate(object field, string value)
        {
            Field = field;
            Value = value;
        }
    }
}
