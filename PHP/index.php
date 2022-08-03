<?php

//Error Reporting functions
ini_set('display_errors', 1);
error_reporting(E_ALL);

require_once "router.php";
require_once "Configuration/config.php";

//Included all controller files
foreach (glob("Controllers/*.php") as $classFileDirectory) {
    include $classFileDirectory;
}

// Routing & calling controller & its respective method
route('/LoginRequestMobileForVendor', function () {
    $obj=new \Controllers\AuthController();
    $obj->loginRequestMobileForVendor();
});

route('/LoginRequest', function () {
    $obj=new \Controllers\AuthController();
    $obj->loginRequest();
});

route('/Holding', function () {
    $obj=new \Controllers\MiscellaneousController();
    $obj->holding();
});

route('/MarketFeed', function () {
    $obj=new \Controllers\MiscellaneousController();
    $obj->marketFeed();
});

route('/Margin', function () {
    $obj=new \Controllers\MiscellaneousController();
    $obj->margin();
});

route('/OrderRequest', function () {
    $obj=new \Controllers\OrderController();
    $obj->orderRequest();
});

route('/OrderStatus', function () {
    $obj=new \Controllers\OrderController();
    $obj->orderStatus();
});

route('/OrderBookV2', function () {
    $obj=new \Controllers\OrderController();
    $obj->orderBookV2();
});

route('/PreOrdMarginCalculation', function () {
    $obj=new \Controllers\OrderController();
    $obj->preOrdMarginCalculation();
});

route('/TradeInformation', function () {
    $obj=new \Controllers\TradingController();
    $obj->tradeInformation();
});

route('/TradeBook', function () {
    $obj=new \Controllers\TradingController();
    $obj->tradeBook();
});

route('/NetPosition', function () {
    $obj=new \Controllers\NetPositionController();
    $obj->netPosition();
});

route('/NetPositionNetWise', function () {
    $obj=new \Controllers\NetPositionController();
    $obj->netPositionNetWise();
});

/*Backoff*/
route('/BackoffMutualFundTransaction', function () {
    $obj=new \Controllers\BackoffController();
    $obj->backoffMutualFundTransaction();
});

route('/BackoffClientProfile', function () {
    $obj=new \Controllers\BackoffController();
    $obj->backoffClientProfile();
});

route('/BackoffEquitytransaction', function () {
    $obj=new \Controllers\BackoffController();
    $obj->backoffEquitytransaction();
});

route('/BackoffFutureTransaction', function () {
    $obj=new \Controllers\BackoffController();
    $obj->backoffFutureTransaction();
});

route('/BackoffoptionTransaction', function () {
    $obj=new \Controllers\BackoffController();
    $obj->backoffoptionTransaction();
});

route('/BackoffLedger', function () {
    $obj=new \Controllers\BackoffController();
    $obj->backoffLedger();
});

route('/BackoffDPTransaction', function () {
    $obj=new \Controllers\BackoffController();
    $obj->backoffDPTransaction();
});

route('/BackoffDPHolding', function () {
    $obj=new \Controllers\BackoffController();
    $obj->backoffDPHolding();
});

$action = $_SERVER['REQUEST_URI'];
dispatch($action);
