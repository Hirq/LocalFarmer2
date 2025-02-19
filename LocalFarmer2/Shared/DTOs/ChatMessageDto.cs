namespace LocalFarmer2.Shared.DTOs
{
    public class ChatMessageDto
    {
        public string IdUserSender { get; set; }
        public string IdUserReceiver { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public bool IsSeparator { get; set; } = false;
    }
}
