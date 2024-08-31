using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
	[Table("DbChiTietSanPham")]
	public class DbChiTietSanPham
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int MaSpChiTiet { get; set; }

		public int MaSp { get; set; } 
		public int MaSize { get; set; } 
		public int MaMau { get; set; }  
		public int SoLuongTon { get; set; }

		public virtual DbSanPham SanPham { get; set; }
		public virtual DbSize Size { get; set; }
		public virtual DbColor Color{ get; set; }
	}
}
