using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql874 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbChiTietDonHang_DbDonHang_MaDhNavigationMaDh",
                table: "DbChiTietDonHang");

            migrationBuilder.DropIndex(
                name: "IX_DbChiTietDonHang_MaDhNavigationMaDh",
                table: "DbChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "MaDhNavigationMaDh",
                table: "DbChiTietDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietDonHang_MaDh",
                table: "DbChiTietDonHang",
                column: "MaDh");

            migrationBuilder.AddForeignKey(
                name: "FK_DbChiTietDonHang_DbDonHang_MaDh",
                table: "DbChiTietDonHang",
                column: "MaDh",
                principalTable: "DbDonHang",
                principalColumn: "MaDh",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbChiTietDonHang_DbDonHang_MaDh",
                table: "DbChiTietDonHang");

            migrationBuilder.DropIndex(
                name: "IX_DbChiTietDonHang_MaDh",
                table: "DbChiTietDonHang");

            migrationBuilder.AddColumn<int>(
                name: "MaDhNavigationMaDh",
                table: "DbChiTietDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietDonHang_MaDhNavigationMaDh",
                table: "DbChiTietDonHang",
                column: "MaDhNavigationMaDh");

            migrationBuilder.AddForeignKey(
                name: "FK_DbChiTietDonHang_DbDonHang_MaDhNavigationMaDh",
                table: "DbChiTietDonHang",
                column: "MaDhNavigationMaDh",
                principalTable: "DbDonHang",
                principalColumn: "MaDh",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
