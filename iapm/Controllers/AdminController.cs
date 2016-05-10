using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace iapm.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin

        public ActionResult Index()
        {
            return View();
        }
    }
}