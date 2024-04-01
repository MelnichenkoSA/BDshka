using BDshka.Models;
using BDshka.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Autorization()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autorization(SecurityModel auto)
        {
            auto.Pass_word = auto.Code(auto.Log_in + auto.Pass_word);
            if (db.Find(auto.Log_in, auto.Pass_word))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Autorization");
            }
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Clients.ToListAsync());
        }
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(SecurityModel sec)
        {
            sec.Pass_word = sec.Code(sec.Log_in + sec.Pass_word);
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
        }

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
