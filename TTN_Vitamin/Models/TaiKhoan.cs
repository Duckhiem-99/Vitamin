namespace TTN_Vitamin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(100)]
        [DisplayName("Email")]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Mật khẩu")]
        public string matKhau { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Quyền")]
        public string quyen { get; set; }
        [StringLength(100)]
        [DisplayName("Họ Tên")]
        public string hoTenDT { get; set; }
        //bbbbbbbbbbb
    }
}
