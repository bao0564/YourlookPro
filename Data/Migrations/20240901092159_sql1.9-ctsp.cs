using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql19ctsp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaMau",
                table: "DbChiTietSanPham");

            migrationBuilder.DropColumn(
                name: "MaSize",
                table: "DbChiTietSanPham");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaMau",
                table: "DbChiTietSanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaSize",
                table: "DbChiTietSanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
