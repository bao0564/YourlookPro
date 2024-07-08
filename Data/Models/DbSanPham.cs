using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Data.Models
{
    [Table("DbSanPham")]
    public class DbSanPham:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSp { get; set; }

        public int MaDm { get; set; }

        public string? TenSp { get; set; }

        public int SaoDanhGia { get; set; }

        public int NhomId { get; set; }

        public string? AnhSp { get; set; }

		public int SoLuongSp { get; set; }

        public decimal PriceMax { get; set; }

        public int GiamGia { get; set; }

        public decimal PriceMin { get; set; }

        public int LuotXem { get; set; }

        public int LuotSold { get; set; }
        public string? MotaSp { get; set; }

        public bool IActive {  get; set; }
        public bool IFeature {  get; set; }
        public bool IHot {  get; set; }
        public bool ISale {  get; set; }

        public string? MetaKeywords { get; set; }

        public string? MetaDescriptions { get; set; }



        public virtual ICollection<DbImg> DbImgs { get; set; } = new List<DbImg>();

        public virtual DbDanhMuc? MaDanhMucsMaDm { get; set; } 

        public virtual DbGroup? Nhom { get; set; }
    }
}
