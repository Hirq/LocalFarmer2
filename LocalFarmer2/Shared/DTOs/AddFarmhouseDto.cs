namespace LocalFarmer2.Shared.DTOs
{
    public class AddFarmhouseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string IdUser { get; set; }
    }
}
