using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Table("DbImg")]
    public class DbImg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MaSp { get; set; }
        public string? Img { get; set; }
        public bool IsDefault { get; set; }
        public string? Place { get; set; }

        public virtual DbSanPham? MaSpNavigation { get; set; }
    }
}
