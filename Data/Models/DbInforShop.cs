
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Table("DbInforShop")]
    public class DbInforShop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Sdt { get; set; }

        public string? Email { get; set; }

        public string? Addres { get; set; }
    }
}
