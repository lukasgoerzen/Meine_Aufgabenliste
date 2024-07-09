using System.ComponentModel.DataAnnotations;

namespace Meine_Aufgabenliste.Models {
    public class Status {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string GetStatusFarbe(string statusName) {
            switch (statusName.ToLower()) {
                case "Offen":
                    return "danger";
                case "in Bearbeitung":
                    return "warning";
                case "Wartend":
                    return "primary";
                case "Abgeschlossen":
                    return "success";
                case "Archiviert":
                    return "light";
                default:
                    return "dark"; // Default-Farbe, wenn kein spezifischer Status gefunden wird
            }
        }
    } 
}
