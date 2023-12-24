using AFKHastanesi.Models;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace AFKHastanesi.Controllers
{
    class RandevuTemsili
    {
        public DateTime RandevuTarihi { get; set; }
        public string PoliklinikAdi { get; set; }
        public string DoktorAdi { get; set; }
        public string DoktorSoyadi { get; set; }
        public string RandevuDurumAdi { get; set; }
        public string BilimDaliAdi { get; set; }

    }

    [Authorize]
    public class HastaController : Controller
    {
        AppDbContext hastaContext = new AppDbContext();
        Uri baseAddress = new Uri("https://localhost:7178/Api");
        HttpClient _client;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Randevular()
        {
            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var hastaId = hastaContext.Kullanicilar.SingleOrDefault(k => k.KullaniciEmail == email).KullaniciID;

            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

            List<RandevuTemsili> randevularlar = new List<RandevuTemsili>();
            HttpResponseMessage httpResponseMessage = _client.GetAsync(_client.BaseAddress + "/HastaApi?&hastaId=" + hastaId).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                randevularlar = JsonConvert.DeserializeObject<List<RandevuTemsili>>(data);
            }

            ViewBag.KullaniciAdi = hastaContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciAdi;
            ViewBag.KullaniciSoyadi = hastaContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciSoyadi;
            ViewBag.Randevular = randevularlar;

            return View();
        }

        [HttpGet]
        public IActionResult GetRandevuAl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostRandevuAl()
        {
            return View();
        }
    }
}
