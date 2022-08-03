package com.iifl.api;

import java.io.IOException;

import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import com.iifl.service.ApiCalls;
import com.iifl.service.Properties;

import okhttp3.Response;

public class Exchange {

	private String loginRequestMobileForVendor = "LoginRequestMobileForVendor";
	private String loginRequest = "LoginRequest";
	private String holding = "Holding";
	private String marketFeed = "MarketFeed";
	private String orderRequest = "OrderRequest";
	private String orderStatus = "OrderStatus";
	private String tradeInformation = "TradeInformation";
	private String margin = "Margin";
	private String orderBook = "OrderBookV2";
	private String tradeBook = "TradeBook";
	private String preOrdMarginCalculation = "PreOrdMarginCalculation";
	private String backoffClientProfile = "BackoffClientProfile";
	private String backoffEquitytransaction = "BackoffEquitytransaction";
	private String netPosition = "NetPosition";
	private String netPositionNetWise = "NetPositionNetWise";
	private String backoffoptionTransaction = "BackoffoptionTransaction";
	private String backoffLedger = "BackoffLedger";
	private String backoffFutureTransaction = "BackoffFutureTransaction";
	private String backoffMutualFundTransaction = "BackoffMutualFundTransaction";
	private String backoffDPHolding = "BackoffDPHolding";
	private String backoffDPTransaction = "BackoffDPTransaction";
	JSONParser parser = new JSONParser();
	ApiCalls ac = new ApiCalls();
	Properties pr = new Properties();

	public Response LoginRequestMobileForVendor(JSONObject requestBody) throws IOException, ParseException {

		return ac.callWithEncrytion(requestBody, loginRequestMobileForVendor, pr.requestCodeLogin);
	}

	public Response LoginRequestV2(JSONObject requestBody) throws IOException, ParseException {
		return ac.callLogin(requestBody, loginRequest, pr.requestCodeLogin);
	}

	public Response OrderRequest(JSONObject requestBody) throws IOException, ParseException {
		return ac.callV2(requestBody, orderRequest, pr.orderRequest);
	}

	public Response HoldingV2(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, holding, pr.holding);
	}

	public Response MarketFeed(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies((requestBody), marketFeed, pr.marketFeed);
	}

	public Response OrderStatus(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, orderStatus, pr.orderStatus);
	}

	public Response TradeInformation(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, tradeInformation, pr.tradeInformation);
	}

	public Response MarginV3(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, margin, pr.margin);
	}

	public Response OrderBookV2(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, orderBook, pr.orderBook);
	}

	public Response TradeBookV1(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, tradeBook, pr.tradeBook);
	}

	public Response PreOrdMarginCalculation(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, preOrdMarginCalculation, pr.tradeBook);
	}

	public Response NetPositionV4(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, netPosition, pr.netPosition);
	}

	public Response NetPositionNetWiseV1(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, netPositionNetWise, pr.netPositionNetWise);
	}

	public Response BackoffClientProfile(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, backoffClientProfile, pr.backoffClientProfile);
	}

	public Response BackoffEquitytransaction(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, backoffEquitytransaction, pr.backoffEquitytransaction);
	}

	public Response BackoffFutureTransaction(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, backoffFutureTransaction, pr.backoffFutureTransaction);
	}

	public Response BackoffoptionTransaction(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, backoffoptionTransaction, pr.backoffoptionTransaction);
	}

	public Response BackoffLedger(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, backoffLedger, pr.backoffLedger);
	}

	public Response BackoffMutualFundTransaction(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, backoffMutualFundTransaction, pr.backoffMutualFundTransaction);
	}

	public Response BackoffDPTransaction(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, backoffDPTransaction, pr.backoffDPTransaction);
	}

	public Response BackoffDPHolding(JSONObject requestBody) throws IOException, ParseException {
		return ac.callWithCookies(requestBody, backoffDPHolding, pr.backoffDPHolding);
	}

}
