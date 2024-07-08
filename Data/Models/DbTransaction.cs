using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Table("DbTransaction")]
    public class DbTransaction:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int MaKh { get; set; }

        public string? TenKh { get; set; }

        public string? Email { get; set; }

        public string? Sdt { get; set; }

        public decimal? Amount { get; set; }

        public int? PaymentId { get; set; }

        public string? Mess { get; set; }

        public virtual DbKhachHang MaKhNavigation { get; set; } = null!;
    }
}
