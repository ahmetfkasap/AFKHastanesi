using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AFKHastanesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaApiController : ControllerBase
    {
        AppDbContext homeContext = new AppDbContext();

        [HttpGet]
        public IQueryable Get()
        {
            var query = from doktor in homeContext.Doktorlar
                        join cinsiyet in homeContext.Cinsiyetler on doktor.CinsiyetID equals cinsiyet.CinsiyetID
                        join derece in homeContext.Dereceler on doktor.DereceID equals derece.DereceID
                        join brans in homeContext.Branslar on doktor.BransID equals brans.BransID
                        select new
                        {
                            doktor.DoktorAdi,
                            doktor.DoktorSoyadi,
                            cinsiyet.CinsiyetAdi,
                            doktor.DoktorEmail,
                            brans.BransAdi,
                            derece.DereceAdi
                        };
            return query;
        }
    }
}
