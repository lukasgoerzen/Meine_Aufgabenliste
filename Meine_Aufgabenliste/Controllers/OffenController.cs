using Microsoft.AspNetCore.Mvc;

namespace Meine_Aufgabenliste.Controllers {
    public class OffenController : Controller {
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTodo(int id) {
            if (id == 0) {
                return View();
            }

            else {
                return View("Index");
            }
        }
    }
}
