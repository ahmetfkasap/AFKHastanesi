using System.ComponentModel.DataAnnotations;

namespace AFKHastanesi.Models
{
    public class RolTipi
    {
        [Key]
        public int RolTipiID { get; set; }
        public string RolTipiAdi { get; set; }
        public ICollection<Rol> Roller { get; set; }
    }
}
