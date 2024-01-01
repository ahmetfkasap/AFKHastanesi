using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFKHastanesi.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Kullanicilar_KullaniciID",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciID",
                table: "Randevular",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Kullanicilar_KullaniciID",
                table: "Randevular",
                column: "KullaniciID",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevular_Kullanicilar_KullaniciID",
                table: "Randevular");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciID",
                table: "Randevular",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevular_Kullanicilar_KullaniciID",
                table: "Randevular",
                column: "KullaniciID",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
