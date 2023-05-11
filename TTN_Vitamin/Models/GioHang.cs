using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TTN_Vitamin.Models
{
    [Serializable]
    public class GioHang
    {
        [Range(minimum: 1, maximum: 200)]
        public int quantity { get; set; }
        public SanPham sanpham { set; get; }
    }
}