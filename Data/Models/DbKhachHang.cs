using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Data.Models
{
    [Table("DbKhachHang")]
    public class DbKhachHang:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaKh { get; set; }

        public string? TenKh { get; set; }

        public string? Img { get; set; }

        public string? GioiTinh { get; set; }

        public string? Addres { get; set; }

        public string? Sdt { get; set; }

        public string Email { get; set; } = null!;

        public string? Passwords { get; set; }
        public virtual ICollection<DbAddres> DbAddreses { get; set; } = new List<DbAddres>();

        public virtual ICollection<DbDonHang> DbDonHangs { get; set; } = new List<DbDonHang>();

        public virtual ICollection<DbTransaction> DbTransactions { get; set; } = new List<DbTransaction>();
    }
}
