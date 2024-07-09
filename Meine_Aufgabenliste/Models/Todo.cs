using System.ComponentModel.DataAnnotations;

namespace Meine_Aufgabenliste.Models
{
    public class ToDo {

        public int Id { get; set; }
        [Required]
        public int KategorieId { get; set; }
        public Kategorie Kategorie { get; set; }
        [Required]
        public int SchluesselwortId { get; set; }
        public Schluesselwort Schluesselwort { get; set; }
        [Required]
        public string Aufgabe {  get; set; }
        [Required]
        public string Beschreibung { get; set; }
        public string? Loesung {  get; set; }
        [Required]
        public int VerantwortlicherId { get; set; }
        public Verantwortlicher Verantwortlicher {  get; set; }
        [Required]
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
