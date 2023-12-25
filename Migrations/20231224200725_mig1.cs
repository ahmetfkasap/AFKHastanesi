using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AFKHastanesi.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BilimDallari",
                columns: table => new
                {
                    BilimDaliID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BilimDaliAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilimDallari", x => x.BilimDaliID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciAdi = table.Column<string>(type: "text", nullable: false),
                    KullaniciSoyadi = table.Column<string>(type: "text", nullable: false),
                    KullaniciEmail = table.Column<string>(type: "text", nullable: false),
                    KullaniciSifre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciID);
                });

            migrationBuilder.CreateTable(
                name: "RandevuDurumlari",
                columns: table => new
                {
                    RandevuDurumID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RandevuDurumAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandevuDurumlari", x => x.RandevuDurumID);
                });

            migrationBuilder.CreateTable(
                name: "RolTipleri",
                columns: table => new
                {
                    RolTipiID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RolTipiAdi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolTipleri", x => x.RolTipiID);
                });

            migrationBuilder.CreateTable(
                name: "Doktorlar",
                columns: table => new
                {
                    DoktorID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DoktorAdi = table.Column<string>(type: "text", nullable: false),
                    DoktorSoyadi = table.Column<string>(type: "text", nullable: false),
                    BilimDaliID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doktorlar", x => x.DoktorID);
                    table.ForeignKey(
                        name: "FK_Doktorlar_BilimDallari_BilimDaliID",
                        column: x => x.BilimDaliID,
                        principalTable: "BilimDallari",
                        principalColumn: "BilimDaliID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciID = table.Column<int>(type: "integer", nullable: false),
                    RolTipiID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.RolID);
                    table.ForeignKey(
                        name: "FK_Roller_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roller_RolTipleri_RolTipiID",
                        column: x => x.RolTipiID,
                        principalTable: "RolTipleri",
                        principalColumn: "RolTipiID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Poliklinikler",
                columns: table => new
                {
                    PoliklinikID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PoliklinikAdi = table.Column<string>(type: "text", nullable: false),
                    BilimDaliID = table.Column<int>(type: "integer", nullable: false),
                    DoktorID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinikler", x => x.PoliklinikID);
                    table.ForeignKey(
                        name: "FK_Poliklinikler_BilimDallari_BilimDaliID",
                        column: x => x.BilimDaliID,
                        principalTable: "BilimDallari",
                        principalColumn: "BilimDaliID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Poliklinikler_Doktorlar_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    RandevuID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KullaniciID = table.Column<int>(type: "integer", nullable: false),
                    BilimDaliID = table.Column<int>(type: "integer", nullable: false),
                    PoliklinikID = table.Column<int>(type: "integer", nullable: false),
                    DoktorID = table.Column<int>(type: "integer", nullable: false),
                    RandevuDurumID = table.Column<int>(type: "integer", nullable: false),
                    RandevuTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuID);
                    table.ForeignKey(
                        name: "FK_Randevular_BilimDallari_BilimDaliID",
                        column: x => x.BilimDaliID,
                        principalTable: "BilimDallari",
                        principalColumn: "BilimDaliID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Doktorlar_DoktorID",
                        column: x => x.DoktorID,
                        principalTable: "Doktorlar",
                        principalColumn: "DoktorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Poliklinikler_PoliklinikID",
                        column: x => x.PoliklinikID,
                        principalTable: "Poliklinikler",
                        principalColumn: "PoliklinikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_RandevuDurumlari_RandevuDurumID",
                        column: x => x.RandevuDurumID,
                        principalTable: "RandevuDurumlari",
                        principalColumn: "RandevuDurumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doktorlar_BilimDaliID",
                table: "Doktorlar",
                column: "BilimDaliID");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinikler_BilimDaliID",
                table: "Poliklinikler",
                column: "BilimDaliID");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinikler_DoktorID",
                table: "Poliklinikler",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_BilimDaliID",
                table: "Randevular",
                column: "BilimDaliID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_DoktorID",
                table: "Randevular",
                column: "DoktorID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_KullaniciID",
                table: "Randevular",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_PoliklinikID",
                table: "Randevular",
                column: "PoliklinikID");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_RandevuDurumID",
                table: "Randevular",
                column: "RandevuDurumID");

            migrationBuilder.CreateIndex(
                name: "IX_Roller_KullaniciID",
                table: "Roller",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Roller_RolTipiID",
                table: "Roller",
                column: "RolTipiID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "Poliklinikler");

            migrationBuilder.DropTable(
                name: "RandevuDurumlari");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "RolTipleri");

            migrationBuilder.DropTable(
                name: "Doktorlar");

            migrationBuilder.DropTable(
                name: "BilimDallari");
        }
    }
}
