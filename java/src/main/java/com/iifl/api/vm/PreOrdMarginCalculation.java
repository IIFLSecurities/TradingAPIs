package com.iifl.api.vm;

import com.fasterxml.jackson.annotation.JsonProperty;

public class PreOrdMarginCalculation {

	@JsonProperty(value = "Exch")
	private String Exch;

	@JsonProperty(value = "ExchType")
	private String ExchType;

	@JsonProperty(value = "ClientCode")
	private String ClientCode;

	@JsonProperty(value = "ScripCode")
	private String ScripCode;

	@JsonProperty(value = "PlaceModifyCancel")
	private String PlaceModifyCancel;

	@JsonProperty(value = "TransactionType")
	private String TransactionType;

	@JsonProperty(value = "AtMarket")
	private String AtMarket;

	@JsonProperty(value = "LimitRate")
	private String LimitRate;

	@JsonProperty(value = "WithSL")
	private String WithSL;

	@JsonProperty(value = "SLTriggerRate")
	private String SLTriggerRate;

	@JsonProperty(value = "IsSLTriggered")
	private String IsSLTriggered;

	@JsonProperty(value = "Volume")
	private String Volume;

	@JsonProperty(value = "OldTradedQty")
	private String OldTradedQty;

	@JsonProperty(value = "ProductType")
	private String ProductType;

	@JsonProperty(value = "ExchOrderId")
	private String ExchOrderId;

	@JsonProperty(value = "ClientIP")
	private String ClientIP;

	@JsonProperty(value = "AppSource")
	private String AppSource;

}