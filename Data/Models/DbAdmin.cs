using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("DbAdmin")]
    public class DbAdmin:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required(ErrorMessage = "*")]
        public string EmailDn {  get; set; }

        public string? NameDn { get; set; }

        [Required(ErrorMessage = "*")]

        public string PasswordDn { get; set; }

        [Required(ErrorMessage = "*")]

        public string? ChucVu { get; set; }
        public string? Quyen {  get; set; }

        public bool IsExternalAccount { get; set; }
    }
}
