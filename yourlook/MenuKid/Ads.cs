using Data.Models;
using System.ComponentModel;

namespace yourlook.MenuKid
{
	public interface IAds
	{
		DbAdd add(DbAdd dbAds);
		DbAdd update(DbAdd dbAds);

		DbAdd delete(string id);
		DbAdd GetAds(string id);

		IEnumerable<DbAdd> GetAllAds();
	}
	public class Ads : IAds
	{
		private readonly YourlookContext _context;
		public Ads(YourlookContext context)
		{
			_context = context;
		}
		public DbAdd add(DbAdd dbAds)
		{
			_context.DbAdds.Add(dbAds);
			_context.SaveChanges();
			return dbAds;
		}

		public DbAdd delete(string id)
		{
			throw new NotImplementedException();
		}

		public DbAdd GetAds(string id)
		{
			return _context.DbAdds.Find(id);
		}

		public IEnumerable<DbAdd> GetAllAds()
		{
			return _context.DbAdds;
		}

		public DbAdd update(DbAdd dbAds)
		{
			_context.Update(dbAds);
			_context.SaveChanges();
			return dbAds;
		}
	}
}
