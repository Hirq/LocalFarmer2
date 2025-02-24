using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.DTOs
{
    public class ChatUserKeyDto
    {
        [Required]
        public string User1Id { get; set; }

        [Required]
        public string User2Id { get; set; }
    }
}
