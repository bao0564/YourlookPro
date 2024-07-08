using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql675 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbChiTietDonHang_DbChiTietSanPham_MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_DbChiTietImg_DbChiTietSanPham_MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietImg");

            migrationBuilder.DropTable(
                name: "DbChiTietSanPham");

            migrationBuilder.DropIndex(
                name: "IX_DbChiTietImg_MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietImg");

            migrationBuilder.DropIndex(
                name: "IX_DbChiTietDonHang_MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietImg");

            migrationBuilder.DropColumn(
                name: "MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietDonHang");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietImg",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DbChiTietSanPham",
                columns: table => new
                {
                    MaChiTietSp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    MaSpNavigationMaSp = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    AnhSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiamGia = table.Column<int>(type: "int", nullable: true),
                    MaSp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbChiTietSanPham", x => x.MaChiTietSp);
                    table.ForeignKey(
                        name: "FK_DbChiTietSanPham_DbColor_ColorId",
                        column: x => x.ColorId,
                        principalTable: "DbColor",
                        principalColumn: "ColorId");
                    table.ForeignKey(
                        name: "FK_DbChiTietSanPham_DbSanPham_MaSpNavigationMaSp",
                        column: x => x.MaSpNavigationMaSp,
                        principalTable: "DbSanPham",
                        principalColumn: "MaSp");
                    table.ForeignKey(
                        name: "FK_DbChiTietSanPham_DbSize_SizeId",
                        column: x => x.SizeId,
                        principalTable: "DbSize",
                        principalColumn: "SizeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietImg_MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietImg",
                column: "MaChiTietSpNavigationMaChiTietSp");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietDonHang_MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietDonHang",
                column: "MaChiTietSpNavigationMaChiTietSp");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_ColorId",
                table: "DbChiTietSanPham",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_MaSpNavigationMaSp",
                table: "DbChiTietSanPham",
                column: "MaSpNavigationMaSp");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_SizeId",
                table: "DbChiTietSanPham",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbChiTietDonHang_DbChiTietSanPham_MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietDonHang",
                column: "MaChiTietSpNavigationMaChiTietSp",
                principalTable: "DbChiTietSanPham",
                principalColumn: "MaChiTietSp",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DbChiTietImg_DbChiTietSanPham_MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietImg",
                column: "MaChiTietSpNavigationMaChiTietSp",
                principalTable: "DbChiTietSanPham",
                principalColumn: "MaChiTietSp",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
