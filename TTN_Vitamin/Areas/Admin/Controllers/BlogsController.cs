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
    public class BlogsController : Controller
    {
        private VitaminHouseDB db = new VitaminHouseDB();

        // GET: Admin/Blogs_test
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.NhanVien).Include(b => b.NhanVien1).Include(b => b.NhanVien2);
            return View(blogs.ToList());
        }

        // GET: Admin/Blogs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen");
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen");
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maBlog,maNV,anhBlog,tieuDe,noiDung")] Blog blog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    blog.anhBlog = "";
                    var f = Request.Files["ImageFile"];
                    if(f!=null && f.ContentLength>0)
                    {
                        string FileName = System.IO.Path.GetFileName(f.FileName);
                        string UploadPath = Server.MapPath("~/AnhSP/VTM/Ảnh Blog" + FileName);
                        f.SaveAs(UploadPath);
                        blog.anhBlog = FileName;
                    }    
                    db.Blogs.Add(blog);
                    db.SaveChanges();
                   
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu!" + ex.Message;
                return View(blog);
            }
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", blog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", blog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", blog.maNV);

        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", blog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", blog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", blog.maNV);
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maBlog,maNV,anhBlog,tieuDe,noiDung")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var f = Request.Files["ImageFile"];
                if(f!=null && f.ContentLength>0)
                {
                    string FileName = System.IO.Path.GetFileName(f.FileName);
                    string UploadPath = Server.MapPath("~/AnhSP/VTM/" + FileName);
                    f.SaveAs(UploadPath);
                    blog.anhBlog = FileName;
                }
                db.Entry(blog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", blog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", blog.maNV);
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", blog.maNV);
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Blog blog = db.Blogs.Find(id);
            try
            {
            db.Blogs.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Không thể xóa được bản ghi này!!!" + ex.Message;
                return View("Delete",blog);
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
