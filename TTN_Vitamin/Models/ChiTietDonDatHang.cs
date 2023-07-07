namespace TTN_Vitamin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonDatHang")]
    public partial class ChiTietDonDatHang
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string maSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        [DisplayName("Mã đơn hàng")]
        public string maDonHang { get; set; }
        [DisplayName("Ngày đặt hàng")]
        public DateTime ngay { get; set; }
        [DisplayName("Số lượng")]
        public int soLuong { get; set; }
        [DisplayName("Tổng tiền")]
        public double tongTien { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual DonHang DonHang1 { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual SanPham SanPham1 { get; set; }
		//khiem thái bình
    }
}
