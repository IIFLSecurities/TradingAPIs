<?php
/**
 * Controller
 * PHP version 7.2
 *
 */
namespace Controllers;

/**
 * Class TradingController
 *
 * @category Controllers
 * @package  IIFL.
 * @author   IIFL. <https://api.iiflsecurities.com/>
 * @license  https://api.iiflsecurities.com/ N/A
 * @link     https://api.iiflsecurities.com/
 */
class TradingController
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
     * TradeInformation API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function tradeInformation($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."TradeInformation";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultTradeInfoRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultTradeInfoHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for TradeInformation API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultTradeInfoRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_TRADE_INFO,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        "TradeInformationList"=>array("Exch"=>"B",
                        "ExchType"=>"C",
                        "ScripCode"=>500410,
                        "ExchOrderID"=>"1557728588259000015"),
                      );

        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for TradeInformation API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultTradeInfoHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }

    /**
     * TradeBook API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function tradeBook($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."TradeBook";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultTradeBookRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultTradeBookHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }

    /**
      * Default request parameters for TradeBook API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultTradeBookRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_TRADE_BOOK,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE);
        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for TradeBook API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultTradeBookHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }
}
