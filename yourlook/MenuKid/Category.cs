using Data.Models;

namespace yourlook.MenuKid
{
	public class Category : ICategory
	{
		private readonly YourlookContext _context;
		public Category(YourlookContext context)
		{
			_context = context;
		}
		public DbDanhMuc add(DbDanhMuc dbDanhMuc)
		{
			_context.DbDanhMucs.Add(dbDanhMuc);
			_context.SaveChanges();
			return dbDanhMuc;
		}

		public DbDanhMuc delete(string maDM)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DbDanhMuc> GetAllDanhMuc()
		{
			return _context.DbDanhMucs;
		}

		public DbDanhMuc GetDanhMuc(string maDM)
		{
			return _context.DbDanhMucs.Find(maDM);
		}

		public DbDanhMuc update(DbDanhMuc dbDanhMuc)
		{
			_context.Update(dbDanhMuc);
			_context.SaveChanges();
			return dbDanhMuc;
		}
	}
}
