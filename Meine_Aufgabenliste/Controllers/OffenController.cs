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

        public IActionResult CreateEditToDo(int? id) {

            // Lade gespeicherte ToDos
            var bestehendeToDos = _toDoService.LoadToDos();

            // Erstelle neues ToDo
            if (id == null) {
                int neueId = bestehendeToDos.Count + 1; // Id für neues ToDo
                ViewBag.NeueId = neueId;
                return View("CreateToDo");
            }

            // Bearbeite ausgewähltes ToDo
            else {
				var toDo = bestehendeToDos.FirstOrDefault(t => t.Id == id);

				if (toDo == null) {
					ViewBag.Error = "Ungültige ToDo-ID.";
					return View("Error");
				}

				ViewBag.ToDo = toDo;
				return View("EditToDo");
			}
        }

        [HttpPost]
        public IActionResult UpdateToDo(ToDo toDo) {

            // Lade gespeicherte ToDos
            var bestehendeToDos = _toDoService.LoadToDos();

            int index = toDo.Id - 1; // Da erste Id = 1, in der List jedoch = 0, muss um eins subtrahiert werden

			if (index <= -1) {
				ViewBag.Error = "Ungültige ToDo-ID.";
				return View("Error");
			}

			bestehendeToDos[index] = toDo;
            _toDoService.SaveToDos(bestehendeToDos);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddUpdateToDo(ToDo toDo) {

            // Lade gespeicherte ToDos
            var bestehendeToDos = _toDoService.LoadToDos();

            int index = toDo.Id - 1; // Da erste Id = 1, in der List jedoch = 0, muss um eins subtrahiert werden

            // Neues ToDo erstellen
            if (bestehendeToDos[index] == null) {
                // Hinzufügen der neuen ToDos
                bestehendeToDos.Add(toDo);

                // Speicher aktualisierte Liste in JSON-Datei
                _toDoService.SaveToDos(bestehendeToDos);
            }

            // Bestehendes ToDo ändern
            else {
                bestehendeToDos[index] = toDo;
                _toDoService.SaveToDos(bestehendeToDos);
            }

            return RedirectToAction("Index");
        }
    }
}
