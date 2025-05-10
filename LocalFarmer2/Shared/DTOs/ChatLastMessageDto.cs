namespace LocalFarmer2.Shared.DTOs
{
    public class ChatLastMessageDto
    {
        public string IdUserSender { get; set; }
        public string IdUserReceiver { get; set; }
        public string Message { get; set; }
        public bool IsLastMessageFromSender { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime DateSent { get; set; }
    }
}
