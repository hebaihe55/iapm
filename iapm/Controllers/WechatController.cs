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
         
            }
            else
            {
                Response.Write("");
                Response.End();
            }
        }
        //处理文本
        private void DowithText(Utils.WxPayData WPD)
        {
            

            if (WPD.GetValue("Content").ToString() == "红包")
            {
        
            }
            else
            {
                Response.Write("");
                Response.End();
            }


        }

    }
}