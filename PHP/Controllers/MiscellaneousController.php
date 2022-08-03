<?php
/**
 * Controller
 * PHP version 7.2
 *
 */
namespace Controllers;

/**
 * Class MiscellaneousController
 *
 * @category Controllers
 * @package  IIFL.
 * @author   IIFL. <https://api.iiflsecurities.com/>
 * @license  https://api.iiflsecurities.com/ N/A
 * @link     https://api.iiflsecurities.com/
 */
class MiscellaneousController
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
     * Holding API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function holding($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."Holding";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultHoldingRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultHoldingHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for Holding API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultHoldingRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_HOLDINGV2,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE);

        return $requestData = array("head"=>$headArry,"body"=>$bodyArry);
    }
    /**
      * Default request header parameters for Holding API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultHoldingHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }

    /**
     * Market Feed API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function marketFeed($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."MarketFeed";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultMarketFeedRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultMarketFeedHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }

    /**
      * Default request parameters for Market Feed API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultMarketFeedRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_MARKETFEED,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        'Count'=>2,
                        'MarketFeedData'=>array(array( 'Exch'=>'N',
                        'ExchType'=>'C',
                        'ScripCode'=>2885),array( 'Exch'=>'N',
                        'ExchType'=>'C',
                        'ScripCode'=>22)),
                        'ClientLoginType'=>0,
                        'LastRequestTime'=>'/Date(1600248018615)/',
                        'RefreshRate'=>'H',
                        );

        return $requestData = array("head"=>$headArry,"body"=>$bodyArry);
    }
    /**
      * Default request header parameters for Market Feed API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultMarketFeedHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }
    /**
     * Margin API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function margin($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."Margin";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultMarginRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultMarginHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }

    /**
      * Default request parameters for Margin API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultMarginRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_MARKET,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE);

        return $requestData = array("head"=>$headArry,"body"=>$bodyArry);
    }
    /**
      * Default request header parameters for Margin API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultMarginHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }
}
