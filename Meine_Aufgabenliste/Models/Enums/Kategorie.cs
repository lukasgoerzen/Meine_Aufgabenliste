using System.ComponentModel.DataAnnotations;

namespace Meine_Aufgabenliste.Models.Enums
{
    public enum Kategorie
    {
        [Display(Name = "Laufender Betrieb")]
        LaufenderBetrieb,

        [Display(Name = "Projekt")]
        Projekt,

        [Display(Name = "MAV")]
        MAV
    }
}
