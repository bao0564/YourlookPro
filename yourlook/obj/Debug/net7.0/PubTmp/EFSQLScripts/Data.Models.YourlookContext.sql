IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbAdds] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [Url] nvarchar(max) NULL,
        [Img] nvarchar(max) NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbAdds] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbAdmin] (
        [Id] int NOT NULL IDENTITY,
        [NameDn] nvarchar(max) NOT NULL,
        [PasswordDn] nvarchar(max) NOT NULL,
        [ChucVu] nvarchar(max) NOT NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbAdmin] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbColor] (
        [ColorId] int NOT NULL IDENTITY,
        [NameColor] nvarchar(max) NOT NULL,
        [Img] nvarchar(max) NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbColor] PRIMARY KEY ([ColorId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbDanhMuc] (
        [MaDm] int NOT NULL IDENTITY,
        [TenDm] nvarchar(50) NOT NULL,
        [AnhDaiDien] nvarchar(max) NULL,
        [ThuTu] int NULL,
        [MaDmcha] int NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbDanhMuc] PRIMARY KEY ([MaDm])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbGroup] (
        [NhomId] int NOT NULL IDENTITY,
        [GroupName] nvarchar(max) NOT NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbGroup] PRIMARY KEY ([NhomId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbInforShop] (
        [Id] int NOT NULL IDENTITY,
        [Sdt] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Addres] nvarchar(max) NULL,
        CONSTRAINT [PK_DbInforShop] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbKhachHang] (
        [MaKh] int NOT NULL IDENTITY,
        [TenKh] nvarchar(max) NULL,
        [Img] nvarchar(max) NULL,
        [GioiTinh] nvarchar(max) NULL,
        [Addres] nvarchar(max) NULL,
        [Sdt] nvarchar(max) NULL,
        [Email] nvarchar(max) NOT NULL,
        [Passwords] nvarchar(max) NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbKhachHang] PRIMARY KEY ([MaKh])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbMenu] (
        [MenuId] int NOT NULL IDENTITY,
        [TenMn] nvarchar(max) NULL,
        [Mota] nvarchar(max) NULL,
        [Links] nvarchar(max) NULL,
        [ThuTu] int NULL,
        [IActive] bit NOT NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbMenu] PRIMARY KEY ([MenuId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbPayment] (
        [PaymentId] int NOT NULL IDENTITY,
        [PaymentName] nvarchar(max) NOT NULL,
        [Icon] nvarchar(max) NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbPayment] PRIMARY KEY ([PaymentId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbSize] (
        [SizeId] int NOT NULL IDENTITY,
        [NameSize] nvarchar(max) NOT NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbSize] PRIMARY KEY ([SizeId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbSanPham] (
        [MaSp] int NOT NULL IDENTITY,
        [MaDm] int NOT NULL,
        [TenSp] nvarchar(max) NULL,
        [SaoDanhGia] int NOT NULL,
        [NhomId] int NOT NULL,
        [AnhSp] nvarchar(max) NULL,
        [SoLuongSp] int NOT NULL,
        [PriceMax] decimal(18,2) NOT NULL,
        [GiamGia] int NOT NULL,
        [PriceMin] decimal(18,2) NOT NULL,
        [LuotXem] int NOT NULL,
        [LuotSold] int NOT NULL,
        [MotaSp] nvarchar(max) NULL,
        [IActive] bit NOT NULL,
        [IFeature] bit NOT NULL,
        [IHot] bit NOT NULL,
        [ISale] bit NOT NULL,
        [MetaKeywords] nvarchar(max) NULL,
        [MetaDescriptions] nvarchar(max) NULL,
        [MaDanhMucsMaDmMaDm] int NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbSanPham] PRIMARY KEY ([MaSp]),
        CONSTRAINT [FK_DbSanPham_DbDanhMuc_MaDanhMucsMaDmMaDm] FOREIGN KEY ([MaDanhMucsMaDmMaDm]) REFERENCES [DbDanhMuc] ([MaDm]),
        CONSTRAINT [FK_DbSanPham_DbGroup_NhomId] FOREIGN KEY ([NhomId]) REFERENCES [DbGroup] ([NhomId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbAddres] (
        [IdAddress] int NOT NULL IDENTITY,
        [MaKh] int NULL,
        [TenNguoiNhan] nvarchar(max) NULL,
        [Sdt] nvarchar(max) NULL,
        [Addres] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [QuanHuyen] nvarchar(max) NULL,
        [PhuongXa] nvarchar(max) NULL,
        [GhiChu] nvarchar(max) NULL,
        [MaKhNavigationMaKh] int NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbAddres] PRIMARY KEY ([IdAddress]),
        CONSTRAINT [FK_DbAddres_DbKhachHang_MaKhNavigationMaKh] FOREIGN KEY ([MaKhNavigationMaKh]) REFERENCES [DbKhachHang] ([MaKh])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbTransaction] (
        [Id] int NOT NULL IDENTITY,
        [MaKh] int NOT NULL,
        [TenKh] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [Sdt] nvarchar(max) NULL,
        [Amount] decimal(18,2) NULL,
        [PaymentId] int NULL,
        [Mess] nvarchar(max) NULL,
        [MaKhNavigationMaKh] int NOT NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbTransaction] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DbTransaction_DbKhachHang_MaKhNavigationMaKh] FOREIGN KEY ([MaKhNavigationMaKh]) REFERENCES [DbKhachHang] ([MaKh]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbDonHang] (
        [MaDh] int NOT NULL IDENTITY,
        [TenKh] nvarchar(max) NULL,
        [Sdt] nvarchar(max) NULL,
        [City] nvarchar(max) NULL,
        [District] nvarchar(max) NULL,
        [Ward] nvarchar(max) NULL,
        [DiaChi] nvarchar(max) NULL,
        [TongTien] decimal(18,2) NULL,
        [PaymentId] int NULL,
        [GhiChu] nvarchar(max) NULL,
        [MaKhNavigationMaKh] int NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbDonHang] PRIMARY KEY ([MaDh]),
        CONSTRAINT [FK_DbDonHang_DbKhachHang_MaKhNavigationMaKh] FOREIGN KEY ([MaKhNavigationMaKh]) REFERENCES [DbKhachHang] ([MaKh]),
        CONSTRAINT [FK_DbDonHang_DbPayment_PaymentId] FOREIGN KEY ([PaymentId]) REFERENCES [DbPayment] ([PaymentId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbChiTietSanPham] (
        [MaChiTietSp] int NOT NULL IDENTITY,
        [MaSp] int NULL,
        [SizeId] int NULL,
        [ColorId] int NULL,
        [AnhSp] nvarchar(max) NULL,
        [GiamGia] int NULL,
        [MaSpNavigationMaSp] int NULL,
        CONSTRAINT [PK_DbChiTietSanPham] PRIMARY KEY ([MaChiTietSp]),
        CONSTRAINT [FK_DbChiTietSanPham_DbColor_ColorId] FOREIGN KEY ([ColorId]) REFERENCES [DbColor] ([ColorId]),
        CONSTRAINT [FK_DbChiTietSanPham_DbSanPham_MaSpNavigationMaSp] FOREIGN KEY ([MaSpNavigationMaSp]) REFERENCES [DbSanPham] ([MaSp]),
        CONSTRAINT [FK_DbChiTietSanPham_DbSize_SizeId] FOREIGN KEY ([SizeId]) REFERENCES [DbSize] ([SizeId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbImg] (
        [Id] int NOT NULL IDENTITY,
        [MaSp] int NOT NULL,
        [Img] nvarchar(max) NULL,
        [IsDefault] bit NOT NULL,
        [Place] nvarchar(max) NULL,
        CONSTRAINT [PK_DbImg] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DbImg_DbSanPham_MaSp] FOREIGN KEY ([MaSp]) REFERENCES [DbSanPham] ([MaSp]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbChiTietDonHang] (
        [MaCTDH] int NOT NULL IDENTITY,
        [MaDh] int NOT NULL,
        [MaSp] int NOT NULL,
        [TenSp] nvarchar(max) NULL,
        [AnhSp] nvarchar(max) NULL,
        [SoLuongSp] int NULL,
        [Price] decimal(18,2) NOT NULL,
        [MaChiTietSpNavigationMaChiTietSp] int NOT NULL,
        [MaDhNavigationMaDh] int NOT NULL,
        [CreateDate] datetime2 NULL,
        [CreateBy] nvarchar(max) NULL,
        [ModifiedDate] datetime2 NULL,
        [ModifiedBy] nvarchar(max) NULL,
        CONSTRAINT [PK_DbChiTietDonHang] PRIMARY KEY ([MaCTDH]),
        CONSTRAINT [FK_DbChiTietDonHang_DbChiTietSanPham_MaChiTietSpNavigationMaChiTietSp] FOREIGN KEY ([MaChiTietSpNavigationMaChiTietSp]) REFERENCES [DbChiTietSanPham] ([MaChiTietSp]) ON DELETE CASCADE,
        CONSTRAINT [FK_DbChiTietDonHang_DbDonHang_MaDhNavigationMaDh] FOREIGN KEY ([MaDhNavigationMaDh]) REFERENCES [DbDonHang] ([MaDh]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE TABLE [DbChiTietImg] (
        [MaChiTietSp] int NOT NULL IDENTITY,
        [Img] nvarchar(max) NOT NULL,
        [Place] nvarchar(max) NULL,
        [MaChiTietSpNavigationMaChiTietSp] int NOT NULL,
        CONSTRAINT [PK_DbChiTietImg] PRIMARY KEY ([MaChiTietSp]),
        CONSTRAINT [FK_DbChiTietImg_DbChiTietSanPham_MaChiTietSpNavigationMaChiTietSp] FOREIGN KEY ([MaChiTietSpNavigationMaChiTietSp]) REFERENCES [DbChiTietSanPham] ([MaChiTietSp]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbAddres_MaKhNavigationMaKh] ON [DbAddres] ([MaKhNavigationMaKh]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbChiTietDonHang_MaChiTietSpNavigationMaChiTietSp] ON [DbChiTietDonHang] ([MaChiTietSpNavigationMaChiTietSp]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbChiTietDonHang_MaDhNavigationMaDh] ON [DbChiTietDonHang] ([MaDhNavigationMaDh]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbChiTietImg_MaChiTietSpNavigationMaChiTietSp] ON [DbChiTietImg] ([MaChiTietSpNavigationMaChiTietSp]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbChiTietSanPham_ColorId] ON [DbChiTietSanPham] ([ColorId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbChiTietSanPham_MaSpNavigationMaSp] ON [DbChiTietSanPham] ([MaSpNavigationMaSp]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbChiTietSanPham_SizeId] ON [DbChiTietSanPham] ([SizeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbDonHang_MaKhNavigationMaKh] ON [DbDonHang] ([MaKhNavigationMaKh]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbDonHang_PaymentId] ON [DbDonHang] ([PaymentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbImg_MaSp] ON [DbImg] ([MaSp]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbSanPham_MaDanhMucsMaDmMaDm] ON [DbSanPham] ([MaDanhMucsMaDmMaDm]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbSanPham_NhomId] ON [DbSanPham] ([NhomId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    CREATE INDEX [IX_DbTransaction_MaKhNavigationMaKh] ON [DbTransaction] ([MaKhNavigationMaKh]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705185533_sql6.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240705185533_sql6.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705190731_DropDbAdminTable')
BEGIN
    DROP TABLE [DbAdmin];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705190731_DropDbAdminTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240705190731_DropDbAdminTable', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240705192601_DropDbhr')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240705192601_DropDbhr', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706091720_sql8.7.1')
BEGIN
    ALTER TABLE [DbDonHang] DROP CONSTRAINT [FK_DbDonHang_DbKhachHang_MaKhNavigationMaKh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706091720_sql8.7.1')
BEGIN
    EXEC sp_rename N'[DbDonHang].[MaKhNavigationMaKh]', N'DbKhachHangMaKh', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706091720_sql8.7.1')
BEGIN
    EXEC sp_rename N'[DbDonHang].[IX_DbDonHang_MaKhNavigationMaKh]', N'IX_DbDonHang_DbKhachHangMaKh', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706091720_sql8.7.1')
BEGIN
    ALTER TABLE [DbDonHang] ADD CONSTRAINT [FK_DbDonHang_DbKhachHang_DbKhachHangMaKh] FOREIGN KEY ([DbKhachHangMaKh]) REFERENCES [DbKhachHang] ([MaKh]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706091720_sql8.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240706091720_sql8.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706095556_sql8.7.2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240706095556_sql8.7.2', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706100814_sql8.7.3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240706100814_sql8.7.3', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706131108_sql6.7.4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240706131108_sql6.7.4', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    ALTER TABLE [DbChiTietDonHang] DROP CONSTRAINT [FK_DbChiTietDonHang_DbChiTietSanPham_MaChiTietSpNavigationMaChiTietSp];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    ALTER TABLE [DbChiTietImg] DROP CONSTRAINT [FK_DbChiTietImg_DbChiTietSanPham_MaChiTietSpNavigationMaChiTietSp];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    DROP TABLE [DbChiTietSanPham];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    DROP INDEX [IX_DbChiTietImg_MaChiTietSpNavigationMaChiTietSp] ON [DbChiTietImg];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    DROP INDEX [IX_DbChiTietDonHang_MaChiTietSpNavigationMaChiTietSp] ON [DbChiTietDonHang];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbChiTietImg]') AND [c].[name] = N'MaChiTietSpNavigationMaChiTietSp');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [DbChiTietImg] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [DbChiTietImg] DROP COLUMN [MaChiTietSpNavigationMaChiTietSp];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbChiTietDonHang]') AND [c].[name] = N'MaChiTietSpNavigationMaChiTietSp');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [DbChiTietDonHang] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [DbChiTietDonHang] DROP COLUMN [MaChiTietSpNavigationMaChiTietSp];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    ALTER TABLE [DbChiTietDonHang] ADD [MaSpNavigationMaSp] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    CREATE INDEX [IX_DbChiTietDonHang_MaSpNavigationMaSp] ON [DbChiTietDonHang] ([MaSpNavigationMaSp]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    ALTER TABLE [DbChiTietDonHang] ADD CONSTRAINT [FK_DbChiTietDonHang_DbSanPham_MaSpNavigationMaSp] FOREIGN KEY ([MaSpNavigationMaSp]) REFERENCES [DbSanPham] ([MaSp]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240706143343_sql6.7.5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240706143343_sql6.7.5', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240707084808_sql7.7.1')
BEGIN
    ALTER TABLE [DbChiTietDonHang] DROP CONSTRAINT [FK_DbChiTietDonHang_DbSanPham_MaSpNavigationMaSp];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240707084808_sql7.7.1')
BEGIN
    DROP INDEX [IX_DbChiTietDonHang_MaSpNavigationMaSp] ON [DbChiTietDonHang];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240707084808_sql7.7.1')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbChiTietDonHang]') AND [c].[name] = N'MaSpNavigationMaSp');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [DbChiTietDonHang] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [DbChiTietDonHang] DROP COLUMN [MaSpNavigationMaSp];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240707084808_sql7.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240707084808_sql7.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240707114037_asl7.7.3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240707114037_asl7.7.3', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240707120545_asl7.7.4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240707120545_asl7.7.4', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240707124043_asl7.7.5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240707124043_asl7.7.5', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240708152419_sql8.7.4')
BEGIN
    ALTER TABLE [DbChiTietDonHang] DROP CONSTRAINT [FK_DbChiTietDonHang_DbDonHang_MaDhNavigationMaDh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240708152419_sql8.7.4')
BEGIN
    DROP INDEX [IX_DbChiTietDonHang_MaDhNavigationMaDh] ON [DbChiTietDonHang];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240708152419_sql8.7.4')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbChiTietDonHang]') AND [c].[name] = N'MaDhNavigationMaDh');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [DbChiTietDonHang] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [DbChiTietDonHang] DROP COLUMN [MaDhNavigationMaDh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240708152419_sql8.7.4')
BEGIN
    CREATE INDEX [IX_DbChiTietDonHang_MaDh] ON [DbChiTietDonHang] ([MaDh]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240708152419_sql8.7.4')
BEGIN
    ALTER TABLE [DbChiTietDonHang] ADD CONSTRAINT [FK_DbChiTietDonHang_DbDonHang_MaDh] FOREIGN KEY ([MaDh]) REFERENCES [DbDonHang] ([MaDh]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240708152419_sql8.7.4')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240708152419_sql8.7.4', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240709112138_sql9.7.1')
BEGIN
    ALTER TABLE [DbDonHang] ADD [soluong] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240709112138_sql9.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240709112138_sql9.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240710102930_sql10.7')
BEGIN
    CREATE TABLE [ThongKes] (
        [Id] int NOT NULL IDENTITY,
        [Time] datetime2 NOT NULL,
        [LuongTruyCap] bigint NOT NULL,
        CONSTRAINT [PK_ThongKes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240710102930_sql10.7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240710102930_sql10.7', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240710114702_sql10.7.2')
BEGIN
    ALTER TABLE [ThongKes] DROP CONSTRAINT [PK_ThongKes];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240710114702_sql10.7.2')
BEGIN
    EXEC sp_rename N'[ThongKes]', N'ThongKe';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240710114702_sql10.7.2')
BEGIN
    ALTER TABLE [ThongKe] ADD CONSTRAINT [PK_ThongKe] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240710114702_sql10.7.2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240710114702_sql10.7.2', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711100810_sql11.7')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbKhachHang]') AND [c].[name] = N'Email');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [DbKhachHang] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [DbKhachHang] ALTER COLUMN [Email] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711100810_sql11.7')
BEGIN
    ALTER TABLE [DbKhachHang] ADD [ConfirmPasswords] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711100810_sql11.7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240711100810_sql11.7', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711130237_sql11.7.1')
BEGIN
    ALTER TABLE [DbAddres] DROP CONSTRAINT [FK_DbAddres_DbKhachHang_MaKhNavigationMaKh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711130237_sql11.7.1')
BEGIN
    ALTER TABLE [DbTransaction] DROP CONSTRAINT [FK_DbTransaction_DbKhachHang_MaKhNavigationMaKh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711130237_sql11.7.1')
BEGIN
    DROP INDEX [IX_DbTransaction_MaKhNavigationMaKh] ON [DbTransaction];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711130237_sql11.7.1')
BEGIN
    DROP INDEX [IX_DbAddres_MaKhNavigationMaKh] ON [DbAddres];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711130237_sql11.7.1')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbTransaction]') AND [c].[name] = N'MaKhNavigationMaKh');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [DbTransaction] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [DbTransaction] DROP COLUMN [MaKhNavigationMaKh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711130237_sql11.7.1')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbAddres]') AND [c].[name] = N'MaKhNavigationMaKh');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [DbAddres] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [DbAddres] DROP COLUMN [MaKhNavigationMaKh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711130237_sql11.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240711130237_sql11.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711173800_sql11.7.2')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbKhachHang]') AND [c].[name] = N'TenKh');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [DbKhachHang] DROP CONSTRAINT [' + @var7 + '];');
    EXEC(N'UPDATE [DbKhachHang] SET [TenKh] = N'''' WHERE [TenKh] IS NULL');
    ALTER TABLE [DbKhachHang] ALTER COLUMN [TenKh] nvarchar(max) NOT NULL;
    ALTER TABLE [DbKhachHang] ADD DEFAULT N'' FOR [TenKh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711173800_sql11.7.2')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbKhachHang]') AND [c].[name] = N'Sdt');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [DbKhachHang] DROP CONSTRAINT [' + @var8 + '];');
    EXEC(N'UPDATE [DbKhachHang] SET [Sdt] = N'''' WHERE [Sdt] IS NULL');
    ALTER TABLE [DbKhachHang] ALTER COLUMN [Sdt] nvarchar(max) NOT NULL;
    ALTER TABLE [DbKhachHang] ADD DEFAULT N'' FOR [Sdt];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711173800_sql11.7.2')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbKhachHang]') AND [c].[name] = N'Passwords');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [DbKhachHang] DROP CONSTRAINT [' + @var9 + '];');
    EXEC(N'UPDATE [DbKhachHang] SET [Passwords] = N'''' WHERE [Passwords] IS NULL');
    ALTER TABLE [DbKhachHang] ALTER COLUMN [Passwords] nvarchar(max) NOT NULL;
    ALTER TABLE [DbKhachHang] ADD DEFAULT N'' FOR [Passwords];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711173800_sql11.7.2')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbKhachHang]') AND [c].[name] = N'Email');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [DbKhachHang] DROP CONSTRAINT [' + @var10 + '];');
    EXEC(N'UPDATE [DbKhachHang] SET [Email] = N'''' WHERE [Email] IS NULL');
    ALTER TABLE [DbKhachHang] ALTER COLUMN [Email] nvarchar(max) NOT NULL;
    ALTER TABLE [DbKhachHang] ADD DEFAULT N'' FOR [Email];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711173800_sql11.7.2')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbKhachHang]') AND [c].[name] = N'ConfirmPasswords');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [DbKhachHang] DROP CONSTRAINT [' + @var11 + '];');
    EXEC(N'UPDATE [DbKhachHang] SET [ConfirmPasswords] = N'''' WHERE [ConfirmPasswords] IS NULL');
    ALTER TABLE [DbKhachHang] ALTER COLUMN [ConfirmPasswords] nvarchar(max) NOT NULL;
    ALTER TABLE [DbKhachHang] ADD DEFAULT N'' FOR [ConfirmPasswords];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711173800_sql11.7.2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240711173800_sql11.7.2', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240711181958_sql11.7.3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240711181958_sql11.7.3', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240712152405_sql12.7.1')
BEGIN
    ALTER TABLE [DbAdds] ADD [IsActive] bit NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240712152405_sql12.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240712152405_sql12.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240713132748_sql13.7')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbSanPham]') AND [c].[name] = N'TenSp');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [DbSanPham] DROP CONSTRAINT [' + @var12 + '];');
    EXEC(N'UPDATE [DbSanPham] SET [TenSp] = N'''' WHERE [TenSp] IS NULL');
    ALTER TABLE [DbSanPham] ALTER COLUMN [TenSp] nvarchar(max) NOT NULL;
    ALTER TABLE [DbSanPham] ADD DEFAULT N'' FOR [TenSp];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240713132748_sql13.7')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbSanPham]') AND [c].[name] = N'MotaSp');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [DbSanPham] DROP CONSTRAINT [' + @var13 + '];');
    EXEC(N'UPDATE [DbSanPham] SET [MotaSp] = N'''' WHERE [MotaSp] IS NULL');
    ALTER TABLE [DbSanPham] ALTER COLUMN [MotaSp] nvarchar(max) NOT NULL;
    ALTER TABLE [DbSanPham] ADD DEFAULT N'' FOR [MotaSp];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240713132748_sql13.7')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbSanPham]') AND [c].[name] = N'MaDm');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [DbSanPham] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [DbSanPham] ALTER COLUMN [MaDm] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240713132748_sql13.7')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbSanPham]') AND [c].[name] = N'AnhSp');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [DbSanPham] DROP CONSTRAINT [' + @var15 + '];');
    EXEC(N'UPDATE [DbSanPham] SET [AnhSp] = N'''' WHERE [AnhSp] IS NULL');
    ALTER TABLE [DbSanPham] ALTER COLUMN [AnhSp] nvarchar(max) NOT NULL;
    ALTER TABLE [DbSanPham] ADD DEFAULT N'' FOR [AnhSp];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240713132748_sql13.7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240713132748_sql13.7', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240714170217_sql15.7.1')
BEGIN
    ALTER TABLE [DbAdds] DROP CONSTRAINT [PK_DbAdds];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240714170217_sql15.7.1')
BEGIN
    EXEC sp_rename N'[DbAdds]', N'DbAdd';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240714170217_sql15.7.1')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbAdd]') AND [c].[name] = N'IsActive');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [DbAdd] DROP CONSTRAINT [' + @var16 + '];');
    EXEC(N'UPDATE [DbAdd] SET [IsActive] = CAST(0 AS bit) WHERE [IsActive] IS NULL');
    ALTER TABLE [DbAdd] ALTER COLUMN [IsActive] bit NOT NULL;
    ALTER TABLE [DbAdd] ADD DEFAULT CAST(0 AS bit) FOR [IsActive];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240714170217_sql15.7.1')
BEGIN
    ALTER TABLE [DbAdd] ADD CONSTRAINT [PK_DbAdd] PRIMARY KEY ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240714170217_sql15.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240714170217_sql15.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240719135250_sql19.7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240719135250_sql19.7', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240719160532_sql19.7.2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240719160532_sql19.7.2', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240719161428_sql19.7.1')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbSanPham]') AND [c].[name] = N'AnhSp');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [DbSanPham] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [DbSanPham] ALTER COLUMN [AnhSp] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240719161428_sql19.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240719161428_sql19.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240720093938_sql20.7')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbSanPham]') AND [c].[name] = N'GiamGia');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [DbSanPham] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [DbSanPham] ALTER COLUMN [GiamGia] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240720093938_sql20.7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240720093938_sql20.7', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240721093053_sql21.7')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbSanPham]') AND [c].[name] = N'GiamGia');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [DbSanPham] DROP CONSTRAINT [' + @var19 + '];');
    EXEC(N'UPDATE [DbSanPham] SET [GiamGia] = 0 WHERE [GiamGia] IS NULL');
    ALTER TABLE [DbSanPham] ALTER COLUMN [GiamGia] int NOT NULL;
    ALTER TABLE [DbSanPham] ADD DEFAULT 0 FOR [GiamGia];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240721093053_sql21.7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240721093053_sql21.7', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240721151344_sql21.7.1')
BEGIN
    ALTER TABLE [DbDonHang] ADD [Complete] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240721151344_sql21.7.1')
BEGIN
    ALTER TABLE [DbDonHang] ADD [ODReadly] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240721151344_sql21.7.1')
BEGIN
    ALTER TABLE [DbDonHang] ADD [ODSuccess] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240721151344_sql21.7.1')
BEGIN
    ALTER TABLE [DbDonHang] ADD [ODTransported] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240721151344_sql21.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240721151344_sql21.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240722095328_sql22.7')
BEGIN
    ALTER TABLE [DbDonHang] DROP CONSTRAINT [FK_DbDonHang_DbKhachHang_DbKhachHangMaKh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240722095328_sql22.7')
BEGIN
    EXEC sp_rename N'[DbDonHang].[DbKhachHangMaKh]', N'MaKhNavigationMaKh', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240722095328_sql22.7')
BEGIN
    EXEC sp_rename N'[DbDonHang].[IX_DbDonHang_DbKhachHangMaKh]', N'IX_DbDonHang_MaKhNavigationMaKh', N'INDEX';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240722095328_sql22.7')
BEGIN
    ALTER TABLE [DbDonHang] ADD [MaKh] int NOT NULL DEFAULT 0;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240722095328_sql22.7')
BEGIN
    ALTER TABLE [DbDonHang] ADD CONSTRAINT [FK_DbDonHang_DbKhachHang_MaKhNavigationMaKh] FOREIGN KEY ([MaKhNavigationMaKh]) REFERENCES [DbKhachHang] ([MaKh]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240722095328_sql22.7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240722095328_sql22.7', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240722110502_sql22.7.1')
BEGIN
    ALTER TABLE [DbDonHang] ADD [EmailKh] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240722110502_sql22.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240722110502_sql22.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240723092707_sql23.7')
BEGIN
    CREATE TABLE [DbFavoriteProduct] (
        [id] int NOT NULL IDENTITY,
        [MaSp] int NOT NULL,
        [MaKh] int NOT NULL,
        [CreatDate] datetime2 NOT NULL,
        [SanphamMaSp] int NULL,
        [KhachhangMaKh] int NULL,
        CONSTRAINT [PK_DbFavoriteProduct] PRIMARY KEY ([id]),
        CONSTRAINT [FK_DbFavoriteProduct_DbKhachHang_KhachhangMaKh] FOREIGN KEY ([KhachhangMaKh]) REFERENCES [DbKhachHang] ([MaKh]),
        CONSTRAINT [FK_DbFavoriteProduct_DbSanPham_SanphamMaSp] FOREIGN KEY ([SanphamMaSp]) REFERENCES [DbSanPham] ([MaSp])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240723092707_sql23.7')
BEGIN
    CREATE INDEX [IX_DbFavoriteProduct_KhachhangMaKh] ON [DbFavoriteProduct] ([KhachhangMaKh]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240723092707_sql23.7')
BEGIN
    CREATE INDEX [IX_DbFavoriteProduct_SanphamMaSp] ON [DbFavoriteProduct] ([SanphamMaSp]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240723092707_sql23.7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240723092707_sql23.7', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240723174120_sql23.7.1')
BEGIN
    ALTER TABLE [DbSanPham] ADD [IFavorite] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240723174120_sql23.7.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240723174120_sql23.7.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240724102715_sql24.7')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240724102715_sql24.7', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240806102517_sql6.8')
BEGIN
    ALTER TABLE [DbKhachHang] ADD [IsExternalAccount] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240806102517_sql6.8')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240806102517_sql6.8', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240806105401_sql6.8.1')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbKhachHang]') AND [c].[name] = N'Passwords');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [DbKhachHang] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [DbKhachHang] ALTER COLUMN [Passwords] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240806105401_sql6.8.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240806105401_sql6.8.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240806105552_sql6.8.2')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbKhachHang]') AND [c].[name] = N'ConfirmPasswords');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [DbKhachHang] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [DbKhachHang] ALTER COLUMN [ConfirmPasswords] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240806105552_sql6.8.2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240806105552_sql6.8.2', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240806110012_sql6.8.3')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbKhachHang]') AND [c].[name] = N'Sdt');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [DbKhachHang] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [DbKhachHang] ALTER COLUMN [Sdt] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240806110012_sql6.8.3')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240806110012_sql6.8.3', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240806180406_sql6.8.5')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbSanPham]') AND [c].[name] = N'IFavorite');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [DbSanPham] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [DbSanPham] DROP COLUMN [IFavorite];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240806180406_sql6.8.5')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240806180406_sql6.8.5', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808143120_sql8.8')
BEGIN
    ALTER TABLE [DbAddres] ADD [MaKhNavigationMaKh] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808143120_sql8.8')
BEGIN
    CREATE INDEX [IX_DbAddres_MaKhNavigationMaKh] ON [DbAddres] ([MaKhNavigationMaKh]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808143120_sql8.8')
BEGIN
    ALTER TABLE [DbAddres] ADD CONSTRAINT [FK_DbAddres_DbKhachHang_MaKhNavigationMaKh] FOREIGN KEY ([MaKhNavigationMaKh]) REFERENCES [DbKhachHang] ([MaKh]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808143120_sql8.8')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240808143120_sql8.8', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808161930_sql8.8.1')
BEGIN
    ALTER TABLE [DbAddres] ADD [Idefault] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808161930_sql8.8.1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240808161930_sql8.8.1', N'7.0.19');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808174017_sql8.8.2')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbAddres]') AND [c].[name] = N'TenNguoiNhan');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [DbAddres] DROP CONSTRAINT [' + @var24 + '];');
    EXEC(N'UPDATE [DbAddres] SET [TenNguoiNhan] = N'''' WHERE [TenNguoiNhan] IS NULL');
    ALTER TABLE [DbAddres] ALTER COLUMN [TenNguoiNhan] nvarchar(max) NOT NULL;
    ALTER TABLE [DbAddres] ADD DEFAULT N'' FOR [TenNguoiNhan];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808174017_sql8.8.2')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbAddres]') AND [c].[name] = N'Sdt');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [DbAddres] DROP CONSTRAINT [' + @var25 + '];');
    EXEC(N'UPDATE [DbAddres] SET [Sdt] = N'''' WHERE [Sdt] IS NULL');
    ALTER TABLE [DbAddres] ALTER COLUMN [Sdt] nvarchar(max) NOT NULL;
    ALTER TABLE [DbAddres] ADD DEFAULT N'' FOR [Sdt];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808174017_sql8.8.2')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbAddres]') AND [c].[name] = N'QuanHuyen');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [DbAddres] DROP CONSTRAINT [' + @var26 + '];');
    EXEC(N'UPDATE [DbAddres] SET [QuanHuyen] = N'''' WHERE [QuanHuyen] IS NULL');
    ALTER TABLE [DbAddres] ALTER COLUMN [QuanHuyen] nvarchar(max) NOT NULL;
    ALTER TABLE [DbAddres] ADD DEFAULT N'' FOR [QuanHuyen];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808174017_sql8.8.2')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbAddres]') AND [c].[name] = N'PhuongXa');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [DbAddres] DROP CONSTRAINT [' + @var27 + '];');
    EXEC(N'UPDATE [DbAddres] SET [PhuongXa] = N'''' WHERE [PhuongXa] IS NULL');
    ALTER TABLE [DbAddres] ALTER COLUMN [PhuongXa] nvarchar(max) NOT NULL;
    ALTER TABLE [DbAddres] ADD DEFAULT N'' FOR [PhuongXa];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808174017_sql8.8.2')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbAddres]') AND [c].[name] = N'MaKh');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [DbAddres] DROP CONSTRAINT [' + @var28 + '];');
    EXEC(N'UPDATE [DbAddres] SET [MaKh] = 0 WHERE [MaKh] IS NULL');
    ALTER TABLE [DbAddres] ALTER COLUMN [MaKh] int NOT NULL;
    ALTER TABLE [DbAddres] ADD DEFAULT 0 FOR [MaKh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808174017_sql8.8.2')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbAddres]') AND [c].[name] = N'City');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [DbAddres] DROP CONSTRAINT [' + @var29 + '];');
    EXEC(N'UPDATE [DbAddres] SET [City] = N'''' WHERE [City] IS NULL');
    ALTER TABLE [DbAddres] ALTER COLUMN [City] nvarchar(max) NOT NULL;
    ALTER TABLE [DbAddres] ADD DEFAULT N'' FOR [City];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808174017_sql8.8.2')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[DbAddres]') AND [c].[name] = N'Addres');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [DbAddres] DROP CONSTRAINT [' + @var30 + '];');
    EXEC(N'UPDATE [DbAddres] SET [Addres] = N'''' WHERE [Addres] IS NULL');
    ALTER TABLE [DbAddres] ALTER COLUMN [Addres] nvarchar(max) NOT NULL;
    ALTER TABLE [DbAddres] ADD DEFAULT N'' FOR [Addres];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20240808174017_sql8.8.2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20240808174017_sql8.8.2', N'7.0.19');
END;
GO

COMMIT;
GO

