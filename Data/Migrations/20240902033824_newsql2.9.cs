using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class newsql29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbChiTietSanPham_DbSanPham_SanPhamMaSp",
                table: "DbChiTietSanPham");

            migrationBuilder.DropIndex(
                name: "IX_DbChiTietSanPham_SanPhamMaSp",
                table: "DbChiTietSanPham");

            migrationBuilder.DropColumn(
                name: "SanPhamMaSp",
                table: "DbChiTietSanPham");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_MaSp",
                table: "DbChiTietSanPham",
                column: "MaSp");

            migrationBuilder.AddForeignKey(
                name: "FK_DbChiTietSanPham_DbSanPham_MaSp",
                table: "DbChiTietSanPham",
                column: "MaSp",
                principalTable: "DbSanPham",
                principalColumn: "MaSp",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbChiTietSanPham_DbSanPham_MaSp",
                table: "DbChiTietSanPham");

            migrationBuilder.DropIndex(
                name: "IX_DbChiTietSanPham_MaSp",
                table: "DbChiTietSanPham");

            migrationBuilder.AddColumn<int>(
                name: "SanPhamMaSp",
                table: "DbChiTietSanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_SanPhamMaSp",
                table: "DbChiTietSanPham",
                column: "SanPhamMaSp");

            migrationBuilder.AddForeignKey(
                name: "FK_DbChiTietSanPham_DbSanPham_SanPhamMaSp",
                table: "DbChiTietSanPham",
                column: "SanPhamMaSp",
                principalTable: "DbSanPham",
                principalColumn: "MaSp",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
