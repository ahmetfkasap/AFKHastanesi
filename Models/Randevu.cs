using System.ComponentModel.DataAnnotations;

namespace AFKHastanesi.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }
        public int KullaniciID { get; set; }
        public int BilimDaliID { get; set; }
        public int PoliklinikID { get; set; }
        public int DoktorID { get; set; }
        public int RandevuDurumID { get; set; }
        public DateTime RandevuTarihi {  get; set; }
    }
}
