﻿// <auto-generated />
using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(YourlookContext))]
    partial class YourlookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Data.Models.DbAdd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DbAdd");
                });

            modelBuilder.Entity("Data.Models.DbAddres", b =>
                {
                    b.Property<int>("IdAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAddress"));

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Idefault")
                        .HasColumnType("bit");

                    b.Property<int>("MaKh")
                        .HasColumnType("int");

                    b.Property<int?>("MaKhNavigationMaKh")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhuongXa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuanHuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sdt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNguoiNhan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAddress");

                    b.HasIndex("MaKhNavigationMaKh");

                    b.ToTable("DbAddres");
                });

            modelBuilder.Entity("Data.Models.DbAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ChucVu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailDn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsExternalAccount")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameDn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordDn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quyen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DbAdmin");
                });

            modelBuilder.Entity("Data.Models.DbChiTietDonHang", b =>
                {
                    b.Property<int>("MaCTDH")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaCTDH"));

                    b.Property<string>("AnhSp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaDh")
                        .HasColumnType("int");

                    b.Property<int>("MaSp")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SoLuongSp")
                        .HasColumnType("int");

                    b.Property<string>("TenSp")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaCTDH");

                    b.HasIndex("MaDh");

                    b.ToTable("DbChiTietDonHang");
                });

            modelBuilder.Entity("Data.Models.DbChiTietSanPham", b =>
                {
                    b.Property<int>("MaSpChiTiet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSpChiTiet"));

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<int>("MaSp")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.HasKey("MaSpChiTiet");

                    b.HasIndex("ColorId");

                    b.HasIndex("MaSp");

                    b.HasIndex("SizeId");

                    b.ToTable("DbChiTietSanPham");
                });

            modelBuilder.Entity("Data.Models.DbColor", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColorId"));

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MaMau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColorId");

                    b.ToTable("DbColor");
                });

            modelBuilder.Entity("Data.Models.DbDanhMuc", b =>
                {
                    b.Property<int>("MaDm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDm"));

                    b.Property<string>("AnhDaiDien")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MaDmcha")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenDm")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ThuTu")
                        .HasColumnType("int");

                    b.HasKey("MaDm");

                    b.ToTable("DbDanhMuc");
                });

            modelBuilder.Entity("Data.Models.DbDonHang", b =>
                {
                    b.Property<int>("MaDh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDh"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Complete")
                        .HasColumnType("bit");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailKh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaKh")
                        .HasColumnType("int");

                    b.Property<int?>("MaKhNavigationMaKh")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("ODReadly")
                        .HasColumnType("bit");

                    b.Property<bool>("ODSuccess")
                        .HasColumnType("bit");

                    b.Property<bool>("ODTransported")
                        .HasColumnType("bit");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Ward")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("soluong")
                        .HasColumnType("int");

                    b.HasKey("MaDh");

                    b.HasIndex("MaKhNavigationMaKh");

                    b.HasIndex("PaymentId");

                    b.ToTable("DbDonHang");
                });

            modelBuilder.Entity("Data.Models.DbFavoriteProduct", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KhachhangMaKh")
                        .HasColumnType("int");

                    b.Property<int>("MaKh")
                        .HasColumnType("int");

                    b.Property<int>("MaSp")
                        .HasColumnType("int");

                    b.Property<int?>("SanphamMaSp")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("KhachhangMaKh");

                    b.HasIndex("SanphamMaSp");

                    b.ToTable("DbFavoriteProduct");
                });

            modelBuilder.Entity("Data.Models.DbGroup", b =>
                {
                    b.Property<int>("NhomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NhomId"));

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NhomId");

                    b.ToTable("DbGroup");
                });

            modelBuilder.Entity("Data.Models.DbImg", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int>("MaSp")
                        .HasColumnType("int");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaSp");

                    b.ToTable("DbImg");
                });

            modelBuilder.Entity("Data.Models.DbInforShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Addres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DbInforShop");
                });

            modelBuilder.Entity("Data.Models.DbKhachHang", b =>
                {
                    b.Property<int>("MaKh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaKh"));

                    b.Property<string>("Addres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmPasswords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GioiTinh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsExternalAccount")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Passwords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaKh");

                    b.ToTable("DbKhachHang");
                });

            modelBuilder.Entity("Data.Models.DbMenu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"));

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IActive")
                        .HasColumnType("bit");

                    b.Property<string>("Links")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenMn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThuTu")
                        .HasColumnType("int");

                    b.HasKey("MenuId");

                    b.ToTable("DbMenu");
                });

            modelBuilder.Entity("Data.Models.DbPayment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.ToTable("DbPayment");
                });

            modelBuilder.Entity("Data.Models.DbSanPham", b =>
                {
                    b.Property<int>("MaSp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaSp"));

                    b.Property<string>("AnhSp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GiamGia")
                        .HasColumnType("int");

                    b.Property<bool>("IActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IFeature")
                        .HasColumnType("bit");

                    b.Property<bool>("IHot")
                        .HasColumnType("bit");

                    b.Property<bool>("ISale")
                        .HasColumnType("bit");

                    b.Property<int>("LuotSold")
                        .HasColumnType("int");

                    b.Property<int>("LuotXem")
                        .HasColumnType("int");

                    b.Property<int?>("MaDanhMucsMaDmMaDm")
                        .HasColumnType("int");

                    b.Property<int?>("MaDm")
                        .HasColumnType("int");

                    b.Property<string>("MetaDescriptions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MetaKeywords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MotaSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NhomId")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceMax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceMin")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SaoDanhGia")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongSp")
                        .HasColumnType("int");

                    b.Property<string>("TenSp")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaSp");

                    b.HasIndex("MaDanhMucsMaDmMaDm");

                    b.HasIndex("NhomId");

                    b.ToTable("DbSanPham");
                });

            modelBuilder.Entity("Data.Models.DbSize", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SizeId"));

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SizeId");

                    b.ToTable("DbSize");
                });

            modelBuilder.Entity("Data.Models.DbTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaKh")
                        .HasColumnType("int");

                    b.Property<string>("Mess")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("Sdt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenKh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DbTransaction");
                });

            modelBuilder.Entity("Data.Models.ThongKe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("LuongTruyCap")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ThongKe");
                });

            modelBuilder.Entity("Data.Models.DbAddres", b =>
                {
                    b.HasOne("Data.Models.DbKhachHang", "MaKhNavigation")
                        .WithMany("DbAddreses")
                        .HasForeignKey("MaKhNavigationMaKh");

                    b.Navigation("MaKhNavigation");
                });

            modelBuilder.Entity("Data.Models.DbChiTietDonHang", b =>
                {
                    b.HasOne("Data.Models.DbDonHang", "MaDhNavigation")
                        .WithMany("DbChiTietDonHangs")
                        .HasForeignKey("MaDh")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaDhNavigation");
                });

            modelBuilder.Entity("Data.Models.DbChiTietSanPham", b =>
                {
                    b.HasOne("Data.Models.DbColor", "Color")
                        .WithMany("DbChiTietSanPhams")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.DbSanPham", "SanPham")
                        .WithMany("DbChiTietSanPhams")
                        .HasForeignKey("MaSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.DbSize", "Size")
                        .WithMany("DbChiTietSanPhams")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("SanPham");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Data.Models.DbDonHang", b =>
                {
                    b.HasOne("Data.Models.DbKhachHang", "MaKhNavigation")
                        .WithMany("DbDonHangs")
                        .HasForeignKey("MaKhNavigationMaKh");

                    b.HasOne("Data.Models.DbPayment", "Payment")
                        .WithMany("DbDonHangs")
                        .HasForeignKey("PaymentId");

                    b.Navigation("MaKhNavigation");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Data.Models.DbFavoriteProduct", b =>
                {
                    b.HasOne("Data.Models.DbKhachHang", "Khachhang")
                        .WithMany()
                        .HasForeignKey("KhachhangMaKh");

                    b.HasOne("Data.Models.DbSanPham", "Sanpham")
                        .WithMany("DbFavorites")
                        .HasForeignKey("SanphamMaSp");

                    b.Navigation("Khachhang");

                    b.Navigation("Sanpham");
                });

            modelBuilder.Entity("Data.Models.DbImg", b =>
                {
                    b.HasOne("Data.Models.DbSanPham", "MaSpNavigation")
                        .WithMany("DbImgs")
                        .HasForeignKey("MaSp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaSpNavigation");
                });

            modelBuilder.Entity("Data.Models.DbSanPham", b =>
                {
                    b.HasOne("Data.Models.DbDanhMuc", "MaDanhMucsMaDm")
                        .WithMany("DbSanPhams")
                        .HasForeignKey("MaDanhMucsMaDmMaDm");

                    b.HasOne("Data.Models.DbGroup", "Nhom")
                        .WithMany("DbSanPhams")
                        .HasForeignKey("NhomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaDanhMucsMaDm");

                    b.Navigation("Nhom");
                });

            modelBuilder.Entity("Data.Models.DbColor", b =>
                {
                    b.Navigation("DbChiTietSanPhams");
                });

            modelBuilder.Entity("Data.Models.DbDanhMuc", b =>
                {
                    b.Navigation("DbSanPhams");
                });

            modelBuilder.Entity("Data.Models.DbDonHang", b =>
                {
                    b.Navigation("DbChiTietDonHangs");
                });

            modelBuilder.Entity("Data.Models.DbGroup", b =>
                {
                    b.Navigation("DbSanPhams");
                });

            modelBuilder.Entity("Data.Models.DbKhachHang", b =>
                {
                    b.Navigation("DbAddreses");

                    b.Navigation("DbDonHangs");
                });

            modelBuilder.Entity("Data.Models.DbPayment", b =>
                {
                    b.Navigation("DbDonHangs");
                });

            modelBuilder.Entity("Data.Models.DbSanPham", b =>
                {
                    b.Navigation("DbChiTietSanPhams");

                    b.Navigation("DbFavorites");

                    b.Navigation("DbImgs");
                });

            modelBuilder.Entity("Data.Models.DbSize", b =>
                {
                    b.Navigation("DbChiTietSanPhams");
                });
#pragma warning restore 612, 618
        }
    }
}
