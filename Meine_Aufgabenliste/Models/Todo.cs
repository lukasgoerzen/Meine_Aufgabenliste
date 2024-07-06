using System.ComponentModel.DataAnnotations;

namespace Meine_Aufgabenliste.Models
{
    public class ToDo {

        public int Id { get; set; }
        [Required]
        public Kategorie Kategorie { get; set; }
        [Required]
        public Schluesselwort Schluesselwort { get; set; }
        [Required]
        public string Aufgabe {  get; set; }
        [Required]
        public string Beschreibung { get; set; }
        public string Loesung {  get; set; }
        [Required]
        public Verantwortlicher Verantwortlicher {  get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
