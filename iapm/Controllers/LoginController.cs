using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace iapm.Controllers
{
    public class LoginController :Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.Login login)
        {
            if (login.name == ConfigurationManager.AppSettings["name"].ToString() && login.pwd == ConfigurationManager.AppSettings["pwd"].ToString())
            {
                System.Web.HttpContext.Current.Session["userinfo"] = login.name;
                return RedirectToAction("Index", "AdminUsers");
            }
            ViewBag.name = login.name;
            ViewBag.password = login.pwd;
            return View();
        }

        public ActionResult LogOut()
        {
           
                System.Web.HttpContext.Current.Session["userinfo"] = null;
                return RedirectToAction("Index", "Login");
           
        
        }
    }
}