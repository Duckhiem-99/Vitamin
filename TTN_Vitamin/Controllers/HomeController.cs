using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTN_Vitamin.Models;
using PagedList;
using System.Net;

namespace TTN_Vitamin.Controllers
{
    public class HomeController : Controller
    {
        VitaminHouseDB db = new VitaminHouseDB();
        public ActionResult Index(string id, string sortOder, string searchString, string currentFilter, int? page)
        {
			//test commint sourcetree
            List<SanPham> sanPhams = db.SanPhams.ToList();
            List<string> ListSort = new List<string> { "Tên từ Z-A","Giá từ thấp đến cao","Giá từ cao xuống thấp"};
            ViewBag.sortOder = new SelectList(ListSort);
            ViewBag.CurrentSort = sortOder;
            ViewBag.SapTheoTen = String.IsNullOrEmpty(sortOder) ? "name_desc" : "";
            ViewBag.SapTheoGia = sortOder == "Gia" ? "gia_desc" : "Gia";
            if (id == null)
            {
                sanPhams = db.SanPhams.Select(s => s).ToList();
            }
            else
            {
                sanPhams = db.SanPhams.Where(s => s.maDMC.Contains(id)).Select(s => s).ToList();
            }
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                sanPhams = db.SanPhams.Where(s => s.tenSanPham.Contains(searchString)).Select(s => s).ToList();
            }
            switch(sortOder)
            {
                case "Tên từ Z-A":
                    sanPhams = sanPhams.OrderByDescending(s => s.tenSanPham).ToList();
                    break;
                case "Giá từ thấp đến cao":
                    sanPhams = sanPhams.OrderBy(s => s.giaSanPham).ToList();
                    break;
                case "Giá từ cao xuống thấp":
                    sanPhams = sanPhams.OrderByDescending(s => s.giaSanPham).ToList();
                    break;
                default:
                    sanPhams = sanPhams.OrderBy(s => s.tenSanPham).ToList();
                    break;
            }

            int pageSize = 8;
            int pageNumber = (page ?? 1);
            return View(sanPhams.ToPagedList(pageNumber, pageSize));   
        }
        public ActionResult Blog()
        {
            return View(db.Blogs.ToList());
        }
        public ActionResult ChiTietBlogs(string id, string idm)
        {
            if (id == null && idm==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.SingleOrDefault(a=>a.maBlog==id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }
        public ActionResult ChiTietSanPham(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }
        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy([Bind(Include = "maNguoiDung,hoTen,diaChi,sDT,email,matKhau")] NguoiDung nd)
        {

                if (ModelState.IsValid)
                {
                nd.maNguoiDung = "MND" + db.NguoiDungs.Count() + 1;
                db.NguoiDungs.Add(nd);
                    db.SaveChanges();
                    return RedirectToAction("DangNhap");
                }
                return View(nd);
        }
        private string giohangsession = "giohangsession";
        [ChildActionOnly]
        public PartialViewResult _GioHang()
        {
            var gh = Session[giohangsession];
            var list = new List<GioHang>();
            if (gh != null)
            {
                list = (List<GioHang>)gh;
            }
            return PartialView(list);
        }
        public PartialViewResult _Nav()
        {
            var tendmc = db.DanhMucCons.Select(n => n);

            return PartialView(tendmc);
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(string email, string matKhau,string hoTen)
        {
            if (ModelState.IsValid)
            {
                var user = db.TaiKhoans.Where(u => u.email.Equals(email) && u.matKhau.Equals(matKhau)&&u.quyen=="Khách Hàng").ToList();
                var tennd = db.NguoiDungs.Where(a=>a.email.Equals(email) && a.matKhau.Equals(matKhau)).ToList();
                if (tennd.Count()>0)
                {
                    //add session
                    Session["email"] = tennd.FirstOrDefault().email;
                    Session["matKhau"] = tennd.FirstOrDefault().matKhau;            
                    Session["hoTen"] = tennd.FirstOrDefault().hoTen;
                    return RedirectToAction("Index");
                }
 
                else
                {
                    ViewBag.error = "Tài khoản hoặc mật khẩu sai! Vui lòng đăng nhập lại!!!!";
                }

            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
        public ActionResult DoiMatKhau()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DoiMatKhau(string email)
        {
            var nd = db.NguoiDungs.Where(a => a.email.Equals(email));
            if (ModelState.IsValid)
            {

                db.SaveChanges();
                return RedirectToAction("DangNhap");
            }
            return View(nd);
        }

    }
}