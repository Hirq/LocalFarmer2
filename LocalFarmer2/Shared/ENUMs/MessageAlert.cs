namespace LocalFarmer2.Shared.ENUMs
{
    public enum MessageAlertEnum
    {
        MessageIsOpen,
    }

    public class MessageAlert
    {
        public string Name { get; }
        public bool IsOpen { get; }
        public MessageAlertEnum AlertEnum { get; }

        public MessageAlert(MessageAlertEnum alertEnum, string nameFarmhouse, bool isOpenFarmhouse)
        {
            AlertEnum = alertEnum; 
            Name = nameFarmhouse;
            IsOpen = isOpenFarmhouse;
        }

        public string GetMessage()
        {
            switch (AlertEnum)
            {
                case MessageAlertEnum.MessageIsOpen:
                    return $"Farmhouse {Name} is actually {(IsOpen ? "open" : "close")}";
                default:
                    return string.Empty;
            }
        }

    }
}
