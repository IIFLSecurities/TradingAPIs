# IIFL Securities Open APIs: PHP
PHP OOPs based structure library for trading Apis.


## Requirement
 ```php
 - PHP Version >= 5.6
 - CURL extension should be installed & Enable
 ```

## Installation
```php
- Download PHP library & put on your localhost
```
## Structure
```php
-Configuration
 |-Config.php
-Controllers
 |-AesEncryptionController.php
 |-AuthController.php
 |-BackoffController.php
 |-MiscellaneousController.php
 |-NetPositionController.php
 |-OrderController.php
 |-TradingController.php
-index.php
-route.php
-requirement.txt
-README.MD

Description
------------

AesEncryptionController : Contain AES-256-CBC Encryption
AuthController: Contain API end point loginRequestMobileForVendor,LoginRequest
BackoffController: Contain API end point
                   BackoffMutualFundTransaction,
                   BackoffClientProfile,
                   BackoffEquitytransaction,
                   BackoffFutureTransaction,
                   BackoffoptionTransaction,
                   BackoffLedger
MiscellaneousController: Contain API end point Holding,MarketFeed,Margin
NetPositionController: Contain API end point NetPosition,NetPositionNetWise
OrderController: Contain API end point OrderRequest,OrderStatus,OrderBookV2,PreOrdMarginCalculation
TradingController: Contain API end point TradeInformation,TradeBook


```
## Usage

```php
Step-1: Put Application credentials in Configuration/Config.php file
Step-2: Open Command-line interface & go to project directory & write below command
        php -S localhost:8000
Step-3: Open browser & run the Url: http://localhost:8000/LoginRequestMobileForVendor

Alternative Way of use
------------------
You can include the controller from directory "Controllers/"
& call its method by passing request params array & headers params array as two arguments.

Example:

 include Controller/AuthController;

 $obj=new \Controllers\AuthController();
 $obj->loginRequestMobileForVendor($requestData, $headerData);

```
## Running Application Note:
Encryption : AES-256-CBC Encryption used

Cookie: Get Cookie in Client Login Apis's response header & save in cookie or session for other API calling & passed in header like this.
'Cookie:IIFLMarcookie=5mqlulw3dr5mzhg5nhozy5v2'

Response Header: For Client Login Api opens the commenting line in the CommanCurlController.php file so you can get a cookie in the response header.


## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.



## License
[MIT](https://choosealicense.com/licenses/mit/)