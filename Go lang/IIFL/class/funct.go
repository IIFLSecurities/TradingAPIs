package class

import (
	"encoding/json"
	"fmt"
	"net"
	"net/http"
	"os"
)

type configuration struct {
	ServiceURL, AppName, AppVer, Key, OsName, RequestCode, RequestCodeHoldingV2, UserID, Password, VersionNo, OcpKey,
	RequestCodeMarketFeed, RequestCodeOrdReq, RequestCodeOrdStatus, RequestCodeTrdInfo, RequestCodeMarginV3,
	RequestCodeOrdBkV2, RequestCodeTrdBkV1, RequestCodeNetPositionV4, RequestCodeNPNWV1,
	RequestCodePreOrdMarCal, RequestCodeBackoffMutulFundTransaction, RequestCodeBackoffClientProfile,
	RequestCodeBackoffEquitytransaction, RequestCodeBackoffFutureTransaction,
	RequestCodeBackoffoptionTransaction, RequestCodeBackoffLedger, RequestCodeBackoffDPTransaction,
	RequestCodeBackoffDPHolding, EncryKey string
}

//CheckConfig : To get the data from conf.json
func CheckConfig() *configuration {

	file, _ := os.Open("conf.json")
	defer file.Close()
	decoder := json.NewDecoder(file)
	Configur := configuration{}
	err := decoder.Decode(&Configur)
	if err != nil {
		fmt.Println("error:", err)
	}
	return &Configur
}

//GetIP : Method 1 to get the IP address
func GetIP(r *http.Request) string {
	forwarded := r.Header.Get("X-FORWARDED-FOR")
	if forwarded != "" {
		return forwarded
	}
	return r.RemoteAddr
}

//GetIPAddress : Method 2 to get the IP address
func GetIPAddress() string {
	var IPadd string
	addrs, err := net.InterfaceAddrs()
	if err != nil {
		fmt.Println("error:", err)
	}

	for _, a := range addrs {
		if ipnet, ok := a.(*net.IPNet); ok && !ipnet.IP.IsLoopback() {
			if ipnet.IP.To4() != nil {
				IPadd = ipnet.IP.String()
			}
		}
	}

	return IPadd
}
