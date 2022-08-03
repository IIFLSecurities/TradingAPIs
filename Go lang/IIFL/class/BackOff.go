package class

import (
	"encoding/json"
	"fmt"
	"net/http"
	"strings"
)

//PreOrdMarginCalculation : This api will calculate and get the exposure margin and span margin of all the margin of the client.
func PreOrdMarginCalculation(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "PreOrdMarginCalculation"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodePreOrdMarCal, UserID: config.UserID, Password: config.Password}

	body := PreOrdMarginCalculationBody{OrderRequestorCode: ClientCode, Exch: "N", ExchType: "D", ClientCode: ClientCode, ScripCode: "45609", PlaceModifyCancel: "M",
		TransactionType: "B", AtMarket: "false", LimitRate: 650, WithSL: "N", SLTriggerRate: 0, IsSLTriggered: "N", Volume: 250, OldTradedQty: 0, ProductType: "D",
		ExchOrderID: "0", ClientIP: "21.1.2", AppSource: 54}

	PreOrdMarginCalculationData := PreOrdMarginCalculationReq{Head: header, Body: body}

	data, _ := json.Marshal(PreOrdMarginCalculationData)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var PreOrdMarginCalculationRes PreOrdMarginCalculationResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &PreOrdMarginCalculationRes)
	fmt.Printf("Message: %s, StatusDescription: %s", PreOrdMarginCalculationRes.Body.Message, PreOrdMarginCalculationRes.Head.StatusDescription)

}

//BackoffMutualFundTransaction : This API is used to the give the information BackOffice client mutual fund transaction information
func BackoffMutualFundTransaction(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "BackoffMutualFundTransaction"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeBackoffMutulFundTransaction, UserID: config.UserID, Password: config.Password}

	body := BackoffMutualFundTranBody{ClientCode: ClientCode, FromDate: "20190101", ToDate: "20201001"}

	BackMutualFundTranData := BackMutualFundTranBodyReq{Head: header, Body: body}

	data, _ := json.Marshal(BackMutualFundTranData)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var BackoffMutualFundTransactionRes BackoffMutualFundTransactionResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &BackoffMutualFundTransactionRes)
	fmt.Printf("Message: %s, StatusDescription: %s", BackoffMutualFundTransactionRes.Body.Message, BackoffMutualFundTransactionRes.Head.StatusDescription)

}

//BackoffClientProfile : This API is used to the give the information BackOffice client profile data
func BackoffClientProfile(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "BackoffClientProfile"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeBackoffClientProfile, UserID: config.UserID, Password: config.Password}

	body := BackoffMutualFundTranBody{ClientCode: ClientCode, FromDate: "20190101", ToDate: "20201001"}

	BackClientProfileData := BackMutualFundTranBodyReq{Head: header, Body: body}

	data, _ := json.Marshal(BackClientProfileData)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var BackoffClientProfileRes BackoffClientProfileResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &BackoffClientProfileRes)
	fmt.Printf("Message: %s, StatusDescription: %s", BackoffClientProfileRes.Body.Message, BackoffClientProfileRes.Head.StatusDescription)

}

//BackoffEquitytransaction : This API is used to the give the information BackOffice client equity transaction information
func BackoffEquitytransaction(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "BackoffEquitytransaction"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeBackoffEquitytransaction, UserID: config.UserID, Password: config.Password}

	body := BackoffMutualFundTranBody{ClientCode: ClientCode, FromDate: "20190101", ToDate: "20201001"}

	BackEquitytransactionData := BackMutualFundTranBodyReq{Head: header, Body: body}

	data, _ := json.Marshal(BackEquitytransactionData)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var BackoffClientProfileRes BackoffClientProfileResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &BackoffClientProfileRes)
	fmt.Printf("Message: %s, StatusDescription: %s", BackoffClientProfileRes.Body.Message, BackoffClientProfileRes.Head.StatusDescription)

}

//BackoffFutureTransaction : This API is used to the give the information BackOffice client future transaction information
func BackoffFutureTransaction(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "BackoffFutureTransaction"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeBackoffFutureTransaction, UserID: config.UserID, Password: config.Password}

	body := BackoffMutualFundTranBody{ClientCode: ClientCode, FromDate: "20190101", ToDate: "20201001"}

	BackFutureTransactionData := BackMutualFundTranBodyReq{Head: header, Body: body}

	data, _ := json.Marshal(BackFutureTransactionData)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var BackoffFutureTransactionRes BackoffFutureTransactionResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &BackoffFutureTransactionRes)
	fmt.Printf("Message: %s, StatusDescription: %s", BackoffFutureTransactionRes.Body.Message, BackoffFutureTransactionRes.Head.StatusDescription)

}

//BackoffoptionTransaction : This API is used to the give the information BackOffice client option transaction information
func BackoffoptionTransaction(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "BackoffoptionTransaction"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeBackoffoptionTransaction, UserID: config.UserID, Password: config.Password}

	body := BackoffMutualFundTranBody{ClientCode: ClientCode, FromDate: "20190101", ToDate: "20201001"}

	BackoptionTransactionData := BackMutualFundTranBodyReq{Head: header, Body: body}

	data, _ := json.Marshal(BackoptionTransactionData)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var BackoffoptionTransactionRes BackoffoptionTransactionResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &BackoffoptionTransactionRes)
	fmt.Printf("Message: %s, StatusDescription: %s", BackoffoptionTransactionRes.Body.Message, BackoffoptionTransactionRes.Head.StatusDescription)

}

//BackoffLedger : This API is used to the give the information BackOffice ledger information
func BackoffLedger(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "BackoffLedger"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeBackoffLedger, UserID: config.UserID, Password: config.Password}

	body := BackoffMutualFundTranBody{ClientCode: ClientCode, FromDate: "20190101", ToDate: "20201001"}

	BackoffLedgerData := BackMutualFundTranBodyReq{Head: header, Body: body}

	data, _ := json.Marshal(BackoffLedgerData)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var BackoffLedgerRes BackoffLedgerResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &BackoffLedgerRes)
	fmt.Printf("Message: %s, StatusDescription: %s", BackoffLedgerRes.Body.Message, BackoffLedgerRes.Head.StatusDescription)

}

//BackoffDPTransaction : This API is used to the give the information BackOffice DP transaction
func BackoffDPTransaction(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "BackoffDPTransaction"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeBackoffDPTransaction, UserID: config.UserID, Password: config.Password}

	body := BackoffMutualFundTranBody{ClientCode: ClientCode, FromDate: "20190101", ToDate: "20201001"}

	BackDPTransactionData := BackMutualFundTranBodyReq{Head: header, Body: body}

	data, _ := json.Marshal(BackDPTransactionData)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var BackoffLedgerRes BackoffLedgerResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &BackoffLedgerRes)
	fmt.Printf("Message: %s, StatusDescription: %s", BackoffLedgerRes.Body.Message, BackoffLedgerRes.Head.StatusDescription)

}

//BackoffDPHolding : This API is used to the give the information BackOffice DP Holding information
func BackoffDPHolding(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "BackoffDPHolding"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeBackoffDPHolding, UserID: config.UserID, Password: config.Password}

	body := BackoffMutualFundTranBody{ClientCode: ClientCode, FromDate: "20190101", ToDate: "20201001"}

	BackDPDPHoldingData := BackMutualFundTranBodyReq{Head: header, Body: body}

	data, _ := json.Marshal(BackDPDPHoldingData)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var BackoffDPHoldingRes BackoffDPHoldingResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &BackoffDPHoldingRes)
	fmt.Printf("Message: %s, StatusDescription: %s", BackoffDPHoldingRes.Body.Message, BackoffDPHoldingRes.Head.StatusDescription)

}
