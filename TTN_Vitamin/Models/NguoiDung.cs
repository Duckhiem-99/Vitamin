namespace TTN_Vitamin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            DonHangs = new HashSet<DonHang>();
            DonHangs1 = new HashSet<DonHang>();
            Gopies = new HashSet<GopY>();
            Gopies1 = new HashSet<GopY>();
            Gopies2 = new HashSet<GopY>();
            Gopies3 = new HashSet<GopY>();
            Gopies4 = new HashSet<GopY>();
        }

        [Key]
        [StringLength(100)]
        [DisplayName("Mã khách hàng")]
        public string maNguoiDung { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Họ tên")]
        public string hoTen { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        public string diaChi { get; set; }

        [Required]
        [StringLength(16)]
        [DisplayName("Số điện thoại")]
        public string sDT { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Email")]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Mật khẩu")]
        public string matKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GopY> Gopies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GopY> Gopies1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GopY> Gopies2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GopY> Gopies3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GopY> Gopies4 { get; set; }
    }
}
