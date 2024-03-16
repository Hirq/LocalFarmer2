using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalFarmer2.Shared.Models
{
    public class Alert
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [ForeignKey(nameof(User))]
        public string IdUser { get; set; }

        [ForeignKey(nameof(Farmhouse))]
        public int IdFarmhouse { get; set; }

        public bool IsOpen { get; set; }

        public ApplicationUser User { get; set; }

        public Farmhouse Farmhouse { get; set; }
    }
}
