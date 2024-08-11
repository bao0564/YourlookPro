using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql88 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaKhNavigationMaKh",
                table: "DbAddres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DbAddres_MaKhNavigationMaKh",
                table: "DbAddres",
                column: "MaKhNavigationMaKh");

            migrationBuilder.AddForeignKey(
                name: "FK_DbAddres_DbKhachHang_MaKhNavigationMaKh",
                table: "DbAddres",
                column: "MaKhNavigationMaKh",
                principalTable: "DbKhachHang",
                principalColumn: "MaKh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbAddres_DbKhachHang_MaKhNavigationMaKh",
                table: "DbAddres");

            migrationBuilder.DropIndex(
                name: "IX_DbAddres_MaKhNavigationMaKh",
                table: "DbAddres");

            migrationBuilder.DropColumn(
                name: "MaKhNavigationMaKh",
                table: "DbAddres");
        }
    }
}
