using Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace yourlook.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public int? MaDm { get; set; }
        public int? MaSp { get; set; }
        public string? TenSp { get; set; }
        public int NhomId { get; set; }
        public string? AnhSp { get; set; }
        public int SoLuongSp { get; set; }
        public decimal PriceMax { get; set; }
        public int GiamGia { get; set; }
        public decimal PriceMin { get; set; }
        public string MotaSp { get; set; }
        public bool IActive { get; set; }
        public bool IFavorite { get; set; }
        public bool IFeature { get; set; }
        public bool IHot { get; set; }
        public bool ISale { get; set; }
        public List<DbImg> Imgs { get; set; } = new List<DbImg>();
        public List<DbSize> SizeList { get; set; } = new List<DbSize>();
        public List<DbColor> ColorList { get; set; } = new List<DbColor>();
        public List<int> SelectedSizes { get; set; } = new List<int>();// Danh sách các size được chọn
        public List<int> SelectedColors { get; set; } = new List<int>(); // Danh sách các màu sắc được chọn
    }
}
