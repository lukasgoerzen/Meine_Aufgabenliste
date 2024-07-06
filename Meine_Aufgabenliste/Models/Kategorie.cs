using System.ComponentModel.DataAnnotations;

namespace Meine_Aufgabenliste.Models {
    public class Kategorie {
        public int Id { get; set; }
        [Required(ErrorMessage = "Der Name der Kategorie ist erforderlich.")]
        public string Name { get; set; }
    }
}
