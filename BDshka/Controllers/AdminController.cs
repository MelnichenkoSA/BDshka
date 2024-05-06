using Microsoft.AspNetCore.Mvc;

namespace BDshka.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
