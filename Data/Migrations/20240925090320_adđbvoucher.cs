using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class adđbvoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbDonHang_DbPayment_PaymentId",
                table: "DbDonHang");

            migrationBuilder.DropIndex(
                name: "IX_DbDonHang_PaymentId",
                table: "DbDonHang");

            migrationBuilder.AddColumn<int>(
                name: "DbPaymentPaymentId",
                table: "DbDonHang",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaVoucher",
                table: "DbDonHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ValueVoucher",
                table: "DbDonHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DbVoucher",
                columns: table => new
                {
                    idVoucher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaVoucher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconVoucher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valueVoucher = table.Column<int>(type: "int", nullable: false),
                    MotaVoucher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbVoucher", x => x.idVoucher);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbDonHang_DbPaymentPaymentId",
                table: "DbDonHang",
                column: "DbPaymentPaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbDonHang_DbPayment_DbPaymentPaymentId",
                table: "DbDonHang",
                column: "DbPaymentPaymentId",
                principalTable: "DbPayment",
                principalColumn: "PaymentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbDonHang_DbPayment_DbPaymentPaymentId",
                table: "DbDonHang");

            migrationBuilder.DropTable(
                name: "DbVoucher");

            migrationBuilder.DropIndex(
                name: "IX_DbDonHang_DbPaymentPaymentId",
                table: "DbDonHang");

            migrationBuilder.DropColumn(
                name: "DbPaymentPaymentId",
                table: "DbDonHang");

            migrationBuilder.DropColumn(
                name: "MaVoucher",
                table: "DbDonHang");

            migrationBuilder.DropColumn(
                name: "ValueVoucher",
                table: "DbDonHang");

            migrationBuilder.CreateIndex(
                name: "IX_DbDonHang_PaymentId",
                table: "DbDonHang",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DbDonHang_DbPayment_PaymentId",
                table: "DbDonHang",
                column: "PaymentId",
                principalTable: "DbPayment",
                principalColumn: "PaymentId");
        }
    }
}
