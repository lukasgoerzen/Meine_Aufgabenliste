﻿using System.ComponentModel.DataAnnotations;

namespace Meine_Aufgabenliste.Models {
    public class Verantwortlicher {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
