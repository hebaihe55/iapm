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
                Response.Write("");
                Response.End();
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
                card.CardType = "核销";
                card.CardFee=GetCardFee(WPD.GetValue("CardId").ToString());
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
                card.CardType = "删除";
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
          var tick=  db.Tickets.Where(w => w.card_id == "ticket").SingleOrDefault();
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