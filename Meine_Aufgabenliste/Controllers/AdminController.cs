using Meine_Aufgabenliste.Models;
using Meine_Aufgabenliste.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Meine_Aufgabenliste.Controllers {
    public class AdminController : Controller {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult BenutzerVerwaltung() {

            return View("Benutzer/Verwaltung");
        }

        public IActionResult KategorienVerwaltung() {

            var kategorien = _context.Kategorie.ToList();
            return View("Kategorien/Verwaltung", kategorien);
        }

        [HttpPost]
        public IActionResult ErstelleKategorie(Kategorie kategorie) {

            if (ModelState.IsValid) {
                _context.Kategorie.Add(kategorie);
                _context.SaveChanges();
                return RedirectToAction("KategorienVerwaltung");
            }
            return RedirectToAction("KategorienVerwaltung", kategorie);
        }

        public IActionResult SchluesselwoerterVerwaltung() {

            var schluesselwoerter = _context.Schluesselwort.Include(s => s.Kategorie).ToList();
            return View("Schluesselwoerter/Verwaltung", schluesselwoerter);
        }

        [HttpPost]
        public IActionResult ErstelleSchluesselwort(Schluesselwort schluesselwort) {

            using (var context = _context) {
                context.Add(schluesselwort);
                context.SaveChanges();
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
