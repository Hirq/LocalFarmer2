using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Server.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CountAll { get; set; }
        public string CountMinOne { get; set; }
        public string PrizeOne { get; set; }

        [ForeignKey(nameof(Farmhouse))]
        public int IdFarmhouse { get; set; }

        public Farmhouse Farmhouse { get; set; }
    }
}
