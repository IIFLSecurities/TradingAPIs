package com.iifl.api.vm;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class OrderStatus {

	@JsonProperty(value = "ClientCode")
	private String ClientCode;

	@JsonProperty(value = "OrdStatusReqList")
	private List<OrdStatusReq> OrdStatusReqList;

}

class OrdStatusReq {
	@JsonProperty(value = "Exch")
	private String Exch;
	
	@JsonProperty(value = "ExchType")
	private String ExchType;
	
	@JsonProperty(value = "ScripCode")
	private String ScripCode;
	
	@JsonProperty(value = "RemoteOrderID")
	private String RemoteOrderID;
}
