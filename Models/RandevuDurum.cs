namespace AFKHastanesi.Models
{
    public class RandevuDurum
    {
        public int DurumID { get; set; }
        public string DurumAdi { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
    }
}
