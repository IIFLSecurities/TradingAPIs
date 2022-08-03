package com.iifl.util;

import java.util.Base64;

import javax.crypto.Cipher;
import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.PBEKeySpec;
import javax.crypto.spec.SecretKeySpec;

public class AES {

	static byte[] salt = { 83, 71, 26, 58, 54, 35, 22, 11, 83, 71, 26, 58, 54, 35, 22, 11 };
	static String password = "YxjDEpOqxMSHJoXWb06CxjLNJxsZGNR0Z7Rg112orvaraf5UsWApy5tH8gCIEDO3";

	public static String encrypt(String data) {
		try {
			char[] passwordchars = password.toCharArray();
			SecretKeyFactory factory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA1");
			PBEKeySpec pbeKeySpec = new PBEKeySpec(passwordchars, salt, 1000, 256 + 128);
			SecretKey secretKey = factory.generateSecret(pbeKeySpec);
			byte[] key = new byte[32];
			byte[] iv = new byte[16];
			System.arraycopy(secretKey.getEncoded(), 0, iv, 0, 16);
			System.arraycopy(secretKey.getEncoded(), 16, key, 0, 32);

			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5PADDING");
			SecretKeySpec secretKeySpec = new SecretKeySpec(key, "AES");
			IvParameterSpec ivps = new IvParameterSpec(iv);

			cipher.init(Cipher.ENCRYPT_MODE, secretKeySpec, ivps);
			byte[] encrypted = cipher.doFinal(data.getBytes("UTF-8"));
			return Base64.getEncoder().encodeToString(encrypted);
		} catch (Exception ex) {
			ex.printStackTrace();
		}

		return null;
	}

	public static String decrypt(String data) {
		try {
			char[] passwordchars = password.toCharArray();
			SecretKeyFactory factory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA1");
			PBEKeySpec pbeKeySpec = new PBEKeySpec(passwordchars, salt, 1000, 256 + 128);
			SecretKey secretKey = factory.generateSecret(pbeKeySpec);
			byte[] key = new byte[32];
			byte[] iv = new byte[16];
			System.arraycopy(secretKey.getEncoded(), 0, iv, 0, 16);
			System.arraycopy(secretKey.getEncoded(), 16, key, 0, 32);

			SecretKeySpec secretKeySpec = new SecretKeySpec(key, "AES");
			IvParameterSpec ivps = new IvParameterSpec(iv);

			Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5PADDING");
			cipher.init(Cipher.DECRYPT_MODE, secretKeySpec, ivps);
			byte[] original = cipher.doFinal(Base64.getDecoder().decode(data.getBytes("UTF-8")));
			return new String(original);
		} catch (Exception ex) {
			ex.printStackTrace();
		}
		return null;
	}
}
