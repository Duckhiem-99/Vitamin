using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TTN_Vitamin.Models
{
    public partial class VitaminHouseDB : DbContext
    {
        public VitaminHouseDB()
            : base("name=VitaminHouseDB")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DanhMucCon> DanhMucCons { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<GopY> Gopies { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<UpdateBlog> UpdateBlogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>()
                .Property(e => e.maBlog)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .Property(e => e.maNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.UpdateBlogs)
                .WithRequired(e => e.Blog)
                .HasForeignKey(e => e.maBlog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.UpdateBlogs1)
                .WithRequired(e => e.Blog1)
                .HasForeignKey(e => e.maBlog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Blog>()
                .HasMany(e => e.UpdateBlogs2)
                .WithRequired(e => e.Blog2)
                .HasForeignKey(e => e.maBlog)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChiTietDonDatHang>()
                .Property(e => e.maSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonDatHang>()
                .Property(e => e.maDonHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .Property(e => e.maDM)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.DanhMucCons)
                .WithRequired(e => e.DanhMuc)
                .HasForeignKey(e => e.maDM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.DanhMucCons1)
                .WithRequired(e => e.DanhMuc1)
                .HasForeignKey(e => e.maDM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.DanhMucCons2)
                .WithRequired(e => e.DanhMuc2)
                .HasForeignKey(e => e.maDM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.DanhMucCons3)
                .WithRequired(e => e.DanhMuc3)
                .HasForeignKey(e => e.maDM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.DanhMucCons4)
                .WithRequired(e => e.DanhMuc4)
                .HasForeignKey(e => e.maDM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMucCon>()
                .Property(e => e.maDMC)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucCon>()
                .Property(e => e.maDM)
                .IsUnicode(false);

            modelBuilder.Entity<DanhMucCon>()
                .HasMany(e => e.SanPhams)
                .WithRequired(e => e.DanhMucCon)
                .HasForeignKey(e => e.maDMC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DanhMucCon>()
                .HasMany(e => e.SanPhams1)
                .WithRequired(e => e.DanhMucCon1)
                .HasForeignKey(e => e.maDMC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.maDonHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .Property(e => e.maNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonDatHangs)
                .WithRequired(e => e.DonHang)
                .HasForeignKey(e => e.maDonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DonHang>()
                .HasMany(e => e.ChiTietDonDatHangs1)
                .WithRequired(e => e.DonHang1)
                .HasForeignKey(e => e.maDonHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GopY>()
                .Property(e => e.maGopY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GopY>()
                .Property(e => e.maNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.maNguoiDung)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.sDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.DonHangs)
                .WithRequired(e => e.NguoiDung)
                .HasForeignKey(e => e.maNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.DonHangs1)
                .WithRequired(e => e.NguoiDung1)
                .HasForeignKey(e => e.maNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.Gopies)
                .WithRequired(e => e.NguoiDung)
                .HasForeignKey(e => e.maNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.Gopies1)
                .WithRequired(e => e.NguoiDung1)
                .HasForeignKey(e => e.maNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.Gopies2)
                .WithRequired(e => e.NguoiDung2)
                .HasForeignKey(e => e.maNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.Gopies3)
                .WithRequired(e => e.NguoiDung3)
                .HasForeignKey(e => e.maNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.Gopies4)
                .WithRequired(e => e.NguoiDung4)
                .HasForeignKey(e => e.maNguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.maNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.sDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.emailNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.matKhau)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.Blogs)
                .WithRequired(e => e.NhanVien)
                .HasForeignKey(e => e.maNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.Blogs1)
                .WithRequired(e => e.NhanVien1)
                .HasForeignKey(e => e.maNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.Blogs2)
                .WithRequired(e => e.NhanVien2)
                .HasForeignKey(e => e.maNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.UpdateBlogs)
                .WithRequired(e => e.NhanVien)
                .HasForeignKey(e => e.maNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.UpdateBlogs1)
                .WithRequired(e => e.NhanVien1)
                .HasForeignKey(e => e.maNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.UpdateBlogs2)
                .WithRequired(e => e.NhanVien2)
                .HasForeignKey(e => e.maNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.maSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.maDMC)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDonDatHangs)
                .WithRequired(e => e.SanPham)
                .HasForeignKey(e => e.maSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.ChiTietDonDatHangs1)
                .WithRequired(e => e.SanPham1)
                .HasForeignKey(e => e.maSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UpdateBlog>()
                .Property(e => e.maNV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UpdateBlog>()
                .Property(e => e.maBlog)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
