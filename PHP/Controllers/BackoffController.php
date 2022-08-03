<?php
/**
 * Controller
 * PHP version 7.2
 *
 */
namespace Controllers;

/**
 * Class BackoffController
 *
 * @category Controllers
 * @package  IIFL.
 * @author   IIFL. <https://api.iiflsecurities.com/>
 * @license  https://api.iiflsecurities.com/ N/A
 * @link     https://api.iiflsecurities.com/
 */
class BackoffController
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
     * BackoffMutualFundTransaction API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function backoffMutualFundTransaction($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."BackoffMutualFundTransaction";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultBackoffMftRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultBackoffMftHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for BackoffMutualFundTransaction API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultBackoffMftRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_BACKOFF_MFT,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        'FromDate'=>'20190101',
                        'ToDate'=>'20201001',
                       );

        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for BackoffMutualFundTransaction API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultBackoffMftHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }

    /**
     * BackoffClientProfile API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function backoffClientProfile($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."BackoffClientProfile";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultClientProfileRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultClientProfileHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }

    /**
      * Default request parameters for BackoffClientProfile API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultClientProfileRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_BACKOFF_CLIENT_PROFILE,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE);
        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for BackoffClientProfile API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultClientProfileHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }
    /**
     * BackoffEquitytransaction API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function backoffEquitytransaction($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."BackoffEquitytransaction";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultEquityTransRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultEquityTransHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for BackoffEquitytransaction API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultEquityTransRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_BACKOFF_EQUITY_TRANSCTION,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        'FromDate'=>'20190101',
                        'ToDate'=>'20201001',
                       );

        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for BackoffEquitytransaction API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultEquityTransHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }

    /**
     * BackoffFutureTransaction API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function backoffFutureTransaction($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."BackoffFutureTransaction";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultFutureTransRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultFutureTransHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for BackoffFutureTransaction API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultFutureTransRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_BACKOFF_FUTURE_TRANSCTION,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        'FromDate'=>'20190101',
                        'ToDate'=>'20201001',
                       );

        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for BackoffFutureTransaction API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultFutureTransHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }

    /**
     * BackoffoptionTransaction API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function backoffoptionTransaction($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."BackoffoptionTransaction";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultOptionTransRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultOptionTransHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for BackoffoptionTransaction API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultOptionTransRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_BACKOFF_OPTION_TRANSCTION,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        'FromDate'=>'20190101',
                        'ToDate'=>'20201001',
                       );

        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for BackoffoptionTransaction API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultOptionTransHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }

    /**
     * BackoffLedger API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function backoffLedger($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."BackoffLedger";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultBackoffLedgerRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultBackoffLedgerHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for BackoffLedger API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultBackoffLedgerRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_BACKOFF_LEDGER,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        'FromDate'=>'20190101',
                        'ToDate'=>'20201001',
                       );

        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for BackoffLedger API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultBackoffLedgerHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }


    /**
     * BackoffDPTransaction API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function backoffDPTransaction($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."BackoffDPTransaction";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultDpTransRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultDptransHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for BackoffDPTransaction API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultDpTransRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_BACKOFF_DP_TRANSACTION,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        'FromDate'=>'20190101',
                        'ToDate'=>'20201001',
                       );

        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for BackoffDPTransaction API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultDptransHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }

    /**
     * BackoffDPHolding API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function backoffDPHolding($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."BackoffDPHolding";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultDpHoldRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultDpHoldHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for BackoffDPHolding API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultDpHoldRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_BACKOFF_DP_HOLDING,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>CLIENT_CODE,
                        'FromDate'=>'20190101',
                        'ToDate'=>'20201001',
                       );

        $requestData = array("head"=>$headArry,"body"=>$bodyArry);
        return $requestData;
    }
    /**
      * Default request header parameters for BackoffDPHolding API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultDpHoldHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            'Cookie: '.IIFL_MAR_COOKIE,
                            );
        return $headerData;
    }
}
