using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class EditOpinionDto
    {
        public string Comment { get; set; }

        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }
    }
}
