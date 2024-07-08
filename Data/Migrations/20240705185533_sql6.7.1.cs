using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class sql671 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbAdds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAdds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordDn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAdmin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbColor",
                columns: table => new
                {
                    ColorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbColor", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "DbDanhMuc",
                columns: table => new
                {
                    MaDm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AnhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    MaDmcha = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDanhMuc", x => x.MaDm);
                });

            migrationBuilder.CreateTable(
                name: "DbGroup",
                columns: table => new
                {
                    NhomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbGroup", x => x.NhomId);
                });

            migrationBuilder.CreateTable(
                name: "DbInforShop",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbInforShop", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbKhachHang",
                columns: table => new
                {
                    MaKh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passwords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbKhachHang", x => x.MaKh);
                });

            migrationBuilder.CreateTable(
                name: "DbMenu",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Links = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuTu = table.Column<int>(type: "int", nullable: true),
                    IActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbMenu", x => x.MenuId);
                });

            migrationBuilder.CreateTable(
                name: "DbPayment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbPayment", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "DbSize",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSize", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "DbSanPham",
                columns: table => new
                {
                    MaSp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDm = table.Column<int>(type: "int", nullable: false),
                    TenSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SaoDanhGia = table.Column<int>(type: "int", nullable: false),
                    NhomId = table.Column<int>(type: "int", nullable: false),
                    AnhSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongSp = table.Column<int>(type: "int", nullable: false),
                    PriceMax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GiamGia = table.Column<int>(type: "int", nullable: false),
                    PriceMin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LuotXem = table.Column<int>(type: "int", nullable: false),
                    LuotSold = table.Column<int>(type: "int", nullable: false),
                    MotaSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IActive = table.Column<bool>(type: "bit", nullable: false),
                    IFeature = table.Column<bool>(type: "bit", nullable: false),
                    IHot = table.Column<bool>(type: "bit", nullable: false),
                    ISale = table.Column<bool>(type: "bit", nullable: false),
                    MetaKeywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaDescriptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaDanhMucsMaDmMaDm = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbSanPham", x => x.MaSp);
                    table.ForeignKey(
                        name: "FK_DbSanPham_DbDanhMuc_MaDanhMucsMaDmMaDm",
                        column: x => x.MaDanhMucsMaDmMaDm,
                        principalTable: "DbDanhMuc",
                        principalColumn: "MaDm");
                    table.ForeignKey(
                        name: "FK_DbSanPham_DbGroup_NhomId",
                        column: x => x.NhomId,
                        principalTable: "DbGroup",
                        principalColumn: "NhomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbAddres",
                columns: table => new
                {
                    IdAddress = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKh = table.Column<int>(type: "int", nullable: true),
                    TenNguoiNhan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Addres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuanHuyen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhuongXa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaKhNavigationMaKh = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbAddres", x => x.IdAddress);
                    table.ForeignKey(
                        name: "FK_DbAddres_DbKhachHang_MaKhNavigationMaKh",
                        column: x => x.MaKhNavigationMaKh,
                        principalTable: "DbKhachHang",
                        principalColumn: "MaKh");
                });

            migrationBuilder.CreateTable(
                name: "DbTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKh = table.Column<int>(type: "int", nullable: false),
                    TenKh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    Mess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaKhNavigationMaKh = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbTransaction_DbKhachHang_MaKhNavigationMaKh",
                        column: x => x.MaKhNavigationMaKh,
                        principalTable: "DbKhachHang",
                        principalColumn: "MaKh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbDonHang",
                columns: table => new
                {
                    MaDh = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentId = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaKhNavigationMaKh = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbDonHang", x => x.MaDh);
                    table.ForeignKey(
                        name: "FK_DbDonHang_DbKhachHang_MaKhNavigationMaKh",
                        column: x => x.MaKhNavigationMaKh,
                        principalTable: "DbKhachHang",
                        principalColumn: "MaKh");
                    table.ForeignKey(
                        name: "FK_DbDonHang_DbPayment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "DbPayment",
                        principalColumn: "PaymentId");
                });

            migrationBuilder.CreateTable(
                name: "DbChiTietSanPham",
                columns: table => new
                {
                    MaChiTietSp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSp = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    AnhSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiamGia = table.Column<int>(type: "int", nullable: true),
                    MaSpNavigationMaSp = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbChiTietSanPham", x => x.MaChiTietSp);
                    table.ForeignKey(
                        name: "FK_DbChiTietSanPham_DbColor_ColorId",
                        column: x => x.ColorId,
                        principalTable: "DbColor",
                        principalColumn: "ColorId");
                    table.ForeignKey(
                        name: "FK_DbChiTietSanPham_DbSanPham_MaSpNavigationMaSp",
                        column: x => x.MaSpNavigationMaSp,
                        principalTable: "DbSanPham",
                        principalColumn: "MaSp");
                    table.ForeignKey(
                        name: "FK_DbChiTietSanPham_DbSize_SizeId",
                        column: x => x.SizeId,
                        principalTable: "DbSize",
                        principalColumn: "SizeId");
                });

            migrationBuilder.CreateTable(
                name: "DbImg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSp = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbImg_DbSanPham_MaSp",
                        column: x => x.MaSp,
                        principalTable: "DbSanPham",
                        principalColumn: "MaSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbChiTietDonHang",
                columns: table => new
                {
                    MaCTDH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDh = table.Column<int>(type: "int", nullable: false),
                    MaSp = table.Column<int>(type: "int", nullable: false),
                    TenSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnhSp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuongSp = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaChiTietSpNavigationMaChiTietSp = table.Column<int>(type: "int", nullable: false),
                    MaDhNavigationMaDh = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbChiTietDonHang", x => x.MaCTDH);
                    table.ForeignKey(
                        name: "FK_DbChiTietDonHang_DbChiTietSanPham_MaChiTietSpNavigationMaChiTietSp",
                        column: x => x.MaChiTietSpNavigationMaChiTietSp,
                        principalTable: "DbChiTietSanPham",
                        principalColumn: "MaChiTietSp",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbChiTietDonHang_DbDonHang_MaDhNavigationMaDh",
                        column: x => x.MaDhNavigationMaDh,
                        principalTable: "DbDonHang",
                        principalColumn: "MaDh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbChiTietImg",
                columns: table => new
                {
                    MaChiTietSp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaChiTietSpNavigationMaChiTietSp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbChiTietImg", x => x.MaChiTietSp);
                    table.ForeignKey(
                        name: "FK_DbChiTietImg_DbChiTietSanPham_MaChiTietSpNavigationMaChiTietSp",
                        column: x => x.MaChiTietSpNavigationMaChiTietSp,
                        principalTable: "DbChiTietSanPham",
                        principalColumn: "MaChiTietSp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbAddres_MaKhNavigationMaKh",
                table: "DbAddres",
                column: "MaKhNavigationMaKh");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietDonHang_MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietDonHang",
                column: "MaChiTietSpNavigationMaChiTietSp");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietDonHang_MaDhNavigationMaDh",
                table: "DbChiTietDonHang",
                column: "MaDhNavigationMaDh");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietImg_MaChiTietSpNavigationMaChiTietSp",
                table: "DbChiTietImg",
                column: "MaChiTietSpNavigationMaChiTietSp");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_ColorId",
                table: "DbChiTietSanPham",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_MaSpNavigationMaSp",
                table: "DbChiTietSanPham",
                column: "MaSpNavigationMaSp");

            migrationBuilder.CreateIndex(
                name: "IX_DbChiTietSanPham_SizeId",
                table: "DbChiTietSanPham",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_DbDonHang_MaKhNavigationMaKh",
                table: "DbDonHang",
                column: "MaKhNavigationMaKh");

            migrationBuilder.CreateIndex(
                name: "IX_DbDonHang_PaymentId",
                table: "DbDonHang",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_DbImg_MaSp",
                table: "DbImg",
                column: "MaSp");

            migrationBuilder.CreateIndex(
                name: "IX_DbSanPham_MaDanhMucsMaDmMaDm",
                table: "DbSanPham",
                column: "MaDanhMucsMaDmMaDm");

            migrationBuilder.CreateIndex(
                name: "IX_DbSanPham_NhomId",
                table: "DbSanPham",
                column: "NhomId");

            migrationBuilder.CreateIndex(
                name: "IX_DbTransaction_MaKhNavigationMaKh",
                table: "DbTransaction",
                column: "MaKhNavigationMaKh");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbAddres");

            migrationBuilder.DropTable(
                name: "DbAdds");

            migrationBuilder.DropTable(
                name: "DbAdmin");

            migrationBuilder.DropTable(
                name: "DbChiTietDonHang");

            migrationBuilder.DropTable(
                name: "DbChiTietImg");

            migrationBuilder.DropTable(
                name: "DbImg");

            migrationBuilder.DropTable(
                name: "DbInforShop");

            migrationBuilder.DropTable(
                name: "DbMenu");

            migrationBuilder.DropTable(
                name: "DbTransaction");

            migrationBuilder.DropTable(
                name: "DbDonHang");

            migrationBuilder.DropTable(
                name: "DbChiTietSanPham");

            migrationBuilder.DropTable(
                name: "DbKhachHang");

            migrationBuilder.DropTable(
                name: "DbPayment");

            migrationBuilder.DropTable(
                name: "DbColor");

            migrationBuilder.DropTable(
                name: "DbSanPham");

            migrationBuilder.DropTable(
                name: "DbSize");

            migrationBuilder.DropTable(
                name: "DbDanhMuc");

            migrationBuilder.DropTable(
                name: "DbGroup");
        }
    }
}
