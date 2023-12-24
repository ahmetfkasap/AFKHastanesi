using System;
using AFKHastanesi.Models;
using Microsoft.EntityFrameworkCore;
namespace HastaneRandevuSistemi.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<RolTipi> RolTipleri { get; set; }
        public DbSet<BilimDali> BilimDallari { get; set; }
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<RandevuDurum> RandevuDurumlari { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=HastaneRandevuSistemi;User Id=postgres;Password=dantes");
        }
    }
}

