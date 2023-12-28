using AFKHastanesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AFKHastanesi.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        AppDbContext appDbContext= new AppDbContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DoktorEkle()
        {
            if (TempData.ContainsKey("HataMsg"))
            {
                ViewBag.HataMsg = TempData["HataMsg"];
            }

            List<BilimDali> bilimDalis = new List<BilimDali>();
            bilimDalis = appDbContext.BilimDallari.ToList();

            ViewBag.BilimDallari = new List<SelectListItem>();

            foreach (var item in bilimDalis)
            {
                ViewBag.BilimDallari.Add(new SelectListItem { Value = item.BilimDaliID.ToString(), Text = item.BilimDaliAdi });
            }

            return View();
        }

        [HttpPost]
        public IActionResult DoktorEkle(Doktor doktor)
        {
            bool doktorVarMi = appDbContext.Doktorlar.Any(d => (d.DoktorAdi == doktor.DoktorAdi && d.DoktorSoyadi == doktor.DoktorSoyadi));

            if (doktorVarMi)
            {
                TempData["HataMsg"] = "Girdiğiniz Doktor Sistemde Bulunmaktadır !!!";
                return RedirectToAction("DoktorEkle", ViewBag.HataMsg);
            }

            appDbContext.Doktorlar.Add(doktor); 
            appDbContext.SaveChanges();

            return RedirectToAction("DoktorListele");
        }

        [HttpPost]
        public IActionResult DoktorSil(int id)
        {
            var deleteDoktor = appDbContext.Doktorlar.SingleOrDefault(e => e.DoktorID == id);

            // Veriyi güncelle
            if (deleteDoktor != null)
            {
                appDbContext.Doktorlar.Remove(deleteDoktor);
            }
            appDbContext.SaveChanges();
            return RedirectToAction("DoktorListele");
        }

        [HttpGet]
        public IActionResult PoliklinikEkle()
        {
            if (TempData.ContainsKey("HataMsg"))
            {
                ViewBag.HataMsg = TempData["HataMsg"];
            }

            List<BilimDali> bilimDalis = new List<BilimDali>();
            bilimDalis = appDbContext.BilimDallari.ToList();

            ViewBag.BilimDallari = new List<SelectListItem>();

            foreach (var item in bilimDalis)
            {
                ViewBag.BilimDallari.Add(new SelectListItem { Value = item.BilimDaliID.ToString(), Text = item.BilimDaliAdi });
            }
            return View();
        }

        [HttpPost]
        public IActionResult PoliklinikEkle(Poliklinik poliklinik)
        {

            bool poliklinikVarMi = appDbContext.Poliklinikler.Any(p => (p.PoliklinikAdi == poliklinik.PoliklinikAdi && p.BilimDaliID == poliklinik.BilimDaliID));

            if (poliklinikVarMi)
            {
                TempData["HataMsg"] = "Girdiğiniz Doktor Sistemde Bulunmaktadır !!!";
                return RedirectToAction("PoliklinikEkle", ViewBag.HataMsg);
            }

            appDbContext.Poliklinikler.Add(poliklinik);
            appDbContext.SaveChanges();

            return RedirectToAction("DoktorListele");
        }

        [HttpPost]
        public IActionResult PoliklinikSil(int id)
        {
            var deletePoliklinik = appDbContext.Poliklinikler.SingleOrDefault(e => e.PoliklinikID == id);

            // Veriyi güncelle
            if (deletePoliklinik != null)
            {
                appDbContext.Poliklinikler.Remove(deletePoliklinik);
            }
            appDbContext.SaveChanges();
            return RedirectToAction("BilimDalListele");
        }

        [HttpGet]
        public IActionResult BilimDaliEkle()
        {
            if (TempData.ContainsKey("HataMsg"))
            {
                ViewBag.HataMsg = TempData["HataMsg"];
            }
            return View();
        }

        [HttpPost]
        public IActionResult BilimDaliEkle(BilimDali bilimDali)
        {
            bool bilimDaliKontrol = appDbContext.BilimDallari.Any(d => d.BilimDaliAdi == bilimDali.BilimDaliAdi);

            if (bilimDaliKontrol)
            {
                TempData["HataMsg"] = "Girdiğiniz Bilim Dalı Sistemde Bulunmaktadır !!!";
                return RedirectToAction("BilimDaliEkle", ViewBag.HataMsg);
            }

            appDbContext.BilimDallari.Add(bilimDali);
            appDbContext.SaveChanges();

            return RedirectToAction("BilimDaliListele");
        }

        [HttpPost]
        public IActionResult BilimDaliSil(int id)
        {
            var deleteBilimDali = appDbContext.BilimDallari.SingleOrDefault(e => e.BilimDaliID == id);

            // Veriyi güncelle
            if (deleteBilimDali != null)
            {
                appDbContext.BilimDallari.Remove(deleteBilimDali);
            }
            appDbContext.SaveChanges();
            return RedirectToAction("BilimDaliListele");
        }

        [HttpGet]
        public IActionResult BilimDaliListele()
        {
            var bilimdallari = appDbContext.BilimDallari.ToList();
            ViewBag.BilimDallari=bilimdallari;
            return View();
        }

        [HttpGet]
        public IActionResult DoktorListele()
        {

            var doktorlar = from doktor in appDbContext.Doktorlar
                        join bilimdali in appDbContext.BilimDallari on doktor.BilimDaliID equals bilimdali.BilimDaliID
                        
                        select new VM_Doktor
                        {
                            DoktorID=doktor.DoktorID,
                            DoktorAdi= doktor.DoktorAdi,
                            DoktorSoyadi=doktor.DoktorSoyadi,
                            BilimDaliID=bilimdali.BilimDaliAdi
                        };

            ViewBag.Doktorlar = doktorlar.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult PoliklinikListele()
        {
            var poliklinikler = from poliklinik in appDbContext.Poliklinikler
                            join bilimdali in appDbContext.BilimDallari on poliklinik.BilimDaliID equals bilimdali.BilimDaliID
                            join doktor in appDbContext.Doktorlar on poliklinik.DoktorID equals doktor.DoktorID
                            select new VM_Poliklinik
                            {
                                PoliklinikID=poliklinik.PoliklinikID,
                                PoliklinikAdi=poliklinik.PoliklinikAdi,
                                BilimDaliID=bilimdali.BilimDaliAdi,
                                DoktorID=doktor.DoktorAdi+" "+doktor.DoktorSoyadi
                            };
            ViewBag.Poliklinikler= poliklinikler.ToList();

            return View();
        }

        [HttpGet]
        public IActionResult GetDoktorlar(int bilimDaliId)
        {
            Console.WriteLine(  "girdi");
            var doktorlar =appDbContext.Doktorlar.Where(d=>d.BilimDaliID==bilimDaliId);

            // Doktorları SelectListItem listesine dönüştürün
            var doktorList = doktorlar.Select(d => new SelectListItem { Value = d.DoktorID.ToString(), Text = d.DoktorAdi }).ToList();
            List<Doktor> doktors = new List<Doktor>();
            doktors = appDbContext.Doktorlar.ToList();

            return Json(doktors);
        }

        
    }
}
