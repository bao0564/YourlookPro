using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("DbFavoriteProduct")]
    public class DbFavoriteProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int MaSp { get; set; }
        public int MaKh { get; set; }
        public DateTime CreatDate { get; set; }

        public virtual DbSanPham? Sanpham { get; set; }
        public virtual DbKhachHang? Khachhang { get; set; }
    }
}
