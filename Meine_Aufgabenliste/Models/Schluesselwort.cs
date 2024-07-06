using System.ComponentModel.DataAnnotations;

namespace Meine_Aufgabenliste.Models {
    public class Schluesselwort {
        public int Id { get; set; }
        [Required(ErrorMessage = "Eine Kategorie ist erforderlich.")]
        public int KategorieId { get; set; }
        [Required(ErrorMessage = "Eine Kategorie ist erforderlich.")]
        public Kategorie Kategorie { get; set; }
        [Required(ErrorMessage = "Der Name des Schlüsselworts ist erforderlich.")]
        public string Name { get; set; }
    }
}
