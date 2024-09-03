using Data.Models;

namespace yourlook.Models
{
	public class ProductDetailViewModel
	{
		public DbSanPham SanPham { get; set; }
		public List<DbImg> ImgProduct { get; set; }
		public List<SizeColorViewModel> SizeColorProduct { get; set; }
		public bool IsFavorite { get; set; }
	}
	public class SizeColorViewModel
	{
		public string? SizeName { get; set; }
		public string? ColorName { get; set; }
		public string? ColorHex { get; set; } 
	}
}
