using LocalFarmer2.Shared.ENUMs;

namespace LocalFarmer2.Shared.DTOs
{
    public class AddAlertDto
    {
        public string Message { get; set; }
        public int? IdFarmhouse { get; set; }
        public string IdUser { get; set; }
        public bool InfoFromFarmhouse { get; set; }
        public MessageAlertEnum AlertEnum { get; set; }
    }
}
