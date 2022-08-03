package class

import (
	"encoding/json"
	"fmt"
	"net/http"
	"strings"
)

//OrderRequest :- This API is the backbone of all the trade dependent APIs and is the key method that you would need to place your order in the market.
func OrderRequest(w http.ResponseWriter, r *http.Request) {
	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()
	url := config.ServiceURL + "OrderRequest"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeOrdReq, UserID: config.UserID, Password: config.Password}

	body := OrderRequestBody{ClientCode: ClientCode, OrderFor: "P", Exchange: "N", ExchangeType: "C", Price: 190, OrderID: 1, OrderType: "BUY",
		Qty: 1, OrderDateTime: "/Date(1601880914379)/", ScripCode: 3045, AtMarket: false, RemoteOrderID: "s000220190", ExchOrderID: "0", DisQty: 0,
		IsStopLossOrder: false, StopLossPrice: 0, IsVTD: false, IOCOrder: false, IsIntraday: false, PublicIP: "192.168.84.215", AHPlaced: "N",
		ValidTillDate: "/Date(1602880914379)/", IOrderValidity: 0, OrderRequesterCode: "96130000", TradedQty: 0}

	OrderData := ReqDataRequest{Head: header, Body: body}

	OrderAPI := OrderRequestAPI{ReqData: OrderData, AppSource: 54}

	data, _ := json.Marshal(OrderAPI)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var OrderRes OrderResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &OrderRes)
	fmt.Printf("Message: %s, StatusDescription: %s", OrderRes.Body.Message, OrderRes.Head.StatusDescription)

}

//OrderStatus :- The purpose of this method is to navigate the status of an order placed by the client.
func OrderStatus(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()
	//fmt.Println(domainame.AppName)
	url := config.ServiceURL + "OrderStatus"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeOrdStatus, UserID: config.UserID, Password: config.Password}

	OrdReqList := OrdStatusReqList{Exch: "N", ExchType: "C", ScripCode: 4717, RemoteOrderID: "S123456789123400000"}

	body := OrderStatusBody{ClientCode: ClientCode, OrdStatusReqList: []OrdStatusReqList{OrdReqList}}

	OrderBookV2Request := OrderStatusRequest{Head: header, Body: body}

	data, _ := json.Marshal(OrderBookV2Request)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var OrderStatusRes OrderStatusResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &OrderStatusRes)
	fmt.Printf("Message: %s, StatusDescription: %s", OrderStatusRes.Body.Message, OrderStatusRes.Head.StatusDescription)

}

//TradeInformation :- Trade Information method is used to Fetch Trade Information for a set of orders placed by the client.
func TradeInformation(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "TradeInformation"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeTrdInfo, UserID: config.UserID, Password: config.Password}

	TradeInformList := OrdStatusReqList{Exch: "B", ExchType: "C", ScripCode: 500410, RemoteOrderID: "1557728588259000000"}

	body := OrderStatusBody{ClientCode: ClientCode, OrdStatusReqList: []OrdStatusReqList{TradeInformList}}

	OrderBookV2Request := OrderStatusRequest{Head: header, Body: body}

	data, _ := json.Marshal(OrderBookV2Request)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var TradeInformationRes TradeInformationResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &TradeInformationRes)
	fmt.Printf("Message: %s, StatusDescription: %s", TradeInformationRes.Body.Message, TradeInformationRes.Head.StatusDescription)

}
