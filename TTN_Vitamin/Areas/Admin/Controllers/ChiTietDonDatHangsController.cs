using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TTN_Vitamin.Models;

namespace TTN_Vitamin.Areas.Admin.Controllers
{
    public class ChiTietDonDatHangsController : Controller
    {
        private VitaminHouseDB db = new VitaminHouseDB();

        // GET: Admin/ChiTietDonDatHangs
        public ActionResult Index()
        {
            var chiTietDonDatHangs = db.ChiTietDonDatHangs.Include(c => c.DonHang).Include(c => c.DonHang1).Include(c => c.SanPham).Include(c => c.SanPham1);
            return View(chiTietDonDatHangs.ToList());
        }

        // GET: Admin/ChiTietDonDatHangs/Details/5
        public ActionResult Details(string id1,string id)
        {
            if (id1==null || id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonDatHang chiTietDonDatHang = db.ChiTietDonDatHangs.Find(id1,id);
            if (chiTietDonDatHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonDatHang);
        }

        // GET: Admin/ChiTietDonDatHangs/Create
        public ActionResult Create()
        {
            ViewBag.maDonHang = new SelectList(db.DonHangs, "maDonHang", "maNguoiDung");
            ViewBag.maDonHang = new SelectList(db.DonHangs, "maDonHang", "maNguoiDung");
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maDMC");
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maDMC");
            return View();
        }

        // POST: Admin/ChiTietDonDatHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSP,maDonHang,ngay,soLuong,tongTien")] ChiTietDonDatHang chiTietDonDatHang)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietDonDatHangs.Add(chiTietDonDatHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maDonHang = new SelectList(db.DonHangs, "maDonHang", "maNguoiDung", chiTietDonDatHang.maDonHang);
            ViewBag.maDonHang = new SelectList(db.DonHangs, "maDonHang", "maNguoiDung", chiTietDonDatHang.maDonHang);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maDMC", chiTietDonDatHang.maSP);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maDMC", chiTietDonDatHang.maSP);
            return View(chiTietDonDatHang);
        }

        // GET: Admin/ChiTietDonDatHangs/Edit/5
        public ActionResult Edit(string id1,string id)
        {
            if (id == null || id1 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonDatHang chiTietDonDatHang = db.ChiTietDonDatHangs.Find(id1, id);
            if (chiTietDonDatHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.maDonHang = new SelectList(db.DonHangs, "maDonHang", "maNguoiDung", chiTietDonDatHang.maDonHang);
            ViewBag.maDonHang = new SelectList(db.DonHangs, "maDonHang", "maNguoiDung", chiTietDonDatHang.maDonHang);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maDMC", chiTietDonDatHang.maSP);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maDMC", chiTietDonDatHang.maSP);
            return View(chiTietDonDatHang);
        }

        // POST: Admin/ChiTietDonDatHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSP,maDonHang,ngay,soLuong,tongTien")] ChiTietDonDatHang chiTietDonDatHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietDonDatHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maDonHang = new SelectList(db.DonHangs, "maDonHang", "maNguoiDung", chiTietDonDatHang.maDonHang);
            ViewBag.maDonHang = new SelectList(db.DonHangs, "maDonHang", "maNguoiDung", chiTietDonDatHang.maDonHang);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maDMC", chiTietDonDatHang.maSP);
            ViewBag.maSP = new SelectList(db.SanPhams, "maSP", "maDMC", chiTietDonDatHang.maSP);
            return View(chiTietDonDatHang);
        }

        // GET: Admin/ChiTietDonDatHangs/Delete/5
        public ActionResult Delete(string id,string id1)
        {
            if (id == null&&id1==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietDonDatHang chiTietDonDatHang = db.ChiTietDonDatHangs.Find(id,id1);
            if (chiTietDonDatHang == null)
            {
                return HttpNotFound();
            }
            return View(chiTietDonDatHang);
        }

        // POST: Admin/ChiTietDonDatHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id1)
        {
            ChiTietDonDatHang chiTietDonDatHang = db.ChiTietDonDatHangs.Find(id,id1);
            db.ChiTietDonDatHangs.Remove(chiTietDonDatHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
