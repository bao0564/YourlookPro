using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Table("DbMenu")]
    public class DbMenu:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }

        public string? TenMn { get; set; }

        public string? Mota { get; set; }

        public string? Links { get; set; }

        public int? ThuTu { get; set; }
        public bool IActive { get; set; }

    }
}
