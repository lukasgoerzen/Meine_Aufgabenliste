using System.ComponentModel.DataAnnotations;

namespace Meine_Aufgabenliste.Models.Enums {
    public enum Status {
        [Display(Name = "Offen")]
        Offen,

        [Display(Name = "in Bearbeitung")]
        inBearbeitung,

        [Display(Name = "Wartend")]
        Wartend,

        [Display(Name = "Abgeschlossen")]
        Abgeschlossen,

        [Display(Name = "Archiv")]
        Archiv,
    }
}
