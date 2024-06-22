using System.Security.Cryptography;
using System.Text;

namespace Project_1
{
    public class CryptoModule
    {
        // 1. Generate AES key
        public static string GenerateAESKey(int keySize = 256)
        {
            using (var aes = Aes.Create())
            {
                aes.KeySize = keySize;
                aes.GenerateKey();
                return Convert.ToBase64String(aes.Key);
            }
        }

        // 2. Encrypt File Using AES
        public static void EncryptFileAES(string inputFile, string outputFile, string key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.GenerateIV();
                aes.Padding = PaddingMode.PKCS7;

                using (var fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(aes.IV, 0, aes.IV.Length);
                    var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (var csEncrypt = new CryptoStream(fs, encryptor, CryptoStreamMode.Write))
                    {
                        using (var fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[1048576]; // 1MB buffer
                            int read;

                            while ((read = fsInput.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                csEncrypt.Write(buffer, 0, read);
                            }
                        }
                    }
                }
            }
        }

        // 3. Decrypt File Using AES
        public static void DecryptFileAES(string inputFile, string outputFile, string key)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(key);
                aes.Padding = PaddingMode.PKCS7;
                using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
                {
                    byte[] iv = new byte[16];
                    inputFileStream.Read(iv, 0, iv.Length);
                    aes.IV = iv;

                    var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    using (var csDecrypt = new CryptoStream(inputFileStream, decryptor, CryptoStreamMode.Read))
                    using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
                    {
                        byte[] buffer = new byte[1048576]; // 1MB buffer
                        int read;

                        while ((read = csDecrypt.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outputFileStream.Write(buffer, 0, read);
                        }
                    }
                }
            }
        }

        public static void GenerateRSAKeyPair(out string privateKey, out string publicKey)
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
                privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
            }
        }

        public static string EncryptStringRSA(string data, string publicKey)
        {
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);
            byte[] encryptedData;

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);
                encryptedData = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.Pkcs1);
            }

            return Convert.ToBase64String(encryptedData);
        }

        public static string DecryptStringRSA(string data, string privateKey)
        {
            byte[] decryptedData;
            byte[] dataToDecrypt = Convert.FromBase64String(data);

            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);
                decryptedData = rsa.Decrypt(dataToDecrypt, RSAEncryptionPadding.Pkcs1);
            }
            return Encoding.UTF8.GetString(decryptedData);
        }

        public static string HashValue(string input, string algorithm = "SHA-256")
        {
            byte[] dataToHash = Encoding.UTF8.GetBytes(input);
            byte[] hashValue;

            if (algorithm == "SHA-1")
            {
                using (var sha1 = SHA1.Create())
                {
                    hashValue = sha1.ComputeHash(dataToHash);
                }
            }
            else if (algorithm == "SHA-256")
            {
                using (var sha256 = SHA256.Create())
                {
                    hashValue = sha256.ComputeHash(dataToHash);
                }
            }
            else
            {
                MessageBox.Show("Algorithm not supported.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }

            return Convert.ToBase64String(hashValue);
        }
    }
}
