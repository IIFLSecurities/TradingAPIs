package iifl;

import static org.junit.Assert.assertTrue;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import org.junit.Test;

import com.iifl.api.Exchange;

import okhttp3.Response;

public class test2 {

	Exchange apis = new Exchange();
	JSONParser parser = new JSONParser();

	@Test
	public void LoginRequestMobileForVendor() throws IOException, ParseException {

		System.out.println(" \n ************* LoginRequestMobileForVendor  ************* \n");
		JSONObject obj = new JSONObject();
		obj.put("Email_id", "ABC@XYZ.COM");
		obj.put("ContactNumber", "9123456780");
		Response response = apis.LoginRequestMobileForVendor(obj);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void LoginRequestV2() throws IOException, ParseException {
		System.out.println(" \n ************* LoginRequestV2  ************* \n");
		JSONObject obj2 = new JSONObject();
		obj2.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj2.put("Password", "YOUR_PASSWORD_HERE");
		obj2.put("HDSerialNumber", "1.0.16.0");
		obj2.put("My2PIN", "YOUR_DOB_HERE_IN_YYYYMMDD_FORMAT");
		obj2.put("MACAddress", "1.0.16.0");
		obj2.put("RequestNo", 1);
		obj2.put("ConnectionType", 1);
		Response response = apis.LoginRequestV2(obj2);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void HoldingV2() throws IOException, ParseException {
		System.out.println(" \n ************* HoldingV2  ************* \n");
		JSONObject obj3 = new JSONObject();
		obj3.put("ClientCode", "96131461");
		Response response = apis.HoldingV2(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void OrderRequest() throws IOException, ParseException {
		System.out.println(" \n ************* OrderRequest  ************* \n");
		JSONObject obj3 = new JSONObject();
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj3.put("OrderFor", "P");
		obj3.put("Exchange", "N");
		obj3.put("ExchangeType", "C");
		obj3.put("Price", 1164);
		obj3.put("OrderID", 2);
		obj3.put("OrderType", "BUY");
		obj3.put("Qty", 1);
		obj3.put("OrderDateTime", "/Date(1563857357612)/");
		obj3.put("ScripCode", 2885);
		obj3.put("AtMarket", false);
		obj3.put("RemoteOrderID", "s0002201907231019172");
		obj3.put("ExchOrderID", "0");
		obj3.put("DisQty", 0);
		obj3.put("IsStopLossOrder", false);
		obj3.put("StopLossPrice", 1170);
		obj3.put("IsVTD", false);
		obj3.put("IOCOrder", false);
		obj3.put("IsIntraday", false);
		obj3.put("PublicIP", "192.168.84.215");
		obj3.put("AHPlaced", "N");
		obj3.put("ValidTillDate", "/Date(1600248018615)/");
		obj3.put("iOrderValidity", 0);
		obj3.put("OrderRequesterCode", "YOUR_CLIENT_CODE_HERE");
		obj3.put("TradedQty", 0);
		Response response = apis.OrderRequest(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void MarginV3() throws IOException, ParseException {
		System.out.println(" \n ************* MarginV3  ************* \n");
		JSONObject obj3 = new JSONObject();
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		;
		Response response = apis.MarginV3(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void OrderBookV2() throws IOException, ParseException {
		System.out.println(" \n ************* OrderBookV2  ************* \n");
		JSONObject obj3 = new JSONObject();
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		Response response = apis.OrderBookV2(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void TradeBookV1() throws IOException, ParseException {
		System.out.println(" \n ************* TradeBookV1  ************* \n");
		JSONObject obj3 = new JSONObject();
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		Response response = apis.TradeBookV1(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void PreOrdMarginCalculation() throws IOException, ParseException {
		System.out.println(" \n ************* PreOrdMarginCalculation  ************* \n");
		JSONObject obj3 = new JSONObject();
		obj3.put("OrderRequestorCode", "YOUR_CLIENT_CODE_HERE");
		obj3.put("Exch", "N");
		obj3.put("ExchType", "D");
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj3.put("ScripCode", "45609");
		obj3.put("PlaceModifyCancel", "M");
		obj3.put("TransactionType", "B");
		obj3.put("AtMarket", "false");
		obj3.put("LimitRate", 650);
		obj3.put("WithSL", "N");
		obj3.put("SLTriggerRate", 0);
		obj3.put("IsSLTriggered", "N");
		obj3.put("Volume", 250);
		obj3.put("OldTradedQty", 0);
		obj3.put("ProductType", "D");
		obj3.put("ExchOrderId", "0");
		obj3.put("ClientIP", "21.1.2");
		obj3.put("AppSource", 59);

		Response response = apis.PreOrdMarginCalculation(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void NetPositionV4() throws IOException, ParseException {
		System.out.println(" \n ************* NetPositionV4  ************* \n");
		JSONObject obj3 = new JSONObject();
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		Response response = apis.NetPositionV4(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void NetPositionNetWiseV1() throws IOException, ParseException {
		System.out.println(" \n ************* NetPositionNetWiseV1  ************* \n");
		JSONObject obj3 = new JSONObject();
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		Response response = apis.NetPositionNetWiseV1(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void MarketFeed() throws IOException, ParseException {
		System.out.println(" ************* NetPositionNetWiseV1  *************");

		JSONObject obj3 = new JSONObject();
		JSONObject ordStatusReqObj = new JSONObject();
		List<JSONObject> ordStatusListReqObj = new ArrayList<JSONObject>();
		ordStatusReqObj.put("Exch", "N");
		ordStatusReqObj.put("ExchType", "C");
		ordStatusReqObj.put("ScripCode", "2885");

		JSONObject ordStatusReqObj2 = new JSONObject();
		ordStatusReqObj2.put("Exch", "N");
		ordStatusReqObj2.put("ExchType", "C");
		ordStatusReqObj2.put("ScripCode", "22");

		ordStatusListReqObj.add(ordStatusReqObj);
		ordStatusListReqObj.add(ordStatusReqObj2);

		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj3.put("Count", "2");
		obj3.put("ClientLoginType", "0");
		obj3.put("LastRequestTime", "/Date(1600248018615)/");
		obj3.put("RefreshRate", "H");
		obj3.put("MarketFeedData", ordStatusListReqObj);

		Response response = apis.MarketFeed(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void OrderStatus() throws IOException, ParseException {

		System.out.println(" \n ************* OrderStatus  ************* \n");

		JSONObject obj3 = new JSONObject();
		JSONObject ordStatusReqObj = new JSONObject();
		List<JSONObject> ordStatusListReqObj = new ArrayList<JSONObject>();
		ordStatusReqObj.put("Exch", "N");
		ordStatusReqObj.put("ExchType", "C");
		ordStatusReqObj.put("ScripCode", 4717);
		ordStatusReqObj.put("RemoteOrderID", "S123456789123456789");
		ordStatusListReqObj.add(ordStatusReqObj);
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj3.put("OrdStatusReqList", ordStatusListReqObj);
		Response response = apis.OrderStatus(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void TradeInformation() throws IOException, ParseException {

		System.out.println(" \n ************* TradeInformation  ************* \n");

		JSONObject obj3 = new JSONObject();
		JSONObject ordStatusReqObj = new JSONObject();
		List<JSONObject> ordStatusListReqObj = new ArrayList<JSONObject>();
		ordStatusReqObj.put("Exch", "B");
		ordStatusReqObj.put("ExchType", "C");
		ordStatusReqObj.put("ScripCode", 500410);
		ordStatusReqObj.put("RemoteOrderID", "1557728588259000015");
		ordStatusListReqObj.add(ordStatusReqObj);
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj3.put("OrdStatusReqList", ordStatusListReqObj);

		Response response = apis.TradeInformation(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void BackoffClientProfile() throws IOException, ParseException {
		System.out.println(" \n ************* BackoffClientProfile  ************* \n");
		JSONObject obj3 = new JSONObject();
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		Response response = apis.BackoffClientProfile(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void BackoffEquitytransaction() throws IOException, ParseException {

		System.out.println(" \n ************* BackoffEquitytransaction  ************* \n");

		JSONObject obj2 = new JSONObject();
		obj2.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj2.put("FromDate", "/Date(1600248018615)/");
		obj2.put("ToDate", "/Date(1600248018615)/");
		Response response = apis.BackoffEquitytransaction(obj2);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void BackoffFutureTransaction() throws IOException, ParseException {

		System.out.println(" \n ************* BackoffFutureTransaction  ************* \n");
		JSONObject obj2 = new JSONObject();
		obj2.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj2.put("FromDate", "/Date(1600248018615)/");
		obj2.put("ToDate", "/Date(1600248018615)/");
		Response response = apis.BackoffFutureTransaction(obj2);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void backoffoptionTransaction() throws IOException, ParseException {
		JSONParser parser = new JSONParser();
		System.out.println(" \n ************* BackoffoptionTransaction  ************* \n");
		JSONObject obj2 = new JSONObject();
		obj2.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj2.put("FromDate", "/Date(1600248018615)/");
		obj2.put("ToDate", "/Date(1600248018615)/");
		Response response = apis.BackoffoptionTransaction(obj2);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void BackoffLedger() throws IOException, ParseException {

		System.out.println(" \n ************* BackoffLedger  ************* \n");

		JSONObject obj2 = new JSONObject();
		obj2.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj2.put("FromDate", "/Date(1600248018615)/");
		obj2.put("ToDate", "/Date(1600248018615)/");
		Response response = apis.BackoffLedger(obj2);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void BackoffMutualFundTransaction() throws IOException, ParseException {

		System.out.println(" \n ************* BackoffMutualFundTransaction  ************* \n");

		JSONObject obj2 = new JSONObject();
		obj2.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj2.put("FromDate", "/Date(1600248018615)/");
		obj2.put("ToDate", "/Date(1600248018615)/");
		Response response = apis.BackoffMutualFundTransaction(obj2);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void BackoffDPTransaction() throws IOException, ParseException {

		System.out.println(" \n ************* BackoffDPTransaction  ************* \n");
		JSONObject obj2 = new JSONObject();
		obj2.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		obj2.put("FromDate", "/Date(1600248018615)/");
		obj2.put("ToDate", "/Date(1600248018615)/");
		Response response = apis.BackoffDPTransaction(obj2);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

	@Test
	public void BackoffDPHolding() throws IOException, ParseException {
		System.out.println(" \n ************* BackoffClientProfile  ************* \n");
		JSONObject obj3 = new JSONObject();
		obj3.put("ClientCode", "YOUR_CLIENT_CODE_HERE");
		Response response = apis.BackoffDPHolding(obj3);
		System.out.println("\n Response >> " + response.body().string());
		assertTrue(response.isSuccessful());
	}

}
