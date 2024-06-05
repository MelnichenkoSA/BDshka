using BDshka.Models;
using BDshka.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BDshka.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        BDContext db;
        public HomeController(BDContext context)
        {
            db = context;
            
        }
        /*public IActionResult Autorization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autorization(SecurityModel auto)
        {
            SHA256 MD5Hash = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(auto.Log_in + auto.Pass_word);
            byte[] hash = MD5Hash.ComputeHash(inputBytes);
            auto.Pass_word = Convert.ToHexString(hash);

            if (db.Find(auto.Log_in, auto.Pass_word))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Autorization");
            }
        }*/
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
        public async Task<IActionResult> Materials()
        {
            return View(await db.Book_of_Material.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> CorzinaRemont()
        {
            return View(await db.Order_Remont.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> CorzinaMaterial()
        {
            return View(await db.Order_Material.ToListAsync());
        }
        [Authorize]
        public async Task<IActionResult> MaterialNabor(int id)
        {
            var result = db.Material_Nabor.Where(u => u.ID_Order == id);
            if(result != null) 
            {
                return View(result);
            }
            return RedirectToAction("CorzinaMaterial", "Home");
        }

        /*public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(SecurityModel sec)
        {
            SHA256 MD5Hash = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(sec.Log_in + sec.Pass_word);
            byte[] hash = MD5Hash.ComputeHash(inputBytes);
            sec.Pass_word = Convert.ToHexString(hash);
            db.Secur.Add(sec);
            await db.SaveChangesAsync();
            return RedirectToAction("PostRegistration");
        }
        public IActionResult PostRegistration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostRegistration(ClientsModel client)
        {
            db.Clients.Add(client);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }*/

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
