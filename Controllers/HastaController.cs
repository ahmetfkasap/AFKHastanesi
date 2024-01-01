using AFKHastanesi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace AFKHastanesi.Controllers
{
    class RandevuTemsili
    {
        public DateTime RandevuTarihi { get; set; }
        public int RandevuID {  get; set; }
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
        Uri baseAddress = new Uri("https://localhost:7201/Api");
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

            List<RandevuTemsili> randevular = new List<RandevuTemsili>();
            HttpResponseMessage httpResponseMessage = _client.GetAsync(_client.BaseAddress + "/HastaApi?&hastaId=" + hastaId).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                randevular = JsonConvert.DeserializeObject<List<RandevuTemsili>>(data);
            }

            ViewBag.KullaniciAdi = hastaContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciAdi;
            ViewBag.KullaniciSoyadi = hastaContext.Kullanicilar.SingleOrDefault(u => u.KullaniciEmail == email).KullaniciSoyadi;
            ViewBag.Randevular = randevular;

            return View();
        }

        [HttpGet]
        public IActionResult RandevuAl()
        {

            List<BilimDali> bilimDalis = new List<BilimDali>();
            bilimDalis = hastaContext.BilimDallari.ToList();

            ViewBag.BilimDallari = new List<SelectListItem>();

            foreach (var item in bilimDalis)
            {
                ViewBag.BilimDallari.Add(new SelectListItem { Value = item.BilimDaliID.ToString(), Text = item.BilimDaliAdi });
            }
            return View();
        }

        [HttpPost]
        public IActionResult RandevuListele(Randevu randevuGelen)
        {
            
            var randevular = from randevu in hastaContext.Randevular.Where(r => r.BilimDaliID == randevuGelen.BilimDaliID &&(r.RandevuDurumID==1||r.RandevuDurumID==4))
                             join bilimdali in hastaContext.BilimDallari on randevu.BilimDaliID equals bilimdali.BilimDaliID
                             join poliklinik in hastaContext.Poliklinikler on randevu.PoliklinikID equals poliklinik.PoliklinikID
                             join doktor in hastaContext.Doktorlar on randevu.DoktorID equals doktor.DoktorID
                             join randevudurum in hastaContext.RandevuDurumlari on randevu.RandevuDurumID equals randevudurum.RandevuDurumID
                             select new RandevuTemsili
                             {
                                 RandevuID = randevu.RandevuID,
                                 RandevuTarihi = randevu.RandevuTarihi,
                                 BilimDaliAdi = bilimdali.BilimDaliAdi,
                                 PoliklinikAdi = poliklinik.PoliklinikAdi,
                                 DoktorAdi = doktor.DoktorAdi,
                                 DoktorSoyadi = doktor.DoktorSoyadi,
                                 RandevuDurumAdi = randevudurum.RandevuDurumAdi
                             };

            List<RandevuTemsili> randevuTemsilis = new List<RandevuTemsili>();

            foreach (var item in randevular)
            {
                if (item.RandevuTarihi.ToShortDateString()==randevuGelen.RandevuTarihi.ToShortDateString())
                {
                    
                    randevuTemsilis.Add(item);
                }
            }
          

            ViewBag.Randevular = randevuTemsilis;
            return View("RandevuListele");
        }

        [HttpPost]
        public IActionResult RandevuAl(int id)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var kullanıcı = hastaContext.Kullanicilar.SingleOrDefault(x => x.KullaniciEmail == email).KullaniciID;

            HttpResponseMessage httpResponseMessage = _client.PutAsync(_client.BaseAddress + "/HastaApi?&randevuId=" + id+"&hastaId="+kullanıcı, null).Result;
            return RedirectToAction("Randevular");
        }

        [HttpPost]
        public IActionResult RandevuSil(int id)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;

            HttpResponseMessage httpResponseMessage = _client.DeleteAsync(_client.BaseAddress + "/HastaApi/" + id).Result;
            return RedirectToAction("Randevular");
        }

        [HttpGet]
        public IActionResult HastaBilgileri()
        {
            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var kullanici = hastaContext.Kullanicilar.SingleOrDefault(x => x.KullaniciEmail == email);

            ViewBag.Kullanici = kullanici;
            return View();
        }

        [HttpPost]
        public IActionResult HastaGuncelle(Kullanici kullanici)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            string email = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            
            HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/HastaApi?&hastaEmail="+kullanici.KullaniciEmail+ "&hastaSifre="+kullanici.KullaniciSifre+"&email="+email, null).Result;

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
