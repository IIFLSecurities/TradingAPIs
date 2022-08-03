package class

import (
	"fmt"
	"io"
	"io/ioutil"
	"net/http"
)

// HTTPClientCookies : http.client call with header and cookies
func HTTPClientCookies(method string, url string, payload io.Reader) string {
	config := CheckConfig()

	client := &http.Client{}
	req, err := http.NewRequest(method, url, payload)

	if err != nil {
		fmt.Println(err)
	}
	req.Header.Add("Ocp-Apim-Subscription-Key", config.OcpKey)
	req.Header.Add("Content-Type", "application/json")

	res, err := client.Do(req)

	body, err := ioutil.ReadAll(res.Body)
	defer res.Body.Close()
	var session string
	var path string
	for _, cookie := range res.Cookies() {
		if cookie.Name == "IIFLMarcookie" {
			session = cookie.Value
			path = cookie.Path
		}
	}
	fmt.Printf("session: %s, path: %s", session, path)

	bodyString := string(body)

	return bodyString
}

// HTTPClient : http.client call with header
func HTTPClient(method string, url string, payload io.Reader) string {
	config := CheckConfig()
	client := &http.Client{}
	req, err := http.NewRequest(method, url, payload)

	if err != nil {
		fmt.Println(err)
	}

	req.Header.Add("Ocp-Apim-Subscription-Key", config.OcpKey)
	req.Header.Add("Content-Type", "application/json")
	// 5cigio2zsorf35q5tbAAAAAA - get this from the login cookies
	req.Header.Add("Cookie", "IIFLMarcookie=5cigio2zsorf35q5tbAAAAAA")

	res, err := client.Do(req)

	body, err := ioutil.ReadAll(res.Body)
	defer res.Body.Close()
	//fmt.Println(string(body))
	bodyString := string(body)

	return bodyString
}
