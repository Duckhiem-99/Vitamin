namespace TTN_Vitamin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            Blogs = new HashSet<Blog>();
            Blogs1 = new HashSet<Blog>();
            Blogs2 = new HashSet<Blog>();
            UpdateBlogs = new HashSet<UpdateBlog>();
            UpdateBlogs1 = new HashSet<UpdateBlog>();
            UpdateBlogs2 = new HashSet<UpdateBlog>();
        }

        [Key]
        [StringLength(100)]
        [DisplayName("Mã nhân viên")]
        public string maNV { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Họ tên")]
        public string hoTen { get; set; }

        [Required]
        [StringLength(16)]
        [DisplayName("Số điện thoại")]
        public string sDT { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Email nhân viên")]
        public string emailNV { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Địa chỉ")]
        public string diaChi { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Mật khẩu")]
        public string matKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog> Blogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog> Blogs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blog> Blogs2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UpdateBlog> UpdateBlogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UpdateBlog> UpdateBlogs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UpdateBlog> UpdateBlogs2 { get; set; }
    }
}
