namespace TTN_Vitamin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
            ChiTietDonDatHangs1 = new HashSet<ChiTietDonDatHang>();
        }

        [Key]
        [StringLength(100)]
        [DisplayName("Mã đơn hàng")]
        public string maDonHang { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Mã khách hàng")]
        public string maNguoiDung { get; set; }

        [StringLength(1000)]
        [DisplayName("Mô tả")]
        public string moTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs1 { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual NguoiDung NguoiDung1 { get; set; }
    }
}
