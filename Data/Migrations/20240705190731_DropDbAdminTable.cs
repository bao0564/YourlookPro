using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class DropDbAdminTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
           name: "DbAdmin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
           name: "DbAdmin",
           columns: table => new
           {
               Id = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:Identity", "1, 1"),
               // Các cột khác...
           },
           constraints: table =>
           {
               table.PrimaryKey("PK_DbAdmin", x => x.Id);
           });
        }
    }
}
