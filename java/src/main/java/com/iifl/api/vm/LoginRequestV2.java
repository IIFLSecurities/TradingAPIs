package com.iifl.api.vm;

import com.fasterxml.jackson.annotation.JsonProperty;

public class LoginRequestV2 {
	@JsonProperty(value = "ClientCode")
	private String ClientCode;
	
	@JsonProperty(value = "Password")
	private String  Password;
	
	@JsonProperty(value = "LocalIP")
	private String  LocalIP;
	
	@JsonProperty(value = "PublicIP")
	private String  PublicIP;
	
	@JsonProperty(value = "HDSerialNumber")
	private String  HDSerialNumber;
	
	@JsonProperty(value = "MACAddress")
	private String  MACAddress;
	
	@JsonProperty(value = "MachineID")
	private String  MachineID;
	@JsonProperty(value = "VersionNo")
	private String  VersionNo;
	
	@JsonProperty(value = "RequestNo")
	private int  RequestNo;
	
	@JsonProperty(value = "My2PIN")
	private String  My2PIN;
	
	@JsonProperty(value = "ConnectionType")
	private String  ConnectionType;
}
