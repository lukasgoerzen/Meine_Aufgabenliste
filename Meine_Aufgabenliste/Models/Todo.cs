namespace Meine_Aufgabenliste.Models {
    public class Todo {

        public int Id { get; set; }
        public string Kategorie { get; set; }
        public string Schlüsselwort { get; set; }
        public string Aufgabe {  get; set; }
        public string Beschreibung { get; set; }
        public string Lösung {  get; set; }
        public string Verantwortlich {  get; set; }
        public string Status { get; set; }
    }
}
