﻿// <auto-generated />
using HastaneRandevuSistemi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AFKHastanesi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231221210029_mig1")]
    partial class mig1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AFKHastanesi.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KullaniciId"));

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

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");
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

            modelBuilder.Entity("AFKHastanesi.Models.Kullanici", b =>
                {
                    b.Navigation("Roller");
                });

            modelBuilder.Entity("AFKHastanesi.Models.RolTipi", b =>
                {
                    b.Navigation("Roller");
                });
#pragma warning restore 612, 618
        }
    }
}
