using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalFarmer2.Shared.Models
{
    public class ChatMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Sender))]
        public string IdUserSender { get; set; }

        [Required]
        [ForeignKey(nameof(Receiver))]
        public string IdUserReceiver { get; set; }

        [Required]
        public byte[] EncryptedMessage { get; set; }

        [Required]
        public byte[] MessageIV { get; set; } 

        [Required]
        public DateTime DateSent { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;

        public DateTime? DateRead { get; set; }

        public ApplicationUser Sender { get; set; }
        public ApplicationUser Receiver { get; set; }
    }
}
