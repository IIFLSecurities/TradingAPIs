package com.iifl.api;

import java.net.SocketException;
import java.net.UnknownHostException;
import java.util.HashMap;
import java.util.Map;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.json.simple.parser.ParseException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.iifl.api.vm.LoginRequestMobileForVendorVM;
import com.iifl.api.vm.LoginRequestV2;
import com.iifl.service.RestApiCallService;
import com.iifl.service.interfaces.IAESEncryptionServicee;

import io.swagger.annotations.ApiOperation;

@RestController
@RequestMapping("/api/")
public class LoginRest {

	public static final Logger log = LoggerFactory.getLogger(LoginRest.class);

	@Autowired
	private IAESEncryptionServicee iAESEncryptionService;

	@Autowired
	private RestApiCallService restApiCall;

	final String url = "https://dataservice.iifl.in/openapi/prod/";
	
	

	
	@Autowired
	private RestTemplate restTemplate;

	public LoginRest(final RestApiCallService restApiCall, final IAESEncryptionServicee iAESEncryptionService) {
		this.restApiCall = restApiCall;
		this.iAESEncryptionService = iAESEncryptionService;
	}

	

	@ApiOperation(value = "Login Request Mobile For Vendor")
	@PostMapping(value = "LoginRequestMobileForVendor")
	public Object LoginRequestMobileForVendor(
			@RequestBody final LoginRequestMobileForVendorVM loginRequestMobileForVendorVM)
			throws ParseException, JsonProcessingException, UnknownHostException, SocketException {
		log.info("** REST request to save Transaction notes : {}", loginRequestMobileForVendorVM.getEmail_id());
		final String path = url + "LoginRequestMobileForVendor";
		JSONObject requestBody = new JSONObject();
		JSONParser parser = new JSONParser();
		ObjectMapper mapper = new ObjectMapper();
		String json = mapper.writeValueAsString(loginRequestMobileForVendorVM);
		requestBody = (JSONObject) parser.parse(json);
	

		log.info("requestBody {} {} {} {} {} {}", requestBody);
		return new ResponseEntity(restApiCall.callOpenApiWithEncryptHeader(requestBody, path).getBody(), HttpStatus.OK);
	}

	@ApiOperation(value = "Login Request V2")
	@PostMapping(value = "LoginRequestV2")
	public Object LoginRequestV2(@RequestBody final LoginRequestV2 loginRequestMobileForVendorVM)
			throws JsonProcessingException, ParseException, UnknownHostException, SocketException {
		final String path = url + "LoginRequest";
		JSONObject requestBody = new JSONObject();
		JSONParser parser = new JSONParser();
		ObjectMapper mapper = new ObjectMapper();
		String json = mapper.writeValueAsString(loginRequestMobileForVendorVM);
		requestBody = (JSONObject) parser.parse(json);
		return new ResponseEntity(restApiCall.callOpenApi(requestBody, path).getBody(), HttpStatus.OK);
	}


@ApiOperation(value = "Order Request")
	@PostMapping(value = "OrderRequest")
	public Object OrderRequest(@RequestBody final OrderRequest OrderRequest)
			throws JsonProcessingException, ParseException, UnknownHostException, SocketException {
		final String path = url + "OrderRequest";

		// iAESEncryptionService.encryptText("iRwx6yEij41"));
		JSONObject requestBody = new JSONObject();
		JSONParser parser = new JSONParser();
		ObjectMapper mapper = new ObjectMapper();
		String json = mapper.writeValueAsString(OrderRequest);
		requestBody = (JSONObject) parser.parse(json);
		requestBody.put("LocalIP", "192.168.88.41");
		requestBody.put("PublicIP", "192.168.88.42");
		log.info("requestBody {} {} {} {} {} {}", requestBody);
		return new ResponseEntity(restApiCall.callOpenApiWithCustomerHeader(requestBody, path).getBody(), HttpStatus.OK);
	}



}
