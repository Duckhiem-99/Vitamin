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
    public class GopiesController : Controller
    {
        private VitaminHouseDB db = new VitaminHouseDB();

        // GET: Admin/Gopies
        public ActionResult Index()
        {
            var gopies = db.Gopies.Include(g => g.NguoiDung).Include(g => g.NguoiDung1).Include(g => g.NguoiDung2).Include(g => g.NguoiDung3).Include(g => g.NguoiDung4);
            return View(gopies.ToList());
        }

        // GET: Admin/Gopies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GopY gopY = db.Gopies.Find(id);
            if (gopY == null)
            {
                return HttpNotFound();
            }
            return View(gopY);
        }

        // GET: Admin/Gopies/Create
        public ActionResult Create()
        {
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen");
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen");
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen");
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen");
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen");
            return View();
        }

        // POST: Admin/Gopies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maGopY,maNguoiDung,noiDung")] GopY gopY)
        {
            if (ModelState.IsValid)
            {
                db.Gopies.Add(gopY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            return View(gopY);
        }

        // GET: Admin/Gopies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GopY gopY = db.Gopies.Find(id);
            if (gopY == null)
            {
                return HttpNotFound();
            }
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            return View(gopY);
        }

        // POST: Admin/Gopies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maGopY,maNguoiDung,noiDung")] GopY gopY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gopY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            ViewBag.maNguoiDung = new SelectList(db.NguoiDungs, "maNguoiDung", "hoTen", gopY.maNguoiDung);
            return View(gopY);
        }

        // GET: Admin/Gopies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GopY gopY = db.Gopies.Find(id);
            if (gopY == null)
            {
                return HttpNotFound();
            }
            return View(gopY);
        }

        // POST: Admin/Gopies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GopY gopY = db.Gopies.Find(id);
            db.Gopies.Remove(gopY);
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
