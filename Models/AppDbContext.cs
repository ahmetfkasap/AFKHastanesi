using Microsoft.EntityFrameworkCore;

namespace AFKHastanesi.Models
{
    public class AppDbContext: DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<RolTipi> RolTipleri { get; set; }
        public DbSet<RandevuDurum> RandevuDurumlari { get; set; }
        public DbSet<BilimDali> BilimDallari { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=AFKHastanesi;User Id=postgres;Password=dantes");
        }
    }
}
