using AFKHastanesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AFKHastanesi.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DoktorEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoktorEkle(Doktor doktor)
        {
            return View();
        }

        [HttpGet]
        public IActionResult PoliklinikEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PoliklinikEkle(Poliklinik poliklinik)
        {
            return View();
        }

        [HttpGet]
        public IActionResult DoktorListele()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PoliklinikListele()
        {
            return View();
        }
    }
}
