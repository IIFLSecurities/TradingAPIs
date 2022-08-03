package com.iifl.service;

import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;

import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;

import com.iifl.util.AES;
import com.iifl.util.ServerDetails;

import okhttp3.Call;
import okhttp3.MediaType;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;

public class ApiCalls {
	Properties pr = new Properties();
	public final MediaType JSON = MediaType.parse("application/json; charset=utf-8");
	String IIFLMarcookie;
	String urls = "https://dataservice.iifl.in";
	String apiUrl = "https://dataservice.iifl.in/openapi/prod/";
	JSONParser parser = new JSONParser();

	public Response callWithEncrytion(JSONObject requestBody, String url, String rc)
			throws IOException, ParseException {
		final JSONObject body = new JSONObject();
		requestBody = ipConfig(requestBody);
		JSONObject requestHead = new JSONObject();
		requestHead = header(rc, AES.encrypt(pr.userId), AES.encrypt(pr.password));
		body.put("body", requestBody);
		body.put("head", requestHead);
		Response ressonse = apiCall(url, body, rc);
		return ressonse;
	}

	public Response callV2(JSONObject requestBody, String url, String rc) throws IOException, ParseException {
		JSONObject body = new JSONObject();
		requestBody = ipConfig(requestBody);
		requestBody.put("OrderDateTime", "/Date(" + System.currentTimeMillis() + ")/");
		requestBody.put("ValidTillDate", "/Date(" + System.currentTimeMillis() + ")/");
		JSONObject requestHead = new JSONObject();
		requestHead = header(rc, pr.userId, pr.password);
		body.put("body", requestBody);
		body.put("head", requestHead);
		JSONObject reqData = new JSONObject();
		reqData.put("_ReqData", body);
		reqData.put("AppSource", pr.AppSource);
		Response ressonse = apiCallWithCookies(url, reqData);
		return ressonse;
	}

	public Response callWithCookies(JSONObject requestBody, String url, String rc) throws IOException, ParseException {
		JSONObject body = new JSONObject();
		JSONObject OrderStatusJson = (JSONObject) requestBody;
		requestBody = ipConfig(OrderStatusJson);
		JSONObject requestHead = new JSONObject();
		requestHead = header(rc, pr.userId, pr.password);
		body.put("body", requestBody);
		body.put("head", requestHead);
		Response resonse = apiCallWithCookies(url, body);
		return resonse;
	}

	public Response callLogin(JSONObject requestBody, String url, String rc) throws IOException, ParseException {
		JSONObject body = new JSONObject();
		requestBody = ipConfig(requestBody);
		requestBody.put("ClientCode", AES.encrypt(requestBody.get("ClientCode").toString()));
		requestBody.put("Password", AES.encrypt(requestBody.get("Password").toString()));
		requestBody.put("My2PIN", AES.encrypt(requestBody.get("My2PIN").toString()));
		JSONObject requestHead = new JSONObject();
		requestHead = header(rc, pr.userId, pr.password);
		body.put("body", requestBody);
		body.put("head", requestHead);
		Response resonse = apiCallWithCookies(url, body);
		return resonse;
	}

	public Response apiCall(String suburl, JSONObject reqbody, String rc) throws IOException, ParseException {
		OkHttpClient client = new OkHttpClient();
		String url = apiUrl + suburl;
		System.out.println("\n Url >> " + url);
		System.out.println("\n Request >> " + reqbody);
		RequestBody body = RequestBody.create(JSON, reqbody.toJSONString());
		Request request = new Request.Builder().url(url)
				.addHeader("Ocp-Apim-Subscription-Key", pr.ocpApimSubscriptionKey).post(body).build();
		Call call = client.newCall(request);
		Response response = call.execute();
		JSONObject requestHead = new JSONObject();
		requestHead = header(rc, pr.userId, pr.password);
		IIFLMarcookie = (response.headers().get("set-cookie").split(";", 2)[0]).split("=", 2)[1];
		whiteFile(IIFLMarcookie);
		if (!response.isSuccessful())
			throw new IOException("Unexpected code " + response);
		return response;
	}

	public Response apiCallWithCookies(String suburl, JSONObject reqbody) throws IOException, ParseException {
		String cookie = readFile();
		OkHttpClient client = new OkHttpClient();
		String url = apiUrl + suburl;
		System.out.println("\n Url >> " + url);
		System.out.println("\n Request >> " + reqbody);
		RequestBody body = RequestBody.create(JSON, reqbody.toJSONString());
		Request request = new Request.Builder().url(url)
				.addHeader("Ocp-Apim-Subscription-Key", pr.ocpApimSubscriptionKey)
				.addHeader("Cookie", "IIFLMarcookie=" + cookie).post(body).build();
		Call call = client.newCall(request);
		Response response = call.execute();
		if (!response.isSuccessful())
			throw new IOException("\n  Unexpected code " + response);
		return response;
	}

	public JSONObject header(String rc, String ui, String pw) throws IOException, ParseException {
		JSONObject requestHead = new JSONObject();
		requestHead.put("requestCode", rc);
		requestHead.put("key", pr.key);
		requestHead.put("appVer", pr.appVer);
		requestHead.put("appName", pr.appName);
		requestHead.put("osName", pr.osName);
		requestHead.put("userId", ui);
		requestHead.put("password", pw);
		return requestHead;
	}

	public JSONObject ipConfig(JSONObject requestBody) throws IOException, ParseException {
		JSONObject ipDetails = ServerDetails.GetIP();
		requestBody.put("LocalIP", ipDetails.get("publicIp"));
		requestBody.put("PublicIP", ipDetails.get("privateIp"));
		return requestBody;
	}

	public void whiteFile(String tx) throws IOException {
		FileWriter myWriter = new FileWriter("cookie.txt");
		myWriter.write(tx);
		myWriter.close();

	}

	public String readFile() throws IOException {
		FileReader fr = new FileReader("cookie.txt");
		int i;
		String cookie = "";
		while ((i = fr.read()) != -1)
			cookie += (char) i;
		fr.close();
		return cookie;
	}
}
