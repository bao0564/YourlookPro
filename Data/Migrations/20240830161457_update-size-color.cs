using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class updatesizecolor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbChiTietImg");

            migrationBuilder.CreateTable(
                name: "DbChiTietSanPham",
                columns: table => new
                {
                    MaSpChiTiet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSp = table.Column<int>(type: "int", nullable: false),
                    MaSize = table.Column<int>(type: "int", nullable: false),
                    MaMau = table.Column<int>(type: "int", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    SanPhamMaSp = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbChiTietSanPham", x => x.MaSpChiTiet);
                    table.ForeignKey(
                        name: "FK_DbChiTietSanPham_DbColor_ColorId",
                        column: x => x.ColorId,
                        principalTable: "DbColor",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbChiTietSanPham_DbSanPham_SanPhamMaSp",
                        column: x => x.SanPhamMaSp,
                        principalTable: "DbSanPham",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbChiTietSanPham_DbSize_SizeId",
                        column: x => x.SizeId,
                        principalTable: "DbSize",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_ColorId",
                table: "DbChiTietSanPham",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_SanPhamMaSp",
                table: "DbChiTietSanPham",
                column: "SanPhamMaSp");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_SizeId",
                table: "DbChiTietSanPham",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbChiTietSanPham");

            migrationBuilder.CreateTable(
                name: "DbChiTietImg",
                columns: table => new
                {
                    MaChiTietSp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbChiTietImg", x => x.MaChiTietSp);
                });
        }
    }
}
