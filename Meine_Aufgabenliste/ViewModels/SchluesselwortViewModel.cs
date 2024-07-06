using Meine_Aufgabenliste.Models;

namespace Meine_Aufgabenliste.ViewModels {
    public class SchluesselwortViewModel {
        public required List<Schluesselwort> Schluesselwort { get; set; }
        public required List<Kategorie> Kategorie { get; set; }
    }
}
