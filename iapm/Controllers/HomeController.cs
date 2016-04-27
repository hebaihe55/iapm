using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using iapm.Models;
using System.Configuration;

namespace iapm.Controllers
{
    public class HomeController : Controller
    {
        private Models.IAMPDBContext db = new Models.IAMPDBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Rule()
        {
            return View();
        }

        public ActionResult LG1()
        {
            return View();
        }

        public ActionResult LG2()
        {
            return View();
        }

        public ActionResult L1()
        {
            return View();
        }
        public ActionResult L2()
        {
            return View();
        }
        public ActionResult L3()
        {
            return View();
        }
        public ActionResult L4()
        {
            return View();
        }
        public ActionResult L5()
        {
            return View();
        }
        public ActionResult TiaoKuan()
        {
            return View();
        }
        public ActionResult L6()
        {
            return View();
        }
        public ActionResult GameMap()
        {
            return View();
        }
        public ActionResult GameBegin()
        {
            return View();
        }
        public ActionResult PrizeDetail(int? id)
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
        public ActionResult Prize()
        {
            return View(db.Tickets.OrderByDescending(t=>t.iconcount).ToList());
        }


        public ActionResult Game()
        {
            //var ib = db.Ibeacons.Find(System.Web.HttpContext.Current.Session["ibeaconid"]);

            var ib = db.Ibeacons.Find(1);

            iapm.Models.ActiveGarden ac = new Models.ActiveGarden();
            //ac.WechatUserId = int.Parse(System.Web.HttpContext.Current.Session["uid"].ToString());
            ac.WechatUserId = 1;

            ac.Ibeaconid = ib.Ibeaconid;
            ac.cdate = DateTime.Now;
            Random rd = new Random();
            ac.gardenFee = rd.Next(ib.minifen, ib.maxifen);
            ac.gardenType = "普通";

            List < Ibeacon > ibeas= db.Ibeacons.Where(i => i.dbtime <= DateTime.Now && i.dbtime >= DateTime.Now && i.Ibeaconid == ac.Ibeaconid).ToList();

            if (ibeas.Count > 0)
            {
              List<ActiveGarden> ags=  db.ActiveGardens.Where(a => a.ctime >= ibeas[0].dbtime && a.ctime <= ibeas[0].detime && a.Ibeaconid == ac.Ibeaconid).ToList();
                if (ags.Count >= ibeas[0].dfen)
                {
                    ViewBag.doublefen = 0;
                }
                else
                {
                    ViewBag.doublefen = 1;
                }
            }


            ViewBag.fee = ac.gardenFee;
            try
            {
                db.ActiveGardens.Add(ac);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Utils.Log.Error("Game", ex.Message);

            }

            // var totalCount = db.ActiveGardens.SingleOrDefault(a=>a.ActiveGardenid== int.Parse(System.Web.HttpContext.Current.Session["uid"].ToString())).

            return View();
        }


        public ActionResult Subscribe(int id)
        {
            System.Web.HttpContext.Current.Session["ibeaconid"] = id;
            return View();
        }
        public ActionResult Login(string code)
        {
            Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();
            if (!string.IsNullOrWhiteSpace(code))
            {
                Utils.WeHelper.code = code;

                string strjson = Utils.WeHelper.GetUserInfo();

                //string strjson = "{\"openid\":\"oQOyyv - MdUWSgP8_Smoh2S_6 - 1I0\",\"nickname\":\"白鹤\",\"sex\":1,\"language\":\"zh_CN\",\"city\":\"长宁\",\"province\":\"上海\",\"country\":\"中国\",\"headimgurl\":\"http://wx.qlogo.cn/mmopen/78EkX665csCmkBmDBDSYTDCmZdvlMDqCX7wYTLcHeeKNeLicSS5ic2fDAYpeTqicaqhF8Iw9Rp9d6hegynMHC7tPMWLRnqMvNicn/0\",\"privilege\":[]}";
                Utils.Log.Info("userin", strjson);
                Models.WechatUser jd = LitJson.JsonMapper.ToObject<Models.WechatUser>(strjson);
                // jd.Ibeaconid =int.Parse( System.Web.HttpContext.Current.Session["ibeaconid"].ToString());

                jd.Ibeaconid = 1;



                try
                {
                    var wu = db.WechatUsers.SingleOrDefault(w => w.openid == jd.openid);

                    if (wu == null)
                    {
                        db.WechatUsers.Add(jd);

                        db.SaveChanges();
                        System.Web.HttpContext.Current.Session["uid"] =jd.WechatUserId;

                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["uid"] = wu.WechatUserId;
                    }
                   


                }
                catch (Exception ex)
                {

                    Utils.Log.Error("userAdd", ex.Message);

                    return View();
                }
            }
            else
            {
                Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid="+ Utils.WeHelper.appid + "&redirect_uri=http://iapm.cjoy.cn/home/Login&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
            }
            //AppID(应用ID)wxa25b827fd42bdf7f
            //AppSecret(应用密钥)00639e0733e2c80d822ccd6a3cbdac51



            return RedirectToAction("index");
          
        }

        public ActionResult Ok()
        {
            LitJson.JsonData cardExt = new LitJson.JsonData();

            cardExt["timestamp"] = Utils.Utils.ConvertDateTimeInt(DateTime.Now);

            cardExt["nonce_str"] = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            cardExt["signature"] = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return View();
        }

        /*英文分割线*/
        public ActionResult EnIndex()
        {
            return View();
        }

        public ActionResult EnTiaoKuan()
        {
            return View();
        }


        public ActionResult EnL1()
        {
            return View();
        }
        public ActionResult EnL2()
        {
            return View();
        }
        public ActionResult EnL3()
        {
            return View();
        }
        public ActionResult EnL4()
        {
            return View();
        }
        public ActionResult EnL5()
        {
            return View();
        }

        public ActionResult EnL6()
        {
            return View();
        }

        public ActionResult EnLG1()
        {
            return View();
        }

        public ActionResult EnLG2()
        {
            return View();
        }

        public ActionResult EnGameMap()
        {
            return View();
        }

        public ActionResult EnRule()
        {
            return View();
        }

        public ActionResult EnGameBegin()
        {
            return View();
        }

        public ActionResult EnGame()
        {
            //var ib = db.Ibeacons.Find(System.Web.HttpContext.Current.Session["ibeaconid"]);

            var ib = db.Ibeacons.Find(1);

            iapm.Models.ActiveGarden ac = new Models.ActiveGarden();
            //ac.WechatUserId = int.Parse(System.Web.HttpContext.Current.Session["uid"].ToString());
            ac.WechatUserId = 1;

            ac.Ibeaconid = ib.Ibeaconid;
            ac.cdate = DateTime.Now;
            Random rd = new Random();
            ac.gardenFee = rd.Next(ib.minifen, ib.maxifen);
            ac.gardenType = "普通";

            List<Ibeacon> ibeas = db.Ibeacons.Where(i => i.dbtime <= DateTime.Now && i.dbtime >= DateTime.Now && i.Ibeaconid == ac.Ibeaconid).ToList();

            if (ibeas.Count > 0)
            {
                List<ActiveGarden> ags = db.ActiveGardens.Where(a => a.ctime >= ibeas[0].dbtime && a.ctime <= ibeas[0].detime && a.Ibeaconid == ac.Ibeaconid).ToList();
                if (ags.Count >= ibeas[0].dfen)
                {
                    ViewBag.doublefen = 0;
                }
                else
                {
                    ViewBag.doublefen = 1;
                }
            }


            ViewBag.fee = ac.gardenFee;
            try
            {
                db.ActiveGardens.Add(ac);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Utils.Log.Error("Game", ex.Message);

            }

            // var totalCount = db.ActiveGardens.SingleOrDefault(a=>a.ActiveGardenid== int.Parse(System.Web.HttpContext.Current.Session["uid"].ToString())).

            return View();
        }


        public ActionResult EnPrizeDetail(int? id)
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
        public ActionResult EnPrize()
        {
            return View(db.Tickets.OrderByDescending(t => t.iconcount).ToList());
        }
    }
}