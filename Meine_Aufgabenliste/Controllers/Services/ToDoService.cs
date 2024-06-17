using Meine_Aufgabenliste.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Linq;
using System.Collections.Generic;

namespace Meine_Aufgabenliste.Controllers.Services {
    public class ToDoService : IToDoService {
        private readonly string _jsonDateipfad;

        public ToDoService(IConfiguration configuration) {
            _jsonDateipfad = configuration.GetValue<string>("JsonDateipfad");
        }

        public List<ToDo> LoadToDos() {
            if (!System.IO.File.Exists(_jsonDateipfad))
                return new List<ToDo>();

            var json = System.IO.File.ReadAllText(_jsonDateipfad);
            return JsonSerializer.Deserialize<List<ToDo>>(json) ?? new List<ToDo>();
        }

        public void SaveToDos(List<ToDo> toDos) {
            var json = JsonSerializer.Serialize(toDos, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_jsonDateipfad, json);
        }

        public List<ToDo> SearchToDos(List<ToDo> toDos, string suchbegriff) {
            return toDos.Where(toDo =>
                toDo.Kategorie != null && toDo.Kategorie.ToString().Contains(suchbegriff, StringComparison.OrdinalIgnoreCase) ||
                toDo.Schluesselwort != null && toDo.Schluesselwort.ToString().Contains(suchbegriff, StringComparison.OrdinalIgnoreCase) ||
                toDo.Aufgabe != null && toDo.Aufgabe.Contains(suchbegriff, StringComparison.OrdinalIgnoreCase) ||
                toDo.Beschreibung != null && toDo.Beschreibung.Contains(suchbegriff, StringComparison.OrdinalIgnoreCase) ||
                toDo.Loesung != null && toDo.Loesung.Contains(suchbegriff, StringComparison.OrdinalIgnoreCase) ||
                toDo.Verantwortlich != null && toDo.Verantwortlich.ToString().Contains(suchbegriff, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }
}