namespace TTN_Vitamin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhMucCon")]
    public partial class DanhMucCon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMucCon()
        {
            SanPhams = new HashSet<SanPham>();
            SanPhams1 = new HashSet<SanPham>();
        }

        [Key]
        [StringLength(50)]
        [DisplayName("Mã danh mục con")]
        public string maDMC { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Mã danh mục")]
        public string maDM { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tên danh mục con")]
        public string tenDMC { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual DanhMuc DanhMuc1 { get; set; }

        public virtual DanhMuc DanhMuc2 { get; set; }

        public virtual DanhMuc DanhMuc3 { get; set; }

        public virtual DanhMuc DanhMuc4 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams1 { get; set; }
    }
}
