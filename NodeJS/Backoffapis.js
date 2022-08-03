const axios = require("axios").default;
const { credentials, urls } = require("./config");

class BackOffApiExamples {
  BackoffClientProfile() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQBackoffClientProfile",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.BackoffClientProfile, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.json());
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  BackoffEquitytransaction() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQBackoffEquitytransaction",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
      FromDate: "20190101",
      ToDate: "20190401",
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.BackoffEquitytransaction, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.json());
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  BackoffFutureTransaction() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQBackoffFutureTransaction",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
      FromDate: "20190101",
      ToDate: "20190401",
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.BackoffFutureTransaction, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.json());
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  BackoffoptionTransaction() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQBackoffoptionTransaction",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
      FromDate: "20190101",
      ToDate: "20190401",
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.BackoffoptionTransaction, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.json());
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  BackoffMutualFundTransaction() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQBackoffMutulFundTransaction",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
      FromDate: "15-Jan-2019",
      ToDate: "01-Apr-2019",
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.BackoffMutualFundTransaction, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.json());
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  BackoffLedger() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQBackoffLedger",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
      FromDate: "20190115",
      ToDate: "20190415",
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.BackoffLedger, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.json());
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  BackoffDPTransaction() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQBackoffDPTransaction",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
      FromDate: "20190115",
      ToDate: "20190415",
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.BackoffDPTransaction, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.json());
        })
        .catch((error) => {
          reject(error);
        });
    });
  }

  BackoffDPHolding() {
    const head = {
      appName: credentials.AppName,
      appVer: "1.0",
      key: credentials.UserKey,
      osName: "Android",
      requestCode: "IIFLMarRQBackoffDPHolding",
      userId: credentials.UserId,
      password: credentials.Password,
    };

    const body = {
      ClientCode: credentials.ClientCOde,
    };

    const payload = { head, body };

    return new Promise(async (resolve, reject) => {
      axios
        .post(urls.baseUrl + urls.BackoffDPTransaction, payload, {
          headers: {
            "Content-Type": "application/json",
            "Ocp-Apim-Subscription-Key": credentials.OcpApimSubscriptionKey,
            Cookie: "IIFLMarcookie=" + readFileSync("cookie.txt", "utf8"),
          },
        })
        .then((response) => {
          resolve(response.json());
        })
        .catch((error) => {
          reject(error);
        });
    });
  }
}

exports.backoff = BackOffApiExamples;
