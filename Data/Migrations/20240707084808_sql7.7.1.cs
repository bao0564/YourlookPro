using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql771 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbChiTietDonHang_DbSanPham_MaSpNavigationMaSp",
                table: "DbChiTietDonHang");

            migrationBuilder.DropIndex(
                name: "IX_DbChiTietDonHang_MaSpNavigationMaSp",
                table: "DbChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "MaSpNavigationMaSp",
                table: "DbChiTietDonHang");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaSpNavigationMaSp",
                table: "DbChiTietDonHang",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietDonHang_MaSpNavigationMaSp",
                table: "DbChiTietDonHang",
                column: "MaSpNavigationMaSp");

            migrationBuilder.AddForeignKey(
                name: "FK_DbChiTietDonHang_DbSanPham_MaSpNavigationMaSp",
                table: "DbChiTietDonHang",
                column: "MaSpNavigationMaSp",
                principalTable: "DbSanPham",
                principalColumn: "MaSp");
        }
    }
}
