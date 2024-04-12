using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalFarmer2.Shared.Models
{
    public class Farmhouse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        [RegularExpression(@"^$|^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        //Szerokość geograficzna - zakres 0:90
        public string Latitude { get; set; }

        //Długość geograficzna - zakres 0:180
        public string Longitude { get; set; }

        public bool IsOpen { get; set; }
        public string PaymentMethods { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
