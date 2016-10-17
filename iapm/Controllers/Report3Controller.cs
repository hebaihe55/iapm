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
    public class Report3Controller : BaseController
    {
        private IAMPDBContext db = new IAMPDBContext();

        // GET: Report3
        public ActionResult Index()
        {
            return View(db.Report3s.ToList());
        }

        // GET: Report3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report3 report3 = db.Report3s.Find(id);
            if (report3 == null)
            {
                return HttpNotFound();
            }
            return View(report3);
        }

        // GET: Report3/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report3/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Report3id,R3date,R3pnum,R3jbnum,R3cynum,R3fc,R3prize,R3LG2,R3LG1,R3L1,R3L2,R3L3,R3L4,R3L5,R3L6")] Report3 report3)
        {
            if (ModelState.IsValid)
            {
                db.Report3s.Add(report3);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(report3);
        }

        // GET: Report3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report3 report3 = db.Report3s.Find(id);
            if (report3 == null)
            {
                return HttpNotFound();
            }
            return View(report3);
        }

        // POST: Report3/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Report3id,R3date,R3pnum,R3jbnum,R3cynum,R3fc,R3prize,R3LG2,R3LG1,R3L1,R3L2,R3L3,R3L4,R3L5,R3L6")] Report3 report3)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report3).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(report3);
        }

        // GET: Report3/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report3 report3 = db.Report3s.Find(id);
            if (report3 == null)
            {
                return HttpNotFound();
            }
            return View(report3);
        }

        // POST: Report3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report3 report3 = db.Report3s.Find(id);
            db.Report3s.Remove(report3);
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
