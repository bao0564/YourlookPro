using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Data.Models
{
    public class YourlookContext:DbContext
    {
        public YourlookContext() 
        { 
        }
        public YourlookContext(DbContextOptions<YourlookContext> options) 
            : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			// Cấu hình quan hệ giữa DbSanPham và Dbimg
			modelBuilder.Entity<DbSanPham>()
                .HasMany(sp => sp.DbImgs)
                .WithOne(img => img.MaSpNavigation)
                .HasForeignKey(img => img.MaSp)
                .OnDelete(DeleteBehavior.Cascade);

			// Cấu hình quan hệ giữa DbChiTietSanPham và DbSanPham
			modelBuilder.Entity<DbChiTietSanPham>()
				.HasOne(ctsp => ctsp.SanPham)
				.WithMany(sp => sp.DbChiTietSanPhams)
				.HasForeignKey(ctsp => ctsp.MaSp)
				.OnDelete(DeleteBehavior.Cascade);

			// Cấu hình quan hệ giữa DbChiTietSanPham và DbColor
			modelBuilder.Entity<DbChiTietSanPham>()
				.HasOne(ctsp => ctsp.Color)
				.WithMany(c => c.DbChiTietSanPhams)
				.HasForeignKey(ctsp => ctsp.ColorId)
				.OnDelete(DeleteBehavior.Cascade);

			// Cấu hình quan hệ giữa DbChiTietSanPham và DbSize
			modelBuilder.Entity<DbChiTietSanPham>()
				.HasOne(ctsp => ctsp.Size)
				.WithMany(s => s.DbChiTietSanPhams)
				.HasForeignKey(ctsp => ctsp.SizeId)
				.OnDelete(DeleteBehavior.Cascade);
			//Cấu hình quan hệ giữa Dbchitietdonhang voiws dbdonhang
			modelBuilder.Entity<DbChiTietDonHang>()
				.HasOne(ctdh => ctdh.MaDhNavigation)
				.WithMany(dh => dh.DbChiTietDonHangs)
				.HasForeignKey(ctdh => ctdh.MaDh)
				.OnDelete(DeleteBehavior.Cascade);
		}
		// sản phẩm yêu thích
		public List<DbSanPham> GetFavoriteProducts(int maKh)
		{
			//lấy ra masp trong bảng yêu thích
			var favoriteProductIds = DbFavoriteProducts
				.Where(fp => fp.MaKh == maKh)
				.Select(fp => fp.MaSp)
				.ToList();

			return DbSanPhams
				.Where(sp => favoriteProductIds.Contains(sp.MaSp))
				.ToList();
		}
		//lịch sử đơn hàng
		public List<DbSanPham> GetHistoryOrders(int maKh)
		{
			//lấy ra masp trong bảng chitiet donhang
			var historyOrders=DbChiTietDonHangs
				.Where(ho=>ho.MaKh==maKh)
				.Select(ho=>ho.MaSp)
				.ToList();

			return DbSanPhams
				.Where(sp=>historyOrders.Contains(sp.MaSp))
				.ToList();
		}
		public virtual DbSet<DbAdd> DbAdds { get; set; }
        public virtual DbSet<DbAddres> DbAddreses { get; set; }
        public virtual DbSet<DbAdmin> DbAdmins { get; set; }

        public virtual DbSet<DbChiTietDonHang> DbChiTietDonHangs { get; set; }

        public virtual DbSet<DbChiTietSanPham> DbChiTietSanPhams { get; set; }

        public virtual DbSet<DbColor> DbColors { get; set; }

        public virtual DbSet<DbDanhMuc> DbDanhMucs { get; set; }

        public virtual DbSet<DbDonHang> DbDonHangs { get; set; }

        public virtual DbSet<DbGroup> DbGroups { get; set; }

        public virtual DbSet<DbImg> DbImgs { get; set; }

        public virtual DbSet<DbInforShop> DbInforShops { get; set; }

        public virtual DbSet<DbKhachHang> DbKhachHangs { get; set; }

        public virtual DbSet<DbMenu> DbMenus { get; set; }

        public virtual DbSet<DbSanPham> DbSanPhams { get; set; }

        public virtual DbSet<DbSize> DbSizes { get; set; }

        public virtual DbSet<DbTransaction> DbTransactions { get; set; }

        public virtual DbSet<DbPayment> DbPayments { get; set; }
		public virtual DbSet<DbVoucher> DbVouchers { get; set; }
        public virtual DbSet<DbFavoriteProduct> DbFavoriteProducts { get; set; }
		public virtual DbSet<ThongKe> DbThongKes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseSqlServer("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=yourlook;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    }
}
