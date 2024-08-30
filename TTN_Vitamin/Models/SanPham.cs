namespace TTN_Vitamin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    [Serializable]
    public partial class SanPham
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
            ChiTietDonDatHangs1 = new HashSet<ChiTietDonDatHang>();
        }

        [Key]
        [StringLength(100)]
        [DisplayName("Mã sản phẩm")]
        public string maSP { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Mã danh mục con")]
        public string maDMC { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("Products")]
        public string tenSanPham { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("Thương hiệu")]
        public string thuongHieu { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ảnh sản phẩm")]
        public string anhSanPham { get; set; }
        [DisplayName("Giá sản phẩm")]
        public double giaSanPham { get; set; }
        [DisplayName("Số lượng")]
        public int? soLuong { get; set; }

        [Required]
        [StringLength(2000)]
        [DisplayName("Mô tả")]
        public string moTaSanPham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs1 { get; set; }

        public virtual DanhMucCon DanhMucCon { get; set; }

        public virtual DanhMucCon DanhMucCon1 { get; set; }
    }
	//test 27/03/2024
