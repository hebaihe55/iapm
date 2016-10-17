using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iapm.Models;

namespace iapm.Controllers
{
    public class Report1Controller : BaseController
    {
        private IAMPDBContext db = new IAMPDBContext();

        // GET: Report1
        public ActionResult Index()
        {
            return View(db.Report1s.ToList());
        }

        // GET: Report1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report1 report1 = db.Report1s.Find(id);
            if (report1 == null)
            {
                return HttpNotFound();
            }
            return View(report1);
        }

        // GET: Report1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report1/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Report1id,R1date,R1pnum,R1cnum,R1dianji,R1cishu")] Report1 report1)
        {
            if (ModelState.IsValid)
            {
                db.Report1s.Add(report1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(report1);
        }

        // GET: Report1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report1 report1 = db.Report1s.Find(id);
            if (report1 == null)
            {
                return HttpNotFound();
            }
            return View(report1);
        }

        // POST: Report1/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Report1id,R1date,R1pnum,R1cnum,R1dianji,R1cishu")] Report1 report1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report1).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(report1);
        }

        // GET: Report1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report1 report1 = db.Report1s.Find(id);
            if (report1 == null)
            {
                return HttpNotFound();
            }
            return View(report1);
        }

        // POST: Report1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report1 report1 = db.Report1s.Find(id);
            db.Report1s.Remove(report1);
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
