using Meine_Aufgabenliste.Models;
using Meine_Aufgabenliste.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Meine_Aufgabenliste.Controllers {
    public class AdminController : Controller {
        /*
            private readonly ApplicationDbContext _context;

            public AdminController(ApplicationDbContext context) {
                _context = context;
            }
        */

        public IActionResult BenutzerVerwaltung() {

            return View("Benutzer/Verwaltung");
        }

        public IActionResult KategorienVerwaltung() {

            List<Kategorie> kategorien = new List<Kategorie>();

            using (var context = new ApplicationDbContext()) {
                if (context.Kategorie != null) {
                    kategorien = context.Kategorie.ToList();
                }
            }

            ViewBag.Kategorien = kategorien;

            return View("Kategorien/Verwaltung");
        }

        [HttpPost]
        public IActionResult ErstelleKategorie(Kategorie kategorie) {

            using (var context = new ApplicationDbContext()) {
                if (ModelState.IsValid) {
                    context.Add(kategorie);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("KategorienVerwaltung");
        }

        public IActionResult SchluesselwoerterVerwaltung() {

            /*
                List<Schluesselwort> schluesselwoerter = new List<Schluesselwort>();
                List<Kategorie> kategorien = new List<Kategorie>();

                using (var context = new ApplicationDbContext()) {
                    if (context.Schluesselwort != null) {
                        schluesselwoerter = context.Schluesselwort.ToList();
                        kategorien = context.Kategorie.ToList();
                    }


                    var viewModel = new SchluesselwortViewModel {
                        Schluesselwort = schluesselwoerter,
                        Kategorie = kategorien
                    };

                    ViewBag.SchluesselwortViewModel = viewModel;
                }
            */
            List<Kategorie> kategorien = new List<Kategorie>();
            using (var context = new ApplicationDbContext()) {
                kategorien = context.Kategorie.ToList();
            }
            ViewBag.Kategorien = kategorien;

            List<Schluesselwort> schluesselwoerter = new List<Schluesselwort>();
            using (var context = new ApplicationDbContext()) {
                schluesselwoerter = context.Schluesselwort.ToList();
            }
            ViewBag.Schluesselwoerter = schluesselwoerter;

            return View("Schluesselwoerter/Verwaltung");
        }
    

        [HttpPost]
        public IActionResult ErstelleSchluesselwort(Schluesselwort schluesselwort) {

            using (var context = new ApplicationDbContext()) {
                using (var transaction = context.Database.BeginTransaction()) {
                    try {
                        schluesselwort.Kategorie = context.Kategorie.FirstOrDefault(k => k.Id == schluesselwort.KategorieId);

                        context.Add(schluesselwort);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex) {
                        transaction.Rollback();
                        ModelState.AddModelError("", "Fehler beim Speichern des Schluesselworts.");

                        return View("Schluesselwoerter/Verwaltung");
                    }
                }
            }
            
            return RedirectToAction("SchluesselwoerterVerwaltung");
        }

        public IActionResult VerantwortlicheVerwaltung() {

            return View("Verantwortliche/Verwaltung");
        }

        public IActionResult StatusVerwaltung() {

            return View("Status/Verwaltung");
        }
    }
}
