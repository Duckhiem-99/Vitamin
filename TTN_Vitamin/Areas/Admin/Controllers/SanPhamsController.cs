using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TTN_Vitamin.Models;
using System.IO;

namespace TTN_Vitamin.Areas.Admin.Controllers
{
    public class SanPhamsController : Controller
    {
        private VitaminHouseDB db = new VitaminHouseDB();

        // GET: Admin/SanPhams
        public ActionResult Index()
        {
            var sanPhams = db.SanPhams.Include(s => s.DanhMucCon).Include(s => s.DanhMucCon1);
            return View(sanPhams.ToList());
        }

        // GET: Admin/SanPhams/Details/5
        public ActionResult Details(string id)
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

        // GET: Admin/SanPhams/Create
        public ActionResult Create()
        {
            ViewBag.maDMC = new SelectList(db.DanhMucCons, "maDMC", "maDM");
            ViewBag.maDMC = new SelectList(db.DanhMucCons, "maDMC", "maDM");
            return View();
        }

        // POST: Admin/SanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maSP,maDMC,tenSanPham,thuongHieu,anhSanPham,giaSanPham,soLuong,moTaSanPham")] SanPham sanPham)
        {
            try
            {
            if (ModelState.IsValid)
            {
                    sanPham.anhSanPham = "";
                    var f = Request.Files["ImageFile"];
                    if (f != null && f.ContentLength > 0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/AnhSP/VTM/" + FileName);
                        f.SaveAs(UploadPath);
                        sanPham.anhSanPham = FileName;
                    }
                    db.SanPhams.Add(sanPham);
                db.SaveChanges();

            }

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Lỗi dữ liệu" + ex.Message;
                return View(sanPham);
            }
            ViewBag.maDMC = new SelectList(db.DanhMucCons, "maDMC", "maDM", sanPham.maDMC);
            ViewBag.maDMC = new SelectList(db.DanhMucCons, "maDMC", "maDM", sanPham.maDMC);

        }

        // GET: Admin/SanPhams/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.maDMC = new SelectList(db.DanhMucCons, "maDMC", "maDM", sanPham.maDMC);
            ViewBag.maDMC = new SelectList(db.DanhMucCons, "maDMC", "maDM", sanPham.maDMC);
            return View(sanPham);
        }

        // POST: Admin/SanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maSP,maDMC,tenSanPham,thuongHieu,anhSanPham,giaSanPham,soLuong,moTaSanPham")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["ImageFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/AnhSP/VTM/" + FileName);
                    f.SaveAs(UploadPath);
                    sanPham.anhSanPham = FileName;
                }
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maDMC = new SelectList(db.DanhMucCons, "maDMC", "maDM", sanPham.maDMC);
            ViewBag.maDMC = new SelectList(db.DanhMucCons, "maDMC", "maDM", sanPham.maDMC);
            return View(sanPham);
        }

        // GET: Admin/SanPhams/Delete/5
        public ActionResult Delete(string id)
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

        // POST: Admin/SanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            try
            {
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Không thể xóa" + ex.Message;
                return View("Delete", sanPham);
            }

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
