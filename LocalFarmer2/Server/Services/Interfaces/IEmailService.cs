namespace LocalFarmer2.Server.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
