using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Table("DbPayment")]
    public class DbPayment:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "*")]

        public string? PaymentName { get; set; }
        public string? Icon { get; set; }

        public virtual ICollection<DbDonHang> DbDonHangs { get; set; } = new List<DbDonHang>();
    }
}
