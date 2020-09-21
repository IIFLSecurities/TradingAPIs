package com.iifl.service;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;

import com.iifl.service.interfaces.IAESEncryptionServicee;
import com.iifl.util.AES;

@Service("aESEncryptionService")
public class AESEncryptionServiceImpl implements IAESEncryptionServicee {

	public static final Logger logger = LoggerFactory.getLogger(AESEncryptionServiceImpl.class);

	@Value("${encryption.key}")
	private String secretKey;

	@Override
	public String encryptText(String text) {
		return AES.encrypt(text, secretKey);
	}

	@Override
	public String decryptText(String text){
		return AES.decrypt(text, secretKey);
	}
}
