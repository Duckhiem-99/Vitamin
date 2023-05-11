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
    public class DanhMucConsController : Controller
    {
        private VitaminHouseDB db = new VitaminHouseDB();

        // GET: Admin/DanhMucCons
        public ActionResult Index()
        {
            var danhMucCons = db.DanhMucCons.Include(d => d.DanhMuc).Include(d => d.DanhMuc1).Include(d => d.DanhMuc2).Include(d => d.DanhMuc3).Include(d => d.DanhMuc4);
            return View(danhMucCons.ToList());
        }

        // GET: Admin/DanhMucCons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCon danhMucCon = db.DanhMucCons.Find(id);
            if (danhMucCon == null)
            {
                return HttpNotFound();
            }
            return View(danhMucCon);
        }

        // GET: Admin/DanhMucCons/Create
        public ActionResult Create()
        {
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM");
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM");
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM");
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM");
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM");
            return View();
        }

        // POST: Admin/DanhMucCons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maDMC,maDM,tenDMC")] DanhMucCon danhMucCon)
        {
            try
            {
            if (ModelState.IsValid)
            {
                db.DanhMucCons.Add(danhMucCon);
                db.SaveChanges();
                
            }
            return RedirectToAction("Index");
            }

            catch(Exception ex)
            {
                ViewBag.Error = "Lỗi nhập dữ liệu" + ex.Message;
                return View(danhMucCon);
            }    
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
        }

        // GET: Admin/DanhMucCons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCon danhMucCon = db.DanhMucCons.Find(id);
            if (danhMucCon == null)
            {
                return HttpNotFound();
            }
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            return View(danhMucCon);
        }

        // POST: Admin/DanhMucCons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maDMC,maDM,tenDMC")] DanhMucCon danhMucCon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(danhMucCon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            ViewBag.maDM = new SelectList(db.DanhMucs, "maDM", "tenDM", danhMucCon.maDM);
            return View(danhMucCon);
        }

        // GET: Admin/DanhMucCons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMucCon danhMucCon = db.DanhMucCons.Find(id);
            if (danhMucCon == null)
            {
                return HttpNotFound();
            }
            return View(danhMucCon);
        }

        // POST: Admin/DanhMucCons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DanhMucCon danhMucCon = db.DanhMucCons.Find(id);
            try
            {
            db.DanhMucCons.Remove(danhMucCon);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Không thể xóa bản ghi này!!!" + ex.Message;
                return View("Delete", danhMucCon);
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
