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
    public class AdminTicketsController : Controller
    {
        private IAMPDBContext db = new IAMPDBContext();

        // GET: AdminTickets
        public ActionResult Index()
        {
            return View(db.Tickets.OrderByDescending(t=>t.iconcount).ToList());
        }
        public ActionResult Add()
        {
            return View();
        }
        // GET: AdminTickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: AdminTickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTickets/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ticketid,title,entitle,quantity,iconcount,btime,etime,detailImg,detail,endetail")] Ticket ticket,HttpPostedFileBase detailImg)
        {
            if (ModelState.IsValid)
            {
                string serpath = Server.MapPath("~/updata/");
                string imgpath =DateTime.Now.ToString("yyyyMMddHHmmssfff") + detailImg.FileName;
                detailImg.SaveAs(serpath+imgpath);
                ticket.detailImg = "/updata/" + imgpath;
                ticket.ctime = DateTime.Now;
                db.Tickets.Add(ticket);
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(ticket);
        }

        // GET: AdminTickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: AdminTickets/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ticketid,title,entitle,quantity,iconcount,btime,etime,detailImg,detail,endetail,flag")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                
                ticket.ctime = DateTime.Now;
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: AdminTickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: AdminTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
