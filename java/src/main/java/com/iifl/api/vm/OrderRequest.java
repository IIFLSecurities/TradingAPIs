package com.iifl.api.vm;

import com.fasterxml.jackson.annotation.JsonProperty;

public class OrderRequest {
	@JsonProperty(value = "ClientCode")
	private String ClientCode;

	@JsonProperty(value = "OrderFor")
	private String OrderFor;

	@JsonProperty(value = "Exchange")
	private String Exchange;

	@JsonProperty(value = "ExchangeType")
	private String ExchangeType;

	@JsonProperty(value = "Price")
	private String Price;

	@JsonProperty(value = "OrderID")
	private String OrderID;

	@JsonProperty(value = "OrderType")
	private String OrderType;

	@JsonProperty(value = "Qty")
	private String Qty;

	@JsonProperty(value = "OrderDateTime")
	private String OrderDateTime;

	@JsonProperty(value = "AtMarket")
	private String AtMarket;

	@JsonProperty(value = "RemoteOrderID")
	private String RemoteOrderID;

	@JsonProperty(value = "ExchOrderID")
	private String ExchOrderID;

	@JsonProperty(value = "DisQty")
	private String DisQty;

	@JsonProperty(value = "IsStopLossOrder")
	private String IsStopLossOrder;

	@JsonProperty(value = "StopLossPrice")
	private String StopLossPrice;

	@JsonProperty(value = "IsVTD")
	private String IsVTD;

	@JsonProperty(value = "IOCOrder")
	private String IOCOrder;

	@JsonProperty(value = "IsIntraday")
	private String IsIntraday;

	@JsonProperty(value = "PublicIP")
	private String PublicIP;

	@JsonProperty(value = "AHPlaced")
	private String AHPlaced;

	@JsonProperty(value = "ValidTillDate")
	private String ValidTillDate;

	@JsonProperty(value = "iOrderValidity")
	private String iOrderValidity;

	@JsonProperty(value = "OrderRequesterCode")
	private String OrderRequesterCode;

	@JsonProperty(value = "TradedQty")
	private String TradedQty;

	@JsonProperty(value = "AppSource")
	private String AppSource;
}