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
    Public Sub LoginRequestMobileForVendor(ByVal Email_id As String, ByVal ContactNumber As String)
        Dim obj As CommonCode = New CommonCode()

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
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("LoginUserID")
        _data.head.password = obj.GetAppKeySettings("LoginPwd")
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

        Session("IIFLcookie") = CookieValue

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))

    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub LoginRequestV2(ByVal ClientCode As String, ByVal Password As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.LoginRequestV2Req()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "V2/LoginRequest"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        _data.head.requestCode = "IIFLMarRQLoginForVendor"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
        _data.body.ClientCode = ClientCode
        _data.body.Password = Password
        _data.body.LocalIP = obj.GetIPAddress()
        _data.body.PublicIP = _data.body.LocalIP
        _data.body.HDSerialNumber = ""
        _data.body.MACAddress = ""
        _data.body.MachineID = ""
        _data.body.VersionNo = "1.0.16.0"
        _data.body.RequestNo = "1"
        _data.body.My2PIN = "xk0gmy36O4AOr77fVcBzxQ=="
        _data.body.ConnectionType = "1"
        postData = Newtonsoft.Json.JsonConvert.SerializeObject(_data)
        Dim bytes = Encoding.UTF8.GetBytes(postData)
        request.ContentLength = bytes.Length

        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes, 0, bytes.Length)
            requestStream.Close()
        End Using

        Dim CookieValue = ""

        Using response As HttpWebResponse = TryCast(request.GetResponse(), HttpWebResponse)

            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If

            Dim stream1 As Stream = response.GetResponseStream()
            Dim sr = New StreamReader(stream1)
            ReturnData = sr.ReadToEnd()
            Dim reponseURI As String() = response.Headers.AllKeys
            Dim value1 As String = response.Headers.[Get]("Set-Cookie")
            Dim value2 = value1.Split(";"c)
            Dim final = value2(0).Split("="c)
            CookieValue = final(1)
        End Using

        Session("IIFLcookie") = CookieValue

        Context.Response.ContentType = "application/json; charset=utf-8"
        Context.Response.Write(JsonConvert.SerializeObject(ReturnData))
    End Sub

    <WebMethod(EnableSession:=True)>
    <ScriptMethod(ResponseFormat:=ResponseFormat.Json)>
    Public Sub OrderBookV1(ByVal ClientCode As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "V1/OrderBook"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        Dim IIFLcookie As String = "IIFLcookie:" & Session("IIFLcookie").ToString()
        request.Headers.Add(IIFLcookie)
        _data.head.requestCode = "IIFLMarRQOrdBkV1"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub HoldingV2(ByVal ClientCode As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "V2/Holding"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQHoldingV2"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub MarginV3(ByVal ClientCode As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "V3/Margin"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQMarginV3"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub OrderBookV2(ByVal ClientCode As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "V2/OrderBook"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQOrdBkV2"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub TradeBookV1(ByVal ClientCode As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "V1/TradeBook"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQTrdBkV1"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub PreOrdMarginCalculation(ByVal ClientCode As String, ByVal OrderRequestorCode As String, ByVal Exch As String, ByVal ExchType As String, ByVal ScripCode As Integer, ByVal PlaceModifyCancel As String, ByVal TransactionType As String, ByVal AtMarket As String, ByVal LimitRate As Double, ByVal WithSL As String, ByVal SLTriggerRate As Double, ByVal IsSLTriggered As Char, ByVal Volume As Long, ByVal OldTradedQty As Long, ByVal ProductType As Char, ByVal ExchOrderId As String, ByVal AppSource As Integer)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.PreOrdMarginCalReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "PreOrdMarginCalculation"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQPreOrdMarCal"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub TradeInformation(ByVal ClientCode As String, ByVal lstData As List(Of CommonCode.TradeInformationList))
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.TradeInformationReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "TradeInformation"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQTrdInfo"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub NetPositionV4(ByVal ClientCode As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "V4/NetPosition"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQNetPositionV4"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub NetPositionNetWiseV1(ByVal ClientCode As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "V1/NetPositionNetWise"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQNPNWV1"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub OrderStatus(ByVal ClientCode As String, ByVal lstData As List(Of CommonCode.OrderStatusList))
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.OrderStatusReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "OrderStatus"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQOrdStatus"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub BackoffClientProfile(ByVal ClientCode As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffClientProfile"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQBackoffClientProfile"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub BackoffEquitytransaction(ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffEquitytransaction"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQBackoffEquitytransaction"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub BackoffFutureTransaction(ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffFutureTransaction"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQBackoffFutureTransaction"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub BackoffoptionTransaction(ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffoptionTransaction"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQBackoffoptionTransaction"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub BackoffMutualFundTransaction(ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffMutualFundTransaction"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQBackoffMutulFundTransaction"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub BackoffLedger(ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffLedger"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQBackoffLedger"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub BackoffDPTransaction(ByVal ClientCode As String, ByVal FromDate As String, ByVal ToDate As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.BOCommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffDPTransaction"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQBackoffDPTransaction"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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
    Public Sub BackoffDPHolding(ByVal ClientCode As String)
        Dim obj As CommonCode = New CommonCode()

        Dim _data = New CommonCode.CommonReq()
        Dim ReturnData As String = String.Empty
        Dim postData As String = String.Empty
        Dim mobileServiceURL As String = obj.GetAppKeySettings("ServiceURL")
        mobileServiceURL = mobileServiceURL & "BackoffDPHolding"
        Dim request As HttpWebRequest = TryCast(WebRequest.Create(mobileServiceURL), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        request.Headers("IIFLcookie") = Session("IIFLcookie").ToString()
        _data.head.requestCode = "IIFLMarRQBackoffDPHolding"
        _data.head.key = obj.GetAppKeySettings("HeadKey")
        _data.head.appVer = "1.0"
        _data.head.appName = obj.GetAppKeySettings("AppName")
        _data.head.osName = "Android"
        _data.head.userId = obj.GetAppKeySettings("UserID")
        _data.head.password = obj.GetAppKeySettings("Pwd")
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