using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTN_Vitamin.Models;

namespace TTN_Vitamin.Controllers
{
    public class GioHangController : Controller 
    {
        VitaminHouseDB db = new VitaminHouseDB();
        public static string giohangsession = "giohangsession";
        public ActionResult Index()
        {
            var gh = Session[giohangsession]; 
            var list = new List<GioHang>();
            if (gh != null)
            {
                list = (List<GioHang>)gh;
            }
            return View(list);
        }
        public ActionResult AddItem(string masp)
        {

            var product = db.SanPhams
                                .Where(p => p.maSP.Equals(masp))
                                 .FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound("Không có sản phẩm");
            }
            //add cart 
            var cart = Session[giohangsession];
            if (cart != null)
            {
                var list = (List<GioHang>)cart;
                var cartItem = list.Find(p => p.sanpham.maSP.Equals(masp));
                if (cartItem != null)
                {
                    cartItem.quantity++;
                }
                else
                {
                    var item = new GioHang();
                    item.sanpham = product;
                    item.quantity = 1;
                    list.Add(item);
                }
                Session[giohangsession] = list;
                return RedirectToAction("Index", "Home");

            }
            else
            {
                var item = new GioHang();
                item.sanpham = product;
                item.quantity = 1;
                var list = new List<GioHang>();
                list.Add(item);
                //gán vào session
                Session[giohangsession] = list;
                return RedirectToAction("Index");
            }



        }
        /*-----Update----*/

        [HttpPost]
        public ActionResult UpdateCart(string masp, int quantity)
        {
            var cart = Session[giohangsession];
            var list = (List<GioHang>)cart;
            var cartItem = list.Find(p => p.sanpham.maSP.Equals(masp));
            if (cartItem != null)
            {
                if (quantity > 0)
                {
                    cartItem.quantity = quantity;
                    Session[giohangsession] = list;
                }
                else
                {
                    ViewBag.error = "--Lỗi-- số lượng phải lớn hơn 0 và là số";
                }
            }
            // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            return RedirectToAction("Index");
        }
        public ActionResult RemoveCart(string masp)
        {
            var gh = Session[giohangsession];
            var list = (List<GioHang>)gh;
            var cartItem = list.Find(p => p.sanpham.maSP == masp);
            if (cartItem != null)
            {
                list.Remove(cartItem);
            }
            Session[giohangsession] = list;
            return RedirectToAction("Index");
        }
        public ActionResult PayMent()
        {
            List<string> listphuongthuc = new List<string> { "Tiền mặt khi nhận hàng", "Thanh toán online qua thẻ" };
            ViewBag.phuongthuc = new SelectList(listphuongthuc);
            return View();
        }

        // POST: Admin/DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult PayMent(string hoten, string diachi, string email, string sdt, string ghichu,int soluong)
        {
            var cart = Session[giohangsession];
            var list = (List<GioHang>)cart;
            List<SanPham> sp = db.SanPhams.ToList();
            NguoiDung kh = new NguoiDung();
            kh.maNguoiDung = "MND" + db.NguoiDungs.Count() + 1;
            kh.hoTen = hoten;
            kh.diaChi = diachi;
            kh.email = email;
            kh.sDT = sdt;
            kh.email = "hihi@gmail.com";
            kh.matKhau = "ngathung";
            db.NguoiDungs.Add(kh);
            db.SaveChanges();
            string makHnow = kh.maNguoiDung;
            //try catch
            DonHang dh = new DonHang();
            dh.maNguoiDung = makHnow;
            dh.maDonHang = "MDH" + db.DonHangs.Count() + 1;
            dh.moTa = ghichu;
            db.SaveChanges();
            db.DonHangs.Add(dh);
            string maDHnow = dh.maDonHang;
            foreach (var item in list)
            {
                ChiTietDonDatHang orderDetail = new ChiTietDonDatHang();
                orderDetail.maSP = item.sanpham.maSP;
                string maspNow = orderDetail.maSP;
                orderDetail.maDonHang = maDHnow;
                orderDetail.soLuong = item.quantity;
                orderDetail.tongTien = item.sanpham.giaSanPham;
                orderDetail.ngay = DateTime.Now;
                db.ChiTietDonDatHangs.Add(orderDetail);
                db.SaveChanges();

            }

            
            return Redirect("Success");
        }

        public ActionResult Success()
        {
            return View();
        }
		
		//test
    }
}