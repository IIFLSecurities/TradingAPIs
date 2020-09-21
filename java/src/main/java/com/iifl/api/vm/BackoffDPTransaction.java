package com.iifl.api.vm;

import com.fasterxml.jackson.annotation.JsonProperty;

public class BackoffDPTransaction {
	@JsonProperty(value = "ClientCode")
	private String ClientCode;

	@JsonProperty(value = "FromDate")
	private String FromDate;

	@JsonProperty(value = "ToDate")
	private String ToDate;
}
