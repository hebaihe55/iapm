﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LitJson;
using System.Net;
using System.Web;
using System.IO;

namespace iapm.Utils
{
    public class item
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicUrl { get; set; }
        public string Url { get; set; }
    }

    public class Articles
    {
        public item[] item { get; set; }
    }
    public class WeHelper
    {
        //基本票据
        private static string access_token;
        private static int expires_in;

        //js票据
        private static string ticket;
        private static int texpires_in;

        //卡券
        private static string kqticket;
        private static int kqtexpires_in;

        //用户信息票据
        private static string caccess_token;
        private static int cexpires_in;
        public static string code { get; set; }
        public static string openid { get; set; }
        public static string MEDIA_ID { get; set; }
        public static string appid { get; set; }
        public static string secret { get; set; }
        public static string noncestr { get; set; }
        public static string timestamp { get; set; }
        public static string card_id { get; set; }
        
        public static string url { get; set; }
        public static string signature
        { get {
                string string1 = string.Format("jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}", Ticket, noncestr, timestamp, url);

                return Utils.SHA1_Hash(string1);
            }
        }


        public static string kqsignature
        {
            get
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("timestamp", timestamp);
                dic.Add("card_id", card_id);
                dic.Add("api_ticket", Kqticket);
                dic.Add("nonce_str", noncestr);
                var dicSort = from objDic in dic orderby objDic.Value  select objDic;
                string string1 = "";
                foreach (KeyValuePair<string, string > kvp in dicSort)
                {
                    string1 += kvp.Value;
                }


                  




                return Utils.SHA1_Hash(string1);
            }
        }


        public static string Access_token
        {
            get
            {
                if (!string.IsNullOrEmpty( access_token) && (expires_in + 7000) > Utils.ConvertDateTimeInt(DateTime.Now))
                {
                    return access_token;
                }

                string strJson = client_credential();

                if (strJson.IndexOf("access_token") > 0)
                {
                    JsonData jd = LitJson.JsonMapper.ToObject(strJson);

                    access_token = jd["access_token"].ToString();
                    expires_in = Utils.ConvertDateTimeInt(DateTime.Now);
                    return access_token;
                }

                return "";
            }


        }

        public static string Ticket
        {
            get
            {
                if (!string.IsNullOrEmpty(ticket) && (texpires_in + 7000) > Utils.ConvertDateTimeInt(DateTime.Now))
                {
                    return ticket;
                }

                string strJson = getticket();

                if (strJson.IndexOf("ok") > 0)
                {
                    JsonData jd = LitJson.JsonMapper.ToObject(strJson);

                    ticket = jd["ticket"].ToString();
                    texpires_in = Utils.ConvertDateTimeInt(DateTime.Now);
                    return ticket;
                }

                return "";
            }

            
        }

        public static string Caccess_token
        {
            get
            {
               

                string strJson = getcticket();

                if (strJson.IndexOf("access_token") > 0)
                {
                    JsonData jd = LitJson.JsonMapper.ToObject(strJson);

                    caccess_token = jd["access_token"].ToString();
                    cexpires_in = Utils.ConvertDateTimeInt(DateTime.Now);
                    openid= jd["openid"].ToString();
                    return caccess_token;
                }

                return "";
            }

           
        }

        public static string Kqticket
        {
            get
            {
                if (!string.IsNullOrEmpty(kqticket) && (kqtexpires_in + 7000) > Utils.ConvertDateTimeInt(DateTime.Now))
                {
                    return kqticket;
                }

                string strJson = kqtticket();

                
                    JsonData jd = LitJson.JsonMapper.ToObject(strJson);
                if (jd["errcode"].ToString() == "0")
                {
                    kqticket = jd["ticket"].ToString();
                    kqtexpires_in = Utils.ConvertDateTimeInt(DateTime.Now);
                    
                    return kqticket;
                }

                return "";
            }


        }

        /// <summary>
        /// 得到页面票据
        /// </summary>
        /// <returns></returns>
        private static string getcticket()
        {
            string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid="+ appid + "&secret="+ secret + "&code="+code+"&grant_type=authorization_code";

            string result= HttpService.Get(url);

            Log.Info("getcticket", result);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string kqtticket()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token="+ Access_token + "&type=wx_card";

            string result = HttpService.Get(url);

            Log.Info("kqtticket", result);
            return result;
        }

        public static string GetUserInfo()
        {
            string url = "https://api.weixin.qq.com/sns/userinfo?access_token="+ Caccess_token + "&openid="+openid+"&lang=zh_CN";
            string result = HttpService.Get(url);
            Log.Info("GetUserInfo", result);
            return result;
        }

        /// <summary>
        /// jsticket票据
        /// </summary>
        /// <returns></returns>
        private static string getticket()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token="+Access_token+"&type=jsapi";

            string result = HttpService.Get(url);
            Log.Info("getticket", result);
            return result;
        }



        /// <summary>
        /// 得到微信票据
        /// </summary>
        /// <returns></returns>
        private static string client_credential()
        {
            string url = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appid + "&secret=" + secret;

            string result = HttpService.Get(url);
            Log.Info("client_credential", result);
            return result;
        }


        /// <summary>  
        /// 下载保存多媒体文件,返回多媒体保存路径  
        /// </summary>  
        /// <param name="ACCESS_TOKEN"></param>  
        /// <param name="MEDIA_ID"></param>  
        /// <returns></returns>  
        public static string GetMultimedia()
        {
            string file = string.Empty;
            string content = string.Empty;
            string strpath = string.Empty;
            string savepath = string.Empty;
            string stUrl = "http://file.api.weixin.qq.com/cgi-bin/media/get?access_token=" + Access_token + "&media_id=" + MEDIA_ID;

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(stUrl);

            req.Method = "GET";
            using (WebResponse wr = req.GetResponse())
            {
                HttpWebResponse myResponse = (HttpWebResponse)req.GetResponse();

                strpath = myResponse.ResponseUri.ToString();
             
                WebClient mywebclient = new WebClient();
                savepath = HttpContext.Current.Request.PhysicalApplicationPath+ "UpImg\\"  ;
                string imgpath =  MEDIA_ID + ".jpg";

                try
                {
                    if (!Directory.Exists(savepath))//如果日志目录不存在就创建
                    {
                        Directory.CreateDirectory(savepath);
                    }
                    mywebclient.DownloadFile(strpath, savepath + imgpath);
                    file = imgpath;
                }
                catch (Exception ex)
                {
                    savepath = ex.ToString();
                }

            }
            return file;
        }



        /// <SUMMARY> 
        /// 上传多媒体文件,返回 MediaId 
        /// </SUMMARY> 
        /// <PARAM name="ACCESS_TOKEN"></PARAM> 
        /// <PARAM name="Type"></PARAM> 
        /// <RETURNS></RETURNS> 
        public static string UploadMultimedia( string filepath)
        {
            string result = "";
           
            WebClient myWebClient = new WebClient();
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                byte[] responseArray = myWebClient.UploadFile("https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token="+ Access_token, "POST", filepath);
                result = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);
           
              
            }
            catch (Exception ex)
            {
                result = "Error:" + ex.Message;
            }
         
            return result;
        }



    }



}
