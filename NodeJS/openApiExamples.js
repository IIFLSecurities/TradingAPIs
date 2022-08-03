const axios = require("axios").default;
const { credentials, urls } = require("./config");
const encObj = require("./encry");
const { platform } = require("os");
const { writeFileSync, readFileSync } = require("fs");

const axiosInstance = axios.create({
  baseURL: urls.baseUrl,
  // jar: cookieJar,
  // withCredentials: true,
  headers: {
    "Content-Type": "application/json",
    "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
  },
});

class OpenAPiExamples {
  createSession() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQLoginForVendor",
      userId: encObj.encrypt(credentials.UserId),
      password: encObj.encrypt(credentials.Password),
    };

    const body = {
      Email_id: credentials.Email_id,
      ContactNumber: credentials.ContactNumber,
      LocalIP: "192.168.88.41",
      PublicIP: "192.168.88.42",
    };
    const payload = { head, body };
    // console.log(JSON.stringify(payload));
    return new Promise((resolve, reject) => {
      axiosInstance
        .post(urls.loginRequestMobileForVendor, payload)
        .then((response) => {
          // console.log("vendor headers", response.headers);
          writeFileSync(
            "cookie.txt",
            response.headers["set-cookie"][0].split(";")[0].split("=")[1]
          );

          resolve(response.headers["set-cookie"][0]);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
  LoginRequestV2() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQLoginForVendor",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: encObj.encrypt(credentials.ClientCOde),
      Password: encObj.encrypt(credentials.cpass),

      HDSerialNumber: "",
      MACAddress: "",
      MachineID: "",
      VersionNo: "1.0.16.0",
      RequestNo: 1,
      My2PIN: encObj.encrypt(credentials.My2Pin),
      ConnectionType: "1",
    };
    const payload = { head, body };
    // console.log(JSON.stringify(payload));

    return new Promise((resolve, reject) => {
      // console.log(readFileSync("cookie.txt", "utf8"));
      axios
        .post(urls.baseUrl + urls.LoginRequestV2, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })

        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  OrderBookV2() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQOrdBkV2",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
    };
    const payload = { head, body };
    // console.log(JSON.stringify(payload));

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.OrderBookV2, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  Holdingv2() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQHoldingV2",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
    };
    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.HoldingV2, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  MarginV3() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQMarginV3",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
    };
    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.MarginV3, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  TradeBookV1() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQTrdBkV1",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
    };
    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.TradeBookV1, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  PreOrdMarginCalculation() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQPreOrdMarCal",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
      OrderRequestorCode: "SURVINHA",
      Exch: "N",
      ExchType: "D",
      ScripCode: "45609",
      PlaceModifyCancel: "M",
      TransactionType: "B",
      AtMarket: "false",
      LimitRate: 650,
      WithSL: "N",
      SLTriggerRate: 0,
      IsSLTriggered: "N",
      Volume: 250,
      OldTradedQty: 0,
      ProductType: "D",
      ExchOrderId: "0",
      ClientIP: "21.1.2",
      AppSource: 59,
    };
    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.PreOrdMarginCalculation, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  TradeInformation() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQTrdInfo",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
      TradeInformationList: [
        {
          Exch: "B",
          ExchType: "C",
          ScripCode: 500410,
          ExchOrderID: "1557728588259000015",
        },
        {
          Exch: "B",
          ExchType: "C",
          ScripCode: 500410,
          ExchOrderID: "1557728588259000017",
        },
        {
          Exch: "B",
          ExchType: "C",
          ScripCode: 500410,
          ExchOrderID: "1557728588259000018",
        },
        {
          Exch: "B",
          ExchType: "C",
          ScripCode: 500410,
          ExchOrderID: "1557728588259000019",
        },
        {
          Exch: "B",
          ExchType: "C",
          ScripCode: 500410,
          ExchOrderID: "1557728588259000020",
        },
      ],
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.TradeInformation, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  NetPositionV4() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQNetPositionV4",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.NetPositionV4, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  NetPositionNetWiseV1() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQNPNWV1",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.NetPositionNetWiseV1, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  OrderStatus() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQOrdStatus",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
      OrdStatusReqList: [
        {
          Exch: "N",
          ExchType: "C",
          ScripCode: 4717,
          RemoteOrderID: "S0002201905060327534",
        },
      ],
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.OrderStatus, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  OrderRequest() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQOrdReq",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
      OrderRequesterCode: credentials.ClientCOde,
      OrderFor: "P", // P- Place (Fresh ), M-Modify, C- Cancel Order
      Exchange: "N", //N- NSE, B- BSE, M-MCX
      ExchangeType: "C", //C-Cash, D-Derivative, U - Currenc
      Price: 211, // (Price=0 for at market order)

      OrderID: 5, //random value

      OrderType: "BUY",
      Qty: 1,
      OrderDateTime: `/Date(${Date.now()})/`,

      TradedQty: 0, //For placing fresh order, value should be 0. For modification/cancellation, send the actual traded qty.

      ScripCode: 3045, //stock code

      AtMarket: false, //false --> limit order true --> market order
      RemoteOrderID: "s000220190", //unique id for each order

      ExchOrderID: "0", //Send 0 for fresh order and for modify cancel send the exchange order id received from exchange.
      DisQty: 0, //display qty

      StopLossPrice: 0, //shoould be checked outside before implementing here
      IsStopLossOrder: false,

      IOCOrder: false,
      IsIntraday: false,

      ValidTillDate: `/Date(${Date.now() + 3 * 24 * 3600 * 1000})/`,
      PublicIP: "192.168.84.215",
      iOrderValidity: 0, //0 - Day 4 - EOS 2 - GTC 1- GTD 3 - IOC 6 - FOK
      IsVTD: false,
      AHPlaced: "N",
    };

    const payload = { _ReqData: { head, body }, AppSource: 54 };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.OrderRequest, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.data);
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
}
exports.openApi = OpenAPiExamples;
