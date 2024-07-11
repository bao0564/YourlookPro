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
            modelBuilder.Entity<DbSanPham>()
                .HasMany(sp => sp.DbImgs)
                .WithOne(img => img.MaSpNavigation)
                .HasForeignKey(img => img.MaSp)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<DbAdd> DbAdds { get; set; }
        public virtual DbSet<DbAddres> DbAddreses { get; set; }
        public virtual DbSet<DbAdmin> DbAdmins { get; set; }

        public virtual DbSet<DbChiTietDonHang> DbChiTietDonHangs { get; set; }

        public virtual DbSet<DbChiTietImg> DbChiTietImgs { get; set; }

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

        public virtual DbSet<DbPayment> Payments { get; set; }
		public virtual DbSet<ThongKe> ThongKes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       => optionsBuilder.UseSqlServer("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=yourlook;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    }
}
