using Meine_Aufgabenliste.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Meine_Aufgabenliste.Controllers {
    public class OffenController : Controller {

        private readonly string _jsonDateipfad = "wwwroot/data/toDos.json";


        public IActionResult Index() {

            //Lade ToDos
            var bestehendeToDos = LadeToDos();
            ViewBag.ToDos = bestehendeToDos;

            return View();
        }

        public IActionResult CreateToDo() {

            // Lade alle ToDos, um neue Id zu ermitteln
            var bestehendeToDos = LadeToDos();
            int neueId = bestehendeToDos.Count + 1; // nächste Id für neues ToDo
            ViewBag.NeueId = neueId;
            return View();
        }

        [HttpPost]
        public IActionResult AddToDo(ToDo toDo) {

            // Laden der bestehenden Daten
            var bestehendeToDos = LadeToDos();

            // Hinzufügen der neuen ToDos
            bestehendeToDos.Add(toDo);

            // Speicher aktualisierte Liste in JSON-Datei
            SpeicherToDos(bestehendeToDos);

            return RedirectToAction("Index");
        }

        private List<ToDo> LadeToDos() {
            if (!System.IO.File.Exists(_jsonDateipfad)) return new List<ToDo>();

            var json = System.IO.File.ReadAllText(_jsonDateipfad);
            return JsonSerializer.Deserialize<List<ToDo>>(json) ?? new List<ToDo>();
        }

        private void SpeicherToDos(List<ToDo> todos) {
            var json = JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(_jsonDateipfad, json);
        }
    }
}
