using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.Models
{
    public class Opinion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Comment { get; set; }
        
        [Range(0, 5, ErrorMessage = "Rating must be between 0 and 5.")]
        public int Rating { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        [ForeignKey(nameof(Farmhouse))]
        public int IdFarmhouse { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string IdUser { get; set; }

        public Farmhouse Farmhouse { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }
    }
}
