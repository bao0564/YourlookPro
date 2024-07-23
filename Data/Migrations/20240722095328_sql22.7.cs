using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql227 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbDonHang_DbKhachHang_DbKhachHangMaKh",
                table: "DbDonHang");

            migrationBuilder.RenameColumn(
                name: "DbKhachHangMaKh",
                table: "DbDonHang",
                newName: "MaKhNavigationMaKh");

            migrationBuilder.RenameIndex(
                name: "IX_DbDonHang_DbKhachHangMaKh",
                table: "DbDonHang",
                newName: "IX_DbDonHang_MaKhNavigationMaKh");

            migrationBuilder.AddColumn<int>(
                name: "MaKh",
                table: "DbDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DbDonHang_DbKhachHang_MaKhNavigationMaKh",
                table: "DbDonHang",
                column: "MaKhNavigationMaKh",
                principalTable: "DbKhachHang",
                principalColumn: "MaKh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbDonHang_DbKhachHang_MaKhNavigationMaKh",
                table: "DbDonHang");

            migrationBuilder.DropColumn(
                name: "MaKh",
                table: "DbDonHang");

            migrationBuilder.RenameColumn(
                name: "MaKhNavigationMaKh",
                table: "DbDonHang",
                newName: "DbKhachHangMaKh");

            migrationBuilder.RenameIndex(
                name: "IX_DbDonHang_MaKhNavigationMaKh",
                table: "DbDonHang",
                newName: "IX_DbDonHang_DbKhachHangMaKh");

            migrationBuilder.AddForeignKey(
                name: "FK_DbDonHang_DbKhachHang_DbKhachHangMaKh",
                table: "DbDonHang",
                column: "DbKhachHangMaKh",
                principalTable: "DbKhachHang",
                principalColumn: "MaKh");
        }
    }
}
