namespace Meine_Aufgabenliste.Models {
    public class ToDo {

        public int Id { get; set; }
        public string Kategorie { get; set; }
        public string Schluesselwort { get; set; }
        public string Aufgabe {  get; set; }
        public string Beschreibung { get; set; }
        public string Loesung {  get; set; }
        public string Verantwortlich {  get; set; }
        public string Status { get; set; }
    }
}
