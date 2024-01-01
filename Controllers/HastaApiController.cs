using AFKHastanesi.Models;
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
            
            var randevular = from randevu in hastaApiContext.Randevular.Where(r=>r.KullaniciID==hastaId)
                        join bilimdali in hastaApiContext.BilimDallari on randevu.BilimDaliID equals bilimdali.BilimDaliID
                        join poliklinik in hastaApiContext.Poliklinikler on randevu.PoliklinikID equals poliklinik.PoliklinikID
                        join doktor in hastaApiContext.Doktorlar on randevu.DoktorID equals doktor.DoktorID
                        join randevudurum in hastaApiContext.RandevuDurumlari on randevu.RandevuDurumID equals randevudurum.RandevuDurumID
                        select new
                        {
                            randevu.RandevuID,
                            randevu.RandevuTarihi,
                            bilimdali.BilimDaliAdi,
                            poliklinik.PoliklinikAdi,
                            doktor.DoktorAdi,
                            doktor.DoktorSoyadi,
                            randevudurum.RandevuDurumAdi
                        };
            return randevular;
        }

        
        [HttpPost]
        public void Post(string hastaEmail,string hastaSifre,string email)
        {
            
            var kullaniciCookie = hastaApiContext.Kullanicilar.SingleOrDefault(x => x.KullaniciEmail == email);

            var entityToUpdate = hastaApiContext.Kullanicilar.SingleOrDefault(e => e.KullaniciID == kullaniciCookie.KullaniciID);

            // Veriyi güncelle
            if (entityToUpdate != null)
            {
                entityToUpdate.KullaniciEmail = hastaEmail;
                entityToUpdate.KullaniciSifre=hastaSifre;

            }

            // Veritabanını güncelle
            hastaApiContext.SaveChanges();
        }

        [HttpPut]
        public void Put(int randevuId, int hastaId)
        {

            var entityToUpdate = hastaApiContext.Randevular.SingleOrDefault(e => e.RandevuID == randevuId);

            // Veriyi güncelle
            if (entityToUpdate != null)
            {
                entityToUpdate.KullaniciID =hastaId ;
                entityToUpdate.RandevuDurumID = 3;
                
            }

            // Veritabanını güncelle
            hastaApiContext.SaveChanges();

        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // LINQ sorgusu ile veriyi getir
            var entityToUpdate = hastaApiContext.Randevular.SingleOrDefault(e => e.RandevuID == id);
           
            // Veriyi güncelle
            if (entityToUpdate != null)
            {
                entityToUpdate.RandevuDurumID = 1;
            }
            hastaApiContext.SaveChanges();
        }
    }
}
