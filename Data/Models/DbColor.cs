using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Table("DbColor")]
    public class DbColor:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "*")]

        public string? NameColor { get; set; }

        public string? Img { get; set; }
        public string? MaMau { get; set; }
    }
}
