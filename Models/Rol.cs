using System.ComponentModel.DataAnnotations;

namespace AFKHastanesi.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        public int KullaniciID { get; set; }
        public int RolTipiID { get; set; }
    }
}
