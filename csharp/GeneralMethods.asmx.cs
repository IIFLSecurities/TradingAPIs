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
        public void LoginRequestMobileForVendor(string AppName, string UserKey, string UserID, string UserPassword, string EncryptionKey, string Email_id, string ContactNumber)
        {
            CommonCode obj = new CommonCode();

            var encoding2 = new UTF8Encoding();

            byte[] UserIDEncryptReturn = { };
            byte[] UserPasswordReturn = { };

            string UserIDPass;
            string UserPasswordPass;

            obj.Encrypt_Vendor(encoding2.GetBytes(UserID), EncryptionKey, ref UserIDEncryptReturn);
            UserIDPass = Convert.ToBase64String(UserIDEncryptReturn);
            obj.Encrypt_Vendor(encoding2.GetBytes(UserPassword), EncryptionKey, ref UserPasswordReturn);
            UserPasswordPass = Convert.ToBase64String(UserPasswordReturn);


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
            _data.head.key = UserKey;
            _data.head.appVer = "1.0";
            _data.head.appName = AppName;
            _data.head.osName = "Android";
            _data.head.userId = UserIDPass;
            _data.head.password = UserPasswordPass;
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

            Session["IIFLMarcookie"] = CookieValue;

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void LoginRequest(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, string Password, string DOB, string EncryptionKey)
        {
            CommonCode obj = new CommonCode();

            var encoding2 = new UTF8Encoding();

            byte[] DOBEncryptReturn = { };
            byte[] PswdEncryptReturn = { };
            byte[] CCEncryptReturn = { };
            string ClientCodePass;
            string PswdPass;
            string DOBPass;
            obj.Encrypt_Vendor(encoding2.GetBytes(ClientCode), EncryptionKey, ref CCEncryptReturn);
            ClientCodePass = Convert.ToBase64String(CCEncryptReturn);
            obj.Encrypt_Vendor(encoding2.GetBytes(Password), EncryptionKey, ref PswdEncryptReturn);
            PswdPass = Convert.ToBase64String(PswdEncryptReturn);
            obj.Encrypt_Vendor(encoding2.GetBytes(DOB), EncryptionKey, ref DOBEncryptReturn);
            DOBPass = Convert.ToBase64String(DOBEncryptReturn);

            var _data = new CommonCode.LoginRequestReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "LoginRequest";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            _data.head.requestCode = "IIFLMarRQLoginForVendor";
            _data.head.key = UserKey;
            _data.head.appVer = "1.0";
            _data.head.appName = AppName;
            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;

            _data.body.ClientCode = ClientCodePass;
            _data.body.Password = PswdPass;
            _data.body.LocalIP = obj.GetIPAddress();
            _data.body.PublicIP = _data.body.LocalIP;
            _data.body.HDSerialNumber = "";
            _data.body.MACAddress = "";
            _data.body.MachineID = "";
            _data.body.VersionNo = "1.0.16.0";
            _data.body.RequestNo = "1";
            _data.body.My2PIN = DOBPass;
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

            Session["IIFLMarcookie"] = CookieValue;

            Context.Response.ContentType = "application/json; charset=utf-8";
            Context.Response.Write(JsonConvert.SerializeObject(ReturnData));
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void OrderBook(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "OrderBook";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQOrdBkV1";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void OrderRequest(string AppName, string UserKey, string ClientCode, string UserID, string UserPassword, string OrderFor, char Exchange, char ExchangeType, double Price, long OrderID, string OrderType, long Qty, long ScripCode, bool AtMarket, string RemoteOrderID, string ExchOrderID, long DisQty, bool IsStopLossOrder, double StopLossPrice, bool IsVTD, bool IOCOrder, bool IsIntraday, string PublicIP, char AHPlaced, CommonCode.OrderValidity iOrderValidity, string OrderRequesterCode, long TradedQty, int AppSource)
        {
            var obj = new CommonCode();
            var _data = new CommonCode.ReqOrderRequest();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "OrderRequest";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data._ReqData.head.requestCode = "IIFLMarRQOrdReq";
            _data._ReqData.head.key = UserKey;
            _data._ReqData.head.appName = AppName;
            _data._ReqData.head.appVer = "1.0";
            _data._ReqData.head.osName = "Android";
            _data._ReqData.head.userId = UserID;
            _data._ReqData.head.password = UserPassword;
            _data._ReqData.body.ClientCode = ClientCode;
            _data._ReqData.body.OrderFor = OrderFor;
            _data._ReqData.body.Exchange = Exchange;
            _data._ReqData.body.ExchangeType = ExchangeType;
            _data._ReqData.body.Price = Price;
            _data._ReqData.body.OrderID = OrderID;
            _data._ReqData.body.OrderType = OrderType;
            _data._ReqData.body.Qty = Qty;
            var setting = new JsonSerializerSettings();
            setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            _data._ReqData.body.OrderDateTime = DateTime.Now;
            _data._ReqData.body.ScripCode = ScripCode;
            _data._ReqData.body.AtMarket = AtMarket;
            _data._ReqData.body.RemoteOrderID = RemoteOrderID;
            _data._ReqData.body.ExchOrderID = ExchOrderID;
            _data._ReqData.body.DisQty = DisQty;
            _data._ReqData.body.StopLossPrice = StopLossPrice;
            _data._ReqData.body.IsStopLossOrder = IsStopLossOrder;
            _data._ReqData.body.IOCOrder = IOCOrder;
            _data._ReqData.body.IsIntraday = IsIntraday;
            _data._ReqData.body.ValidTillDate = DateTime.Now;
            _data._ReqData.body.AHPlaced = AHPlaced;
            _data._ReqData.body.PublicIP = PublicIP;
            _data._ReqData.body.iOrderValidity = iOrderValidity;
            _data._ReqData.body.TradedQty = TradedQty;
            _data._ReqData.body.OrderRequesterCode = OrderRequesterCode;
            _data.AppSource = AppSource;
            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data, setting);
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
        public void AdvanceModifySMOOrder(string AppName, string UserKey, string ClientCode, string UserID, string UserPassword, string OrderRequesterCode, string OrderFor, char Exchange, char ExchangeType, double Price, long OrderID, string OrderType, long Qty, long ScripCode, bool AtMarket, string RemoteOrderID, string ExchOrderID, long DisQty, bool IsStopLossOrder, double StopLossPrice, bool IsVTD, bool IOCOrder, bool IsIntraday, char AHPlaced, CommonCode.OrderValidity iOrderValidity, double TrailingSL, int LegType, int TMOPartnerOrderID, int AppSource)
        {
            var obj = new CommonCode();
            var _data = new CommonCode.ReqAdvModifySMOOrderDetails();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "AdvanceModifySMOOrder";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data._ReqData.head.requestCode = "IIFLMarKETANMAR";
            _data._ReqData.head.key = UserKey;
            _data._ReqData.head.appName = AppName;
            _data._ReqData.head.appVer = "1.0";
            _data._ReqData.head.osName = "Android";
            _data._ReqData.head.userId = UserID;
            _data._ReqData.head.password = UserPassword;
            _data._ReqData.body.ClientCode = ClientCode;
            _data._ReqData.body.OrderFor = OrderFor;
            _data._ReqData.body.OrderRequesterCode = OrderRequesterCode;
            _data._ReqData.body.Exchange = Exchange;
            _data._ReqData.body.ExchangeType = ExchangeType;
            _data._ReqData.body.Price = Price;
            _data._ReqData.body.OrderID = OrderID;
            _data._ReqData.body.OrderType = OrderType;
            _data._ReqData.body.Qty = Qty;
            var setting = new JsonSerializerSettings();
            setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            _data._ReqData.body.OrderDateTime = DateTime.Now;
            _data._ReqData.body.ScripCode = ScripCode;
            _data._ReqData.body.AtMarket = AtMarket;
            _data._ReqData.body.RemoteOrderID = RemoteOrderID;
            _data._ReqData.body.ExchOrderID = ExchOrderID;
            _data._ReqData.body.DisQty = DisQty;
            _data._ReqData.body.StopLossPrice = StopLossPrice;
            _data._ReqData.body.IsStopLossOrder = IsStopLossOrder;
            _data._ReqData.body.IOCOrder = IOCOrder;
            _data._ReqData.body.IsIntraday = IsIntraday;
            _data._ReqData.body.ValidTillDate = DateTime.Now;
            _data._ReqData.body.AHPlaced = AHPlaced;
            _data._ReqData.body.PublicIP = obj.GetIPAddress();
            _data._ReqData.body.iOrderValidity = iOrderValidity;
            _data._ReqData.body.TrailingSL = TrailingSL;
            _data._ReqData.body.LegType = LegType;
            _data._ReqData.body.TMOPartnerOrderID = TMOPartnerOrderID;

            _data.AppSource = AppSource;
            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data, setting);
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
        public void PlaceSMOOrder(string AppName, string UserKey, string ClientCode, string UserID, string UserPassword, string OrderRequesterCode, string RequestType, string BuySell, long Qty, string Exch, string ExchType, long DisQty, bool AtMarket, long ExchOrderID, double LimitPriceInitialOrder, double TriggerPriceInitialOrder, double LimitPriceProfitOrder, double LimitPriceForSL, double TriggerPriceForSL, double TrailingSL, bool StopLoss, int ScripCode, string OrderFor, string UniqueOrderIDNormal, string UniqueOrderIDSL, string UniqueOrderIDLimit, long LocalOrderIDNormal, long LocalOrderIDSL, long LocalOrderIDLimit, int AppSource)
        {
            var obj = new CommonCode();
            var _data = new CommonCode.ReqPlaceSMOOrderDetails();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "PlaceSMOOrder";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data._ReqData.head.requestCode = "IIFLMarKETANMAR";
            _data._ReqData.head.key = UserKey;
            _data._ReqData.head.appName = AppName;
            _data._ReqData.head.appVer = "1.0";
            _data._ReqData.head.osName = "Android";
            _data._ReqData.head.userId = UserID;
            _data._ReqData.head.password = UserPassword;
            _data._ReqData.body.ClientCode = ClientCode;

            _data._ReqData.body.OrderRequesterCode = OrderRequesterCode;
            _data._ReqData.body.Exch = Exch;
            _data._ReqData.body.ExchType = ExchType;
            _data._ReqData.body.DisQty = DisQty;
            _data._ReqData.body.AtMarket = AtMarket;
            _data._ReqData.body.ExchOrderID = ExchOrderID;

            _data._ReqData.body.LimitPriceInitialOrder = LimitPriceInitialOrder;
            _data._ReqData.body.TriggerPriceInitialOrder = TriggerPriceInitialOrder;
            _data._ReqData.body.LimitPriceProfitOrder = LimitPriceProfitOrder;
            _data._ReqData.body.LimitPriceForSL = LimitPriceForSL;
            _data._ReqData.body.TriggerPriceForSL = TriggerPriceForSL;
            _data._ReqData.body.TrailingSL = TrailingSL;
            _data._ReqData.body.StopLoss = StopLoss;
            _data._ReqData.body.ScripCode = ScripCode;
            _data._ReqData.body.OrderFor = OrderFor;
            _data._ReqData.body.UniqueOrderIDNormal = UniqueOrderIDNormal;
            _data._ReqData.body.UniqueOrderIDLimit = UniqueOrderIDLimit;
            _data._ReqData.body.LocalOrderIDNormal = LocalOrderIDNormal;
            _data._ReqData.body.LocalOrderIDSL = LocalOrderIDSL;
            _data._ReqData.body.LocalOrderIDLimit = LocalOrderIDLimit;
            _data._ReqData.body.PublicIP = obj.GetIPAddress();
            _data.AppSource = AppSource;
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
        public void MarketFeed(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, int Count, string MarketFeedData, int ClientLoginType, string RefreshRate)
        {
            CommonCode obj = new CommonCode();
            List<CommonCode.MarketFeedNew> lstMFN = new List<CommonCode.MarketFeedNew>();
            lstMFN = JsonConvert.DeserializeObject<List<CommonCode.MarketFeedNew>>(MarketFeedData);

            var _data = new CommonCode.MarketFeedReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "MarketFeed";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarLOHIO1";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
            _data.body.ClientCode = ClientCode;
            _data.body.Count = Count;
            _data.body.MarketFeedData = lstMFN;
            _data.body.ClientLoginType = ClientLoginType;
            var setting = new JsonSerializerSettings();
            setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            _data.body.LastRequestTime = DateTime.Now;
            _data.body.RefreshRate = RefreshRate;

            postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data, setting);
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
        public void Holding(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "Holding";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQHoldingV2";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void Margin(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "Margin";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQMarginV3";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void OrderBookV2(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "OrderBookV2";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQOrdBkV2";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void TradeBook(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "TradeBook";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQTrdBkV1";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void PreOrdMarginCalculation(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, string OrderRequestorCode, string Exch, string ExchType, int ScripCode, string PlaceModifyCancel,
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQPreOrdMarCal";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void TradeInformation(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, List<CommonCode.TradeInformationList> lstData)
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQTrdInfo";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void NetPosition(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "NetPosition";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQNetPositionV4";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void NetPositionNetWise(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode)
        {
            CommonCode obj = new CommonCode();

            var _data = new CommonCode.CommonReq();
            string ReturnData = string.Empty;
            string postData = string.Empty;
            string mobileServiceURL = obj.GetAppKeySettings("ServiceURL");
            mobileServiceURL = mobileServiceURL + "NetPositionNetWise";
            HttpWebRequest request = WebRequest.Create(mobileServiceURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQNPNWV2";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void OrderStatus(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, List<CommonCode.OrderStatusList> lstData)
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQOrdStatus";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
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
        public void BackoffClientProfile(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode)
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQBackoffClientProfile";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void BackoffEquitytransaction(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, string FromDate, string ToDate)
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQBackoffEquitytransaction";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void BackoffFutureTransaction(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, string FromDate, string ToDate)
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQBackoffFutureTransaction";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void BackoffoptionTransaction(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, string FromDate, string ToDate)
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQBackoffoptionTransaction";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void BackoffMutualFundTransaction(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, string FromDate, string ToDate)
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQBackoffMutulFundTransaction";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void BackoffLedger(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, string FromDate, string ToDate)
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQBackoffLedger";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void BackoffDPTransaction(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode, string FromDate, string ToDate)
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQBackoffDPTransaction";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
        public void BackoffDPHolding(string AppName, string UserKey, string UserID, string UserPassword, string ClientCode)
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

            var container = new CookieContainer();
            var cookie = new Cookie("IIFLMarcookie", Session["IIFLMarcookie"].ToString());
            cookie.Domain = "dataservice.iifl.in";
            container.Add(cookie);
            request.CookieContainer = container;

            _data.head.requestCode = "IIFLMarRQBackoffDPHolding";
            _data.head.key = UserKey;
            _data.head.appName = AppName;
            _data.head.appVer = "1.0";

            _data.head.osName = "Android";
            _data.head.userId = UserID;
            _data.head.password = UserPassword;
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
