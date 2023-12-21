using System.ComponentModel.DataAnnotations;

namespace AFKHastanesi.Models
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }
        
        public string KullaniciAdi { get; set; }
        
        public string KullaniciSoyadi { get; set; }
               
        public string KullaniciEmail { get; set; }
  
        public string KullaniciSifre { get; set; }
        public ICollection<Rol> Roller { get; set; }
    }
}
