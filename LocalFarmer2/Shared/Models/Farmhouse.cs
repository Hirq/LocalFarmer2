using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LocalFarmer2.Shared.Utilities;

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

        //Szerokość geograficzna - zakres 0:90
        public string Latitude { get; set; }

        //Długość geograficzna - zakres 0:180
        public string Longitude { get; set; }

        public bool IsOpen { get; set; }

        public string PaymentMethods { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
