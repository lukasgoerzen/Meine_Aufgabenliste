using Meine_Aufgabenliste.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Meine_Aufgabenliste.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*
        [HttpGet]
        public IActionResult ShowResults(string suchbegriff) {
            // Lade alle gespeicherten ToDos
            var bestehendeToDos = _toDoService.LoadToDos();

            List<ToDo> ergebnisse = _toDoService.SearchToDos(bestehendeToDos, suchbegriff);
            ViewBag.ToDos = ergebnisse;

            ViewBag.Suchebegriff = suchbegriff;
            return View("Results");
        }
        */
    }
}
