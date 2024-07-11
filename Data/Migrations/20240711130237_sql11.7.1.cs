using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql1171 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbAddres_DbKhachHang_MaKhNavigationMaKh",
                table: "DbAddres");

            migrationBuilder.DropForeignKey(
                name: "FK_DbTransaction_DbKhachHang_MaKhNavigationMaKh",
                table: "DbTransaction");

            migrationBuilder.DropIndex(
                name: "IX_DbTransaction_MaKhNavigationMaKh",
                table: "DbTransaction");

            migrationBuilder.DropIndex(
                name: "IX_DbAddres_MaKhNavigationMaKh",
                table: "DbAddres");

            migrationBuilder.DropColumn(
                name: "MaKhNavigationMaKh",
                table: "DbTransaction");

            migrationBuilder.DropColumn(
                name: "MaKhNavigationMaKh",
                table: "DbAddres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaKhNavigationMaKh",
                table: "DbTransaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaKhNavigationMaKh",
                table: "DbAddres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DbTransaction_MaKhNavigationMaKh",
                table: "DbTransaction",
                column: "MaKhNavigationMaKh");

            migrationBuilder.CreateIndex(
                name: "IX_DbAddres_MaKhNavigationMaKh",
                table: "DbAddres",
                column: "MaKhNavigationMaKh");

            migrationBuilder.AddForeignKey(
                name: "FK_DbAddres_DbKhachHang_MaKhNavigationMaKh",
                table: "DbAddres",
                column: "MaKhNavigationMaKh",
                principalTable: "DbKhachHang",
                principalColumn: "MaKh");

            migrationBuilder.AddForeignKey(
                name: "FK_DbTransaction_DbKhachHang_MaKhNavigationMaKh",
                table: "DbTransaction",
                column: "MaKhNavigationMaKh",
                principalTable: "DbKhachHang",
                principalColumn: "MaKh",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
