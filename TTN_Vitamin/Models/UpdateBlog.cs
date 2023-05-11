namespace TTN_Vitamin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UpdateBlog")]
    public partial class UpdateBlog
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        [DisplayName("Mã nhân viên")]
        public string maNV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        [DisplayName("Mã Blog")]
        public string maBlog { get; set; }
        [DisplayName("Ngày cập nhật")]
        public DateTime ngayUpdate { get; set; }

        public virtual Blog Blog { get; set; }

        public virtual Blog Blog1 { get; set; }

        public virtual Blog Blog2 { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual NhanVien NhanVien1 { get; set; }

        public virtual NhanVien NhanVien2 { get; set; }
    }
}
