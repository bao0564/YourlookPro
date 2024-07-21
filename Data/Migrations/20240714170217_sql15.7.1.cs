using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql1571 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbAdds",
                table: "DbAdds");

            migrationBuilder.RenameTable(
                name: "DbAdds",
                newName: "DbAdd");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "DbAdd",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbAdd",
                table: "DbAdd",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DbAdd",
                table: "DbAdd");

            migrationBuilder.RenameTable(
                name: "DbAdd",
                newName: "DbAdds");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "DbAdds",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DbAdds",
                table: "DbAdds",
                column: "Id");
        }
    }
}
