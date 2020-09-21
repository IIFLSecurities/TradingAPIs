package com.iifl.util;

import java.io.UnsupportedEncodingException;
import java.security.Key;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.util.Arrays;
import java.util.Base64;

import javax.crypto.Cipher;
import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.GCMParameterSpec;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.PBEKeySpec;
import javax.crypto.spec.SecretKeySpec;

//import org.springframework.security.crypto.codec.Hex;
public class AES {

	private static SecretKeySpec secretKey;

	public static void setKey(String myKey) {
		byte[] key;
		MessageDigest sha = null;
		try {
			key = myKey.getBytes("UTF-8");
			sha = MessageDigest.getInstance("SHA-1");
			key = sha.digest(key);
			key = Arrays.copyOf(key, 16);
			secretKey = new SecretKeySpec(key, "AES");
		} catch (NoSuchAlgorithmException e) {
			e.printStackTrace();
		} catch (UnsupportedEncodingException e) {
			e.printStackTrace();
		}
	}

//	public static String encrypt(String strToEncrypt, String secret) {
//		try {
//			setKey(secret);
//			Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
//			cipher.init(Cipher.ENCRYPT_MODE, secretKey);
//			return Base64.getEncoder().encodeToString(cipher.doFinal(strToEncrypt.getBytes("UTF-8")));
//		} catch (Exception e) {
//			System.out.println("Error while encrypting: " + e.toString());
//		}
//		return null;
//	}

	public static String decrypt(String strToDecrypt, String secret) {
		try {
			setKey(secret);
			Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5PADDING");
			cipher.init(Cipher.DECRYPT_MODE, secretKey);
			return null;	 //String(cipher.doFinal(Base64.getDecoder().decode(strToDecrypt)));
		} catch (Exception e) {
			System.out.println("Error while decrypting: " + e.toString());
		}
		return null;
	}

//	public static String encryptAndHex(String strToEncrypt, String secret) {
//		try {
//			setKey(secret);
//			Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5Padding");
//			cipher.init(Cipher.ENCRYPT_MODE, secretKey);
//			String data = Base64.getEncoder().encodeToString(cipher.doFinal(strToEncrypt.getBytes("UTF-8")));
//			return new String(Hex.encode(data.getBytes())); // encodeHexString(data.getBytes());
//		} catch (Exception e) {
//			System.out.println("Error while encrypting: " + e.toString());
//		}
//		return null;
//	}
//
//	public static String decryptAndHex(String strToDecrypt, String secret) {
//		try {
//			setKey(secret);
//			Cipher cipher = Cipher.getInstance("AES/ECB/PKCS5PADDING");
//			cipher.init(Cipher.DECRYPT_MODE, secretKey);
//			return new String(cipher.doFinal(Base64.getDecoder().decode(Hex.decode(strToDecrypt))));
//		} catch (Exception e) {
//			System.out.println("Error while decrypting: " + e.toString());
//		}
//		return null;
//	}
	
	
	
	private static String secretKeys = "secretKeys";
	private static String salt = "ssshhhhhhhhhhh!!!!";
	 
//	public static String encrypt(String strToEncrypt, String secret) 
//	{
//	    try
//	    {
//	        byte[] iv = {83, 71, 26, 58, 54, 35, 22, 11,
//                    83, 71, 26, 58, 54, 35, 22, 11 };
//	        IvParameterSpec ivspec = new IvParameterSpec(iv);
//	         
//	        SecretKeyFactory factory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA256"); // PBKDF2
//	        KeySpec spec = new PBEKeySpec(secret.toCharArray(),iv	, 65536, 256);
//	        SecretKey tmp = factory.generateSecret(spec);
//	     //   SecretKeySpec secretKey = new SecretKeySpec(tmp.getEncoded(), "AES");
//	         setKey(secret	);
//	         
//	         System.out.println("Error while encrypting secretKey: " +secretKey.toString());
//	        Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
//	        cipher.init(Cipher.ENCRYPT_MODE, secretKey, ivspec);
//	        return Base64.getEncoder().encodeToString(cipher.doFinal(strToEncrypt.getBytes("UTF-8")));
//	    } 
//	    catch (Exception e) 
//	    {
//	        System.out.println("Error while encrypting: " + e.toString());
//	    }
//	    return null;
//	}	
//	
	
	
	private static final String key = "YxjDEpOqxMSHJoXW";
	private static final String initVector = "encryptionIntVec";
	 

    private static final String ENCRYPT_ALGO = "AES/GCM/NoPadding";
    private static final int TAG_LENGTH_BIT = 128;
    private static final int IV_LENGTH_BYTE = 12;
    private static final int AES_KEY_BIT = 256;	
	   public static byte[] encrypt2(byte[] pText, SecretKey secret, byte[] iv) throws Exception {

	        Cipher cipher = Cipher.getInstance(ENCRYPT_ALGO);
	        cipher.init(Cipher.ENCRYPT_MODE, secret, new GCMParameterSpec(TAG_LENGTH_BIT, iv));
	        byte[] encryptedText = cipher.doFinal(pText);
	        return encryptedText;

	    }
	   
	   public static	 byte[] generateSalt() {
		    SecureRandom random = new SecureRandom();
		    byte saltBytes[] = new byte[16];
		    random.nextBytes(saltBytes);
		    return saltBytes;
		}


	   
	
	
	
	
	public static String encrypt(String value ,	String secret) {
	    try {
	    	 byte[] ivs = {83, 71, 26, 58, 54, 35, 22, 11,
	                    83, 71, 26, 58, 54, 35, 22, 11 };		 
//	    	 KeyGenerator keyGenerator = KeyGenerator.getInstance("AES");
//	         keyGenerator.init(128);

	         // Generate Key
	    	 SecretKey skeySpec = new SecretKeySpec(secret.getBytes("UTF-8"), 0, 32, "AES");
	     //    SecretKeySpec skeySpec = new SecretKeySpec(secret.getBytes("UTF-8"), "AES");
	    	 //Get Cipher Instance
	        Cipher cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
	        
	        //Create SecretKeySpec
//	        SecretKeySpec keySpec = new SecretKeySpec(skeySpec.getEncoded(), "AES");
	        SecretKey keySpec = new SecretKeySpec(skeySpec.getEncoded(), 0, skeySpec.getEncoded().length, "AES");
	
	        //Create IvParameterSpec
	        IvParameterSpec ivSpec = new IvParameterSpec(ivs);
	        
	        //Initialize Cipher for ENCRYPT_MODE
	        cipher.init(Cipher.ENCRYPT_MODE, keySpec, ivSpec);
	        
	        //Perform Encryption
//	        byte[] cipherText = cipher.doFinal(plaintext);
//	        
//	        return cipherText;
	        
	        return Base64.getEncoder().encodeToString(cipher.doFinal(value.getBytes("UTF-8")));
	        
	    } catch (Exception ex) {
	        ex.printStackTrace();
	    }
	    return null;
	}	
	
//	public final static String ENCRYPTIONKEY="YxjDEpOqxMSHJoXW";
//    private final static String KEY_2="a675f7c1-0a8a-4b7d-b0fd-f3b04726";
//Ae86Ls5iwTrPOm1w6PL2Cg==
    private final static String characterEncoding ="UTF-8";
    private final static String cipherTransformation ="AES/CBC/PKCS5Padding";
    private final static String aesEncryptionAlgorithm ="AES";
    public static String encrypt2(String plainText,String secret) {
        try{	
        	 byte[] ivs = {83, 71, 26, 58, 54, 35, 22, 11,
	                    83, 71, 26, 58, 54, 35, 22, 11 };
            System.out.print("ivs--------------  "+ivs.toString() +new String(ivs) );	 		 
        	String ENCRYPTIONKEY="YxOqxMSHJoXW";
            String KEY_2="a675f7c1-0a8a-4b7d-b0fd-f3b04726";
            byte[] plaintextBytes = plainText.getBytes(characterEncoding);
            byte[] keyBytes = getKeyBytes(ENCRYPTIONKEY);
            byte[] ivBytes = ivs; //getKeyBytes(ENCRYPTIONKEY );
//             FOR HEX RESULT
            byte[] ba = encrypt(plaintextBytes,keyBytes,ivBytes);
            return  Base64.getEncoder().encodeToString(ba);
//            return URLEncoder.encode(base64encoded,characterEncoding);

//             FOR BASE64 string
//            String base64encoded =Base64.encodeBase64String(encrypt(plaintextBytes,keyBytes,ivBytes));
//            return base64encoded;
        }
        catch(Exception ex){
            ex.printStackTrace();
        }
        return null;
    }
    
    
    public static String encrypt3(String plainText,String secret) {
        try{
        	
        	 byte[] ivs = {83, 71, 26, 58, 54, 35, 22, 11,
	                    83, 71, 26, 58, 54, 35, 22, 11 };
        	 
        		String ENCRYPTIONKEY="YxjDEpOqxMSHJoXW";
                String KEY_2="a675f7c1-0a8a-4b7d-b0fd-f3b04726";
                
                Rfc2898DeriveBytes keyGenerator = null;
              
                keyGenerator = new Rfc2898DeriveBytes(ENCRYPTIONKEY.getBytes(), ivs	, 1000);
        	 SecretKeyFactory factory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA1");
        	 PBEKeySpec pbeKeySpec = new PBEKeySpec(ENCRYPTIONKEY.toCharArray(), ivs, 1000, 384);
        	 Key secretKey = factory.generateSecret(pbeKeySpec);
        	 byte[] key = new byte[32];
        	 byte[] iv = new byte[16];
        	 System.arraycopy(secretKey.getEncoded(), 0, key, 0, 32);
        	 System.arraycopy(secretKey.getEncoded(), 32, iv, 0, 16);
        	 
        	 
           
            byte[] plaintextBytes = plainText.getBytes(characterEncoding);
            byte[] keyBytes = getKeyBytes(ENCRYPTIONKEY);
            byte[] ivBytes = ivs; //getKeyBytes(ENCRYPTIONKEY );
//             FOR HEX RESULT
            byte[] ba = encrypt(plaintextBytes,keyGenerator.getBytes(32),keyGenerator.getBytes(16));
            return  Base64.getEncoder().encodeToString(ba);
//            return URLEncoder.encode(base64encoded,characterEncoding);

//             FOR BASE64 string
//            String base64encoded =Base64.encodeBase64String(encrypt(plaintextBytes,keyBytes,ivBytes));
//            return base64encoded;
        }
        catch(Exception ex){
            ex.printStackTrace();
        }
        return null;
    }
    
    
    
    
	   private static byte[] encrypt(byte[] plainTextBytes, byte[] keyBytes, byte[] initialVector) throws Exception{
	        try {
	            Cipher cipher = Cipher.getInstance(cipherTransformation);
	            SecretKeySpec secretKeySpec = new SecretKeySpec(keyBytes,aesEncryptionAlgorithm);
	            IvParameterSpec ivParameterSpec = new IvParameterSpec(initialVector);
	            cipher.init(Cipher.ENCRYPT_MODE,secretKeySpec,ivParameterSpec);
	            byte[] plainText = cipher.doFinal(plainTextBytes);
	            
	            // FOR BASE64 string
	            //String base64encoded =Base64.encodeBase64String(encrypt(plaintextBytes,keyBytes,ivBytes));
	           // return base64encoded;
	            return plainText;
	        }
	        catch (Exception ex){
	            ex.printStackTrace();
	        }
	        return null;
	    }
	   
	   private static byte[] getKeyBytes(String key) throws Exception{
	        try{
	            byte [] keyBytes= new byte[key.length()];
	            byte [] parameterKeyBytes= key.getBytes(characterEncoding);
	            System.arraycopy(parameterKeyBytes, 0 , keyBytes, 0, Math.min(parameterKeyBytes.length, keyBytes.length));
	            return keyBytes;

	        }
	        catch(Exception ex){
	            ex.printStackTrace();
	        }
	        return null;
	    }
}