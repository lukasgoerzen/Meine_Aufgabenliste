using Microsoft.AspNetCore.Mvc;

namespace Meine_Aufgabenliste.Controllers {
    public class ArchivController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
