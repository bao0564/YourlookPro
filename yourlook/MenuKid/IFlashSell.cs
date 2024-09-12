using Data.Models;

namespace yourlook.MenuKid
{
    public interface IFlashSell
    {
        DbSanPham add(DbSanPham dbSanPham);
        DbSanPham update(DbSanPham dbSanPham);

        DbSanPham delete(string maSP);
        DbSanPham GetSanPham(string maSP);

        IEnumerable<DbSanPham> GetAllSanPhamFlashSell();
    }
}
