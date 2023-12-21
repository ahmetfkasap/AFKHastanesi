namespace AFKHastanesi.Models
{
    public class RolTipi
    {
        public int RolTipiID { get; set; }
        public string RolTipiAdi { get; set; }
        public ICollection<Rol> Roller { get; set; }
    }
}
