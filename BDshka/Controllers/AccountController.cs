using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using BDshka.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System.Text;
using System.Security.Cryptography;

namespace BDshka.Controllers
{
    public class AccountController : Controller
    {
        private BDContext db;
        public AccountController(BDContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Autorization()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Autorization(ClientsModel model)
        {
            SHA256 Hash = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(model.Log_in + model.Pass_word);
            byte[] hash = Hash.ComputeHash(inputBytes);
            model.Pass_word = Convert.ToHexString(hash);

            if (ModelState.IsValid)
            {
                ClientsModel sec = await db.Clients.FirstOrDefaultAsync(u => u.ID_Client == model.ID_Client && u.Log_in == model.Log_in && u.Pass_word == model.Pass_word && u.FIO == model.FIO && u.Phone_Number == model.Phone_Number && u.ID_Role == model.ID_Role);
                if (sec != null)
                {
                    await Authenticate(model.Log_in); // аутентификация
                    
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(ClientsModel model)
        {

            SHA256 Hash = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(model.Log_in + model.Pass_word);
            byte[] hash = Hash.ComputeHash(inputBytes);
            model.Pass_word = Convert.ToHexString(hash);

            if (ModelState.IsValid && !db.Find(model.Log_in))
            {
                ClientsModel sec = await db.Clients.FirstOrDefaultAsync(u => u.ID_Client == model.ID_Client && u.Log_in == model.Log_in && u.Pass_word == model.Pass_word && u.FIO == model.FIO && u.Phone_Number == model.Phone_Number && u.ID_Role == model.ID_Role);
                if (sec == null)
                {
                    // добавляем пользователя в бд
                    db.Clients.Add(new ClientsModel { ID_Client = model.ID_Client, FIO = model.FIO, Phone_Number = model.Phone_Number, ID_Role = 1, Pass_word = model.Pass_word, Log_in = model.Log_in});
                    await db.SaveChangesAsync();

                    await Authenticate(model.Log_in); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            ModelState.AddModelError("", "");
            return View(model); 
        }
        /*public async Task<IActionResult> PostRegistration(ClientsModel model)
        {
            if (ModelState.IsValid)
            {
                ClientsModel client = await db.Clients.FirstOrDefaultAsync(u => u.ID_Client == model.ID_Client && u.FIO == model.FIO && u.Phone_Number == model.Phone_Number && u.ID_Role == model.ID_Role);
                if (client == null)
                {
                    // добавляем пользователя в бд
                    db.Clients.Add(new ClientsModel { ID_Client = model.ID_Client, FIO = model.FIO, Phone_Number = model.Phone_Number, ID_Role = 1 });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Phone_Number); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model); ;
        }*/
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
                    return RedirectToAction("Index","Home");
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

            //db.Clients.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string login)
        {
            if (db.Find(login))
                return Json(false);
            return Json(true);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Autorization", "Account");
        }
    }
}
