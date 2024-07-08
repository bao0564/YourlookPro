using Data.Models;

namespace yourlook.MenuKid
{
	public class SanPhamHot : ISanPhamHot
	{
		private readonly YourlookContext _context;
		public SanPhamHot(YourlookContext context)
		{
			_context = context;
		}
		DbSanPham ISanPhamHot.add(DbSanPham dbSanPham)
		{
			_context.DbSanPhams.Add(dbSanPham);
			_context.SaveChanges();
			return dbSanPham;
		}

		DbSanPham ISanPhamHot.delete(string maSP)
		{
			throw new NotImplementedException();
		}

		IEnumerable<DbSanPham> ISanPhamHot.GetAllSanPhamHot()
		{
			return _context.DbSanPhams;
		}

		DbSanPham ISanPhamHot.GetSanPham(string maSP)
		{
			return _context.DbSanPhams.Find(maSP);
		}

		DbSanPham ISanPhamHot.update(DbSanPham dbSanPham)
		{
			_context.Update(dbSanPham);
			_context.SaveChanges();
			return dbSanPham;
		}
	}
}
