using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AFKHastanesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaApiController : ControllerBase
    {
        AppDbContext hastaApiContext = new AppDbContext();

        [HttpGet]
        public IQueryable Get(int hastaId)
        {
            
            var ranedvular = from randevu in hastaApiContext.Randevular
                        join bilimdali in hastaApiContext.BilimDallari on randevu.BilimDaliID equals bilimdali.BilimDaliID
                        join poliklinik in hastaApiContext.Poliklinikler on randevu.PoliklinikID equals poliklinik.PoliklinikID
                        join doktor in hastaApiContext.Doktorlar on randevu.DoktorID equals doktor.DoktorID
                        join randevudurum in hastaApiContext.RandevuDurumlari on randevu.RandevuDurumID equals randevudurum.RandevuDurumID
                        select new
                        {
                            randevu.RandevuTarihi,
                            bilimdali.BilimDaliAdi,
                            poliklinik.PoliklinikAdi,
                            doktor.DoktorAdi,
                            doktor.DoktorSoyadi,
                            randevudurum.RandevuDurumAdi
                        };
            return ranedvular;
        }
    }
}
