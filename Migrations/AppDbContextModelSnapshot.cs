﻿// <auto-generated />
using System;
using AFKHastanesi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AFKHastanesi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AFKHastanesi.Models.BilimDali", b =>
                {
                    b.Property<int>("BilimDaliID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BilimDaliID"));

                    b.Property<string>("BilimDaliAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BilimDaliID");

                    b.ToTable("BilimDallari");
                });

            modelBuilder.Entity("AFKHastanesi.Models.Doktor", b =>
                {
                    b.Property<int>("DoktorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DoktorID"));

                    b.Property<int>("BilimDaliID")
                        .HasColumnType("integer");

                    b.Property<string>("DoktorAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DoktorSoyadi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("DoktorID");

                    b.HasIndex("BilimDaliID");

                    b.ToTable("Doktorlar");
                });

            modelBuilder.Entity("AFKHastanesi.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KullaniciID"));

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciEmail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciSifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciSoyadi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("KullaniciID");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("AFKHastanesi.Models.Poliklinik", b =>
                {
                    b.Property<int>("PoliklinikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PoliklinikID"));

                    b.Property<int>("BilimDaliID")
                        .HasColumnType("integer");

                    b.Property<int>("DoktorID")
                        .HasColumnType("integer");

                    b.Property<string>("PoliklinikAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PoliklinikID");

                    b.HasIndex("BilimDaliID");

                    b.HasIndex("DoktorID");

                    b.ToTable("Poliklinikler");
                });

            modelBuilder.Entity("AFKHastanesi.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RandevuID"));

                    b.Property<int>("BilimDaliID")
                        .HasColumnType("integer");

                    b.Property<int>("DoktorID")
                        .HasColumnType("integer");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("integer");

                    b.Property<int>("PoliklinikID")
                        .HasColumnType("integer");

                    b.Property<int>("RandevuDurumID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RandevuTarihi")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("RandevuID");

                    b.HasIndex("BilimDaliID");

                    b.HasIndex("DoktorID");

                    b.HasIndex("KullaniciID");

                    b.HasIndex("PoliklinikID");

                    b.HasIndex("RandevuDurumID");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("AFKHastanesi.Models.RandevuDurum", b =>
                {
                    b.Property<int>("RandevuDurumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RandevuDurumID"));

                    b.Property<string>("RandevuDurumAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RandevuDurumID");

                    b.ToTable("RandevuDurumlari");
                });

            modelBuilder.Entity("AFKHastanesi.Models.Rol", b =>
                {
                    b.Property<int>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RolID"));

                    b.Property<int>("KullaniciID")
                        .HasColumnType("integer");

                    b.Property<int>("RolTipiID")
                        .HasColumnType("integer");

                    b.HasKey("RolID");

                    b.HasIndex("KullaniciID");

                    b.HasIndex("RolTipiID");

                    b.ToTable("Roller");
                });

            modelBuilder.Entity("AFKHastanesi.Models.RolTipi", b =>
                {
                    b.Property<int>("RolTipiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RolTipiID"));

                    b.Property<string>("RolTipiAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RolTipiID");

                    b.ToTable("RolTipleri");
                });

            modelBuilder.Entity("AFKHastanesi.Models.Doktor", b =>
                {
                    b.HasOne("AFKHastanesi.Models.BilimDali", null)
                        .WithMany("Doktorlar")
                        .HasForeignKey("BilimDaliID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AFKHastanesi.Models.Poliklinik", b =>
                {
                    b.HasOne("AFKHastanesi.Models.BilimDali", null)
                        .WithMany("Poliklinikler")
                        .HasForeignKey("BilimDaliID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AFKHastanesi.Models.Doktor", null)
                        .WithMany("Poliklinikler")
                        .HasForeignKey("DoktorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AFKHastanesi.Models.Randevu", b =>
                {
                    b.HasOne("AFKHastanesi.Models.BilimDali", null)
                        .WithMany("Randevular")
                        .HasForeignKey("BilimDaliID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AFKHastanesi.Models.Doktor", null)
                        .WithMany("Randevular")
                        .HasForeignKey("DoktorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AFKHastanesi.Models.Kullanici", null)
                        .WithMany("Randevular")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AFKHastanesi.Models.Poliklinik", null)
                        .WithMany("Randevular")
                        .HasForeignKey("PoliklinikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AFKHastanesi.Models.RandevuDurum", null)
                        .WithMany("Randevular")
                        .HasForeignKey("RandevuDurumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AFKHastanesi.Models.Rol", b =>
                {
                    b.HasOne("AFKHastanesi.Models.Kullanici", null)
                        .WithMany("Roller")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AFKHastanesi.Models.RolTipi", null)
                        .WithMany("Roller")
                        .HasForeignKey("RolTipiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AFKHastanesi.Models.BilimDali", b =>
                {
                    b.Navigation("Doktorlar");

                    b.Navigation("Poliklinikler");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("AFKHastanesi.Models.Doktor", b =>
                {
                    b.Navigation("Poliklinikler");

                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("AFKHastanesi.Models.Kullanici", b =>
                {
                    b.Navigation("Randevular");

                    b.Navigation("Roller");
                });

            modelBuilder.Entity("AFKHastanesi.Models.Poliklinik", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("AFKHastanesi.Models.RandevuDurum", b =>
                {
                    b.Navigation("Randevular");
                });

            modelBuilder.Entity("AFKHastanesi.Models.RolTipi", b =>
                {
                    b.Navigation("Roller");
                });
#pragma warning restore 612, 618
        }
    }
}
