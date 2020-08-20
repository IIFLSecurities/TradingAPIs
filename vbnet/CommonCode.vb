Imports System.Net

Public Class CommonCode
    Public Function GetAppKeySettings(ByVal sKey As String) As String
        Return ConfigurationManager.AppSettings(sKey).ToString()
    End Function

    Public Function GetIPAddress() As String
        Dim strHostName As String = ""
        Dim strIPAddress = ""

        Try
            strHostName = Net.Dns.GetHostName()
            Dim ipaddress As IPAddress() = Net.Dns.GetHostAddresses(strHostName)

            For Each ip As IPAddress In ipaddress
                strIPAddress = ip.ToString()
            Next

        Catch ex As Exception
            strIPAddress = ""
        End Try

        Return strIPAddress
    End Function

    Public Class LoginRequestMobileRes
        Public head As ResHeader = New ResHeader()
        Public body As LoginRequestMobileResBody = New LoginRequestMobileResBody()
    End Class

    Public Class LoginRequestMobileResBody
        Public Property EmailId As String
        Public Property Message As String
        Public Property Status As Integer
        Public Property TTManagerId As String
        Public Property UserName As String
        Public Property ValidUpto As Date
        Public Property VendorName As String
    End Class

    Public Class ResHeader
        Public Property responseCode As String
        Public Property status As String
        Public Property statusDescription As String
    End Class

    Public Class BOCommonReq
        Public head As ReqHeader = New ReqHeader()
        Public body As BOCommonReqBody = New BOCommonReqBody()
    End Class

    Public Class BOCommonReqBody
        Public Property ClientCode As String
        Public Property FromDate As String
        Public Property ToDate As String
    End Class

    Public Class OrderStatusReq
        Public head As ReqHeader = New ReqHeader()
        Public body As OrderStatusReqBody = New OrderStatusReqBody()
    End Class

    Public Class OrderStatusReqBody
        Public Property ClientCode As String
        Public OrdStatusReqList As List(Of OrderStatusList) = New List(Of OrderStatusList)()
    End Class

    Public Class OrderStatusList
        Public Property Exch As Char
        Public Property ExchType As Char
        Public Property ScripCode As Long
        Public Property RemoteOrderID As String
    End Class

    Public Class TradeInformationReq
        Public head As ReqHeader = New ReqHeader()
        Public body As TradeInformationReqBody = New TradeInformationReqBody()
    End Class

    Public Class TradeInformationReqBody
        Public Property ClientCode As String
        Public TradeInformationList As List(Of TradeInformationList) = New List(Of TradeInformationList)()
    End Class

    Public Class TradeInformationList
        Public Property Exch As Char
        Public Property ExchType As Char
        Public Property ScripCode As Long
        Public Property ExchOrderID As String
    End Class

    Public Class PreOrdMarginCalReq
        Public head As ReqHeader = New ReqHeader()
        Public body As PreOrdMarginCalReqBody = New PreOrdMarginCalReqBody()
    End Class

    Public Class PreOrdMarginCalReqBody
        Public Property ClientCode As String
        Public Property OrderRequestorCode As String
        Public Property Exch As String
        Public Property ExchType As String
        Public Property ScripCode As Integer
        Public Property PlaceModifyCancel As String
        Public Property TransactionType As String
        Public Property AtMarket As String
        Public Property LimitRate As Double
        Public Property WithSL As String
        Public Property SLTriggerRate As Double
        Public Property IsSLTriggered As Char
        Public Property Volume As Long
        Public Property OldTradedQty As Long
        Public Property ProductType As Char
        Public Property ExchOrderId As String
        Public Property ClientIP As String
        Public Property AppSource As Integer
    End Class

    Public Class CommonReq
        Public head As ReqHeader = New ReqHeader()
        Public body As CommonBody = New CommonBody()
    End Class

    Public Class CommonBody
        Public Property ClientCode As String
    End Class

    Public Class LoginRequestV2Req
        Public head As ReqHeader = New ReqHeader()
        Public body As LoginRequestV2ReqBody = New LoginRequestV2ReqBody()
    End Class

    Public Class LoginRequestV2ReqBody
        Public Property ClientCode As String
        Public Property Password As String
        Public Property LocalIP As String
        Public Property PublicIP As String
        Public Property HDSerialNumber As String
        Public Property MACAddress As String
        Public Property MachineID As String
        Public Property VersionNo As String
        Public Property RequestNo As String
        Public Property My2PIN As String
        Public Property ConnectionType As String
    End Class

    Public Class LoginRequestMobileReq
        Public head As ReqHeader = New ReqHeader()
        Public body As LoginRequestMobileReqBody = New LoginRequestMobileReqBody()
    End Class

    Public Class ReqHeader
        Public Property appName As String
        Public Property appVer As String
        Public Property key As String
        Public Property osName As String
        Public Property requestCode As String
        Public Property userId As String
        Public Property password As String
    End Class

    Public Class LoginRequestMobileReqBody
        Public Property Email_id As String
        Public Property LocalIP As String
        Public Property PublicIP As String
        Public Property ContactNumber As String
    End Class


End Class
