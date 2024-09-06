using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql59 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "DbChiTietDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "DbChiTietDonHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "DbChiTietDonHang",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "DbChiTietDonHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "DbChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "DbChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "DbChiTietDonHang");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "DbChiTietDonHang");
        }
    }
}
