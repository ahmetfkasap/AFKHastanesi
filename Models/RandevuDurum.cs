using System.ComponentModel.DataAnnotations;

namespace AFKHastanesi.Models
{
    public class RandevuDurum
    {
        [Key]
        public int RandevuDurumID { get; set; }
        public string RandevuDurumAdi { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
    }
}
