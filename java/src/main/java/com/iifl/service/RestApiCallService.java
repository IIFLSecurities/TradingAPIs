package com.iifl.service;

import java.net.InetAddress;
import java.net.SocketException;
import java.net.UnknownHostException;
import java.util.HashMap;
import java.util.Map;

import org.json.simple.JSONObject;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpMethod;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;

import com.iifl.util.ServerDetails;

@Service
public class RestApiCallService {
	public static final Logger log = LoggerFactory.getLogger(RestApiCallService.class);

	@Autowired
	private RestTemplate restTemplate;

	@Value("${requestCode}")
	private String requestCode;

	@Value("${Ocp-Apim-Subscription-Key}")
	private String ocpApimSubscriptionKey;

	@Value("${key}")
	private String key;

	@Value("${appVer}")
	private String appVer;

	@Value("${appName}")
	private String appName;

	@Value("${osName}")
	private String osName;

	@Value("${userId}")
	private String userId;

	@Value("${password}")
	private String password;

	@Value("${enpassword}")
	private String enuserId;

	@Value("${enpassword}")
	private String enpassword;

	public ResponseEntity<Map> callOpenApi(JSONObject requestBody, String url)
			throws UnknownHostException, SocketException {
		final HttpHeaders headers = new HttpHeaders();
		final Map<String, String> map = new HashMap<>();
		map.put("Ocp-Apim-Subscription-Key", ocpApimSubscriptionKey);
//		map.put("Content-Type", "application/json");
		String ip = InetAddress.getLocalHost().getHostAddress();
		System.out.println("Ip: " + ip);
		System.out.println("Mac: " + ServerDetails.GetSerialNo());
		System.out.println("Mac Id :" + ServerDetails.GetMachineId());
		System.out.println("Mac Id :");
		JSONObject ipDetails = ServerDetails.GetIP();
		final JSONObject body = new JSONObject();
		final JSONObject requestHead = new JSONObject();
		requestHead.put("requestCode", requestCode);
		requestHead.put("key", key);
		requestHead.put("appVer", appVer);
		requestHead.put("appName", appName);
		requestHead.put("osName", osName);
		requestHead.put("userId", userId);
		requestHead.put("password", password);

		body.put("body", requestBody);
		body.put("head", requestHead);

		headers.setAll(map);
//		NetworkInterface ni= new NetworkInterface();	
		log.info("InetAddress {} {} {} {} {} {}", body);
//		System.out.println("Ip: " + GetNetworkAddress.GetAddress("ip"));
//		System.out.println("Mac: " + GetNetworkAddress.GetAddress("mac"));

//		final Map<String, String> map = new HashMap<>();	
		final HttpEntity<JSONObject> request = new HttpEntity<>(body, headers);
		final ResponseEntity<Map> response = restTemplate.exchange(url, HttpMethod.POST, request, Map.class);
		log.info("response {} {} {} {} {} {}", response);
		return response;
	}

	public ResponseEntity<Map> callOpenApiWithEncryptHeader(JSONObject requestBody, String url)
			throws UnknownHostException, SocketException {
		final HttpHeaders headers = new HttpHeaders();
		final Map<String, String> map = new HashMap<>();
		map.put("Ocp-Apim-Subscription-Key", "fc714d8e5b82438a93a95baa493ff45b");
		map.put("Content-Type", "application/json");

		String ip = InetAddress.getLocalHost().getHostAddress();
		System.out.println("Ip: " + ip);
		System.out.println("Mac: " + ServerDetails.GetSerialNo());
		System.out.println("Mac Id :" + ServerDetails.GetMachineId());
		System.out.println("Mac Id :");
		JSONObject ipDetails = ServerDetails.GetIP();
		final JSONObject body = new JSONObject();
		requestBody.put("LocalIP", ipDetails.get("publicIp"));
		requestBody.put("PublicIP", ipDetails.get("privateIp"));
		final JSONObject requestHead = new JSONObject();

		requestHead.put("requestCode", requestCode);
		requestHead.put("key", key);
		requestHead.put("appVer", appVer);
		requestHead.put("appName", appName);
		requestHead.put("osName", osName);
		requestHead.put("userId", enuserId);
		requestHead.put("password", enpassword);
		body.put("body", requestBody);
		body.put("head", requestHead);

		headers.setAll(map);

		log.info("requestBody {} {} {} {} {} {}", body);
//		final Map<String, String> map = new HashMap<>();	
		final HttpEntity<JSONObject> request = new HttpEntity<>(body, headers);
		final ResponseEntity<Map> response = restTemplate.exchange(url, HttpMethod.POST, request, Map.class);
		log.info("response {} {} {} {} {} {}", response);
		return response;
	}

	public ResponseEntity<Map> callOpenApiWithCustomerHeader(JSONObject requestBody, String url)
			throws UnknownHostException, SocketException {
		final HttpHeaders headers = new HttpHeaders();
		final Map<String, String> map = new HashMap<>();
		map.put("Ocp-Apim-Subscription-Key", "fc714d8e5b82438a93a95baa493ff45b");
//		map.put("Content-Type", "application/json");
		JSONObject ipDetails = ServerDetails.GetIP();
		final JSONObject body = new JSONObject();
		final JSONObject requestHead = new JSONObject();
		final JSONObject reqData = new JSONObject();
		requestHead.put("requestCode", "IIFLMarRQOrdReq");
		requestHead.put("key", key);
		requestHead.put("appVer", appVer);
		requestHead.put("appName", appName);
		requestHead.put("osName", osName);
		requestHead.put("userId", userId);
		requestHead.put("password", password);
		body.put("body", requestBody);
		body.put("head", requestHead);
		reqData.put("_ReqData", body);
		reqData.put("AppSource", 54);
		headers.setAll(map);

		log.info("requestBody {} {} {} {} {} {}", reqData);
//		final Map<String, String> map = new HashMap<>();	
		final HttpEntity<JSONObject> request = new HttpEntity<>(reqData, headers);
		final ResponseEntity<Map> response = restTemplate.exchange(url, HttpMethod.POST, request, Map.class);
		log.info("response {} {} {} {} {} {}", response);
		return response;
	}

}
