using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalFarmer2.Shared.Models
{
    public class Note
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Text { get; set; }
        public bool IsArchive { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        public string IdUser { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
