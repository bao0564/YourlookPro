using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql2171 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Complete",
                table: "DbDonHang",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ODReadly",
                table: "DbDonHang",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ODSuccess",
                table: "DbDonHang",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ODTransported",
                table: "DbDonHang",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complete",
                table: "DbDonHang");

            migrationBuilder.DropColumn(
                name: "ODReadly",
                table: "DbDonHang");

            migrationBuilder.DropColumn(
                name: "ODSuccess",
                table: "DbDonHang");

            migrationBuilder.DropColumn(
                name: "ODTransported",
                table: "DbDonHang");
        }
    }
}
