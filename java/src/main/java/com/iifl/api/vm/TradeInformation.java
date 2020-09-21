package com.iifl.api.vm;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class TradeInformation {

	@JsonProperty(value = "ClientCode")
	private String ClientCode;
	
	@JsonProperty(value = "OrdStatusReqList")
	private List<TradeInformationData>	 TradeInformationList;
			
			
}

class TradeInformationData{
	
	@JsonProperty(value = "Exch")
	private String Exch;
	
	@JsonProperty(value = "ExchType")
	private String ExchType;
	
	@JsonProperty(value = "ScripCode")
	private String ScripCode;
	
	@JsonProperty(value = "ExchOrderID")
	private String ExchOrderID;
}