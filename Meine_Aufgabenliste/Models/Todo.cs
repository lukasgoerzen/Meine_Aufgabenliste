using Meine_Aufgabenliste.Models.Enums;

namespace Meine_Aufgabenliste.Models
{
    public class ToDo {

        public int Id { get; set; }
        public Kategorie Kategorie { get; set; }
        public Schluesselwort Schluesselwort { get; set; }
        public string Aufgabe {  get; set; }
        public string Beschreibung { get; set; }
        public string Loesung {  get; set; }
        public Verantwortlich Verantwortlich {  get; set; }
        public string Status { get; set; }
    }
}
