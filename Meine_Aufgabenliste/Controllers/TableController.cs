using Microsoft.AspNetCore.Mvc;

namespace Meine_Aufgabenliste.Controllers {
    public class TableController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEditTodo() {
            return View();
        }
    }
}
