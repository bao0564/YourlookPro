using Data.Models;

namespace yourlook.Models
{
    public class ViewAllDetail
    {
        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public string AnhSp { get; set; }
        public decimal PriceMax { get; set; }
        public int GiamGia { get; set; }
        public decimal PriceMin { get; set; }
        public bool IFavorite { get; set; }
        public int LuotXem { get; set; }
        public List<DbSize> Sizes { get; set; }
        public List<DbColor> Colors { get; set; }
    }
}
