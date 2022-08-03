package class

import (
	"encoding/json"
	"fmt"
	"net/http"
	"strings"
)

//LoginRequestMobileForVendor : his method allows the developer to login the client into the application
func LoginRequestMobileForVendor(w http.ResponseWriter, r *http.Request) {

	//	fmt.Printf("GetIP: %s", class.GetIP(r))
	//	fmt.Printf("GetIP2: %s", class.GetIPAddress())

	EmailID := r.URL.Query().Get("EmailID")
	ContactNumber := r.URL.Query().Get("ContactNumber")

	var IPadd string
	IPadd = GetIPAddress()

	config := CheckConfig()

	url := config.ServiceURL + "LoginRequestMobileForVendor"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCode, UserID: Encryption(config.UserID), Password: Encryption(config.Password)}

	body := LoginMobileVendorBody{EmailID: EmailID, LocalIP: IPadd, PublicIP: IPadd, ContactNumber: ContactNumber}

	loginMobileVendorRequest := LoginMobileVendorRequest{Head: header, Body: body}

	// golang struct to json
	data, _ := json.Marshal(loginMobileVendorRequest)

	payload := strings.NewReader(string(data))
	bodyString := HTTPClientCookies(method, url, payload)
	json.NewEncoder(w).Encode(bodyString)

	var LoginVendorRes LoginVendorResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &LoginVendorRes)
	fmt.Printf("Message: %s, TTManagerID: %s", LoginVendorRes.Body.Message, LoginVendorRes.Body.TTManagerID)

}

//LoginRequest : This API is used to fetch Client’s Available Margin details.
func LoginRequest(w http.ResponseWriter, r *http.Request) {

	var IPadd string
	IPadd = GetIPAddress()

	config := CheckConfig()

	url := config.ServiceURL + "LoginRequest"

	method := "POST"

	header := Header{AppName: config.AppName, AppVer: config.AppVer, Key: config.Key, OsName: config.OsName, RequestCode: config.RequestCode, UserID: config.UserID, Password: config.Password}

	body := LoginRequestBody{ClientCode: Encryption("{ClientCode}"), Password: "{ClientPassword}", HDSerialNumber: "asdf", MACAddress: "asdf", MachineID: "asfdasdf", VersionNo: config.VersionNo, RequestNo: 1, My2PIN: "{ClientMy2PIN}", ConnectionType: 1, LocalIP: IPadd, PublicIP: IPadd}

	LoginRequestRequest := LoginRequestRequest{Head: header, Body: body}

	data, _ := json.Marshal(LoginRequestRequest)
	fmt.Printf("LoginRequestRequest: %s", data)
	payload := strings.NewReader(string(data))
	bodyString := HTTPClientCookies(method, url, payload)

	json.NewEncoder(w).Encode(bodyString)

	var LoginClientRes LoginClientResponse

	// json to golang struct
	json.Unmarshal([]byte(bodyString), &LoginClientRes)
	fmt.Printf("\nClientName: %s, StatusDescription: %s", LoginClientRes.Body.ClientName, LoginClientRes.Head.StatusDescription)

}
