using Microsoft.AspNetCore.Mvc;

namespace Meine_Aufgabenliste.Controllers {
    public class InBearbeitungController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
