using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalFarmer2.Shared.Models
{
    public class ChatUserKey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string User1Id { get; set; }

        [Required]
        public string User2Id { get; set; }

        [Required]
        public byte[] AESKey { get; set; }
    }
}
