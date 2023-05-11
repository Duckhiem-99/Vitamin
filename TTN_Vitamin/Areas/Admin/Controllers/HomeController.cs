using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTN_Vitamin.Models;
using PagedList;
using System.Net;

namespace TTN_Vitamin.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        VitaminHouseDB db = new VitaminHouseDB();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["idUserAD"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("DangNhapADMIN");
            }
        }
        [HttpGet]
        public ActionResult DangNhapADMIN()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhapADMIN(string email, string matKhau)
        {
            if (ModelState.IsValid)
            {
                var tendn = db.TaiKhoans.Where(u => u.email.Equals(email) && u.matKhau.Equals(matKhau)).ToList();
                if (tendn.Count() > 0 && tendn.Select(u => u.quyen).Contains("Nhân Viên"))
                {
                        Session["Email"] = tendn.FirstOrDefault().email;
                        Session["idUserAD"] = tendn.FirstOrDefault().email;
                    Session["HoTenNV"] = tendn.FirstOrDefault().hoTenDT;
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
            return RedirectToAction("DangNhapADMIN");
        }
    }
}