<?php

//Credentials
define("OCP_APIM_SUBSCRIPTION_KEY", "{GET FROM IIFL}");
define("BASE_URL", "https://dataservice.iifl.in/openapi/prod/");
define("APP_NAME", "{GET FROM IIFL}");
define("APP_VERSION", "1.0");
define("KEY", "{GET FROM IIFL}");
define("OS_NAME", "Android");
define("USER_ID", "{GET FROM IIFL}");
define("PASSWORD", "{GET FROM IIFL}");
define("VERSION_NO", "1.0.16.0");
define("OCP_KEY", "{GET FROM IIFL}");
define("ENCRYPT_KEY", "{GET FROM IIFL}");
define('AES_256_CBC', 'aes-256-cbc');
define('AES_IV', [83, 71, 26, 58, 54, 35, 22, 11, 83, 71, 26, 58, 54, 35, 22, 11]);
define('CLIENT_CODE', '{GET FROM IIFL}'); //Client Code of IIFL Trading Account
define("PASSWORD_ENCYPTED_CLIENT_LOGIN", "{GET FROM IIFL}"); //Password of IIFL Trading Account
define("MY2PIN", "{GET FROM IIFL}"); //Date of Birth in YYYYMMDD format
/*
NOTE: Got cooki in Client login api response's header & set in cooki or session & use for other api call by passing it into header like 'Cookie: IIFLMarcookie=5mqlulw3dr5mzhg5nhozy5v2'
Here We have set as  define Constant & use in default header.
*/
define("IIFL_MAR_COOKIE", "IIFLMarcookie=122dor34kqqa5iupfh2nwrac");


//Request code According to API

/*LOGIN*/
define("REQUEST_CODE_VENDOR", "IIFLMarRQLoginForVendor");

/*HOLDING & MARKET FEEDS*/
define("REQUEST_CODE_HOLDINGV2", "IIFLMarRQHoldingV2");
define("REQUEST_CODE_MARKETFEED", "IIFLMarRQMarketFeed");
define("REQUEST_CODE_MARKET", "IIFLMarRQMarginV3");

/*ORDER*/
define("REQUEST_CODE_OREDER_REQUEST", "IIFLMarRQOrdReq");
define("REQUEST_CODE_OREDER_STATUS", "IIFLMarRQOrdStatus");
define("REQUEST_CODE_OREDER_BOOKV2", "IIFLMarRQOrdBkV2");
define("REQUEST_CODE_PRE_ORD_MARGIN_CALCULATION", "IIFLMarRQPreOrdMarCal");

/*TRADING*/
define("REQUEST_CODE_TRADE_INFO", "IIFLMarRQTrdInfo");
define("REQUEST_CODE_TRADE_BOOK", "IIFLMarRQTrdBkV1");

/*NET POSITION*/
define("REQUEST_CODE_NET_POSITION", "IIFLMarRQNetPositionV4");
define("REQUEST_CODE_NET_POSITION_NETWISE", "IIFLMarRQNPNWV2");

/*BACKOFF*/
define("REQUEST_CODE_BACKOFF_MFT", "IIFLMarRQBackoffMutulFundTransaction");
define("REQUEST_CODE_BACKOFF_CLIENT_PROFILE", "IIFLMarRQBackoffClientProfile");
define("REQUEST_CODE_BACKOFF_EQUITY_TRANSCTION", "IIFLMarRQBackoffEquitytransaction");
define("REQUEST_CODE_BACKOFF_FUTURE_TRANSCTION", "IIFLMarRQBackoffFutureTransaction");
define("REQUEST_CODE_BACKOFF_OPTION_TRANSCTION", "IIFLMarRQBackoffoptionTransaction");
define("REQUEST_CODE_BACKOFF_LEDGER", "IIFLMarRQBackoffLedger");
define("REQUEST_CODE_BACKOFF_DP_TRANSACTION", "IIFLMarRQBackoffDPTransaction");
define("REQUEST_CODE_BACKOFF_DP_HOLDING", "IIFLMarRQBackoffDPHolding");
