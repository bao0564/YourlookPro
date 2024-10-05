using Data.Models;

namespace yourlook.MenuKid
{
	public interface ISanPhamNew
	{
		DbSanPham add(DbSanPham dbSanPham);
		DbSanPham update(DbSanPham dbSanPham);

		DbSanPham delete(string maSP);
		DbSanPham GetSanPham(string maSP);

		IEnumerable<DbSanPham> GetAllSanPhamNew();
	}
	public class SanPhamNew : ISanPhamNew
    {
        private readonly YourlookContext _context;
        public SanPhamNew(YourlookContext context)
        {
            _context = context;
        }
        public DbSanPham add(DbSanPham dbSanPham)
        {
            _context.DbSanPhams.Add(dbSanPham);
            _context.SaveChanges();
            return dbSanPham;
        }

        public DbSanPham delete(string maSP)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DbSanPham> GetAllSanPhamNew()
        {
            return _context.DbSanPhams;
        }

        public DbSanPham GetSanPham(string maSP)
        {
            return _context.DbSanPhams.Find(maSP);
        }

        public DbSanPham update(DbSanPham dbSanPham)
        {
            _context.Update(dbSanPham);
            _context.SaveChanges();
            return dbSanPham;
        }
    }
}
