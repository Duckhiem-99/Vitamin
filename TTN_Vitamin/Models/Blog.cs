namespace TTN_Vitamin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Blog()
        {
            UpdateBlogs = new HashSet<UpdateBlog>();
            UpdateBlogs1 = new HashSet<UpdateBlog>();
            UpdateBlogs2 = new HashSet<UpdateBlog>();
        }

        [Key]
        [StringLength(100)]
        [DisplayName("Mã Blog")]
        public string maBlog { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Mã nhân viên")]
        public string maNV { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Ảnh Blog")]
        public string anhBlog { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Tiêu đề")]
        public string tieuDe { get; set; }

        [Required]
        [StringLength(2000)]
        [DisplayName("Nội dung")]
        public string noiDung { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual NhanVien NhanVien1 { get; set; }

        public virtual NhanVien NhanVien2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UpdateBlog> UpdateBlogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UpdateBlog> UpdateBlogs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UpdateBlog> UpdateBlogs2 { get; set; }
    }
}
