using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalFarmer2.Shared.Models
{
    public class FavoriteFarmhouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string IdUser { get; set; }

        [ForeignKey(nameof(Farmhouse))]
        public int IdFarmhouse { get; set; }


        public ApplicationUser ApplicationUser { get; set; }

        public Farmhouse Farmhouse { get; set; }
    }
}
