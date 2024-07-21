using Data.Models;

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
}
