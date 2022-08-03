package class

///**********************Request************************************** //

// Header : Header
type Header struct {
	AppName     string `json:"appName"`
	AppVer      string `json:"appVer"`
	Key         string `json:"key"`
	OsName      string `json:"osName"`
	RequestCode string `json:"requestCode"`
	UserID      string `json:"userId"`
	Password    string `json:"password"`
}

//LoginMobileVendorBody :LoginMobileVendorBody
type LoginMobileVendorBody struct {
	EmailID       string `json:"Email_id"`
	LocalIP       string `json:"LocalIP"`
	PublicIP      string `json:"PublicIP"`
	ContactNumber string `json:"ContactNumber"`
}

// LoginMobileVendorRequest : LoginMobileVendorRequest
type LoginMobileVendorRequest struct {
	Head Header                `json:"head"`
	Body LoginMobileVendorBody `json:"body"`
}

// LoginRequestBody : LoginRequestBody
type LoginRequestBody struct {
	ClientCode     string `json:"ClientCode"`
	Password       string `json:"Password"`
	HDSerialNumber string `json:"HDSerialNumber"`
	MACAddress     string `json:"MACAddress"`
	MachineID      string `json:"MachineID"`
	VersionNo      string `json:"VersionNo"`
	RequestNo      int    `json:"RequestNo"`
	My2PIN         string `json:"My2PIN"`
	ConnectionType int    `json:"ConnectionType"`
	LocalIP        string `json:"LocalIP"`
	PublicIP       string `json:"PublicIP"`
}

// LoginRequestRequest : LoginRequestRequest
type LoginRequestRequest struct {
	Head Header           `json:"head"`
	Body LoginRequestBody `json:"body"`
}

// HoldingBody : HoldingBody
type HoldingBody struct {
	ClientCode string `json:"ClientCode"`
}

// NetPositionHoldingBody : HoldingBody
type NetPositionHoldingBody struct {
	ClientCode string `json:"Clientcode"`
}

// HoldingRequest : HoldingRequest
type HoldingRequest struct {
	Head Header      `json:"head"`
	Body HoldingBody `json:"body"`
}

// NetPositionHoldingRequest : HoldingRequest
type NetPositionHoldingRequest struct {
	Head Header                 `json:"head"`
	Body NetPositionHoldingBody `json:"body"`
}

// OrderRequestBody : OrderRequestBody
type OrderRequestBody struct {
	ClientCode         string `json:"ClientCode"`
	OrderFor           string `json:"OrderFor"`
	Exchange           string `json:"Exchange"`
	ExchangeType       string `json:"ExchangeType"`
	Price              int    `json:"Price"`
	OrderID            int    `json:"OrderID"`
	OrderType          string `json:"OrderType"`
	Qty                int    `json:"Qty"`
	OrderDateTime      string `json:"OrderDateTime"`
	ScripCode          int    `json:"ScripCode"`
	AtMarket           bool   `json:"AtMarket"`
	RemoteOrderID      string `json:"RemoteOrderID"`
	ExchOrderID        string `json:"ExchOrderID"`
	DisQty             int    `json:"DisQty"`
	IsStopLossOrder    bool   `json:"IsStopLossOrder"`
	StopLossPrice      int    `json:"StopLossPrice"`
	IsVTD              bool   `json:"IsVTD"`
	IOCOrder           bool   `json:"IOCOrder"`
	IsIntraday         bool   `json:"IsIntraday"`
	PublicIP           string `json:"PublicIP"`
	AHPlaced           string `json:"AHPlaced"`
	ValidTillDate      string `json:"ValidTillDate"`
	IOrderValidity     int    `json:"iOrderValidity"`
	OrderRequesterCode string `json:"OrderRequesterCode"`
	TradedQty          int    `json:"TradedQty"`
}

// ReqDataRequest :ReqDataRequest
type ReqDataRequest struct {
	Head Header           `json:"head"`
	Body OrderRequestBody `json:"body"`
}

// OrderRequestAPI : OrderRequestAPI
type OrderRequestAPI struct {
	ReqData   ReqDataRequest `json:"_ReqData"`
	AppSource int            `json:"AppSource"`
}

//OrderStatusBody : OrderStatusBody
type OrderStatusBody struct {
	ClientCode       string             `json:"ClientCode"`
	OrdStatusReqList []OrdStatusReqList `json:"OrdStatusReqList"`
}

// OrdStatusReqList : OrdStatusReqListf
type OrdStatusReqList struct {
	Exch          string `json:"Exch"`
	ExchType      string `json:"ExchType"`
	ScripCode     int    `json:"ScripCode"`
	RemoteOrderID string `json:"RemoteOrderID"`
}

// OrderStatusRequest :OrderStatusRequest
type OrderStatusRequest struct {
	Head Header          `json:"head"`
	Body OrderStatusBody `json:"body"`
}

//PreOrdMarginCalculationBody : PreOrdMarginCalculationBody
type PreOrdMarginCalculationBody struct {
	OrderRequestorCode string `json:"OrderRequestorCode"`
	Exch               string `json:"Exch"`
	ExchType           string `json:"ExchType"`
	ClientCode         string `json:"ClientCode"`
	ScripCode          string `json:"ScripCode"`
	PlaceModifyCancel  string `json:"PlaceModifyCancel"`
	TransactionType    string `json:"TransactionType"`
	AtMarket           string `json:"AtMarket"`
	LimitRate          int    `json:"LimitRate"`
	WithSL             string `json:"WithSL"`
	SLTriggerRate      int    `json:"SLTriggerRate"`
	IsSLTriggered      string `json:"IsSLTriggered"`
	Volume             int    `json:"Volume"`
	OldTradedQty       int    `json:"OldTradedQty"`
	ProductType        string `json:"ProductType"`
	ExchOrderID        string `json:"ExchOrderId"`
	ClientIP           string `json:"ClientIP"`
	AppSource          int    `json:"AppSource"`
}

// PreOrdMarginCalculationReq : PreOrdMarginCalculationReq
type PreOrdMarginCalculationReq struct {
	Head Header                      `json:"head"`
	Body PreOrdMarginCalculationBody `json:"body"`
}

// BackoffMutualFundTranBody :BackoffMutualFundTranBody
type BackoffMutualFundTranBody struct {
	ClientCode string `json:"ClientCode"`
	FromDate   string `json:"FromDate"`
	ToDate     string `json:"ToDate"`
}

// BackMutualFundTranBodyReq : BackMutualFundTranBodyReq
type BackMutualFundTranBodyReq struct {
	Head Header                    `json:"head"`
	Body BackoffMutualFundTranBody `json:"body"`
}

//MarketFeedBody : MarketFeedBody
type MarketFeedBody struct {
	ClientCode         string               `json:"ClientCode"`
	Count              string               `json:"Count"`
	MarketFeedDataList []MarketFeedDataList `json:"MarketFeedData"`
	ClientLoginType    string               `json:"ClientLoginType"`
	LastRequestTime    string               `json:"LastRequestTime"`
	RefreshRate        string               `json:"RefreshRate"`
}

//MarketFeedDataList : MarketFeedDataList
type MarketFeedDataList struct {
	Exch      string `json:"Exch"`
	ExchType  string `json:"ExchType"`
	ScripCode string `json:"ScripCode"`
}

// MarketFeedDataRequest :MarketFeedDataRequest
type MarketFeedDataRequest struct {
	Head Header         `json:"head"`
	Body MarketFeedBody `json:"body"`
}

///**********************Response************************************** //

//LoginVendorResponse : Response of LoginRequestMobileForVendor
type LoginVendorResponse struct {
	Body struct {
		EmailID     string `json:"EmailId"`
		Message     string `json:"Message"`
		Status      int    `json:"Status"`
		TTManagerID string `json:"TTManagerId"`
		UserName    string `json:"UserName"`
		ValidUpto   string `json:"ValidUpto"`
		VendorName  string `json:"VendorName"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//LoginClientResponse : Response of LoginRequest
type LoginClientResponse struct {
	Body struct {
		BulkOrderAllowed      int    `json:"BulkOrderAllowed"`
		CleareDt              string `json:"CleareDt"`
		ClientName            string `json:"ClientName"`
		ClientType            int    `json:"ClientType"`
		DPID                  string `json:"DPID"`
		EmailID               string `json:"EmailId"`
		InteractiveLocalIP    string `json:"InteractiveLocalIP"`
		InteractivePort       int    `json:"InteractivePort"`
		InteractivePublicIP   string `json:"InteractivePublicIP"`
		IsExternal            string `json:"IsExternal"`
		IsIDBound             int    `json:"IsIDBound"`
		IsIDBound2            int    `json:"IsIDBound2"`
		IsPLM                 int    `json:"IsPLM"`
		IsPLMDefined          int    `json:"IsPLMDefined"`
		LastAccessedTime      string `json:"LastAccessedTime"`
		LastLogin             string `json:"LastLogin"`
		LastPasswordModify    string `json:"LastPasswordModify"`
		Msg                   string `json:"Msg"`
		OTPCredentialID       string `json:"OTPCredentialID"`
		PLMsAllowed           int    `json:"PLMsAllowed"`
		POAStatus             string `json:"POAStatus"`
		PasswordChangeFlag    int    `json:"PasswordChangeFlag"`
		PasswordChangeMessage string `json:"PasswordChangeMessage"`
		RunningAuthorization  int    `json:"RunningAuthorization"`
		ServerDt              string `json:"ServerDt"`
		Success               int    `json:"Success"`
		TCPBCastPort          int    `json:"TCPBCastPort"`
		TCPBcastLocalIP       string `json:"TCPBcastLocalIP"`
		TCPBcastPublicIP      string `json:"TCPBcastPublicIP"`
		UDPBCastPort          int    `json:"UDPBCastPort"`
		UDPBcastIP            string `json:"UDPBcastIP"`
		VersionChanged        int    `json:"VersionChanged"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//HoldResponse : Response of Holding
type HoldResponse struct {
	Body struct {
		CacheTime int `json:"CacheTime"`
		Data      []struct {
			BseCode        int     `json:"BseCode"`
			CurrentPL      int     `json:"CurrentPL"`
			CurrentPrice   float64 `json:"CurrentPrice"`
			CurrentValue   int     `json:"CurrentValue"`
			Exch           string  `json:"Exch"`
			ExchType       string  `json:"ExchType"`
			FullName       string  `json:"FullName"`
			FundedQty      int     `json:"FundedQty"`
			NseCode        int     `json:"NseCode"`
			PerChange      float64 `json:"PerChange"`
			PreviousClose  float64 `json:"PreviousClose"`
			Quantity       int     `json:"Quantity"`
			Symbol         string  `json:"Symbol"`
			YesterDayValue int     `json:"YesterDayValue"`
			CollateralQty  int     `json:"collateralQty"`
		} `json:"Data"`
		Message string `json:"Message"`
		Status  int    `json:"Status"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//MarketFeedResponse : Response of MarketFeed
type MarketFeedResponse struct {
	Body struct {
		CacheTime int `json:"CacheTime"`
		Data      []struct {
			Exch     string  `json:"Exch"`
			ExchType string  `json:"ExchType"`
			High     float64 `json:"High"`
			LastRate float64 `json:"LastRate"`
			Low      float64 `json:"Low"`
			Message  string  `json:"Message"`
			PClose   float64 `json:"PClose"`
			Status   int     `json:"Status"`
			TickDt   string  `json:"TickDt"`
			Time     int     `json:"Time"`
			Token    int     `json:"Token"`
			TotalQty int     `json:"TotalQty"`
		} `json:"Data"`
		Message   string `json:"Message"`
		Status    int    `json:"Status"`
		TimeStamp string `json:"TimeStamp"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//OrderResponse : Reponse of OrderRequest
type OrderResponse struct {
	Body struct {
		BrokerOrderID   int    `json:"BrokerOrderID"`
		ClientCode      string `json:"ClientCode"`
		Exch            string `json:"Exch"`
		ExchOrderID     string `json:"ExchOrderID"`
		ExchType        string `json:"ExchType"`
		LocalOrderID    int    `json:"LocalOrderID"`
		Message         string `json:"Message"`
		RMSResponseCode int    `json:"RMSResponseCode"`
		ScripCode       int    `json:"ScripCode"`
		Status          int    `json:"Status"`
		Time            string `json:"Time"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//OrderStatusResponse : Resposne OrderStatus
type OrderStatusResponse struct {
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
	Body struct {
		Message         string `json:"Message"`
		OrdStatusResLst []struct {
			Exch          string `json:"Exch"`
			ExchOrderID   int64  `json:"ExchOrderID"`
			ExchOrderTime string `json:"ExchOrderTime"`
			ExchType      string `json:"ExchType"`
			OrderQty      int    `json:"OrderQty"`
			OrderRate     int    `json:"OrderRate"`
			PendingQty    int    `json:"PendingQty"`
			ScripCode     int    `json:"ScripCode"`
			Status        string `json:"Status"`
			Symbol        string `json:"Symbol"`
			TradedQty     int    `json:"TradedQty"`
		} `json:"OrdStatusResLst"`
		Status int `json:"Status"`
	} `json:"body"`
}

//TradeInformationResponse : Response for TradeInformation
type TradeInformationResponse struct {
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
	Body struct {
		Message     string `json:"Message"`
		Status      int    `json:"Status"`
		TradeDetail []struct {
			BuySell           string  `json:"BuySell"`
			Exch              string  `json:"Exch"`
			ExchOrderID       int64   `json:"ExchOrderID"`
			ExchType          string  `json:"ExchType"`
			ExchangeTradeID   int     `json:"ExchangeTradeID"`
			ExchangeTradeTime string  `json:"ExchangeTradeTime"`
			OrgQty            int     `json:"OrgQty"`
			PendingQty        int     `json:"PendingQty"`
			Qty               int     `json:"Qty"`
			Rate              float64 `json:"Rate"`
			ScripCode         int     `json:"ScripCode"`
			ScripName         string  `json:"ScripName"`
		} `json:"TradeDetail"`
	} `json:"body"`
}

//MarginResponse : Response of Margin
type MarginResponse struct {
	Body struct {
		ClientCode   string `json:"ClientCode"`
		EquityMargin []struct {
			ALB             int `json:"ALB"`
			Adhoc           int `json:"Adhoc"`
			AvailableMargin int `json:"AvailableMargin"`
			GHV             int `json:"GHV"`
			GHVPer          int `json:"GHVPer"`
			GrossMargin     int `json:"GrossMargin"`
			Lb              int `json:"Lb"`
			Mgn4PendOrd     int `json:"Mgn4PendOrd"`
			Mgn4Position    int `json:"Mgn4Position"`
			NDDebit         int `json:"NDDebit"`
			OptionsMtoMLoss int `json:"OptionsMtoMLoss"`
			PDHV            int `json:"PDHV"`
			Payments        int `json:"Payments"`
			Receipts        int `json:"Receipts"`
			THV             int `json:"THV"`
			UnclChq         int `json:"UnclChq"`
			Undlv           int `json:"Undlv"`
		} `json:"EquityMargin"`
		Message   string `json:"Message"`
		Status    int    `json:"Status"`
		TimeStamp string `json:"TimeStamp"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//OrderBookV2Response : Response for OrderBookV2
type OrderBookV2Response struct {
	Body struct {
		Message         string `json:"Message"`
		OrderBookDetail []struct {
			AHProcess          string `json:"AHProcess"`
			AfterHours         string `json:"AfterHours"`
			AtMarket           string `json:"AtMarket"`
			BrokerOrderID      int    `json:"BrokerOrderId"`
			BrokerOrderTime    string `json:"BrokerOrderTime"`
			BuySell            string `json:"BuySell"`
			DelvIntra          string `json:"DelvIntra"`
			DisClosedQty       int    `json:"DisClosedQty"`
			Exch               string `json:"Exch"`
			ExchOrderID        string `json:"ExchOrderID"`
			ExchOrderTime      string `json:"ExchOrderTime"`
			ExchType           string `json:"ExchType"`
			MarketLot          int    `json:"MarketLot"`
			OldorderQty        int    `json:"OldorderQty"`
			OrderRequesterCode string `json:"OrderRequesterCode"`
			OrderStatus        string `json:"OrderStatus"`
			OrderValidUpto     string `json:"OrderValidUpto"`
			OrderValidity      int    `json:"OrderValidity"`
			PendingQty         int    `json:"PendingQty"`
			Qty                int    `json:"Qty"`
			Rate               int    `json:"Rate"`
			Reason             string `json:"Reason"`
			RequestType        string `json:"RequestType"`
			SLTriggerRate      int    `json:"SLTriggerRate"`
			SLTriggered        string `json:"SLTriggered"`
			SMOProfitRate      int    `json:"SMOProfitRate"`
			SMOSLLimitRate     int    `json:"SMOSLLimitRate"`
			SMOSLTriggerRate   int    `json:"SMOSLTriggerRate"`
			SMOTrailingSL      int    `json:"SMOTrailingSL"`
			ScripCode          int    `json:"ScripCode"`
			ScripName          string `json:"ScripName"`
			TerminalID         int    `json:"TerminalId"`
			TradedQty          int    `json:"TradedQty"`
			WithSL             string `json:"WithSL"`
		} `json:"OrderBookDetail"`
		Status int `json:"Status"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//TradeBookRespone : Response for TradeBook
type TradeBookRespone struct {
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
	Body struct {
		Message         string `json:"Message"`
		Status          int    `json:"Status"`
		TradeBookDetail []struct {
			BuySell           string `json:"BuySell"`
			DelvIntra         string `json:"DelvIntra"`
			Exch              string `json:"Exch"`
			ExchOrderID       string `json:"ExchOrderID"`
			ExchType          string `json:"ExchType"`
			ExchangeTradeID   string `json:"ExchangeTradeID"`
			ExchangeTradeTime string `json:"ExchangeTradeTime"`
			Multiplier        int    `json:"Multiplier"`
			OrgQty            int    `json:"OrgQty"`
			PendingQty        int    `json:"PendingQty"`
			Qty               int    `json:"Qty"`
			Rate              int    `json:"Rate"`
			ScripCode         int    `json:"ScripCode"`
			ScripName         string `json:"ScripName"`
			TradeType         string `json:"TradeType"`
		} `json:"TradeBookDetail"`
	} `json:"body"`
}

//NetPositionResponse : Response for NetPosition
type NetPositionResponse struct {
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
	Body struct {
		Message           string `json:"Message"`
		NetPositionDetail []struct {
			BookedPL    int     `json:"BookedPL"`
			BuyAvgRate  float64 `json:"BuyAvgRate"`
			BuyQty      int     `json:"BuyQty"`
			BuyValue    float64 `json:"BuyValue"`
			Exch        string  `json:"Exch"`
			ExchType    string  `json:"ExchType"`
			LTP         int     `json:"LTP"`
			MtoM        float64 `json:"MtoM"`
			Multiplier  int     `json:"Multiplier"`
			NetQty      int     `json:"NetQty"`
			OrderFor    string  `json:"OrderFor"`
			ScripCode   int     `json:"ScripCode"`
			ScripName   string  `json:"ScripName"`
			SellAvgRate int     `json:"SellAvgRate"`
			SellQty     int     `json:"SellQty"`
			SellValue   int     `json:"SellValue"`
		} `json:"NetPositionDetail"`
		Status    int    `json:"Status"`
		TimeStamp string `json:"TimeStamp"`
	} `json:"body"`
}

//NetPositionNetWiseResponse : Response of NetPositionNetWise
type NetPositionNetWiseResponse struct {
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
	Body struct {
		Message           string `json:"Message"`
		NetPositionDetail []struct {
			BodQty           int     `json:"BodQty"`
			BookedPL         float64 `json:"BookedPL"`
			BuyAvgRate       float64 `json:"BuyAvgRate"`
			BuyQty           int     `json:"BuyQty"`
			BuyValue         int     `json:"BuyValue"`
			Exch             string  `json:"Exch"`
			ExchType         string  `json:"ExchType"`
			LTP              int     `json:"LTP"`
			MTOM             float64 `json:"MTOM"`
			Multiplier       int     `json:"Multiplier"`
			NetQty           int     `json:"NetQty"`
			OrderFor         string  `json:"OrderFor"`
			BODPositionPrice int     `json:"BODPositionPrice"`
			ScripCode        int     `json:"ScripCode"`
			ScripName        string  `json:"ScripName"`
			SellAvgRate      int     `json:"SellAvgRate"`
			SellQty          int     `json:"SellQty"`
			SellValue        int     `json:"SellValue"`
		} `json:"NetPositionDetail"`
		Status int `json:"Status"`
	} `json:"body"`
}

//PreOrdMarginCalculationResponse : Response for PreOrdMarginCalculation
type PreOrdMarginCalculationResponse struct {
	Body struct {
		Margin  int    `json:"Margin"`
		Message string `json:"Message"`
		Status  int    `json:"Status"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//BackoffMutualFundTransactionResponse : Response for BackoffMutualFundTransaction
type BackoffMutualFundTransactionResponse struct {
	Body struct {
		MutulFundTransactionRes []struct {
			Brokerage       int     `json:"Brokerage"`
			BuyQty          float64 `json:"BuyQty"`
			BuyRate         float64 `json:"BuyRate"`
			ClientCode      string  `json:"ClientCode"`
			ISIN            string  `json:"ISIN"`
			SchemeName      string  `json:"SchemeName"`
			SellQty         int     `json:"SellQty"`
			SellRate        int     `json:"SellRate"`
			Tax             int     `json:"Tax"`
			TradeDate       string  `json:"TradeDate"`
			TransactionType string  `json:"TransactionType"`
		} `json:"MutulFundTransactionRes"`
		Status  string `json:"Status"`
		Message string `json:"message"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//BackoffClientProfileResponse : Response of BackoffClientProfile
type BackoffClientProfileResponse struct {
	Body struct {
		AccountType           string `json:"AccountType"`
		ActivationDate        string `json:"ActivationDate"`
		BankAccountNumber     string `json:"BankAccountNumber"`
		BankIFSC              string `json:"BankIFSC"`
		BankName              string `json:"BankName"`
		ClientCode            string `json:"ClientCode"`
		ClientName            string `json:"ClientName"`
		CorrespondenceAddress string `json:"CorrespondenceAddress"`
		DOB                   string `json:"DOB"`
		Email                 string `json:"Email"`
		Mobile                string `json:"Mobile"`
		NomineeName           string `json:"NomineeName"`
		PINCode               string `json:"PINCode"`
		Pan                   string `json:"Pan"`
		PermanentAddress      string `json:"PermanentAddress"`
		State                 string `json:"State"`
		Status                int    `json:"Status"`
		Message               string `json:"message"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//BackoffFutureTransactionResponse : Response for BackoffFutureTransaction
type BackoffFutureTransactionResponse struct {
	Body struct {
		FutureTransaction []struct {
			Brokerage      float64 `json:"Brokerage"`
			BuyQty         int     `json:"BuyQty"`
			BuyRate        float64 `json:"BuyRate"`
			ClientCode     string  `json:"ClientCode"`
			ExpiryDate     string  `json:"ExpiryDate"`
			InstrumentName string  `json:"InstrumentName"`
			OrderNo        int64   `json:"OrderNo"`
			SellQty        int     `json:"SellQty"`
			SellRate       int     `json:"SellRate"`
			Symbol         string  `json:"Symbol"`
			Tax            float64 `json:"Tax"`
			TradeDate      int     `json:"TradeDate"`
			TradeNo        int     `json:"TradeNo"`
		} `json:"FutureTransaction"`
		Status  int    `json:"Status"`
		Message string `json:"message"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//BackoffoptionTransactionResponse : Response for BackoffoptionTransaction
type BackoffoptionTransactionResponse struct {
	Body struct {
		OptionTransactionRes []struct {
			Brokerage      float64 `json:"Brokerage"`
			BuyQty         int     `json:"BuyQty"`
			BuyRate        float64 `json:"BuyRate"`
			ClientCode     string  `json:"ClientCode"`
			ExpiryDate     string  `json:"ExpiryDate"`
			InstrumentName string  `json:"InstrumentName"`
			OptionType     string  `json:"OptionType"`
			OrderNo        int64   `json:"OrderNo"`
			SellQty        int     `json:"SellQty"`
			SellRate       int     `json:"SellRate"`
			StrikePrice    int     `json:"StrikePrice"`
			Symbol         string  `json:"Symbol"`
			Tax            float64 `json:"Tax"`
			TradeDate      int     `json:"TradeDate"`
			TradeNo        int     `json:"TradeNo"`
		} `json:"OptionTransactionRes"`
		Status  int    `json:"Status"`
		Message string `json:"message"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//BackoffLedgerResponse : Response of BackoffLedger
type BackoffLedgerResponse struct {
	Body struct {
		LedgerRes []struct {
			Amount          int    `json:"Amount"`
			ClientCode      string `json:"ClientCode"`
			DebitCreditFlag string `json:"DebitCreditFlag"`
			Narration       string `json:"Narration"`
			VoucherDate     int    `json:"VoucherDate"`
			VoucherNumber   int    `json:"VoucherNumber"`
		} `json:"LedgerRes"`
		OpeningBalance int    `json:"OpeningBalance"`
		Status         string `json:"Status"`
		Message        string `json:"message"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}

//BackoffDPHoldingResponse : Response of BackoffDPHolding
type BackoffDPHoldingResponse struct {
	Body struct {
		DPHolding []struct {
			AsOnDate   string `json:"AsOnDate"`
			ClientCode string `json:"ClientCode"`
			FaceValue  int    `json:"FaceValue"`
			ISIN       string `json:"ISIN"`
			Quantity   int    `json:"Quantity"`
			ScripType  string `json:"ScripType"`
			Symbol     string `json:"Symbol"`
		} `json:"DPHolding"`
		Message string `json:"message"`
		Status  int    `json:"status"`
	} `json:"body"`
	Head struct {
		ResponseCode      string `json:"responseCode"`
		Status            string `json:"status"`
		StatusDescription string `json:"statusDescription"`
	} `json:"head"`
}
