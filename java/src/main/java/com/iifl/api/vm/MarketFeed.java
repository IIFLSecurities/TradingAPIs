package com.iifl.api.vm;

import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public class MarketFeed {

	
	@JsonProperty(value = "ClientCode")
	private String ClientCode; 
	
	@JsonProperty(value = "Count")
	private String Count;
	
	@JsonProperty(value = "MarketFeedData")
	private List<MarketFeedd> MarketFeedData;
	
	@JsonProperty(value = "ClientLoginType")
	private String ClientLoginType;
	
	@JsonProperty(value = "LastRequestTime")
	private String LastRequestTime;
	
	@JsonProperty(value = "RefreshRate")
	private String RefreshRate;
		
		
}


 class MarketFeedd{
	@JsonProperty(value = "Exch")
	private String Exch;
	@JsonProperty(value = "ExchType")
	private String ExchType;
	@JsonProperty(value = "ScripCode")
	private String ScripCode;
}
