using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace iapm.Controllers
{
    public class WechatController : Controller
    {
        private Models.IAMPDBContext db = new Models.IAMPDBContext();
        // GET: Wechat
        public ActionResult Index()
        {
            return View();
        }
        public string Api(string echostr)
        {
            if (echostr == "")
            {
                return "success";
            }
            return echostr;
        }

        [HttpPost]
        public void Api()
        {

            Stream st = Request.InputStream;

            StreamReader sr = new StreamReader(st, Encoding.GetEncoding("UTF-8"));

            String xmlStr = sr.ReadToEnd();

            Utils.Log.Info("apire", xmlStr);

            Utils.WxPayData wpd = new Utils.WxPayData();

            wpd.FromXml(xmlStr);


            DoWithReceive(wpd);






        }

        private void DoWithReceive(Utils.WxPayData WPD)
        {
            switch (WPD.GetValue("MsgType").ToString())
            {
                case "event":
                    DowithEvent(WPD);
                    break;
                case "text":
                    DowithText(WPD);
                    break;
                default:
                    Response.Write("");
                    Response.End();
                    break;
            }
        }

        private Utils.WxPayData redata = new Utils.WxPayData();

        /// <summary>
        /// 处理事件
        /// </summary>
        /// <param name="WPD"></param>
        private void DowithEvent(Utils.WxPayData WPD)
        {

            if (WPD.GetValue("Event").ToString() == "subscribe")
            {


                string rexm = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>12345678</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[感谢关注iapm商场官方微信：）]]></Content></xml>", WPD.GetValue("FromUserName").ToString(), WPD.GetValue("ToUserName").ToString());


                Response.Write(rexm);
                Response.End();
            }
            if (WPD.GetValue("Event").ToString() == "CLICK")
            {
                if (WPD.GetValue("EventKey").ToString() == "bcyh")
                {

                    string rexm1 = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>12345678</CreateTime><MsgType><![CDATA[image]]></MsgType><Image><MediaId><![CDATA[k4q-LkGIMk6GLSNRJM5I7-8ZG35CtWBFTj8YPLncXt4SVcT40Klh3ZVEslnDnezX]]></MediaId></Image></xml>", WPD.GetValue("FromUserName").ToString(), WPD.GetValue("ToUserName").ToString());


                    Response.Write(rexm1);
                    Response.End();
                }
                else if (WPD.GetValue("EventKey").ToString() == "yaoyiyao")
                {

                    string rexm1 = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>12345678</CreateTime><MsgType><![CDATA[image]]></MsgType><Image><MediaId><![CDATA[GIq3gK8dZSBrkMTt8M0XkhOYOmTqfllvtmg2c_HEEsZLpxgMciL36AcfRaRGUW7s]]></MediaId></Image></xml>", WPD.GetValue("FromUserName").ToString(), WPD.GetValue("ToUserName").ToString());


                    Response.Write(rexm1);
                    Response.End();
                }
                else if (WPD.GetValue("EventKey").ToString() == "ivc")
                {
                    string rexml = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>20140814</CreateTime><MsgType><![CDATA[news]]></MsgType><ArticleCount>2</ArticleCount><Articles><item><Title><![CDATA[iapm VIC Club 诚邀您的加入]]></Title> <Description><![CDATA[点击进入详情页面]]></Description><PicUrl><![CDATA[http://iapm.cjoy.cn/images/tbanner1.jpg]]></PicUrl><Url><![CDATA[http://mp.weixin.qq.com/s?__biz=MjM5MjI1NDE4NQ==&mid=200725952&idx=1&sn=281b840a49bb71a85b3d0ccf12aaeb85&scene=18#rd]]></Url></item><item><Title><![CDATA[iapm VIC Club | 积分奖赏换领]]></Title> <Description><![CDATA[点击进入详情页面]]></Description><PicUrl><![CDATA[http://iapm.cjoy.cn/images/tbanner2.jpg]]></PicUrl><Url><![CDATA[http://mp.weixin.qq.com/s?__biz=MjM5MjI1NDE4NQ==&mid=200725952&idx=2&sn=a1b0b135c864e7378aea769868bc67a3&scene=18#rd]]></Url></item></Articles></xml>", WPD.GetValue("FromUserName").ToString(), WPD.GetValue("ToUserName").ToString());

                    Response.Write(rexml);
                    Response.End();
                }


                else if (WPD.GetValue("EventKey").ToString() == "jj")
                {
                    string rexml = string.Format("<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>20140814</CreateTime><MsgType><![CDATA[news]]></MsgType><ArticleCount>1</ArticleCount><Articles>	<item><Title><![CDATA[环贸iapm商场介绍]]></Title> <Description><![CDATA[点击进入详情页面]]></Description><PicUrl><![CDATA[http://iapm.cjoy.cn/images/tbanner3.jpg]]></PicUrl><Url><![CDATA[http://mp.weixin.qq.com/mp/appmsg/show?__biz=MjM5MjI1NDE4NQ==&appmsgid=10000006&itemidx=1&sign=f3d6fac0a517a74e215c10defc133d47&scene=18#wechat_redirect]]></Url></item></Articles></xml>", WPD.GetValue("FromUserName").ToString(), WPD.GetValue("ToUserName").ToString());



                    Response.Write(rexml);
                    Response.End();

                }
            }

            else if (WPD.GetValue("Event").ToString() == "user_get_card")
            {
                Models.Card card = new Models.Card();
                card.OpenId = WPD.GetValue("FromUserName").ToString();
                card.CardId = WPD.GetValue("CardId").ToString();
                card.CardCode = WPD.GetValue("UserCardCode").ToString();
                card.CardType = "领取";
                card.CardFee = GetCardFee(WPD.GetValue("CardId").ToString());
                card.CCtime = DateTime.Now;
                db.Cards.Add(card);
                db.SaveChanges();
                Response.Write("");
                Response.End();

            }
            else if (WPD.GetValue("Event").ToString() == "user_del_card")
            {
                Models.Card card = new Models.Card();
                card.OpenId = WPD.GetValue("FromUserName").ToString();
                card.CardId = WPD.GetValue("CardId").ToString();
                card.CardCode = WPD.GetValue("UserCardCode").ToString();
                card.CardType = "删除";
                card.CardFee = GetCardFee(WPD.GetValue("CardId").ToString());
                card.CCtime = DateTime.Now;
                db.Cards.Add(card);
                db.SaveChanges();
                Response.Write("");
                Response.End();

            }
            else if (WPD.GetValue("Event").ToString() == "user_consume_card")
            {
                Models.Card card = new Models.Card();
                card.OpenId = WPD.GetValue("FromUserName").ToString();
                card.CardId = WPD.GetValue("CardId").ToString();
                card.CardCode = WPD.GetValue("UserCardCode").ToString();
                card.CardType = "核销";
                card.CardFee = GetCardFee(WPD.GetValue("CardId").ToString());
                card.CCtime = DateTime.Now;
                db.Cards.Add(card);
                db.SaveChanges();
                Response.Write("");
                Response.End();

            }
            else
            {
                Response.Write("");
                Response.End();
            }
        }
        //处理文本


        private int GetCardFee(string ticketid)
        {
            var tick = db.Tickets.Where(w => w.card_id == ticketid).SingleOrDefault();
            return tick.iconcount;
        }


        private void DowithText(Utils.WxPayData WPD)
        {
            if (WPD.GetValue("Content").ToString() == "红包")
            {
                Response.Write("");
                Response.End();
            }
            else
            {
                Response.Write("");
                Response.End();
            }
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