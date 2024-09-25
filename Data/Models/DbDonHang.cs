using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Table("DbDonHang")]
    public class DbDonHang : CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaDh { get; set; }
        public int MaKh { get; set; }
        public string? EmailKh {  get; set; }
        public string? TenKh { get; set; }
        public string? Sdt { get; set; }
        public string? City {  get; set; }
        public string? District { get; set; }
        public string? Ward { get; set; }
        public string? DiaChi { get; set; }
        public decimal? TongTien { get; set; }
        public int soluong {  get; set; }
        public int? PaymentId { get; set; }
        public string? PaymentName {  get; set; }
        public string? MaVoucher { get; set; }
        public string? ValueVoucher { get; set; }
        public string? GhiChu { get; set; }
        public bool ODSuccess { get; set; }
        public bool ODReadly { get; set; }
        public bool ODTransported { get; set; }
        public bool Complete { get; set; }
        public virtual ICollection<DbChiTietDonHang> DbChiTietDonHangs { get; set; } = new List<DbChiTietDonHang>();

        public virtual DbKhachHang? MaKhNavigation { get; set; }
    }
}
