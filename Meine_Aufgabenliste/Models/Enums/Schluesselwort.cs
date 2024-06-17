using System.ComponentModel.DataAnnotations;

namespace Meine_Aufgabenliste.Models.Enums {
    public enum Schluesselwort {
        [Display(Name = "E-Mail")]
        EMail,

        [Display(Name = "Ticket")]
        Ticket,

        [Display(Name = "Zahlungen")]
        Zahlungen,

        [Display(Name = "DigiFAM")]
        DigiFAM

    }
}
