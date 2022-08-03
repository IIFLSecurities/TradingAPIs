Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports System.Web.Script.Services

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")>
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<ToolboxItem(False)>
Public Class GeneralMethods
    Inherits System.Web.Services.WebService

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub LoginRequestMobileForVendor(ByVal AppName As String, ByVal UserKey As String, ByVal UserID As String, ByVal UserPassword As String, ByVal EncryptionKey As String, ByVal Email_id As String, ByVal ContactNumber As String)
        Dim obj As CommonCode = New CommonCode()

        Dim encoding2 As New System.Text.UTF8Encoding
        Dim UserIDEncryptReturn() As Byte = {}
        Dim UserPasswordReturn() As Byte = {}
        Dim UserIDPass As String, UserPasswordPass As String

        obj.Encrypt_Vendor(encoding2.GetBytes(UserID), EncryptionKey, UserIDEncryptReturn)
        UserIDPass = Convert.ToBase64String(UserIDEncryptReturn)

        obj.Encrypt_Vendor(encoding2.GetBytes(UserPassword), EncryptionKey, UserPasswordReturn)
        UserPasswordPass = Convert.ToBase64String(UserPasswordReturn)

        Dim _data = New CommonCode.LoginRequestMobileReq()
        Dim objFinal As CommonCode.LoginRequestMobileRes = New CommonCode.LoginRequestMobileRes()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "LoginRequestMobileForVendor"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        _data.head.requestCode = "IIFLMarRQLoginForVendor"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserIDPass
        _data.head.password = UserPasswordPass
        _data.body.Email_id = Email_id
        _data.body.ContactNumber = ContactNumber
        _data.body.LocalIP = obj.GetIPAddress()
        _data.body.PublicIP = _data.body.LocalIP
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Dim CookieValue = ""
        Dim value1 As String = ""

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
            Dim reponseURI As String() = response.Headers.AllKeys
            value1 = response.Headers.[Get]("Set-Cookie")
            Dim value2 = value1.Split(";")
            Dim final = value2(0).Split("=")
            CookieValue = final(1)
        End Using

        'Session("IIFLMarcookie") = CookieValue
        Session("IIFLcookie") = CookieValue

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))

    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub LoginRequest(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal Password As String, ByVal DOB As String, ByVal UserID As String, ByVal UserPassword As String, ByVal EncryptionKey As String)
        Dim obj As CommonCode = New CommonCode()

        Dim encoding2 As New System.Text.UTF8Encoding
        Dim DOBEncryptReturn() As Byte = {}
        Dim PswdEncryptReturn() As Byte = {}
        Dim CCEncryptReturn() As Byte = {}
        Dim ClientCodePass As String, PswdPass As String, DOBPass As String

        obj.Encrypt_Vendor(encoding2.GetBytes(ClientCode), EncryptionKey, CCEncryptReturn)
        ClientCodePass = Convert.ToBase64String(CCEncryptReturn)

        obj.Encrypt_Vendor(encoding2.GetBytes(Password), EncryptionKey, PswdEncryptReturn)
        PswdPass = Convert.ToBase64String(PswdEncryptReturn)

        obj.Encrypt_Vendor(encoding2.GetBytes(DOB), EncryptionKey, DOBEncryptReturn)
        DOBPass = Convert.ToBase64String(DOBEncryptReturn)

        Dim _data = New CommonCode.LoginRequestReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "LoginRequest"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        _data.head.requestCode = "IIFLMarRQLoginRequestV2"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"

        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCodePass
        _data.body.Password = PswdPass
        _data.body.LocalIP = obj.GetIPAddress()
        _data.body.PublicIP = _data.body.LocalIP
        _data.body.HDSerialNumber = ""
        _data.body.MACAddress = ""
        _data.body.MachineID = ""
        _data.body.VersionNo = "1.0.16.0"
        _data.body.RequestNo = "1"
        _data.body.My2PIN = DOBPass
        _data.body.ConnectionType = "1"
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Dim CookieValue = ""
        Dim value1 = ""
        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
            Dim reponseURI As String() = response.Headers.AllKeys
            value1 = response.Headers.[Get]("Set-Cookie")
            Dim value2 = value1.Split(";")
            Dim final = value2(0).Split("=")
            CookieValue = final(1)
        End Using

        Session("IIFLMarcookie") = CookieValue

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub OrderBook(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "OrderBook"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQOrdBkV1"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"

        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))

    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub OrderRequest(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String, ByVal OrderFor As String,
        ByVal Exchange As Char, ByVal ExchangeType As Char, ByVal Price As Double, ByVal OrderID As Long, ByVal OrderType As String, ByVal Qty As Long,
        ByVal ScripCode As Long, ByVal AtMarket As Boolean, ByVal RemoteOrderID As String, ByVal ExchOrderID As String, ByVal DisQty As Long, ByVal IsStopLossOrder As Boolean,
        ByVal StopLossPrice As Double, ByVal IsVTD As Boolean, ByVal IOCOrder As Boolean, ByVal IsIntraday As Boolean, ByVal PublicIP As String, ByVal AHPlaced As Char,
        ByVal iOrderValidity As CommonCode.OrderValidity, ByVal OrderRequesterCode As String, ByVal TradedQty As Long, ByVal AppSource As Integer)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.ReqOrderRequest()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "OrderRequest"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data._ReqData.head.requestCode = "IIFLMarRQOrdReq"
        _data._ReqData.head.key = UserKey
        _data._ReqData.head.appName = AppName
        _data._ReqData.head.appVer = "1.0"

        _data._ReqData.head.osName = "Android"
        _data._ReqData.head.userId = UserID
        _data._ReqData.head.password = UserPassword

        _data._ReqData.body.ClientCode = ClientCode
        _data._ReqData.body.OrderFor = OrderFor
        _data._ReqData.body.Exchange = Exchange
        _data._ReqData.body.ExchangeType = ExchangeType
        _data._ReqData.body.Price = Price
        _data._ReqData.body.OrderID = OrderID
        _data._ReqData.body.OrderType = OrderType
        _data._ReqData.body.Qty = Qty

        Dim setting As JsonSerializerSettings = New JsonSerializerSettings
        setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat

        _data._ReqData.body.OrderDateTime = DateTime.Now
        _data._ReqData.body.ScripCode = ScripCode
        _data._ReqData.body.AtMarket = AtMarket
        _data._ReqData.body.RemoteOrderID = RemoteOrderID
        _data._ReqData.body.ExchOrderID = ExchOrderID
        _data._ReqData.body.DisQty = DisQty
        _data._ReqData.body.StopLossPrice = StopLossPrice
        _data._ReqData.body.IsStopLossOrder = IsStopLossOrder
        _data._ReqData.body.IOCOrder = IOCOrder
        _data._ReqData.body.IsIntraday = IsIntraday
        _data._ReqData.body.ValidTillDate = DateTime.Now
        _data._ReqData.body.AHPlaced = AHPlaced
        _data._ReqData.body.PublicIP = PublicIP
        _data._ReqData.body.iOrderValidity = iOrderValidity
        _data._ReqData.body.TradedQty = TradedQty
        _data._ReqData.body.OrderRequesterCode = OrderRequesterCode

        _data.AppSource = AppSource
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data, setting)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub AdvanceModifySMOOrder(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String, ByVal OrderRequesterCode As String, ByVal OrderFor As String, ByVal Exchange As Char, ByVal ExchangeType As Char, ByVal Price As Double, ByVal OrderID As Long, ByVal OrderType As String, ByVal Qty As Long, ByVal ScripCode As Long, ByVal AtMarket As Boolean, ByVal RemoteOrderID As String, ByVal ExchOrderID As String, ByVal DisQty As Long, ByVal IsStopLossOrder As Boolean, ByVal StopLossPrice As Double, ByVal IsVTD As Boolean, ByVal IOCOrder As Boolean, ByVal IsIntraday As Boolean, ByVal AHPlaced As Char, ByVal iOrderValidity As CommonCode.OrderValidity, ByVal TrailingSL As Double, ByVal LegType As Integer, ByVal TMOPartnerOrderID As Integer, ByVal AppSource As Integer)
        Dim obj = New CommonCode()
        Dim _data = New CommonCode.ReqAdvModifySMOOrderDetails()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "AdvanceModifySMOOrder"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        Dim container = New CookieContainer()
        Dim cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container
        _data._ReqData.head.requestCode = "IIFLMarKETANMAR"
        _data._ReqData.head.key = UserKey
        _data._ReqData.head.appName = AppName
        _data._ReqData.head.appVer = "1.0"
        _data._ReqData.head.osName = "Android"
        _data._ReqData.head.userId = UserID
        _data._ReqData.head.password = UserPassword
        _data._ReqData.body.ClientCode = ClientCode
        _data._ReqData.body.OrderFor = OrderFor
        _data._ReqData.body.OrderRequesterCode = OrderRequesterCode
        _data._ReqData.body.Exchange = Exchange
        _data._ReqData.body.ExchangeType = ExchangeType
        _data._ReqData.body.Price = Price
        _data._ReqData.body.OrderID = OrderID
        _data._ReqData.body.OrderType = OrderType
        _data._ReqData.body.Qty = Qty
        Dim setting = New JsonSerializerSettings()
        setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
        _data._ReqData.body.OrderDateTime = Date.Now
        _data._ReqData.body.ScripCode = ScripCode
        _data._ReqData.body.AtMarket = AtMarket
        _data._ReqData.body.RemoteOrderID = RemoteOrderID
        _data._ReqData.body.ExchOrderID = ExchOrderID
        _data._ReqData.body.DisQty = DisQty
        _data._ReqData.body.StopLossPrice = StopLossPrice
        _data._ReqData.body.IsStopLossOrder = IsStopLossOrder
        _data._ReqData.body.IOCOrder = IOCOrder
        _data._ReqData.body.IsIntraday = IsIntraday
        _data._ReqData.body.ValidTillDate = Date.Now
        _data._ReqData.body.AHPlaced = AHPlaced
        _data._ReqData.body.PublicIP = obj.GetIPAddress()
        _data._ReqData.body.iOrderValidity = iOrderValidity
        _data._ReqData.body.TrailingSL = TrailingSL
        _data._ReqData.body.LegType = LegType
        _data._ReqData.body.TMOPartnerOrderID = TMOPartnerOrderID
        _data.AppSource = AppSource
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data, setting)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If
            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub PlaceSMOOrder(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String, ByVal OrderRequesterCode As String, ByVal RequestType As String, ByVal BuySell As String, ByVal Qty As Long, ByVal Exch As String, ByVal ExchType As String, ByVal DisQty As Long, ByVal AtMarket As Boolean, ByVal ExchOrderID As Long, ByVal LimitPriceInitialOrder As Double, ByVal TriggerPriceInitialOrder As Double, ByVal LimitPriceProfitOrder As Double, ByVal LimitPriceForSL As Double, ByVal TriggerPriceForSL As Double, ByVal TrailingSL As Double, ByVal StopLoss As Boolean, ByVal ScripCode As Integer, ByVal OrderFor As String, ByVal UniqueOrderIDNormal As String, ByVal UniqueOrderIDSL As String, ByVal UniqueOrderIDLimit As String, ByVal LocalOrderIDNormal As Long, ByVal LocalOrderIDSL As Long, ByVal LocalOrderIDLimit As Long, ByVal AppSource As Integer)
        Dim obj = New CommonCode()
        Dim _data = New CommonCode.ReqPlaceSMOOrderDetails()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "PlaceSMOOrder"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        Dim container = New CookieContainer()
        Dim cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container
        _data._ReqData.head.requestCode = "IIFLMarKETANMAR"
        _data._ReqData.head.key = UserKey
        _data._ReqData.head.appName = AppName
        _data._ReqData.head.appVer = "1.0"
        _data._ReqData.head.osName = "Android"
        _data._ReqData.head.userId = UserID
        _data._ReqData.head.password = UserPassword
        _data._ReqData.body.ClientCode = ClientCode
        _data._ReqData.body.OrderRequesterCode = OrderRequesterCode
        _data._ReqData.body.Exch = Exch
        _data._ReqData.body.ExchType = ExchType
        _data._ReqData.body.DisQty = DisQty
        _data._ReqData.body.AtMarket = AtMarket
        _data._ReqData.body.ExchOrderID = ExchOrderID
        _data._ReqData.body.LimitPriceInitialOrder = LimitPriceInitialOrder
        _data._ReqData.body.TriggerPriceInitialOrder = TriggerPriceInitialOrder
        _data._ReqData.body.LimitPriceProfitOrder = LimitPriceProfitOrder
        _data._ReqData.body.LimitPriceForSL = LimitPriceForSL
        _data._ReqData.body.TriggerPriceForSL = TriggerPriceForSL
        _data._ReqData.body.TrailingSL = TrailingSL
        _data._ReqData.body.StopLoss = StopLoss
        _data._ReqData.body.ScripCode = ScripCode
        _data._ReqData.body.OrderFor = OrderFor
        _data._ReqData.body.UniqueOrderIDNormal = UniqueOrderIDNormal
        _data._ReqData.body.UniqueOrderIDLimit = UniqueOrderIDLimit
        _data._ReqData.body.LocalOrderIDNormal = LocalOrderIDNormal
        _data._ReqData.body.LocalOrderIDSL = LocalOrderIDSL
        _data._ReqData.body.LocalOrderIDLimit = LocalOrderIDLimit
        _data._ReqData.body.PublicIP = obj.GetIPAddress()
        _data.AppSource = AppSource
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)
            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If
            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub


    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub MarketFeed(ByVal AppName As String, ByVal UserKey As String, ByVal UserID As String, ByVal UserPassword As String, ByVal ClientCode As String, ByVal Count As Integer, ByVal MarketFeedData As String, ByVal ClientLoginType As Integer, ByVal RefreshRate As String)
        Dim obj As CommonCode = New CommonCode()
        Dim lstMFN As List(Of CommonCode.MarketFeedNew) = New List(Of CommonCode.MarketFeedNew)()
        lstMFN = JsonConvert.DeserializeObject(Of List(Of CommonCode.MarketFeedNew))(MarketFeedData)

        Dim _data = New CommonCode.MarketFeedReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "MarketFeed"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarLOHIO1"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        _data.body.Count = Count
        _data.body.MarketFeedData = lstMFN
        _data.body.ClientLoginType = ClientLoginType
        Dim setting = New JsonSerializerSettings()
        setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
        _data.body.LastRequestTime = Date.Now
        _data.body.RefreshRate = RefreshRate
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data, setting)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Holding(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "Holding"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQHoldingV2"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"

        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub Margin(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "Margin"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQMarginV3"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"

        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub OrderBookV2(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "OrderBookV2"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQOrdBkV2"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"

        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub TradeBook(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "TradeBook"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQTrdBkV1"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"

        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub PreOrdMarginCalculation(ByVal AppName As String, ByVal UserKey As String, ByVal UserID As String, ByVal UserPassword As String, ByVal ClientCode As String, ByVal OrderRequestorCode As String, ByVal Exch As String, ByVal ExchType As String, ByVal ScripCode As Integer, ByVal PlaceModifyCancel As String, ByVal TransactionType As String, ByVal AtMarket As String, ByVal LimitRate As Double, ByVal WithSL As String, ByVal SLTriggerRate As Double, ByVal IsSLTriggered As Char, ByVal Volume As Long, ByVal OldTradedQty As Long, ByVal ProductType As Char, ByVal ExchOrderId As String, ByVal AppSource As Integer)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.PreOrdMarginCalReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "PreOrdMarginCalculation"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQPreOrdMarCal"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"

        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        _data.body.OrderRequestorCode = OrderRequestorCode
        _data.body.Exch = Exch
        _data.body.ExchType = ExchType
        _data.body.ScripCode = ScripCode
        _data.body.PlaceModifyCancel = PlaceModifyCancel
        _data.body.TransactionType = TransactionType
        _data.body.AtMarket = AtMarket
        _data.body.LimitRate = LimitRate
        _data.body.WithSL = WithSL
        _data.body.SLTriggerRate = SLTriggerRate
        _data.body.IsSLTriggered = IsSLTriggered
        _data.body.Volume = Volume
        _data.body.OldTradedQty = OldTradedQty
        _data.body.ProductType = ProductType
        _data.body.ExchOrderId = ExchOrderId
        _data.body.ClientIP = obj.GetIPAddress()
        _data.body.AppSource = AppSource
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub TradeInformation(ByVal AppName As String, ByVal UserKey As String, ByVal UserID As String, ByVal UserPassword As String, ByVal ClientCode As String, ByVal lstData As List(Of CommonCode.TradeInformationList))
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.TradeInformationReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "TradeInformation"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQTrdInfo"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"

        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        _data.body.TradeInformationList = lstData
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub NetPosition(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "NetPosition"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQNetPositionV4"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub NetPositionNetWise(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "NetPositionNetWise"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQNPNWV2"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub OrderStatus(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String, ByVal lstData As List(Of CommonCode.OrderStatusList))
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.OrderStatusReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "OrderStatus"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQOrdStatus"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        _data.body.OrdStatusReqList = lstData
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub BackoffClientProfile(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffClientProfile"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQBackoffClientProfile"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub BackoffEquitytransaction(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffEquitytransaction"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQBackoffEquitytransaction"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        _data.body.FromDate = FromDate
        _data.body.ToDate = ToDate
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub BackoffFutureTransaction(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffFutureTransaction"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQBackoffFutureTransaction"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        _data.body.FromDate = FromDate
        _data.body.ToDate = ToDate
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub BackoffoptionTransaction(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffoptionTransaction"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQBackoffoptionTransaction"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        _data.body.FromDate = FromDate
        _data.body.ToDate = ToDate
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub BackoffMutualFundTransaction(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffMutualFundTransaction"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQBackoffMutulFundTransaction"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        _data.body.FromDate = FromDate
        _data.body.ToDate = ToDate
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub BackoffLedger(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffLedger"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQBackoffLedger"
        _data.head.key = UserKey
        _data.head.appName = AppName
        _data.head.appVer = "1.0"
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        _data.body.FromDate = FromDate
        _data.body.ToDate = ToDate
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub BackoffDPTransaction(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffDPTransaction"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQBackoffDPTransaction"
        _data.head.key = UserKey
        _data.head.appVer = "1.0"
        _data.head.appName = AppName
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        _data.body.FromDate = FromDate
        _data.body.ToDate = ToDate
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub BackoffDPHolding(ByVal AppName As String, ByVal UserKey As String, ByVal ClientCode As String, ByVal UserID As String, ByVal UserPassword As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffDPHolding"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"

        Dim container As CookieContainer = New CookieContainer()
        Dim cookie As Cookie = New Cookie("IIFLMarcookie", Session("IIFLMarcookie").ToString())
        cookie.Domain = "dataservice.iifl.in"
        container.Add(cookie)
        request.CookieContainer = container

        _data.head.requestCode = "IIFLMarRQBackoffDPHolding"
        _data.head.key = UserKey
        _data.head.appVer = "1.0"
        _data.head.appName = AppName
        _data.head.osName = "Android"
        _data.head.userId = UserID
        _data.head.password = UserPassword
        _data.body.ClientCode = ClientCode
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
        End Using

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

End Class