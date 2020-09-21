package com.iifl.api.vm;

import org.springframework.beans.factory.annotation.Autowired;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.iifl.service.interfaces.IAESEncryptionServicee;

public class LoginRequestMobileForVendorVM {

	@Autowired
	private IAESEncryptionServicee iAESEncryptionService;

	@JsonProperty(value = "Email_id")
	private String Email_id;
	@JsonProperty(value = "ContactNumber")
	private String ContactNumber;

	public String getEmail_id() {
		return (Email_id);
	}

	public void setEmail_id(String email_id) {
		Email_id = email_id;
	}

	public String getContactNumber() {
		return ContactNumber;
	}

	public void setContactNumber(String contactNumber) {
		ContactNumber = contactNumber;
	}

	@Override
	public String toString() {
		return "LoginRequestMobileForVendorVM [iAESEncryptionService=" + iAESEncryptionService + ", Email_id="
				+ Email_id + ", ContactNumber=" + ContactNumber + "]";
	}

}
