using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LocalFarmer2.Shared.Models
{
    public class Farmhouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        //Szerokość geograficzna
        public double Latitude { get; set; }

        //Długość geograficzna
        public double Longitude { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
