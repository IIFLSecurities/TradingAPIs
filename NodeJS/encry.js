const crypto = require("crypto");
const { credentials, urls } = require("./config");

class EncryptionClient {
  constructor() {
    this.iv = Buffer.from([
      83, 71, 26, 58, 54, 35, 22, 11, 83, 71, 26, 58, 54, 35, 22, 11,
    ]);
    this.enc_key = credentials.EncryKey;
  }

  encrypt(text) {
    const keyLen = 256;
    const IVLen = 128;

    try {
      const keyGen = crypto.pbkdf2Sync(
        Buffer.from(this.enc_key),
        Uint8Array.from(this.iv),
        1000,
        keyLen + IVLen,
        "sha1"
      );

      const aesKey = Buffer.allocUnsafe(32);
      const aesIV = Buffer.allocUnsafe(16);

      // you need to limit the buffer copy to 16 for aesIV.
      keyGen.copy(aesIV, 0, 0, 16);
      keyGen.copy(aesKey, 0, 16);
      const cipher = crypto.createCipheriv("aes-256-cbc", aesKey, aesIV);

      let encrypted = cipher.update(text, "utf8", "base64");
      encrypted += cipher.final("base64");
      console.log(encrypted);
      return encrypted;
    } catch (error) {
      console.log(error, "error in encrypt");
    }
  }
}

module.exports = new EncryptionClient();
