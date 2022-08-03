<?php
/**
 * Controller
 * PHP version 7.2
 *
 */
namespace Controllers;

/**
 * Class OrderController
 *
 * @category Controllers
 * @package  IIFL.
 * @author   IIFL. <https://api.iiflsecurities.com/>
 * @license  https://api.iiflsecurities.com/ N/A
 * @link     https://api.iiflsecurities.com/
 */
class OrderController
{
    private $commanCurl;
    /**
     * Create a new controller instance.
     */
    public function __construct()
    {
        $this->commanCurl=new CommanCurlController();
    }
    /**
      * Get all headers of request
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return Array
      */
    public function getAllHeaders()
    {
        $headerData=array();
        foreach (getallheaders() as $key => $value) {
            if ($key=='Content-Type' || $key=='Ocp-Apim-Subscription-Key') {
                $val=$key.':'.$value;
                array_push($headerData, $val);
            }
        }
        return $headerData;
    }
    /**
      * Get Json RAW request
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return Json
      */
    public function getJsonRequestParams()
    {
        return $jsonRequestParams = file_get_contents('php://input');
    }
    /**
     * OrderRequest API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function orderRequest($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."OrderRequest";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultOrderRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultOrderHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for OrderRequest API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultOrderRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_OREDER_REQUEST,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        "OrderFor"=>"P",
                        "Exchange"=>"N",
                        "ExchangeType"=>"C",
                        "Price"=>190,
                        "OrderID"=>1,
                        "OrderType"=>"BUY",
                        "Qty"=>1,
                        "OrderDateTime"=>"/Date(1601880914379)/",
                        "ScripCode"=>3045,
                        "AtMarket"=>false,
                        "RemoteOrderID"=>"s000220190",
                        "ExchOrderID"=>"0",
                        "DisQty"=>0,
                        "IsStopLossOrder"=>false,
                        "StopLossPrice"=>0,
                        "IsVTD"=>false,
                        "IOCOrder"=>false,
                        "IsIntraday"=>false,
                        "PublicIP"=>"192.168.84.215",
                        "AHPlaced"=>"N",
                        "ValidTillDate"=>"/Date(1602880914379)/",
                        "iOrderValidity"=>0,
                        "OrderRequesterCode"=>"96131461",
                        "TradedQty"=>0,
                      );

        $requestData =array("_ReqData"=>array("head"=>$headArry,"body"=>$bodyArry),
                             "AppSource"=>54
                             );
        return $requestData;
    }
    /**
      * Default request header parameters for OrderRequest API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultOrderHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }

    /**
     * OrderStatus API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function orderStatus($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."OrderStatus";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultOrderStatusRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultOrderStatusHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }

    /**
      * Default request parameters for OrderStatus API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultOrderStatusRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_OREDER_STATUS,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        'OrdStatusReqList'=>array('Exch'=>"N",
                        'ExchType'=>'C',
                        'ScripCode'=>4717,
                        'RemoteOrderID'=>"S123456789123456789")

                        );

        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for OrderStatus API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultOrderStatusHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }
    /**
     * OrderBookV2 API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function orderBookV2($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."OrderBookV2";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultOrderBookV2RequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultOrderBookV2HeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }

    /**
      * Default request parameters for OrderBookV2 API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultOrderBookV2RequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_OREDER_BOOKV2,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE);
        return $requestData = array("head"=>$headArry,"body"=>$bodyArry);
    }
    /**
      * Default request header parameters for OrderBookV2 API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultOrderBookV2HeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }

    /**
     * PreOrdMarginCalculation API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function preOrdMarginCalculation($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."PreOrdMarginCalculation";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultPreOrderRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultPreOrderHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }

    /**
      * Default request parameters for PreOrdMarginCalculation API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultPreOrderRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_PRE_ORD_MARGIN_CALCULATION,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('OrderRequestorCode'=>CLIENT_CODE,
                        'Exch'=>'N',
                        'ExchType'=>'D',
                        'ClientCode'=>CLIENT_CODE,
                        'ScripCode'=>'45609',
                        'PlaceModifyCancel'=>'M',
                        'TransactionType'=>'B',
                        'AtMarket'=>'false',
                        'LimitRate'=>650,
                        'WithSL'=>'N',
                        'SLTriggerRate'=>0,
                        'IsSLTriggered'=>'N',
                        'Volume'=>250,
                        'OldTradedQty'=>0,
                        'ProductType'=>'D',
                        'ExchOrderId'=>'0',
                        'ClientIP'=>'21.1.2',
                        'AppSource'=>54,
                       );
        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for PreOrdMarginCalculation API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultPreOrderHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }
}
