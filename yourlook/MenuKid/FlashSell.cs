using Data.Models;

namespace yourlook.MenuKid
{
    public class FlashSell : IFlashSell
    {
        private readonly YourlookContext _context;
        public FlashSell(YourlookContext context)
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

        public IEnumerable<DbSanPham> GetAllSanPhamFlashSell()
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
