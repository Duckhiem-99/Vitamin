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
    public class UpdateBlogsController : Controller
    {
        private VitaminHouseDB db = new VitaminHouseDB();

        // GET: Admin/UpdateBlogs
        public ActionResult Index()
        {
            var updateBlogs = db.UpdateBlogs.Include(u => u.Blog).Include(u => u.Blog1).Include(u => u.Blog2).Include(u => u.NhanVien).Include(u => u.NhanVien1).Include(u => u.NhanVien2);
            return View(updateBlogs.ToList());
        }

        // GET: Admin/UpdateBlogs/Details/5
        public ActionResult Details(string id,string id1)
        {
            if (id == null||id1==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateBlog updateBlog = db.UpdateBlogs.Find(id,id1);
            if (updateBlog == null)
            {
                return HttpNotFound();
            }
            return View(updateBlog);
        }

        // GET: Admin/UpdateBlogs/Create
        public ActionResult Create()
        {
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV");
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV");
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV");
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen");
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen");
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen");
            return View();
        }

        // POST: Admin/UpdateBlogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maNV,maBlog,ngayUpdate")] UpdateBlog updateBlog)
        {
            if (ModelState.IsValid)
            {
                db.UpdateBlogs.Add(updateBlog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV", updateBlog.maBlog);
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV", updateBlog.maBlog);
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV", updateBlog.maBlog);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", updateBlog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", updateBlog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", updateBlog.maNV);
            return View(updateBlog);
        }

        // GET: Admin/UpdateBlogs/Edit/5
        public ActionResult Edit(string id,string id1)
        {
            if (id == null||id1==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateBlog updateBlog = db.UpdateBlogs.Find(id,id1);
            if (updateBlog == null)
            {
                return HttpNotFound();
            }
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV", updateBlog.maBlog);
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV", updateBlog.maBlog);
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV", updateBlog.maBlog);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", updateBlog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", updateBlog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", updateBlog.maNV);
            return View(updateBlog);
        }

        // POST: Admin/UpdateBlogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maNV,maBlog,ngayUpdate")] UpdateBlog updateBlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(updateBlog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV", updateBlog.maBlog);
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV", updateBlog.maBlog);
            ViewBag.maBlog = new SelectList(db.Blogs, "maBlog", "maNV", updateBlog.maBlog);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", updateBlog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", updateBlog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", updateBlog.maNV);
            return View(updateBlog);
        }

        // GET: Admin/UpdateBlogs/Delete/5
        public ActionResult Delete(string id,string id1)
        {
            if (id == null||id1==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UpdateBlog updateBlog = db.UpdateBlogs.Find(id,id1);
            if (updateBlog == null)
            {
                return HttpNotFound();
            }
            return View(updateBlog);
        }

        // POST: Admin/UpdateBlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id,string id1)
        {
            UpdateBlog updateBlog = db.UpdateBlogs.Find(id,id1);
            db.UpdateBlogs.Remove(updateBlog);
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
