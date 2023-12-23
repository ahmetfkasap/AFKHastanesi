namespace AFKHastanesi.Models
{
    public class Poliklinik
    {
        public int PoliklinikID { get; set; }
        public string PoliklinikAdi { get; set; }
        public int BilimDaliID { get; set; }
        public int DoktorID { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
    }
}
