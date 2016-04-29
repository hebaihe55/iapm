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
using Newtonsoft.Json.Linq;

namespace iapm.Controllers
{
    public class HomeController : Controller
    {
        private Models.IAMPDBContext db = new Models.IAMPDBContext();
        // GET: Home



            [HttpPost]
        public int AddIcon(int? id)
        {
          string uid=  System.Web.HttpContext.Current.Session["uid"].ToString()  ;

          string bid= System.Web.HttpContext.Current.Session["bid"].ToString();

            Models.ActiveGarden ag = new ActiveGarden();
            ag.OpenId = uid;
            ag.Ibeaconid =int.Parse( bid);
            ag.gardenFee = 1;
            ag.gardenType = "分享";
            ag.cdate = DateTime.Now;
            ag.ctime = DateTime.Now;

           int i= db.ActiveGardens.Where(t => t.OpenId == ag.OpenId && t.cdate == DateTime.Now.Date && t.gardenType=="分享").Count();

            if (i == 0)
            {
                db.ActiveGardens.Add(ag);

                return 1;
            }

            return 0;
        }

        public ActionResult EnNoIndex()
        {
            return View();
        }

        public ActionResult Index()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult NoIndex()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult Rule()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult LG1()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult LG2()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult L1()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult L2()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult L3()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult L4()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult L5()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult TiaoKuan()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult Short()
        {


            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }




        public ActionResult L6()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult GameMap()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult GameBegin()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
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

            int pleft = ticket.quantity - db.Cards.Where(w => w.CardId == ticket.card_id && w.CardType=="领取").Count();

            ViewBag.pleft = pleft;

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View(ticket);
        }




        public ActionResult Prize()
        {
            string openId = System.Web.HttpContext.Current.Session["uid"].ToString();

            //总共获得积分
            int iconTotal = db.ActiveGardens.Where(w => w.OpenId == openId).Sum(s => (int?)s.gardenFee).GetValueOrDefault(0);

            //已经使用的积分
             int iconUsed = db.Cards.Where(t => t.OpenId == openId && t.CardType == "领取").Sum(s=>(int?)s.CardFee).GetValueOrDefault();

            ViewBag.totalCount = iconTotal- iconUsed;

            var q = from t in db.Tickets
                    join c in db.Cards.Where(t=>t.CardType=="领取") on
                    t.card_id equals c.CardId
                    into cards
                    select new VTicket
                    {
                        Ticketid = t.Ticketid,
                        title = t.title,
                        entitle = t.entitle,
                        quantity = t.quantity,
                        iconcount = t.iconcount,
                        btime = t.btime,
                        etime = t.etime,
                        detailImg = t.detailImg,
                        detail = t.detail,
                        endetail = t.endetail,
                        card_id = t.card_id,
                        ctime = t.ctime,
                        flag = t.flag,

                        kqleft = t.quantity - cards.Count()

                    };


            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;

            return View(q.OrderBy(o => o.flag).ToList());
        }



        public ActionResult Game()
        {
            //根据ibeacon 的id查询
            var ibeacon = db.Ibeacons.Find(System.Web.HttpContext.Current.Session["bid"]);

            iapm.Models.ActiveGarden ac = new Models.ActiveGarden();

            //获取用户id
            ac.OpenId = System.Web.HttpContext.Current.Session["uid"].ToString();


            ac.Ibeaconid = ibeacon.Ibeaconid;
            ac.ctime = ac.cdate = DateTime.Now;

            Random rd = new Random();

            //在双倍积分时间内积分 * 2
            if (DateTime.Now >= ibeacon.dbtime && DateTime.Now <= ibeacon.detime)
            {
                ibeacon.maxifen *= 2;
                ibeacon.minifen *= 2;
            }

            ac.gardenFee = rd.Next(ibeacon.minifen, ibeacon.maxifen);

            ac.gardenType = "普通";




            ViewBag.fee = ac.gardenFee;


            int jfk = rd.Next(1, 100);

            int jfkTag = 0;

            if (jfk <= ibeacon.dfen)
            {
                jfkTag = 1;
            }

            ViewBag.jfkTag = jfkTag;

            try
            {
                db.ActiveGardens.Add(ac);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Utils.Log.Error("Game", ex.Message);
                ViewBag.fee = 0;
            }


            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();
           
            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;

            return View();
        }


        public ActionResult Subscribe(int id)
        {
            System.Web.HttpContext.Current.Session["bid"] = id;
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
                jd.Ibeaconid = int.Parse(System.Web.HttpContext.Current.Session["bid"].ToString());





                try
                {
                    var wu = db.WechatUsers.SingleOrDefault(w => w.openid == jd.openid);

                    if (wu == null)
                    {
                        db.WechatUsers.Add(jd);

                        db.SaveChanges();
                        System.Web.HttpContext.Current.Session["uid"] = jd.openid;

                    }
                    else
                    {
                        System.Web.HttpContext.Current.Session["uid"] = wu.openid;
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
                Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Utils.WeHelper.appid + "&redirect_uri=http://iapm.cjoy.cn/home/Login&response_type=code&scope=snsapi_userinfo&state=STATE#wechat_redirect");
            }
            //AppID(应用ID)wxa25b827fd42bdf7f
            //AppSecret(应用密钥)00639e0733e2c80d822ccd6a3cbdac51



            return RedirectToAction("index");

        }

        public ActionResult Ok(string id)
        {



            string openId = System.Web.HttpContext.Current.Session["uid"].ToString();



            //总共获得积分
            int iconTotal = db.ActiveGardens.Where(w => w.OpenId == openId).Sum(s => (int?)s.gardenFee).GetValueOrDefault(0);

            //已经使用的积分
            int iconUsed = db.Cards.Where(t => t.OpenId == openId && t.CardType== "领取").Sum(s => (int?)s.CardFee).GetValueOrDefault(0);

            //卡券积分
            int iconKQ = db.Tickets.Where(t => t.card_id == id).Sum(s => s.iconcount);
            if (iconTotal- iconUsed < iconKQ)
            {
                return RedirectToAction("Short");
            }

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();
            ViewBag.card_id = Utils.WeHelper.card_id = id;
            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;

            LitJson.JsonData o = new LitJson.JsonData();
            o["timestamp"] = Utils.WeHelper.timestamp;
            o["nonce_str"] = Utils.WeHelper.noncestr;
            o["signature"] = Utils.WeHelper.kqsignature;

            ViewBag.cardExt = o.ToJson();











            return View();
        }

        /*英文分割线*/
        public ActionResult EnIndex()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult EnTiaoKuan()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }


        public ActionResult EnL1()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult EnL2()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult EnL3()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult EnL4()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }
        public ActionResult EnL5()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult EnL6()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult EnLG1()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult EnLG2()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult EnGameMap()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult EnRule()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult EnGameBegin()
        {

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View();
        }

        public ActionResult EnGame()
        {
            //根据ibeacon 的id查询
            var ibeacon = db.Ibeacons.Find(System.Web.HttpContext.Current.Session["bid"]);

            iapm.Models.ActiveGarden ac = new Models.ActiveGarden();

            //获取用户id
            ac.OpenId = System.Web.HttpContext.Current.Session["uid"].ToString();


            ac.Ibeaconid = ibeacon.Ibeaconid;
            ac.ctime = ac.cdate = DateTime.Now;

            Random rd = new Random();

            //在双倍积分时间内积分 * 2
            if (DateTime.Now >= ibeacon.dbtime && DateTime.Now <= ibeacon.detime)
            {
                ibeacon.maxifen *= 2;
                ibeacon.minifen *= 2;
            }

            ac.gardenFee = rd.Next(ibeacon.minifen, ibeacon.maxifen);

            ac.gardenType = "普通";




            ViewBag.fee = ac.gardenFee;


            int jfk = rd.Next(1, 100);

            int jfkTag = 0;

            if (jfk <= ibeacon.dfen)
            {
                jfkTag = 1;
            }

            ViewBag.jfkTag = jfkTag;

            try
            {
                db.ActiveGardens.Add(ac);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Utils.Log.Error("Game", ex.Message);
                ViewBag.fee = 0;
            }


            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;

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

            int pleft = ticket.quantity - db.Cards.Where(w => w.CardId == ticket.card_id && w.CardType == "领取").Count();

            ViewBag.pleft = pleft;

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();






            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;
            return View(ticket);
        }



        public ActionResult EnPrize()
        {
            string openId = System.Web.HttpContext.Current.Session["uid"].ToString();

            //总共获得积分
            int iconTotal = db.ActiveGardens.Where(w => w.OpenId == openId).Sum(s => (int?)s.gardenFee).GetValueOrDefault(0);

            //已经使用的积分
            int iconUsed = db.Cards.Where(t => t.OpenId == openId && t.CardType == "领取").Sum(s => (int?)s.CardFee).GetValueOrDefault();

            ViewBag.totalCount = iconTotal - iconUsed;

            var q = from t in db.Tickets
                    join c in db.Cards.Where(t => t.CardType == "领取") on
                   t.card_id equals c.CardId
                    into cards
                    select new VTicket
                    {
                        Ticketid = t.Ticketid,
                        title = t.title,
                        entitle = t.entitle,
                        quantity = t.quantity,
                        iconcount = t.iconcount,
                        btime = t.btime,
                        etime = t.etime,
                        detailImg = t.detailImg,
                        detail = t.detail,
                        endetail = t.endetail,
                        card_id = t.card_id,
                        ctime = t.ctime,
                        flag = t.flag,

                        kqleft = t.quantity - cards.Count()

                    };


            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();


            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;

            return View(q.OrderBy(o => o.flag).ToList());
        }

    }
}