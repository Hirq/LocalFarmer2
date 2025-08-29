namespace LocalFarmer2.Shared.ENUMs
{
    public enum MessageAlertEnum
    {
        FarmhouseIsOpen,
        NewProduct,
        EditProduct,
        EditDetails,
        //
        NewSubscriber,
        NewOpinion,
        NewMessageChat
        //NewMessageFromForm - nowa wiadomość z formularza
    }

    public class MessageAlert
    {
        public string Value { get; }
        public string? Value2 { get; }
        public bool? IsOpen { get; }
        public MessageAlertEnum AlertEnum { get; }

        public MessageAlert(MessageAlertEnum alertEnum, string value, string? value2 = null, bool? isOpen = null)
        {
            AlertEnum = alertEnum; 
            Value = value;
            Value2 = value2;
            IsOpen = isOpen;
        }

        public string GetMessage()
        {
            switch (AlertEnum)
            {
                case MessageAlertEnum.FarmhouseIsOpen:
                    return $"{Value} - {((bool)IsOpen ? "open" : "close")}";
                case MessageAlertEnum.NewProduct:
                    return $"{Value} - {Value2}";
                case MessageAlertEnum.EditProduct:
                    return $"{Value} - {Value2}";
                case MessageAlertEnum.EditDetails:
                    return $"{Value}";
                case MessageAlertEnum.NewSubscriber:
                    return $"{Value}";
                case MessageAlertEnum.NewOpinion:
                    return $"{Value}";
                case MessageAlertEnum.NewMessageChat:
                    return $"{Value}";
                default:
                    return string.Empty;
            }
        }

    }
}
