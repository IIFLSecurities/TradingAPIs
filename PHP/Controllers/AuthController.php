<?php
/**
 * Controller
 * PHP version 7.2
 *
 */
namespace Controllers;

/**
 * Class AuthController
 *
 * @category Controllers
 * @package  IIFL.
 * @author   IIFL. <https://api.iiflsecurities.com/>
 * @license  https://api.iiflsecurities.com/ N/A
 * @link     https://api.iiflsecurities.com/
 */
class AuthController
{
    private $commanCurl;
    private $aesEncryption;
    /**
     * Create a new controller instance.
     */
    public function __construct()
    {
        $this->commanCurl=new CommanCurlController();
        $this->aesEncryption=new AesEncyptionController();
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
     * Vendor Login API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function loginRequestMobileForVendor($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."LoginRequestMobileForVendor";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultVendorLoginRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultVendorLoginHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }
    /**
      * Default request parameters for Vendor Login API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultVendorLoginRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_VENDOR,
                        'userId'=>$this->aesEncryption->encrypt(USER_ID),
                        'password'=>$this->aesEncryption->encrypt(PASSWORD),
                       );

        $bodyArry=array('Email_id'=>'{GET FROM IIFL}',
                        'LocalIP'=>'123.123.123.123',
                        'PublicIP'=>'123.123.123.12',
                        'ContactNumber'=>'7769941110',
                        );

        return $requestData = array("head"=>$headArry,"body"=>$bodyArry);
    }
    /**
      * Default request header parameters for Vendor Login API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultVendorLoginHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            );
        return $headerData;
    }

    /**
     * Client Login API
     * @param $requestData
     * @param $headerData
     * @author IIFL. <https://api.iiflsecurities.com/>
     * @return Json
     */
    public function loginRequest($requestData = null, $headerData = null)
    {
        $requestHeader=$this->getAllHeaders();
        $jsonRequestParams=$this->getJsonRequestParams();

        $method='POST';
        $apiUrl=BASE_URL."LoginRequest";

        if ($jsonRequestParams && $requestHeader) {
            //JSON RAW Request params from postman or other api tool
            $requestData=json_decode($jsonRequestParams, true);
            $headerData=$requestHeader;
        } else {
            //Pass array of requestData & headerData in argument & overwrite this two variable.
            $requestData=!empty($requestData)?$requestData:$this->defaultClientLoginRequestParam();
            $headerData=!empty($headerData)?$headerData:$this->defaultClientLoginHeaderParam();
        }
        return $this->commanCurl->callApi($method, $apiUrl, $requestData, $headerData);
    }

    /**
      * Default request parameters for Vendor Login API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultClientLoginRequestParam()
    {
        $headArry=array('appName'=>APP_NAME,
                        'appVer'=>APP_VERSION,
                        'key'=>KEY,
                        'osName'=>OS_NAME,
                        'requestCode'=>REQUEST_CODE_VENDOR,
                        'userId'=>USER_ID,
                        'password'=>PASSWORD,
                       );

        $bodyArry=array('ClientCode'=>$this->aesEncryption->encrypt(CLIENT_CODE),
                        'Password'=>$this->aesEncryption->encrypt(PASSWORD_ENCYPTED_CLIENT_LOGIN),
                        'HDSerialNumber'=>'asdf',
                        'MACAddress'=>'asdf',
                        'MachineID'=>'asfdasdf',
                        'VersionNo'=>VERSION_NO,
                        'RequestNo'=>1,
                        'My2PIN'=>$this->aesEncryption->encrypt(MY2PIN),
                        'ConnectionType'=>1,
                        'LocalIP'=>'192.168.88.41',
                        'PublicIP'=>'192.168.88.42',
                        );

        return $requestData = array("head"=>$headArry,"body"=>$bodyArry);
    }
    /**
      * Default request header parameters for Vendor Login API
      * @author IIFL. <https://api.iiflsecurities.com/>
      * @return array
      */
    public function defaultClientLoginHeaderParam()
    {
        $headerData = array(
                            'Content-Type: application/json',
                            'Ocp-Apim-Subscription-Key: '.OCP_APIM_SUBSCRIPTION_KEY,
                            );
        return $headerData;
    }
}
