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
        
        [RegularExpression(@"^(0(\.5)?|1(\.5)?|2(\.5)?|3(\.5)?|4(\.5)?|5)$", ErrorMessage = "Rating must be in increments of 0.5 between 0 and 5.")]
        public double Rating { get; set; }
        
        public DateTime DateCreated { get; set; }
        
        [ForeignKey(nameof(Farmhouse))]
        public int IdFarmhouse { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string IdUser { get; set; }

        public Farmhouse Farmhouse { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }
    }
}
