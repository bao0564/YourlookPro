using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("DbDanhMuc")]
    public class DbDanhMuc:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDm { get; set; }
        [Required(ErrorMessage = "tên danh mục không được trống")]
        [StringLength(50)]
        public string? TenDm { get; set; }

        public string? AnhDaiDien { get; set; }

        public int? ThuTu { get; set; }

        public int? MaDmcha { get; set; }

        public virtual ICollection<DbSanPham> DbSanPhams { get; set; } = new List<DbSanPham>();

    }
}
