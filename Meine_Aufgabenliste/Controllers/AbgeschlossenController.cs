using Microsoft.AspNetCore.Mvc;

namespace Meine_Aufgabenliste.Controllers {
    public class AbgeschlossenController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
