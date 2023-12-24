using System.ComponentModel.DataAnnotations;

namespace AFKHastanesi.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorID { get; set; }
        public string DoktorAdi { get; set; }
        public string DoktorSoyadi { get; set; }
        public int BilimDaliID { get; set; }
        public ICollection<Poliklinik> Poliklinikler { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
    }
}
