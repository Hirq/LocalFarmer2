using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class AddOpinionDto
    {
        public string Comment { get; set; }

        [RegularExpression(@"^(0(\.5)?|1(\.5)?|2(\.5)?|3(\.5)?|4(\.5)?|5)$", ErrorMessage = "Rating must be in increments of 0.5 between 0 and 5.")]
        public double Rating { get; set; }
        public int IdFarmhouse { get; set; }
        public string IdUser { get; set; }
    }
}
