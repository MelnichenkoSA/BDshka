using Microsoft.AspNetCore.Mvc;
using BDshka.Models;
using BDshka.ViewModels;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using System.Text;

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
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorker(WorkersModel model)
        {

            if (ModelState.IsValid)
            {
                WorkersModel sec = await db.Workers.FirstOrDefaultAsync(u => u.ID_Worker == model.ID_Worker && u.FIO == model.FIO && u.Oklad == model.Oklad);
                if (sec == null)
                {
                    var item = new WorkersModel();
                    item.ID_Worker = model.ID_Worker;
                    item.FIO = model.FIO;
                    item.Oklad = model.Oklad;
                    db.Workers.Add(item);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Workers", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRemont(RemontsModel model)
        {

            if (ModelState.IsValid)
            {
                RemontsModel sec = await db.Remonts.FirstOrDefaultAsync(u => u.ID_Remont == model.ID_Remont && u.Title == model.Title && u.ID_Spec == model.ID_Spec && u.Cost == model.Cost);
                if (sec == null)
                {
                    var item = new RemontsModel();
                    item.ID_Remont = model.ID_Remont;
                    item.Title = model.Title;
                    item.Cost = model.Cost;
                    item.ID_Spec = model.ID_Spec;
                    // добавляем пользователя в бд
                    db.Remonts.Add(item);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Remonts", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
    }
}
