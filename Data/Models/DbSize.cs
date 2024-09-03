using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("DbSize")]
    public class DbSize:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SizeId { get; set; }

        [Required(ErrorMessage = "*")]

        public string? NameSize { get; set; }

		public virtual ICollection<DbChiTietSanPham> DbChiTietSanPhams { get; set; } = new List<DbChiTietSanPham>();
	}
}
