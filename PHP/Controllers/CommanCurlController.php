<?php
/**
 * Controller
 * PHP version 7.2
 *
 */
namespace Controllers;

/**
 * Class CommanCurlController
 *
 * @category Controllers
 * @package  IIFL.
 * @author   IIFL. <https://api.iiflsecurities.com/>
 * @license  https://api.iiflsecurities.com/ N/A
 * @link     https://api.iiflsecurities.com/
 */
class CommanCurlController
{

    /**
     * Create a new controller instance.
     */
    public function __construct()
    {
    }
    /**
      * Call API by curl
      * @param Request $request
      * @author IIFLSecurities. <https://api.iiflsecurities.com/>
      * @return string
      */
    public function callApi($apiMethod, $apiUrl, $requestData, $headerData = array())
    {
        $curl = curl_init();
        curl_setopt($curl, CURLOPT_URL, $apiUrl);

        switch ($apiMethod) {
            case "GET":
                curl_setopt($curl, CURLOPT_POSTFIELDS, json_encode($requestData));
                curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "GET");
                break;
            case "POST":
                curl_setopt($curl, CURLOPT_POST, true);
                curl_setopt($curl, CURLOPT_POSTFIELDS, json_encode($requestData));
                break;
            case "PUT":
                curl_setopt($curl, CURLOPT_POSTFIELDS, json_encode($requestData));
                curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "PUT");
                break;
            case "DELETE":
                curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "DELETE");
                curl_setopt($curl, CURLOPT_POSTFIELDS, json_encode($requestData));
                break;
        }
        curl_setopt($curl, CURLOPT_HTTPHEADER, $headerData);
        curl_setopt($curl, CURLOPT_RETURNTRANSFER, true);
        curl_setopt($curl, CURLOPT_SSL_VERIFYPEER, false);
        //If want to get response header then open this line
        // curl_setopt($curl, CURLOPT_HEADER, 1);

        $result = curl_exec($curl);
        echo $result . "\n";
    }
}
