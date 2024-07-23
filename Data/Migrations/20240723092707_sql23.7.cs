using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql237 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbFavoriteProduct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSp = table.Column<int>(type: "int", nullable: false),
                    MaKh = table.Column<int>(type: "int", nullable: false),
                    CreatDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SanphamMaSp = table.Column<int>(type: "int", nullable: true),
                    KhachhangMaKh = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbFavoriteProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_DbFavoriteProduct_DbKhachHang_KhachhangMaKh",
                        column: x => x.KhachhangMaKh,
                        principalTable: "DbKhachHang",
                        principalColumn: "MaKh");
                    table.ForeignKey(
                        name: "FK_DbFavoriteProduct_DbSanPham_SanphamMaSp",
                        column: x => x.SanphamMaSp,
                        principalTable: "DbSanPham",
                        principalColumn: "MaSp");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbFavoriteProduct_KhachhangMaKh",
                table: "DbFavoriteProduct",
                column: "KhachhangMaKh");

            migrationBuilder.CreateIndex(
                name: "IX_DbFavoriteProduct_SanphamMaSp",
                table: "DbFavoriteProduct",
                column: "SanphamMaSp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbFavoriteProduct");
        }
    }
}
