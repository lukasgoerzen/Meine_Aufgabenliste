namespace Meine_Aufgabenliste.Models {
    public class Schluesselwort {
        public int Id { get; set; }
        public int KategorieId { get; set; }
        public Kategorie Kategorie { get; set; }
        public string Name { get; set; }
    }
}
