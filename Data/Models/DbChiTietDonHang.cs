using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Table("DbChiTietDonHang")]
    public class DbChiTietDonHang:CmAbstract
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int MaCTDH { get; set; }
		[ForeignKey("DbDonHang")]
		public int MaDh{  get; set; }
		public int MaSp { get; set; }
		public string? TenSp { get; set; }
		public string? AnhSp { get; set; }
		public int ColorId { get; set; }
		public string? ColorName { get; set; }
		public int SizeId { get; set; }
		public string? SizeName { get; set; }
		public int? SoLuongSp { get; set; }

		public decimal Price { get; set; }

		public virtual DbDonHang MaDhNavigation { get; set; }
	}
}
