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

        private static List<ImgManager> imglist;

        public ActionResult Subscribe(int id)
        {


            if (id != 22)
            {
                return RedirectToAction("gameover");
            }

            //if (DateTime.Now > DateTime.Parse("2016-07-17 23:59:59"))
            //{
            //    return RedirectToAction("gameover");
            //}



            System.Web.HttpContext.Current.Session["bid"] = id;


            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();

            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;

            return View();
        }


        public ActionResult Subview()
        {
           
            return View();
        }



        [HttpPost]
        public int add(Models.ActiveGarden ag)
        {

        
            ag.cdate = DateTime.Now;
            ag.ctime = DateTime.Now;


            // int i = db.ActiveGardens.Where(t => t.OpenId == ag.OpenId && t.cdate == ag.cdate && t.gardenType == "分享").Count();

            try
            {
                db.ActiveGardens.Add(ag);
                int i = db.SaveChanges();
            }
            catch (Exception ex)
            {

                Utils.Log.Error("AddIcon", ex.Message);

                return -1;
            }
            return 0;




          
         

          
        }

        public ActionResult EnNoIndex()
        {
            return View();
        }

        public ActionResult Index()
        {


            imglist = db.ImgManagers.ToList();


            ViewBag.img1 = imglist.ToList()[0].imgurl;
            ViewBag.img2 = imglist.ToList()[1].imgurl;
            ViewBag.img3 = imglist.ToList()[2].imgurl;
            ViewBag.img4 = imglist.ToList()[3].imgurl;
            ViewBag.img5 = imglist.ToList()[4].imgurl;
            ViewBag.img6 = imglist.ToList()[5].imgurl;

            return View();
        }
        public ActionResult Index1()
        {
            return View();
        }
        public ActionResult NoIndex()
        {
            
            return View();
        }
        public ActionResult Rule()
        {
            imglist = db.ImgManagers.ToList();


            ViewBag.img1 = imglist.ToList()[8].imgurl;
            return View();
        }
        public ActionResult Rulebake1()
        {

            return View();
        }


        public ActionResult TiaoKuanBake()
        {
            return View();
        }
        public ActionResult EnTiaoKuanBake()
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



        public ActionResult Rulebake()
        {
            return View();
        }

        public ActionResult EnRulebake()
        {
            return View();
        }





        public ActionResult TiaoKuan()
        {
            

            return View();
        }

        public ActionResult Short()
        {


               return View();
        }

        public ActionResult BuGou()
        {
            string openId = System.Web.HttpContext.Current.Session["uid"].ToString();

            //总共获得积分
            int iconTotal = db.ActiveGardens.Where(w => w.OpenId == openId).Sum(s => (int?)s.gardenFee).GetValueOrDefault(0);

            //已经使用的积分
            int iconUsed = db.Cards.Where(t => t.OpenId == openId && t.CardType == "领取").Sum(s => (int?)s.CardFee).GetValueOrDefault();

            ViewBag.totalCount = iconTotal - iconUsed;

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();

            Utils.WeHelper.url = Request.Url.ToString();

            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;

            return View();
        }
        public ActionResult EnBuGou()
        {
            
            string openId = System.Web.HttpContext.Current.Session["uid"].ToString();

            //总共获得积分
            int iconTotal = db.ActiveGardens.Where(w => w.OpenId == openId).Sum(s => (int?)s.gardenFee).GetValueOrDefault(0);

            //已经使用的积分
            int iconUsed = db.Cards.Where(t => t.OpenId == openId && t.CardType == "领取").Sum(s => (int?)s.CardFee).GetValueOrDefault();

            ViewBag.totalCount = iconTotal - iconUsed;

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
            
            return View();
        }
        public ActionResult GameMap()
        {
return View();
        }
        public ActionResult GameBegin()
        {

            imglist = db.ImgManagers.ToList();


            ViewBag.img1 = imglist.ToList()[6].imgurl;
          


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

           
            return View(ticket);
        }

        public double geoconv(string geo)
        {

          string strJson=  Utils.HttpService.Get("http://api.map.baidu.com/geoconv/v1/?coords=" + geo + "&ak=4cd1159aeca678076305724404e4bf88");

            Utils.Log.Info("geovonv", strJson);

            LitJson.JsonData jd = LitJson.JsonMapper.ToObject(strJson);

            string x = "";
            string y = "";

            foreach (LitJson.JsonData j in jd["result"])
            {
                x = j["x"].ToString();
                y = j["y"].ToString();
            }

            double dd=   Utils.Utils.GetShortDistance(double.Parse(x), double.Parse(y), 121.464256, 31.221655);

            return dd;


        }


        public ActionResult Prize()
        {
            string openId = System.Web.HttpContext.Current.Session["uid"].ToString();

            //总共获得积分
            int iconTotal = db.ActiveGardens.Where(w => w.OpenId == openId).Sum(s => (int?)s.gardenFee).GetValueOrDefault(0);

            //已经使用的积分
             int iconUsed = db.Cards.Where(t => t.OpenId == openId && t.CardType == "领取").Sum(s=>(int?)s.CardFee).GetValueOrDefault();

            ViewBag.totalCount = iconTotal- iconUsed;

            var q = from t in db.Tickets.Where(t => t.etime >= DateTime.Now && t.btime <= DateTime.Now)
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


           
            return View(q.OrderBy(o => o.iconcount).ToList());
        }

        private Random rd;

        public ActionResult GameOver()
        {
            return View();

        }

        public ActionResult Game()
        {
            //根据ibeacon 的id查询
            var ibeacon = db.Ibeacons.Find(System.Web.HttpContext.Current.Session["bid"]);

            iapm.Models.ActiveGarden ac = new Models.ActiveGarden();

            //获取用户id
            ac.OpenId = System.Web.HttpContext.Current.Session["uid"].ToString();

            ViewBag.uid = ac.OpenId;

            ac.Ibeaconid = ibeacon.Ibeaconid;

            ViewBag.bid = ac.Ibeaconid;

            ac.ctime = ac.cdate = DateTime.Now;

            if (rd == null)
            {
                rd = new Random();
            }

            int minj = 0;
            int maxj = 0;

            //在双倍积分时间内积分 * 2
            if (DateTime.Now >= ibeacon.dbtime && DateTime.Now <= ibeacon.detime)
            {
                maxj = ibeacon.maxifen * 2;
                minj = ibeacon.minifen * 2;
            }
            else
            {
                maxj = ibeacon.maxifen;
                minj = ibeacon.minifen;
            }

            ac.gardenFee = rd.Next(minj, minj);

            ac.gardenType = "普通";

           


            //当天摇到的分数
            int? totalCount = db.ActiveGardens.Where(t => t.OpenId == ac.OpenId && t.cdate.Equals(DateTime.Today)).Sum(s => s.gardenFee).GetValueOrDefault(0);



            if (totalCount <= 200)
            {
                ViewBag.fee = ac.gardenFee;
            }
            else
            {
                ac.gardenFee = 10;
                ViewBag.fee = 10;
            }

            //历史分数
            int? hisCount = db.Cards.Where(t => t.CardFee >= 2000 && t.OpenId == ac.OpenId).Sum(s => s.CardFee).GetValueOrDefault(0);

            if (hisCount >= 4000)
            {
                ac.gardenFee = 10;
                ViewBag.fee = 10;
            }


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

            imglist = db.ImgManagers.ToList();


            ViewBag.img1 = imglist.ToList()[7].imgurl;

            ViewBag.appId = Utils.WeHelper.appid = ConfigurationManager.AppSettings["AppID"].ToString();
            Utils.WeHelper.secret = ConfigurationManager.AppSettings["AppSecret"].ToString();
          
            Utils.WeHelper.url = Request.Url.ToString();

            ViewBag.timestamp = Utils.WeHelper.timestamp = Utils.Utils.ConvertDateTimeInt(DateTime.Now).ToString();
            ViewBag.nonceStr = Utils.WeHelper.noncestr = "iapm" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            ViewBag.signature = Utils.WeHelper.signature;




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
                //jd.Ibeaconid = int.Parse(System.Web.HttpContext.Current.Session["bid"].ToString());
                jd.ctime = DateTime.Now;




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


        public ActionResult addCard(string id)
        {
            Ticket card = db.Tickets.SingleOrDefault(t => t.card_id == id);

            Card c = new Card();
            c.CardId = card.card_id;
            c.CardFee = card.iconcount;
            c.CardType = "领取";
            c.OpenId= System.Web.HttpContext.Current.Session["uid"].ToString();

            return RedirectToAction("Prize");
        }

        public ActionResult Ok(string id)
        {

            string openId = System.Web.HttpContext.Current.Session["uid"].ToString();

            //string openId = "oXXgKjy0gDLYvPrCA9tqhQAFFl7w";

            //总共获得积分
            int iconTotal = db.ActiveGardens.Where(w => w.OpenId == openId).Sum(s => (int?)s.gardenFee).GetValueOrDefault(0);

            //已经使用的积分
            int iconUsed = db.Cards.Where(t => t.OpenId == openId && t.CardType == "领取").Sum(s => (int?)s.CardFee).GetValueOrDefault(0);

            //卡券积分
            int iconKQ = db.Tickets.Where(t => t.card_id == id).Sum(s => s.iconcount);
            if (iconTotal - iconUsed < iconKQ)
            {
              return  RedirectToAction("BuGou", "Home");
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
        public ActionResult EnOk(string id)
        {

            string openId = System.Web.HttpContext.Current.Session["uid"].ToString();



            //总共获得积分
            int iconTotal = db.ActiveGardens.Where(w => w.OpenId == openId).Sum(s => (int?)s.gardenFee).GetValueOrDefault(0);

            //已经使用的积分
            int iconUsed = db.Cards.Where(t => t.OpenId == openId && t.CardType == "领取").Sum(s => (int?)s.CardFee).GetValueOrDefault(0);

            //卡券积分
            int iconKQ = db.Tickets.Where(t => t.card_id == id).Sum(s => s.iconcount);
            if (iconTotal - iconUsed < iconKQ)
            {
                return RedirectToAction("EnBuGou");
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
            //根据ibeacon 的id查询
            var ibeacon = db.Ibeacons.Find(System.Web.HttpContext.Current.Session["bid"]);

            iapm.Models.ActiveGarden ac = new Models.ActiveGarden();

            //获取用户id
            ac.OpenId = System.Web.HttpContext.Current.Session["uid"].ToString();

            ViewBag.uid = ac.OpenId;

            ac.Ibeaconid = ibeacon.Ibeaconid;

            ViewBag.bid = ac.Ibeaconid;

            ac.ctime = ac.cdate = DateTime.Now;

            if (rd == null)
            {
                rd = new Random();
            }
            int minj = 0;
            int maxj = 0;

            //在双倍积分时间内积分 * 2
            if (DateTime.Now >= ibeacon.dbtime && DateTime.Now <= ibeacon.detime)
            {
                maxj = ibeacon.maxifen * 2;
                minj = ibeacon.minifen * 2;
            }
            else
            {
                maxj = ibeacon.maxifen;
                minj = ibeacon.minifen;
            }

            ac.gardenFee = rd.Next(minj, minj);

            ac.gardenType = "普通";

          


            int? totalCount = db.ActiveGardens.Where(t => t.OpenId == ac.OpenId && t.cdate.Equals(DateTime.Today)).Sum(s => s.gardenFee);


            if (totalCount <= 200)
            {
                ViewBag.fee = ac.gardenFee;
            }
            else
            {
                ac.gardenFee = 5;
                ViewBag.fee = 5;
            }

            int? hisCount = db.Cards.Where(t => t.CardFee >= 2000 && t.OpenId == ac.OpenId).Sum(s => s.CardFee).GetValueOrDefault(0);

            if (hisCount >= 4000)
            {
                ac.gardenFee = 10;
                ViewBag.fee = 10;
            }

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

            var q = from t in db.Tickets.Where(t=>t.etime>=DateTime.Now && t.btime<=DateTime.Now)
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


          

            return View(q.OrderBy(o => o.iconcount).ToList());
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