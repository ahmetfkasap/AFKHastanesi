﻿namespace AFKHastanesi.Models
{
    public class BilimDali
    {
        public int BilimDaliID { get; set; }
        public string BilimDaliAdi { get; set; }
        public ICollection<Doktor> Doktorlar { get; set; }
        public ICollection<Poliklinik> Poliklinikler { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
    }
}
