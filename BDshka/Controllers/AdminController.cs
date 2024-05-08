using Microsoft.AspNetCore.Mvc;
using BDshka.Models;
using BDshka.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace BDshka.Controllers
{
    public class AdminController : Controller
    {
        private BDContext db;
        public AdminController(BDContext context)
        {
            db = context;
        }
        public IActionResult AddWorker()
        {
            return View();
        }
        public IActionResult AddRemont()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        [HttpDelete]
        public IActionResult Delete(DeleteModel model)
        {
            db.Clients.Remove(model.Client);
            db.Secur.Remove(model.Security);
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public IActionResult AddWorker(WorkersModel model)
        {
            db.Workers.Add(model);
            return RedirectToAction("Workers", "Home");
        }
        [HttpPost]
        public IActionResult AddRemont(RemontsModel model)
        {
            db.Remonts.Add(model);
            return RedirectToAction("Remonts", "Home");
        }
    }
}
