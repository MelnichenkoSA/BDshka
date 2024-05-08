using Microsoft.AspNetCore.Mvc;

namespace BDshka.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Delete()
        {
            db.Clients.remove();
            return RedirectToAction(Index,Home);
        }
        public IActionResult AddWorker()
        {
            db.Workers.Add();
            return RedirectToAction(Index,Home);
        }
        public IActionResult AddRemont()
        {
            db.Remonts.Add();
            return RedirectToAction(Index,Home);
        }
    }
}
