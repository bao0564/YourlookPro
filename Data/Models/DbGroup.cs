using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Table("DbGroup")]
    public class DbGroup:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NhomId { get; set; }

        [Required(ErrorMessage = "*")]

        public string? GroupName { get; set; }

        public virtual ICollection<DbSanPham> DbSanPhams { get; set; } = new List<DbSanPham>();
    }
}
