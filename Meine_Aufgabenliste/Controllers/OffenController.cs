using Meine_Aufgabenliste.Controllers.Services;
using Meine_Aufgabenliste.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Meine_Aufgabenliste.Controllers {
    public class OffenController : Controller {

        private readonly IToDoService _toDoService;

        public OffenController(IToDoService toDoService) {
            _toDoService = toDoService;
        }


        public IActionResult Index() {

            //Lade gespeicherte ToDos
            var bestehendeToDos = _toDoService.LoadToDos();
            ViewBag.ToDos = bestehendeToDos;

            return View();
        }

        public IActionResult CreateToDo() {

            // Lade gespeicherte ToDos, um die nächste (freie) Id ermitteln zu können
            var bestehendeToDos = _toDoService.LoadToDos();
            int neueId = bestehendeToDos.Count + 1; // Id für neues ToDo
            ViewBag.NeueId = neueId;

            return View();
        }

        [HttpPost]
        public IActionResult AddToDo(ToDo toDo) {

            // Lade gespeicherte ToDos
            var bestehendeToDos =_toDoService.LoadToDos();

            // Hinzufügen der neuen ToDos
            bestehendeToDos.Add(toDo);

            // Speicher aktualisierte Liste in JSON-Datei
            _toDoService.SaveToDos(bestehendeToDos);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateEditToDo(ToDo toDo) {

            // Lade gespeicherte ToDos
            var bestehendeToDos = _toDoService.LoadToDos();

            // Erstelle neues ToDo
            if (toDo == null) {
                int neueId = bestehendeToDos.Count + 1; // Id für neues ToDo
                ViewBag.NeueId = toDo;
                return View("CreateToDo");
            }

            // Bearbeite ausgewähltes ToDo
            else {
                int index = toDo.Id - 1; // ToDos Id beginnt bei 1, List jedoch bei 0, daher um 1 subtrahieren

                if (index >= 0 && index < bestehendeToDos.Count) {
                    ViewBag.toDo = bestehendeToDos[index];
                }
                else {
                    // Falls die ID ungültig ist, handle den Fehler entsprechend
                    ViewBag.Error = "Ungültige ToDo-ID.";
                    return View("Error"); // Zeige eine Fehlerseite oder Nachricht an
                }

                return View("EditToDo");
            }

            
        }

        [HttpPost]
        public IActionResult UpdateToDo(ToDo toDo) {

            // Lade gespeicherte ToDos
            var bestehendeToDos = _toDoService.LoadToDos();

            int index = toDo.Id - 1; // Da erste Id = 1, in der List jedoch = 0, muss um eins subtrahiert werden

            bestehendeToDos[index] = toDo;
            _toDoService.SaveToDos(bestehendeToDos);

            return RedirectToAction("Index");
        }
    }
}
