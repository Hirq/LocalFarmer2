using LocalFarmer2.Shared.ENUMs;
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

        //Receiver
        [ForeignKey(nameof(UserTarget))]
        public string IdUserTarget { get; set; }

        //Sender
        [ForeignKey(nameof(UserSource))]
        public string IdUserSource { get; set; }

        [ForeignKey(nameof(Farmhouse))]
        public int? IdFarmhouse { get; set; }

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
        // Przywitalny
        // Nowa wiadomość na chat
        // Wyśle zapytanie przez formularz - BRAK -> Brak formularza *@

        public bool InfoFromFarmhouse { get; set; }

        // Dodać ENUM, który wskazuje na dany rodzaj alertu / do filtrowania tego i łatwiej wyświetlać wtedy dwujęzyczne teksty - bo tutaj bedzie opis czego dotyczy,
        // a wiadomość co została wpisana w polu Message lub pusto tam 
        public MessageAlertEnum AlertEnum { get; set; }

        public ApplicationUser UserTarget { get; set; }

        public ApplicationUser UserSource { get; set; }

        public Farmhouse Farmhouse { get; set; }
    }
}
