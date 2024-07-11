using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql1072 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ThongKes",
                table: "ThongKes");

            migrationBuilder.RenameTable(
                name: "ThongKes",
                newName: "ThongKe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThongKe",
                table: "ThongKe",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ThongKe",
                table: "ThongKe");

            migrationBuilder.RenameTable(
                name: "ThongKe",
                newName: "ThongKes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThongKes",
                table: "ThongKes",
                column: "Id");
        }
    }
}
