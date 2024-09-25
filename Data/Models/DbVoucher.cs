using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("DbVoucher")]
    public class DbVoucher:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idVoucher {  get; set; }
        public string MaVoucher {  get; set; }
        public string? IconVoucher {  get; set; }
        public int valueVoucher { get; set; }
        public string MotaVoucher {  get; set; }
    }
}
