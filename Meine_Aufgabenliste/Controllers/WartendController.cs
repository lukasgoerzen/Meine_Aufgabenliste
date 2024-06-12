using Microsoft.AspNetCore.Mvc;

namespace Meine_Aufgabenliste.Controllers {
    public class WartendController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
