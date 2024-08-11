using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("DbAddres")]
    public partial class DbAddres:CmAbstract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAddress { get; set; }

        public int MaKh { get; set; }

        public string TenNguoiNhan { get; set; }

        public string Sdt { get; set; }

        public string Addres { get; set; }

        public string City { get; set; }

        public string QuanHuyen { get; set; }

        public string PhuongXa { get; set; }

        public string? GhiChu { get; set; }
        public bool Idefault { get; set; }

        public virtual DbKhachHang? MaKhNavigation { get; set; }
    }
}

