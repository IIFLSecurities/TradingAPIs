package class

import (
	"encoding/json"
	"fmt"
	"net/http"
	"strings"
)

//Holding : This method is used to provide the client’s holdings as of beginning of the day.
func Holding(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "Holding"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCode, UserID: config.UserID, Password: config.Password}

	body := HoldingBody{ClientCode: ClientCode}

	HoldingRequest := HoldingRequest{Head: header, Body: body}

	data, _ := json.Marshal(HoldingRequest)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var HoldRes HoldResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &HoldRes)
	fmt.Printf("Message: %s, StatusDescription: %s", HoldRes.Body.Message, HoldRes.Head.StatusDescription)

}

//Margin : This API is used to fetch Client’s Available Margin details.
func Margin(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()
	//fmt.Println(domainame.AppName)
	url := config.ServiceURL + "Margin"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeMarginV3, UserID: config.UserID, Password: config.Password}

	body := HoldingBody{ClientCode: ClientCode}

	MarginRequest := HoldingRequest{Head: header, Body: body}

	data, _ := json.Marshal(MarginRequest)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var MarginRes MarginResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &MarginRes)
	fmt.Printf("TimeStamp: %s, StatusDescription: %s", MarginRes.Body.TimeStamp, MarginRes.Head.StatusDescription)

}

//OrderBookV2 : This API is used to Fetch Order Book of a particular Client which will contain both Equity and Commodity Orders.
func OrderBookV2(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()
	url := config.ServiceURL + "OrderBookV2"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeOrdBkV2, UserID: config.UserID, Password: config.Password}

	body := HoldingBody{ClientCode: ClientCode}

	OrderBookV2Request := HoldingRequest{Head: header, Body: body}

	data, _ := json.Marshal(OrderBookV2Request)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var OrderBookV2Res OrderBookV2Response

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &OrderBookV2Res)
	fmt.Printf("Reason: %s, StatusDescription: %s", OrderBookV2Res.Body.Message, OrderBookV2Res.Head.StatusDescription)

}

//TradeBook : This method is used to provide the daily trade details of the day.
func TradeBook(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()
	//fmt.Println(domainame.AppName)
	url := config.ServiceURL + "TradeBook"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeTrdBkV1, UserID: config.UserID, Password: config.Password}

	body := HoldingBody{ClientCode: ClientCode}

	TradeBookRequest := HoldingRequest{Head: header, Body: body}

	data, _ := json.Marshal(TradeBookRequest)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var TradeBookRes TradeBookRespone

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &TradeBookRes)
	fmt.Printf("Message: %s, StatusDescription: %s", TradeBookRes.Body.Message, TradeBookRes.Head.StatusDescription)

}

//NetPosition : This method will provide the client’s Positions in both equity and commodity market across all exchanges and exchange segments.
func NetPosition(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "NetPosition"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeNetPositionV4, UserID: config.UserID, Password: config.Password}

	body := HoldingBody{ClientCode: ClientCode}

	NetPositionRequest := HoldingRequest{Head: header, Body: body}

	data, _ := json.Marshal(NetPositionRequest)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var NetPositionRes NetPositionResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &NetPositionRes)
	fmt.Printf("Message: %s, StatusDescription: %s", NetPositionRes.Body.Message, NetPositionRes.Head.StatusDescription)

}

//NetPositionNetWise : This API will provide client Net Position report with additional parameter as multiplier.
func NetPositionNetWise(w http.ResponseWriter, r *http.Request) {
	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()
	url := config.ServiceURL + "NetPositionNetWise"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeNPNWV1, UserID: config.UserID, Password: config.Password}

	body := NetPositionHoldingBody{ClientCode: ClientCode}

	NetPositionNetWiseReq := NetPositionHoldingRequest{Head: header, Body: body}

	data, _ := json.Marshal(NetPositionNetWiseReq)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var NetPositionNetWiseRes NetPositionNetWiseResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &NetPositionNetWiseRes)
	fmt.Printf("Message: %s, StatusDescription: %s", NetPositionNetWiseRes.Body.Message, NetPositionNetWiseRes.Head.StatusDescription)

}
