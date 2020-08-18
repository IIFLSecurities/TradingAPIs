using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;

namespace VendorOpenAPIWebApp
{
    public class CommonCode
    {
        public string GetAppKeySettings(string sKey)
        {
            return ConfigurationManager.AppSettings[sKey].ToString();
        }

        public string GetIPAddress()
        {
            string strHostName = "";
            var strIPAddress = "";
            try
            {
                strHostName = System.Net.Dns.GetHostName();
                IPAddress[] ipaddress = System.Net.Dns.GetHostAddresses(strHostName);
                foreach (IPAddress ip in ipaddress)
                {
                    strIPAddress = ip.ToString();
                }
            }
            catch (Exception ex)
            {
                strIPAddress = "";
            }

            return strIPAddress;
        }

        public class LoginRequestMobileRes
        {
            public ResHeader head = new ResHeader();
            public LoginRequestMobileResBody body = new LoginRequestMobileResBody();
        }

        public class LoginRequestMobileResBody
        {
            public string EmailId { get; set; }
            public string Message { get; set; }
            public int Status { get; set; }
            public string TTManagerId { get; set; }
            public string UserName { get; set; }
            public DateTime ValidUpto { get; set; }
            public string VendorName { get; set; }
        }

        public class ResHeader
        {
            public string responseCode { get; set; }
            public string status { get; set; }
            public string statusDescription { get; set; }
        }
        public class BOCommonReq
        {
            public ReqHeader head = new ReqHeader();
            public BOCommonReqBody body = new BOCommonReqBody();
        }

        public class BOCommonReqBody
        {
            public string ClientCode { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
        }

        public class OrderStatusReq
        {
            public ReqHeader head = new ReqHeader();
            public OrderStatusReqBody body = new OrderStatusReqBody();
        }

        public class OrderStatusReqBody
        {
            public string ClientCode { get; set; }
            public List<OrderStatusList> OrdStatusReqList = new List<OrderStatusList>();
        }

        public class OrderStatusList
        {
            public char Exch { get; set; }
            public char ExchType { get; set; }
            public long ScripCode { get; set; }
            public string RemoteOrderID { get; set; }
        }

        public class TradeInformationReq
        {
            public ReqHeader head = new ReqHeader();
            public TradeInformationReqBody body = new TradeInformationReqBody();
        }

        public class TradeInformationReqBody
        {
            public string ClientCode { get; set; }
            public List<TradeInformationList> TradeInformationList = new List<TradeInformationList>();
        }

        public class TradeInformationList
        {
            public char Exch { get; set; }
            public char ExchType { get; set; }
            public long ScripCode { get; set; }
            public string ExchOrderID { get; set; }
        }

        public class PreOrdMarginCalReq
        {
            public ReqHeader head = new ReqHeader();
            public PreOrdMarginCalReqBody body = new PreOrdMarginCalReqBody();
        }

        public class PreOrdMarginCalReqBody
        {
            public string ClientCode { get; set; }
            public string OrderRequestorCode { get; set; }
            public string Exch { get; set; }
            public string ExchType { get; set; }
            public int ScripCode { get; set; }
            public string PlaceModifyCancel { get; set; }
            public string TransactionType { get; set; }
            public string AtMarket { get; set; }
            public double LimitRate { get; set; }
            public string WithSL { get; set; }
            public double SLTriggerRate { get; set; }
            public char IsSLTriggered { get; set; }
            public long Volume { get; set; }
            public long OldTradedQty { get; set; }
            public char ProductType { get; set; }
            public string ExchOrderId { get; set; }
            public string ClientIP { get; set; }
            public int AppSource { get; set; }
        }

        public class CommonReq
        {
            public ReqHeader head = new ReqHeader();
            public CommonBody body = new CommonBody();
        }

        public class CommonBody
        {
            public string ClientCode { get; set; }
        }

        public class LoginRequestV2Req
        {
            public ReqHeader head = new ReqHeader();
            public LoginRequestV2ReqBody body = new LoginRequestV2ReqBody();
        }

        public class LoginRequestV2ReqBody
        {
            public string ClientCode { get; set; }
            public string Password { get; set; }
            public string LocalIP { get; set; }
            public string PublicIP { get; set; }
            public string HDSerialNumber { get; set; }
            public string MACAddress { get; set; }
            public string MachineID { get; set; }
            public string VersionNo { get; set; }
            public string RequestNo { get; set; }
            public string My2PIN { get; set; }
            public string ConnectionType { get; set; }
        }

        public class LoginRequestMobileReq
        {
            public ReqHeader head = new ReqHeader();
            public LoginRequestMobileReqBody body = new LoginRequestMobileReqBody();
        }

        public class ReqHeader
        {
            public string appName { get; set; }
            public string appVer { get; set; }
            public string key { get; set; }
            public string osName { get; set; }
            public string requestCode { get; set; }
            public string userId { get; set; }
            public string password { get; set; }
        }

        public class LoginRequestMobileReqBody
        {
            public string Email_id { get; set; }
            public string LocalIP { get; set; }
            public string PublicIP { get; set; }
            public string ContactNumber { get; set; }
        }
    }
}