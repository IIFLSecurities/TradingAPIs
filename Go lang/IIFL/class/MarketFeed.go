package class

import (
	"encoding/json"
	"fmt"
	"net/http"
	"strings"
)

//MarketFeed :- This API is used to fetch the market feed of a particular scrip or a set of scrips
func MarketFeed(w http.ResponseWriter, r *http.Request) {

	ClientCode := r.URL.Query().Get("ClientCode")

	config := CheckConfig()

	url := config.ServiceURL + "MarketFeed"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCodeMarketFeed, UserID: config.UserID, Password: config.Password}

	TradeInformList1 := MarketFeedDataList{Exch: "N", ExchType: "C", ScripCode: "2885"}
	TradeInformList2 := MarketFeedDataList{Exch: "N", ExchType: "C", ScripCode: "22"}

	body := MarketFeedBody{ClientCode: ClientCode, Count: "2", MarketFeedDataList: []MarketFeedDataList{TradeInformList1, TradeInformList2}, ClientLoginType: "0", LastRequestTime: "/Date(1600248018615)/", RefreshRate: "H"}

	MarketFeedRequest := MarketFeedDataRequest{Head: header, Body: body}

	data, _ := json.Marshal(MarketFeedRequest)

	payload := strings.NewReader(string(data))

	bodyString := HTTPClient(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var MarketFeedRes MarketFeedResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &MarketFeedRes)
	fmt.Printf("TimeStamp: %s, StatusDescription: %s", MarketFeedRes.Body.TimeStamp, MarketFeedRes.Head.StatusDescription)

}
