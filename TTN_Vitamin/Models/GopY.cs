namespace TTN_Vitamin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GopY")]
    public partial class GopY
    {
        [Key]
        [StringLength(100)]
        [DisplayName("Mã góp ý")]
        public string maGopY { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Mã khách hàng")]
        public string maNguoiDung { get; set; }

        [Required]
        [StringLength(1000)]
        [DisplayName("Nội dung")]
        public string noiDung { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual NguoiDung NguoiDung1 { get; set; }

        public virtual NguoiDung NguoiDung2 { get; set; }

        public virtual NguoiDung NguoiDung3 { get; set; }

        public virtual NguoiDung NguoiDung4 { get; set; }
    }
}
