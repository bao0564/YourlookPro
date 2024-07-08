using Data.Models;

namespace yourlook.MenuKid
{
	public interface ICategory
	{
		DbDanhMuc add(DbDanhMuc dbDanhMuc);
		DbDanhMuc update(DbDanhMuc dbDanhMuc);

		DbDanhMuc delete(string maDM);
		DbDanhMuc GetDanhMuc(string maDM);

		IEnumerable<DbDanhMuc> GetAllDanhMuc();
	}
}
