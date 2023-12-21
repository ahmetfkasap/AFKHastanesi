namespace AFKHastanesi.Models
{
    public class RolTipi
    {
        public int KisiTipiID { get; set; }
        public string KisiTipiAdi { get; set; }
        public ICollection<Rol> Roller { get; set; }
    }
}
