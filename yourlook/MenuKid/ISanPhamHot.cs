using Data.Models;

namespace yourlook.MenuKid
{
	public interface ISanPhamHot
	{
		DbSanPham add(DbSanPham dbSanPham);
		DbSanPham update(DbSanPham dbSanPham);

		DbSanPham delete(string maSP);
		DbSanPham GetSanPham(string maSP);

		IEnumerable<DbSanPham> GetAllSanPhamHot();
	}
}
