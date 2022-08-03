require("dotenv").config();

const { openApi } = require("./openApiExamples");

const { backoff } = require("./Backoffapis");
const obj = new openApi();
const backoffObj = new backoff();
obj
  .createSession()
  .then((res) => {
    console.log(res);
    return obj.LoginRequestV2();
  })
  .then((res) => {
    console.log(res);
    return obj.OrderRequest();
  })
  .then((res) => {
    console.log(JSON.stringify(res));
    return obj.OrderBookV2();
  })
  .then((res) => {
    console.log("orderbook", JSON.stringify(res));
  })
  .catch((err) => console.log(err));
