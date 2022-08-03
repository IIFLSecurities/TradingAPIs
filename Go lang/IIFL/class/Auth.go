package class

import (
	"bytes"
	"crypto/aes"
	"crypto/cipher"
	"crypto/sha1"
	"encoding/base64"

	"golang.org/x/crypto/pbkdf2"
)

var (
	block cipher.Block
)

// PKCS5Padding : Padding implements the Padding interface Padding method.
func PKCS5Padding(ciphertext []byte, blockSize int) []byte {
	padding := blockSize - len(ciphertext)%blockSize
	padtext := bytes.Repeat([]byte{byte(padding)}, padding)
	return append(ciphertext, padtext...)
}

//Encryption : Encryption function for encoded
func Encryption(text string) string {
	data := []byte(text)
	config := CheckConfig()

	EncryKey := config.EncryKey
	Iv := []byte{83, 71, 26, 58, 54, 35, 22, 11, 83, 71, 26, 58, 54, 35, 22, 11}

	convertKey := pbkdf2.Key([]byte(EncryKey), Iv, 1000, 48, sha1.New)
	aesIv := convertKey[:16]

	aesKey := convertKey[16:]

	paddingData := PKCS5Padding(data, 16)

	block, _ := aes.NewCipher(aesKey)

	cipherData := make([]byte, len(paddingData))
	mode := cipher.NewCBCEncrypter(block, aesIv)
	mode.CryptBlocks(cipherData, paddingData)

	return base64.StdEncoding.EncodeToString(cipherData)
}
