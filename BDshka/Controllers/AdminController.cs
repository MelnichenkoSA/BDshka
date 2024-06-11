using Microsoft.AspNetCore.Mvc;
using BDshka.Models;
using BDshka.ViewModels;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BDshka.Controllers
{
    public class AdminController : Controller
    {
        private BDContext db;
        public AdminController(BDContext context)
        {
            db = context;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await db.Clients.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> Remonts()
        {
            return View(await db.Remonts.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> Workers()
        {
            return View(await db.Workers.ToListAsync());
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
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                ClientsModel? user = await db.Clients.FirstOrDefaultAsync(p => p.ID_Client == id);
                if (user != null)
                {
                    db.Clients.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Admin");
                }
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteRemont(int? id)
        {
            if (id != null)
            {
                Order_RemontModel? user = await db.Order_Remont.FirstOrDefaultAsync(p => p.ID_Client == id);
                if (user != null)
                {
                    db.Order_Remont.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("CorzinaRemont", "Home");
                }
            }
            return NotFound();
        }
        [HttpPost]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(Order_MaterialModel model)
        {
            db.Order_Material.Remove(model);
            await db.SaveChangesAsync();
            return RedirectToAction("CorzinaMaterial", "Home");
        }
        [HttpPost]
        [HttpDelete]
        public async Task<IActionResult> DeleteAllRemonts()
        {
            db.Order_Remont.RemoveRange(db.Order_Remont);
            await db.SaveChangesAsync();
            return RedirectToAction("CorzinaRemont", "Home");
        }
        [HttpPost]
        [HttpDelete]
        public async Task<IActionResult> DeleteAllOrderss()
        {
            db.Order_Material.RemoveRange(db.Order_Material);
            db.Material_Nabor.RemoveRange(db.Material_Nabor);
            await db.SaveChangesAsync();
            return RedirectToAction("CorzinaMaterial", "Home");
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

                    return RedirectToAction("Workers", "Admin");
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

                    return RedirectToAction("Remonts", "Admin");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                ClientsModel? user = await db.Clients.FirstOrDefaultAsync(p => p.ID_Client == id);
                if (user != null)
                {
                    db.Clients.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index", "Admin");
                }
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                ClientsModel? user = await db.Clients.FirstOrDefaultAsync(p => p.ID_Client == id);
                if (user != null) return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ClientsModel user)
        {
            ClientsModel? userDB = await db.Clients.FirstOrDefaultAsync(p => p.ID_Client == user.ID_Client);
            userDB.Phone_Number = user.Phone_Number;
            userDB.FIO = user.FIO;
            userDB.ID_Role = user.ID_Role;
            db.Clients.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Admin");
        }
    }
}
