using Meine_Aufgabenliste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Meine_Aufgabenliste.Controllers {
    public class ToDosController : Controller {

        public IActionResult Index() {

            List<ToDo> toDos = new List<ToDo>();

            using (var context = new ApplicationDbContext()) {
                toDos = context.ToDo
                    .Include(t => t.Kategorie)
                    .Include(t => t.Schluesselwort)
                    .Include(t => t.Verantwortlicher)
                    .Include(t => t.Status)
                    .ToList();

                ViewBag.ToDos = toDos;
                ViewBag.Kategorien = context.Kategorie.ToList();
                ViewBag.Schluesselwoerter = context.Schluesselwort.ToList();
                ViewBag.Verantwortliche = context.Verantwortlicher.ToList();
                ViewBag.Status = context.Status.ToList();
                ViewBag.Color = "dark";
            }

            return View();
        }

        public IActionResult ToDos_Offen() {
            string title = "Offene Aufgaben";
            ViewBag.Title = title;

            List<ToDo> toDos = new List<ToDo>();
            List<Verantwortlicher> verantwortliche = new List<Verantwortlicher>();
            List<Status> status = new List<Status>();

            using (var context = new ApplicationDbContext()) {
                toDos = context.ToDo
                       .Include(toDo => toDo.Kategorie)
                       .Include(toDo => toDo.Schluesselwort)
                       .Include(toDo => toDo.Verantwortlicher)
                       .Include(toDo => toDo.Status)
                       .Where(toDo => toDo.Status.Name == "Offen")
                       .ToList();

                // Laden der Verantwortlichen und Status für Dropdowns
                verantwortliche = context.Verantwortlicher.ToList();
                status = context.Status.ToList();
            }

            ViewBag.ToDos = toDos;
            ViewBag.Verantwortliche = verantwortliche;
            ViewBag.Status = status;
            ViewBag.Color = "danger";

            return View("Index");
        }

        public IActionResult ToDos_inBearbeitung() {
            string title = "Aufgaben in Bearbeitung";
            ViewBag.Title = title;

            List<ToDo> toDos = new List<ToDo>();
            List<Verantwortlicher> verantwortliche = new List<Verantwortlicher>();
            List<Status> status = new List<Status>();

            using (var context = new ApplicationDbContext()) {
                toDos = context.ToDo
                       .Include(toDo => toDo.Kategorie)
                       .Include(toDo => toDo.Schluesselwort)
                       .Include(toDo => toDo.Verantwortlicher)
                       .Include(toDo => toDo.Status)
                       .Where(toDo => toDo.Status.Name == "in Bearbeitung")
                       .ToList();

                // Laden der Verantwortlichen und Status für Dropdowns
                verantwortliche = context.Verantwortlicher.ToList();
                status = context.Status.ToList();
            }

            ViewBag.ToDos = toDos;
            ViewBag.Verantwortliche = verantwortliche;
            ViewBag.Status = status;
            ViewBag.Color = "warning";

            return View("Index");
        }

        public IActionResult ToDos_Wartend() {
            string title = "Wartende Aufgaben";
            ViewBag.Title = title;

            List<ToDo> toDos = new List<ToDo>();
            List<Verantwortlicher> verantwortliche = new List<Verantwortlicher>();
            List<Status> status = new List<Status>();

            using (var context = new ApplicationDbContext()) {
                toDos = context.ToDo
                       .Include(toDo => toDo.Kategorie)
                       .Include(toDo => toDo.Schluesselwort)
                       .Include(toDo => toDo.Verantwortlicher)
                       .Include(toDo => toDo.Status)
                       .Where(toDo => toDo.Status.Name == "Wartend")
                       .ToList();

                // Laden der Verantwortlichen und Status für Dropdowns
                verantwortliche = context.Verantwortlicher.ToList();
                status = context.Status.ToList();
            }

            ViewBag.ToDos = toDos;
            ViewBag.Verantwortliche = verantwortliche;
            ViewBag.Status = status;
            ViewBag.Color = "primary";

            return View("Index");
        }

        public IActionResult ToDos_Abgeschlossen() {
            string title = "Abgeschlossene Aufgaben";
            ViewBag.Title = title;

            List<ToDo> toDos = new List<ToDo>();
            List<Verantwortlicher> verantwortliche = new List<Verantwortlicher>();
            List<Status> status = new List<Status>();

            using (var context = new ApplicationDbContext()) {
                toDos = context.ToDo
                       .Include(toDo => toDo.Kategorie)
                       .Include(toDo => toDo.Schluesselwort)
                       .Include(toDo => toDo.Verantwortlicher)
                       .Include(toDo => toDo.Status)
                       .Where(toDo => toDo.Status.Name == "Abgeschlossen")
                       .ToList();

                // Laden der Verantwortlichen und Status für Dropdowns
                verantwortliche = context.Verantwortlicher.ToList();
                status = context.Status.ToList();
            }

            ViewBag.ToDos = toDos;
            ViewBag.Verantwortliche = verantwortliche;
            ViewBag.Status = status;
            ViewBag.Color = "success";

            return View("Index");
        }

        public IActionResult ToDos_Archiv() {
            string title = "Archivierte Aufgaben";
            ViewBag.Title = title;

            List<ToDo> toDos = new List<ToDo>();
            List<Verantwortlicher> verantwortliche = new List<Verantwortlicher>();
            List<Status> status = new List<Status>();

            using (var context = new ApplicationDbContext()) {
                toDos = context.ToDo
                       .Include(toDo => toDo.Kategorie)
                       .Include(toDo => toDo.Schluesselwort)
                       .Include(toDo => toDo.Verantwortlicher)
                       .Include(toDo => toDo.Status)
                       .Where(toDo => toDo.Status.Name == "Archiviert")
                       .ToList();

                // Laden der Verantwortlichen und Status für Dropdowns
                verantwortliche = context.Verantwortlicher.ToList();
                status = context.Status.ToList();
            }

            ViewBag.ToDos = toDos;
            ViewBag.Verantwortliche = verantwortliche;
            ViewBag.Status = status;
            ViewBag.Color = "light";

            return View("Index");
        }

        public IActionResult CreateToDo() {

            List<Kategorie> kategorien = new List<Kategorie>();
            List<Schluesselwort> schluesselwoerter = new List<Schluesselwort>();
            List<Verantwortlicher> verantwortliche = new List<Verantwortlicher>();
            List<Status> status = new List<Status>();
            int nextId = 0; // zum Speichern der nächstfreien Id für neues ToDo

            using (var context = new ApplicationDbContext()) {
                kategorien = context.Kategorie.ToList();
                schluesselwoerter = context.Schluesselwort.ToList();
                verantwortliche = context.Verantwortlicher.ToList();
                status = context.Status.ToList();
                nextId = context.ToDo.Count() + 1;
            }

            ViewBag.Kategorien = kategorien;
            ViewBag.Schluesselwoerter = schluesselwoerter;
            ViewBag.Verantwortliche = verantwortliche;
            ViewBag.Status = status;
            ViewBag.NextId = nextId;

            return View();
        }

        [HttpPost]
        public IActionResult CreateToDo(ToDo toDo) {

            if (!ModelState.IsValid) {
                using (var context = new ApplicationDbContext()) {
                    using (var transaction = context.Database.BeginTransaction()) {
                        try {
                            toDo.Kategorie = context.Kategorie.FirstOrDefault(k => k.Id == toDo.KategorieId);
                            toDo.Schluesselwort = context.Schluesselwort.FirstOrDefault(s => s.Id == toDo.SchluesselwortId);
                            toDo.Verantwortlicher = context.Verantwortlicher.FirstOrDefault(v => v.Id == toDo.VerantwortlicherId);
                            toDo.Status = context.Status.FirstOrDefault(st => st.Id == toDo.StatusId);

                            context.Add(toDo);
                            context.SaveChanges();

                            transaction.Commit();
                        }
                        catch (Exception ex) {
                            transaction.Rollback();
                            ModelState.AddModelError("", "Fehler beim Speichern des ToDos.");

                            // ViewBag-Daten wieder zurückgeben und zur CreateToDo-Maske zurückkehren
                            ViewBag.Kategorien = context.Kategorie.ToList();
                            ViewBag.Schluesselwoerter = context.Schluesselwort.ToList();
                            ViewBag.Verantwortliche = context.Verantwortlicher.ToList();
                            ViewBag.Status = context.Status.ToList();
                            return View("CreateToDo", toDo);
                        }
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditToDo(ToDo? toDo) {

            using (var context = new ApplicationDbContext()) {
                try {
                    toDo = context.ToDo.FirstOrDefault(t => t.Id == toDo.Id);
                    toDo.Kategorie = context.Kategorie.FirstOrDefault(k => k.Id == toDo.Id);
                    toDo.Schluesselwort = context.Schluesselwort.FirstOrDefault(s => s.Id == toDo.Id);
                    toDo.Verantwortlicher = context.Verantwortlicher.FirstOrDefault(v => v.Id == toDo.Id);
                    toDo.Status = context.Status.FirstOrDefault(st => st.Id == toDo.Id);
                    ViewBag.ToDo = toDo;
                    ViewBag.Kategorien = context.Kategorie.ToList();
                    ViewBag.Schluesselwoerter = context.Schluesselwort.ToList();
                    ViewBag.Verantwortliche = context.Verantwortlicher.ToList();
                    ViewBag.Status = context.Status.ToList();
                }
                catch (Exception ex) {
                    ModelState.AddModelError("", "Fehler beim Speichern des ToDos.");
                    return View("Index");
                }
            }
            
            return View("EditToDo");
        }

        [HttpPost]
        public IActionResult UpdateToDo(ToDo toDo) {

            using (var context = new ApplicationDbContext()) {
                 
            }

            return RedirectToAction("Index");
        }

        /*[HttpPost]
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
        }*/
    }
}
