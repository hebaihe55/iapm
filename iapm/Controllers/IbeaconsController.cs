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
    public class IbeaconsController : Controller
    {
        private IAMPDBContext db = new IAMPDBContext();

        // GET: Ibeacons
        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["name"] == null)
            {
                RedirectToAction("index", "login");
            }
            return View(db.Ibeacons.ToList());
        }

        // GET: Ibeacons/Details/5
        public ActionResult Details(int? id)
        {
            if (System.Web.HttpContext.Current.Session["name"] == null)
            {
                RedirectToAction("index", "login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ibeacon ibeacon = db.Ibeacons.Find(id);
            if (ibeacon == null)
            {
                return HttpNotFound();
            }
            return View(ibeacon);
        }

        // GET: Ibeacons/Create
        public ActionResult Create()
        {
            if (System.Web.HttpContext.Current.Session["name"] == null)
            {
                RedirectToAction("index", "login");
            }
            return View();
        }

        // POST: Ibeacons/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ibeaconid,code,floor,bueness,demo,minifen,maxifen,dbtime,detime,dfen")] Ibeacon ibeacon)
        {
            if (ModelState.IsValid)
            {
                db.Ibeacons.Add(ibeacon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ibeacon);
        }

        // GET: Ibeacons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (System.Web.HttpContext.Current.Session["name"] == null)
            {
                RedirectToAction("index", "login");
            }
            if (System.Web.HttpContext.Current.Session["name"] == null)
            {
                RedirectToAction("index", "login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ibeacon ibeacon = db.Ibeacons.Find(id);
            if (ibeacon == null)
            {
                return HttpNotFound();
            }
            return View(ibeacon);
        }

        // POST: Ibeacons/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ibeaconid,code,floor,bueness,demo,minifen,maxifen,dbtime,detime,dfen")] Ibeacon ibeacon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ibeacon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ibeacon);
        }

        // GET: Ibeacons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (System.Web.HttpContext.Current.Session["name"] == null)
            {
                RedirectToAction("index", "login");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ibeacon ibeacon = db.Ibeacons.Find(id);
            if (ibeacon == null)
            {
                return HttpNotFound();
            }
            return View(ibeacon);
        }

        // POST: Ibeacons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ibeacon ibeacon = db.Ibeacons.Find(id);
            db.Ibeacons.Remove(ibeacon);
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
