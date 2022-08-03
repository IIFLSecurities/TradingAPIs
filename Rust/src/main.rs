use aes::Aes256;
use base64::encode;
use block_modes::block_padding::Pkcs7;
use block_modes::{BlockMode, Cbc};
use dotenv::var;
use error_chain::error_chain;
use http::{HeaderMap, HeaderValue};

use ring::pbkdf2;

use serde_json::json;

use std::num::NonZeroU32;
use std::time::{SystemTime, UNIX_EPOCH};
error_chain! {
    foreign_links {
        HttpRequest(reqwest::Error);
        IoError(::std::io::Error);
    }
}
type AesCbc = Cbc<Aes256, Pkcs7>;

fn main() {
    // create_session().expect("create session failed");
    // login_request_v2().expect("login request version 2 failed");
    Order_request().expect("order request failed");
    // order_book_v2().expect("order book failed");
}

fn encrypt(data: &str) -> String {
    let iv = &[
        83, 71, 26, 58, 54, 35, 22, 11, 83, 71, 26, 58, 54, 35, 22, 11,
    ];
    let mut password = var("enc_key").unwrap();

    let mut pbkdf2_hash = [0u8; 256 + 128];
    pbkdf2::derive(
        pbkdf2::PBKDF2_HMAC_SHA1,
        NonZeroU32::new(1000).unwrap(),
        iv,
        password.as_bytes(),
        &mut pbkdf2_hash,
    );
    let mut new_key = [0u8; 32];
    let mut new_iv = [0u8; 16];
    new_key[..32].copy_from_slice(&pbkdf2_hash[16..48]);
    new_iv.copy_from_slice(&pbkdf2_hash[0..16]);

    let cipher = AesCbc::new_var(&new_key, &new_iv).unwrap();
    let cipher_text = cipher.encrypt_vec(data.as_bytes());
    // print!("{} is encrypted", encode(&cipher_text));
    return encode(&cipher_text);
}

fn create_session() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQLoginForVendor",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": encrypt(&var("UserId").unwrap()),
                         "password": encrypt(&var("Password").unwrap())
                     },
                 "body": {
                     "Email_id": var("EmailID").unwrap(),
                     "ContactNumber": var("ContactNumber").unwrap(),
                     "LocalIP": "192.168.88.41",
                     "PublicIP": "192.168.88.42"
                  }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/LoginRequestMobileForVendor";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    let cookies = response.headers().get("Set-Cookie").unwrap();
    let v: Vec<&str> = cookies.to_str().unwrap().split(";").collect();

    let cookie_string: Vec<&str> = v[0].split("=").collect();
    print!("AAAAAAAAAAAAA{:?}", cookie_string[1]);
    std::fs::write("cookies.txt", cookie_string[1]).expect("Unable to write file");

    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    println!("{}", file_content);

    Ok(())
}

fn login_request_v2() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQLoginForVendor",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": encrypt(&var("ClientCode").unwrap()),
                    "Password": encrypt(&var("cpass").unwrap()),
            "HDSerialNumber": "asdf",
            "MACAddress": "asdf",
            "MachineID": "asfdasdf",
            "VersionNo": "1.0.16.0",
            "RequestNo": 1,
            "My2PIN": encrypt(&var("My2Pin").unwrap()),
            "ConnectionType": 1,
            "LocalIP": "192.168.88.41",
            "PublicIP": "192.168.88.42"
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/LoginRequest";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}

fn order_book_v2() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQOrdBkV2",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/OrderBookV2";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
fn holding_v2() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQHoldingV2",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/Holding";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response);

    Ok(())
}
fn margin_v3() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQMarginV3",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/Margin";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response);

    Ok(())
}
fn Trade_Book_v1() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQTrdBkV1",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/TradeBook";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response);

    Ok(())
}
fn Pre_Order_margin_Calculation() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQPreOrdMarCal",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
                    "Exch": "N",
            "ExchType": "D",
            "ScripCode": "45609",
            "PlaceModifyCancel": "M",
            "TransactionType": "B",
            "AtMarket": "false",
            "LimitRate": 650,
            "WithSL": "N",
            "SLTriggerRate": 0,
            "IsSLTriggered": "N",
            "Volume": 250,
            "OldTradedQty": 0,
            "ProductType": "D",
            "ExchOrderId": "0",
            "ClientIP": "21.1.2",
            "AppSource": 59
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/PreOrdMarginCalculation";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response);

    Ok(())
}
fn Trade_Information() -> Result<()> {
    let gist_body = json!({
       "head": {
                            "requestCode": "IIFLMarRQTrdInfo",
                            "key": var("UserKey").unwrap(),
                            "appVer": "1.0",
                            "appName": var("AppName").unwrap(),
                            "osName": "Android",
                            "userId": var("UserId").unwrap(),
                            "password": var("Password").unwrap()
                        },
                    "body": {
                       "ClientCode": var("ClientCode").unwrap(),
    "TradeInformationList": [
                 {
                   "Exch": "B",
                   "ExchType": "C",
                   "ScripCode": 500410,
                   "ExchOrderID": "1557728588259000015"
                 }
               ]



             }

        });

    let request_url = "https://dataservice.iifl.in/openapi/prod/TradeInformation";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response);

    Ok(())
}

fn Net_Position_V4() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQNetPositionV4",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap()



          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/NetPosition";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response);

    Ok(())
}
fn Net_Position_Net_Wise() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQNPNWV1",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap()



          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/NetPositionNetWise";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
fn Order_status() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQOrdStatus",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
                      "OrdStatusReqList": [
              {
                "Exch": "N",
                "ExchType": "C",
                "ScripCode": 4717,
                "RemoteOrderID": "S123456789123456789"
              }
            ]



          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/OrderStatus";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
fn to_date(epoch: u64) -> String {
    format!("/Date({:?})/", epoch)
}
fn Order_request() -> Result<()> {
    let start = SystemTime::now();
    let since_the_epoch = start
        .duration_since(UNIX_EPOCH)
        .expect("Time went backwards");
    let current_in_ms = since_the_epoch.as_secs() as u64 * 1000;

    let expiry = current_in_ms + 3 * 24 * 3600 * 1000;

    let gist_body = json!({

    "_ReqData":{
         "head": {
                          "requestCode": "IIFLMarRQOrdReq",
                          "key": var("UserKey").unwrap(),
                          "appVer": "1.0",
                          "appName": var("AppName").unwrap(),
                          "osName": "Android",
                          "userId": var("UserId").unwrap(),
                          "password": var("Password").unwrap()
                      },
                  "body": {
                     "ClientCode": var("ClientCode").unwrap(),
            "OrderFor": "P",
              "Exchange": "N",
              "ExchangeType": "C",
              "Price": 0,
              "OrderID": 1,
              "OrderType": "BUY",
              "Qty": 1,
              "OrderDateTime": to_date(current_in_ms),
              "ScripCode": 3045,
              "AtMarket": false,
              "RemoteOrderID": "s000220190",
              "ExchOrderID": "0",
              "DisQty": 0,
              "IsStopLossOrder": false,
              "StopLossPrice": 0,
              "IsVTD": false,
              "IOCOrder": false,
              "IsIntraday": false,
              "PublicIP": "192.168.84.215",
              "AHPlaced": "N",
              "ValidTillDate": to_date(expiry),
              "iOrderValidity": 0,
              "OrderRequesterCode": var("ClientCode").unwrap(),
              "TradedQty": 0



           }

      },
      "AppSource":54

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/OrderRequest";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());

    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
fn Backoff_Client_Profile() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQBackoffClientProfile",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/BackoffClientProfile";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
fn Backoff_Equity_Transaction() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQBackoffEquitytransaction",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
                     "FromDate": "20190101",
      "ToDate": "20190401",
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/BackoffEquitytransaction";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
fn Backoff_Future_Transaction() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQBackoffFutureTransaction",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
                     "FromDate": "20190101",
      "ToDate": "20190401",
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/BackoffFutureTransaction";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
fn Backoff_Option_Transaction() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQBackoffoptionTransaction",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
                     "FromDate": "20190101",
      "ToDate": "20190401",
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/BackoffoptionTransaction";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
fn Backoff_Mutual_Fund_Transaction() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQBackoffMutulFundTransaction",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
                     "FromDate": "15-Jan-2019",
      "ToDate":"01-Apr-2019" ,
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/BackoffoptionTransaction";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
fn Backoff_Ledger() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQBackoffLedger",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
                   "FromDate": "20190115",
      "ToDate": "20190415",
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/BackoffLedger";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}

fn Backoff_Dpt_Transaction() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQBackoffDPTransaction",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
                   "FromDate": "20190115",
      "ToDate": "20190415",
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/BackoffDPTransaction";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
fn Backoff_Dp_Holding() -> Result<()> {
    let gist_body = json!({
    "head": {
                         "requestCode": "IIFLMarRQBackoffDPHolding",
                         "key": var("UserKey").unwrap(),
                         "appVer": "1.0",
                         "appName": var("AppName").unwrap(),
                         "osName": "Android",
                         "userId": var("UserId").unwrap(),
                         "password": var("Password").unwrap()
                     },
                 "body": {
                    "ClientCode": var("ClientCode").unwrap(),
          }

     });

    let request_url = "https://dataservice.iifl.in/openapi/prod/BackoffDPHolding";
    let mut headers = HeaderMap::new();
    headers.insert(
        "Content-Type",
        HeaderValue::from_str("application/json").unwrap(),
    );
    headers.insert(
        "Ocp-Apim-Subscription-Key",
        HeaderValue::from_str(&var("OcpApimSubscriptionKey").unwrap()).unwrap(),
    );
    let file_content = std::fs::read_to_string("cookies.txt").expect("Unable to read file");
    let owned_string: String = file_content;
    let borrowed_string: String = "IIFLMarcookie=".to_string();

    let together = [borrowed_string, owned_string].join("");
    headers.insert("Cookie", HeaderValue::from_str(&together).unwrap());
    let response = reqwest::blocking::Client::new()
        .post(request_url)
        .headers(headers)
        .json(&gist_body)
        .send()
        .unwrap();

    print!("{:?}", response.text());

    Ok(())
}
