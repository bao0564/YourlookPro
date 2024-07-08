using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Table("DbChiTietImg")]
    public class DbChiTietImg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChiTietSp { get; set; }

        public string Img { get; set; } = null!;

        public string? Place { get; set; }
    }
}
