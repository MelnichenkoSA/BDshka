﻿using BDshka.Models;
using BDshka.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BDshka.Controllers
{
    public class AccountController : Controller
    {
        private DateTime Today = new DateTime();
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
        public async Task<IActionResult> Autorization(AutorizationModel model)
        {
            if (ModelState.IsValid)
            {
                SHA256 Hash = SHA256.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(model.Log_in + model.Pass_word);
                byte[] hash = Hash.ComputeHash(inputBytes);
                model.Pass_word = Convert.ToHexString(hash);

                ClientsModel sec = await db.Clients.FirstOrDefaultAsync(u => u.Log_in == model.Log_in && u.Pass_word == model.Pass_word);
                if (sec != null)
                {
                    await Authenticate(sec);
                    if (sec.ID_Role == 1)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    if (sec.ID_Role == 3)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
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
                ClientsModel sec = await db.Clients.FirstOrDefaultAsync(u => u.Log_in == model.Log_in && u.Pass_word == model.Pass_word && u.FIO == model.FIO && u.Phone_Number == model.Phone_Number && u.ID_Role == model.ID_Role);
                if (sec == null)
                {
                    db.Clients.Add(new ClientsModel { FIO = model.FIO, Phone_Number = model.Phone_Number, ID_Role = 1, Pass_word = model.Pass_word, Log_in = model.Log_in });
                    await db.SaveChangesAsync();

                    var a = db.Clients.OrderBy(u => u.ID_Client).First().ID_Client;

                    await Authenticate(db.Clients.OrderBy(u => u.ID_Client).Last());

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            ModelState.AddModelError("", "");
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
                    return RedirectToAction("Index", "Home");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddtoCorzinaRemont(int id)
        {

            if (id != null)
            {
                db.Order_Remont.Add(new Order_RemontModel { ID_Remont = id, ID_Client = Convert.ToInt32(User.FindFirst("ID").Value), Date_Order = Today, ID_Stat = 1 });
                await db.SaveChangesAsync();
                return RedirectToAction("CorzinaRemont", "Home");

            }
            return NotFound();
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> AddtoNaborMaterial(int id, List<int> kolvo, List<int> IsChoosen)
        {
            var a = 0;
            Order_MaterialModel order = new Order_MaterialModel { ID_Client = Convert.ToInt32(User.FindFirst("ID").Value), Date_Order = Today, ID_Stat = 1 };
            db.Order_Material.Add(order);
            await db.SaveChangesAsync();

            a = db.Order_Material.OrderBy(u => u.ID_Order).Last().ID_Order;

            foreach (int item in IsChoosen)
            {
                db.Material_Nabor.Add(new Material_NaborModel { ID_Material = item, ID_Order = a, Kol_vo = kolvo[item - 1] });
            }
            await db.SaveChangesAsync();
            return RedirectToAction("CorzinaMaterial", "Home");
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

            await db.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }



        private async Task Authenticate(ClientsModel Client)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, Client.Log_in),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, Client.ID_Role.ToString()),
                new Claim("ID", Client.ID_Client.ToString()),
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Autorization", "Account");
        }
    }
}
