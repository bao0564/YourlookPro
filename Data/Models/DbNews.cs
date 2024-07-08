using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Data.Models
{
    [Table("DbNews")]
    public class DbNews:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bạn không để trống tiêu đề tin")]
        [StringLength(150)]
        public string? Title { get; set; }
        public string? Alias { get; set; }
        public string? Mota { get; set; }   
        public string? Detail { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDescription { get; set; }
        public string? SeoKeywords { get; set; }
        public bool IsActive { get; set; }
        public virtual DbDanhMuc? MaDanhMucsMaDm { get; set; }
    }
}
