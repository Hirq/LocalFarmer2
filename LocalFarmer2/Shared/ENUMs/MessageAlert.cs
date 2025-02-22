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
        Welcome,
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
                    return $"Farmhouse {Value} is actually {((bool)IsOpen ? "open" : "close")}";
                case MessageAlertEnum.NewProduct:
                    return $"Farmhouse {Value} add new product {Value2}";
                case MessageAlertEnum.EditProduct:
                    return $"Farmhouse {Value} edit product {Value2}";
                case MessageAlertEnum.EditDetails:
                    return $"Farmhouse {Value} change information";
                case MessageAlertEnum.NewSubscriber:
                    return $"New Subscriber: {Value}";
                case MessageAlertEnum.NewOpinion:
                    return $"New Opinion: {Value}";
                case MessageAlertEnum.Welcome:
                    return $"Welcome Localfarmer";
                case MessageAlertEnum.NewMessageChat:
                    return $"You have new message in chat from: {Value}";
                default:
                    return string.Empty;
            }
        }

    }
}
