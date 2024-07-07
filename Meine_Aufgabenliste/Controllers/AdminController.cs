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
                        //schluesselwort.Kategorie = context.Kategorie.FirstOrDefault(k => k.Id == schluesselwort.KategorieId);

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

            List<Verantwortlicher> verantwortliche = new List<Verantwortlicher>();

            using (var context = new ApplicationDbContext()) {
                if (context.Verantwortlicher != null) {
                    verantwortliche = context.Verantwortlicher.ToList();
                }
                else {
                    Console.WriteLine("DbSet<Verantwortlicher> is null");
                }
            }

            ViewBag.Verantwortliche = verantwortliche;

            return View("Verantwortliche/Verwaltung");
        }

        [HttpPost]
        public IActionResult ErstelleVerantwortlicher(Verantwortlicher verantwortlicher) {

            using (var context = new ApplicationDbContext()) {
                if (ModelState.IsValid) {
                    context.Add(verantwortlicher);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("VerantwortlicheVerwaltung");
        }

        public IActionResult StatusVerwaltung() {

            List<Status> status = new List<Status>();

            using (var context = new ApplicationDbContext()) {
                if (context.Status != null) {
                    status = context.Status.ToList();
                }
            }

            ViewBag.Status = status;

            return View("Status/Verwaltung");
        }

        [HttpPost]
        public IActionResult ErstelleStatus(Status status) {

            using (var context = new ApplicationDbContext()) {
                if (ModelState.IsValid) {
                    context.Add(status);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("StatusVerwaltung");
        }
    }
}
