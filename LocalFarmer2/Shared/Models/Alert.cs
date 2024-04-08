using AutoMapper;
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

        public DateTime DateCreated { get; set; }

        // Cz1 - TRUE
        // Zmiana otawrcie/zamknięcie favorite farmhouse
        // Dodanie nowego produktu od favorite
        // Edycja produktu od favorite
        // Edycja na mapie lub Zmiany informacji(adress, nr telefonu lub coś innego) od favoriteod favorite

        // Cz2 - FALSE
        // Ktoś polubi moj farmhouse
        // DOda opinie o moim farmhouse
        // Wyśle zapytanie przez formularz - BRAK -> Brak formularza *@

        public bool InfoFromFarmhouse { get; set; }

        public ApplicationUser User { get; set; }

        public Farmhouse Farmhouse { get; set; }
    }
}
