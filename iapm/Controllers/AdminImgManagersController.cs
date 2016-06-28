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
    public class AdminImgManagersController : Controller
    {
        private IAMPDBContext db = new IAMPDBContext();

        // GET: AdminImgManagers
        public ActionResult Index()
        {
            return View(db.ImgManagers.ToList());
        }

        // GET: AdminImgManagers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImgManager imgManager = db.ImgManagers.Find(id);
            if (imgManager == null)
            {
                return HttpNotFound();
            }
            return View(imgManager);
        }

        // GET: AdminImgManagers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminImgManagers/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,imgurl,imgname,imgsize,pagename,cctime")] ImgManager imgManager)
        {
            if (ModelState.IsValid)
            {
                db.ImgManagers.Add(imgManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imgManager);
        }

        // GET: AdminImgManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImgManager imgManager = db.ImgManagers.Find(id);
            if (imgManager == null)
            {
                return HttpNotFound();
            }
            return View(imgManager);
        }

        // POST: AdminImgManagers/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,imgurl,imgname,imgsize,pagename,cctime")] ImgManager imgManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imgManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imgManager);
        }

        // GET: AdminImgManagers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImgManager imgManager = db.ImgManagers.Find(id);
            if (imgManager == null)
            {
                return HttpNotFound();
            }
            return View(imgManager);
        }

        // POST: AdminImgManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImgManager imgManager = db.ImgManagers.Find(id);
            db.ImgManagers.Remove(imgManager);
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
