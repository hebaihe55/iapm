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
    public class Report2Controller : BaseController
    {
        private IAMPDBContext db = new IAMPDBContext();

        // GET: Report2
        public ActionResult Index()
        {
            return View(db.Report2s.ToList());
        }

        // GET: Report2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report2 report2 = db.Report2s.Find(id);
            if (report2 == null)
            {
                return HttpNotFound();
            }
            return View(report2);
        }

        // GET: Report2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report2/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Report2id,R2biaoqian,R2jishu")] Report2 report2)
        {
            if (ModelState.IsValid)
            {
                db.Report2s.Add(report2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(report2);
        }

        // GET: Report2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report2 report2 = db.Report2s.Find(id);
            if (report2 == null)
            {
                return HttpNotFound();
            }
            return View(report2);
        }

        // POST: Report2/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Report2id,R2biaoqian,R2jishu")] Report2 report2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(report2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(report2);
        }

        // GET: Report2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Report2 report2 = db.Report2s.Find(id);
            if (report2 == null)
            {
                return HttpNotFound();
            }
            return View(report2);
        }

        // POST: Report2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Report2 report2 = db.Report2s.Find(id);
            db.Report2s.Remove(report2);
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
