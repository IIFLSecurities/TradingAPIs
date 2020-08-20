using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Services;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace VendorOpenAPIWebApp
{
    /// <summary>
    /// Summary description for GeneralMethods
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GeneralMethods : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void LoginRequestMobileForVendor(string Email_id, string ContactNumber)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.LoginRequestMobileReq();
            CommonCode.LoginRequestMobileRes objFinal = new CommonCode.LoginRequestMobileRes();

            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "LoginRequestMobileForVendor";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            _data.head.requestCode = "IIFLMarRQLoginForVendor";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("LoginUserID");
            _data.head.password = obj.GetAppKeySettings("LoginPwd");
            _data.body.Email_id = Email_id;
            _data.body.ContactNumber = ContactNumber;
            _data.body.LocalIP = obj.GetIPAddress();
            _data.body.PublicIP = _data.body.LocalIP;
            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }
            var CookieValue = ""; string value1 = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();

                string[] reponseURI = response.Headers.AllKeys;
                value1 = response.Headers.Get("Set-Cookie");

                var value2 = value1.Split(';');
                var final = value2[0].Split('=');
                CookieValue = final[1];
            }

            Session["IIFLcookie"] = CookieValue;


            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void LoginRequestV2(string ClientCode, string Password)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.LoginRequestV2Req();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "V2/LoginRequest";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            _data.head.requestCode = "IIFLMarRQLoginForVendor";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");

            _data.body.ClientCode = ClientCode;
            _data.body.Password = Password;
            _data.body.LocalIP = obj.GetIPAddress();
            _data.body.PublicIP = _data.body.LocalIP;
            _data.body.HDSerialNumber = "";
            _data.body.MACAddress = "";
            _data.body.MachineID = "";
            _data.body.VersionNo = "1.0.16.0";
            _data.body.RequestNo = "1";
            _data.body.My2PIN = "xk0gmy36O4AOr77fVcBzxQ==";
            _data.body.ConnectionType = "1";

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }
            var CookieValue = "";
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();

                string[] reponseURI = response.Headers.AllKeys;
                string value1 = response.Headers.Get("Set-Cookie");

                var value2 = value1.Split(';');
                var final = value2[0].Split('=');
                CookieValue = final[1];
            }

            Session["IIFLcookie"] = CookieValue;

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void OrderBookV1(string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "V1/OrderBook";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            string IIFLcookie = "IIFLcookie:" + Session["IIFLcookie"].ToString();
            request.Headers.Add(IIFLcookie);

            _data.head.requestCode = "IIFLMarRQOrdBkV1";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void HoldingV2(string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "V2/Holding";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQHoldingV2";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void MarginV3(string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "V3/Margin";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQMarginV3";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void OrderBookV2(string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "V2/OrderBook";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQOrdBkV2";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TradeBookV1(string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "V1/TradeBook";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQTrdBkV1";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void PreOrdMarginCalculation(string ClientCode, string OrderRequestorCode, string Exch, string ExchType, int ScripCode, string PlaceModifyCancel,
            string TransactionType, string AtMarket, double LimitRate, string WithSL, double SLTriggerRate, char IsSLTriggered, long Volume, long OldTradedQty,
            char ProductType, string ExchOrderId, int AppSource)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.PreOrdMarginCalReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "PreOrdMarginCalculation";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQPreOrdMarCal";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;
            _data.body.OrderRequestorCode = OrderRequestorCode;
            _data.body.Exch = Exch;
            _data.body.ExchType = ExchType;
            _data.body.ScripCode = ScripCode;
            _data.body.PlaceModifyCancel = PlaceModifyCancel;
            _data.body.TransactionType = TransactionType;
            _data.body.AtMarket = AtMarket;
            _data.body.LimitRate = LimitRate;
            _data.body.WithSL = WithSL;
            _data.body.SLTriggerRate = SLTriggerRate;
            _data.body.IsSLTriggered = IsSLTriggered;
            _data.body.Volume = Volume;
            _data.body.OldTradedQty = OldTradedQty;
            _data.body.ProductType = ProductType;
            _data.body.ExchOrderId = ExchOrderId;
            _data.body.ClientIP = obj.GetIPAddress();
            _data.body.AppSource = AppSource;


            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void TradeInformation(string ClientCode, List<CommonCode.TradeInformationList> lstData)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.TradeInformationReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "TradeInformation";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQTrdInfo";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;
            _data.body.TradeInformationList = lstData;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void NetPositionV4(string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "V4/NetPosition";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQNetPositionV4";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void NetPositionNetWiseV1(string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "V1/NetPositionNetWise";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQNPNWV1";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void OrderStatus(string ClientCode, List<CommonCode.OrderStatusList> lstData)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.OrderStatusReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "OrderStatus";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQOrdStatus";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;
            _data.body.OrdStatusReqList = lstData;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void BackoffClientProfile(string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "BackoffClientProfile";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQBackoffClientProfile";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void BackoffEquitytransaction(string ClientCode, string FromDate, string ToDate)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.BOCommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "BackoffEquitytransaction";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQBackoffEquitytransaction";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;
            _data.body.FromDate = FromDate;
            _data.body.ToDate = ToDate;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void BackoffFutureTransaction(string ClientCode, string FromDate, string ToDate)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.BOCommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "BackoffFutureTransaction";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQBackoffFutureTransaction";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;
            _data.body.FromDate = FromDate;
            _data.body.ToDate = ToDate;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void BackoffoptionTransaction(string ClientCode, string FromDate, string ToDate)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.BOCommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "BackoffoptionTransaction";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQBackoffoptionTransaction";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;
            _data.body.FromDate = FromDate;
            _data.body.ToDate = ToDate;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void BackoffMutualFundTransaction(string ClientCode, string FromDate, string ToDate)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.BOCommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "BackoffMutualFundTransaction";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQBackoffMutulFundTransaction";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;
            _data.body.FromDate = FromDate;
            _data.body.ToDate = ToDate;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void BackoffLedger(string ClientCode, string FromDate, string ToDate)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.BOCommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "BackoffLedger";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQBackoffLedger";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;
            _data.body.FromDate = FromDate;
            _data.body.ToDate = ToDate;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void BackoffDPTransaction(string ClientCode, string FromDate, string ToDate)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.BOCommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "BackoffDPTransaction";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQBackoffDPTransaction";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;
            _data.body.FromDate = FromDate;
            _data.body.ToDate = ToDate;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void BackoffDPHolding(string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "BackoffDPHolding";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers["IIFLcookie"] = Session["IIFLcookie"].ToString();
            _data.head.requestCode = "IIFLMarRQBackoffDPHolding";
            _data.head.key = obj.GetAppKeySettings("HeadKey");
            _data.head.appVer = "1.0";
            _data.head.appName = obj.GetAppKeySettings("AppName");
            _data.head.osName = "Android";
            _data.head.userId = obj.GetAppKeySettings("UserID");
            _data.head.password = obj.GetAppKeySettings("Pwd");
            _data.body.ClientCode = ClientCode;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data);
            var bytes = Encoding.UTF8.GetBytes(postData);
            request.ContentLength = bytes.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(string.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                Stream stream1 = response.GetResponseStream();
                var sr = new StreamReader(stream1);
                ReturnData = sr.ReadToEnd();
            }

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }
    }
}
