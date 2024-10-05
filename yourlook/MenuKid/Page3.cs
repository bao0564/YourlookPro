using Data.Models;

namespace yourlook.MenuKid
{
	public interface IPage3
	{
		DbSanPham add(DbSanPham dbSanPham);
		DbSanPham update(DbSanPham dbSanPham);

		DbSanPham delete(string maSP);
		DbSanPham GetSanPham(string maSP);

		IEnumerable<DbSanPham> GetAllSanPhamPage3();
	}
	public class Page3 : IPage3
    {
        private readonly YourlookContext _context;
        public Page3(YourlookContext context)
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

        public IEnumerable<DbSanPham> GetAllSanPhamPage3()
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
