using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iapm.Controllers
{
    public class AdminUsersController : Controller
    {
        private Models.IAMPDBContext db = new Models.IAMPDBContext();
        // GET: AdminUsers
        public ActionResult Index()
        {
            return View(db.WechatUsers.ToList());
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