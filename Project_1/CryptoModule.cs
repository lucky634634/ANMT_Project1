using System.Security.Cryptography;
using System.Text;

namespace Project_1
{
    public class CryptoModule
    {
        // 1. Generate AES key
        // This function generates an AES key of a specified keySize
        public static string GenerateAESKey(int keySize = 256)
        {
            // Using block ensures proper disposal of AES object
            using (var aes = Aes.Create())
            {
                // Set the key size to the specified keySize
                aes.KeySize = keySize;

                // Generate a new random key
                aes.GenerateKey();

                // Convert the generated key to a base64 string before returning
                return Convert.ToBase64String(aes.Key);
            }
        }

        // 2. Encrypt File Using AES
        // This method takes an input file, output file, and a key to encrypt the input file using AES encryption algorithm
        public static void EncryptFileAES(string inputFile, string outputFile, string key)
        {
            // Creating a new instance of AES encryption algorithm
            using (var aes = Aes.Create())
            {
                // Setting the key for the AES algorithm from the base64 encoded key provided
                aes.Key = Convert.FromBase64String(key);

                // Generating a new Initialization Vector (IV) for the AES algorithm
                aes.GenerateIV();

                // Setting the padding mode for the AES algorithm
                aes.Padding = PaddingMode.PKCS7;

                // Using a FileStream to write the encrypted data to the output file
                using (var fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                {
                    // Writing the IV to the beginning of the output file
                    fs.Write(aes.IV, 0, aes.IV.Length);

                    // Creating an encryptor using the AES key and IV
                    var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    // Using a CryptoStream to perform the encryption
                    using (var csEncrypt = new CryptoStream(fs, encryptor, CryptoStreamMode.Write))
                    {
                        // Using a FileStream to read the input file
                        using (var fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                        {
                            byte[] buffer = new byte[1048576]; // Using a 1MB buffer
                            int read;

                            // Reading from the input file and writing the encrypted data to the output file
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
        // DecryptFileAES method decrypts a file using AES encryption algorithm
        public static void DecryptFileAES(string inputFile, string outputFile, string key)
        {
            // Creating a new instance of AES encryption algorithm
            using (var aes = Aes.Create())
            {
                // Setting the key for the AES algorithm from the base64 encoded key provided
                aes.Key = Convert.FromBase64String(key);
                aes.Padding = PaddingMode.PKCS7;

                // Opening the input encrypted file for reading
                using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
                {
                    // Reading the Initialization Vector (IV) from the beginning of the input file
                    byte[] iv = new byte[16];
                    inputFileStream.Read(iv, 0, iv.Length);
                    aes.IV = iv;

                    // Creating a decryptor to perform the decryption
                    var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    // Using a CryptoStream to decrypt the input file data
                    using (var csDecrypt = new CryptoStream(inputFileStream, decryptor, CryptoStreamMode.Read))
                    // Opening the output file for writing the decrypted data
                    using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
                    {
                        byte[] buffer = new byte[1048576]; // 1MB buffer
                        int read;

                        // Reading and decrypting the input file data in chunks
                        while ((read = csDecrypt.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            // Writing the decrypted data to the output file
                            outputFileStream.Write(buffer, 0, read);
                        }
                    }
                }
            }
        }

        // This method generates an RSA key pair consisting of a public and private key
        public static void GenerateRSAKeyPair(out string privateKey, out string publicKey)
        {
            // Using block to ensure proper disposal of the RSACryptoServiceProvider object
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                // Exporting the RSA public key and converting it to a base64 string
                publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());

                // Exporting the RSA private key and converting it to a base64 string
                privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
            }
        }

        // This method takes a string data and a public key, encrypts the data using RSA encryption with PKCS1 padding, and returns the encrypted data as a base64 string
        public static string EncryptStringRSA(string data, string publicKey)
        {
            // Convert the input string data to bytes using UTF-8 encoding
            byte[] dataToEncrypt = Encoding.UTF8.GetBytes(data);

            // Declare an array to store the encrypted data
            byte[] encryptedData;

            // Create a new instance of RSACryptoServiceProvider
            using (var rsa = new RSACryptoServiceProvider())
            {
                // Import the RSA public key from the base64 encoded publicKey parameter
                rsa.ImportRSAPublicKey(Convert.FromBase64String(publicKey), out _);

                // Encrypt the data using the RSA instance with PKCS1 padding
                encryptedData = rsa.Encrypt(dataToEncrypt, RSAEncryptionPadding.Pkcs1);
            }

            // Convert the encrypted data to a base64 string before returning
            return Convert.ToBase64String(encryptedData);
        }

        // This function decrypts a string using RSA encryption algorithm
        public static string DecryptStringRSA(string data, string privateKey)
        {
            // Initialize variables to hold decrypted data and data to decrypt
            byte[] decryptedData;
            byte[] dataToDecrypt = Convert.FromBase64String(data);

            // Create a new instance of RSACryptoServiceProvider
            using (var rsa = new RSACryptoServiceProvider())
            {
                // Import the RSA private key
                rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);

                // Decrypt the data using RSA encryption with PKCS1 padding
                decryptedData = rsa.Decrypt(dataToDecrypt, RSAEncryptionPadding.Pkcs1);
            }

            // Return the decrypted data as a UTF-8 encoded string
            return Encoding.UTF8.GetString(decryptedData);
        }

        // This method calculates the hash value of the input string using the specified algorithm.
        // It takes an input string and an optional algorithm parameter (default is "SHA-1").
        // It returns the base64 encoded hash value of the input string.

        public static string HashValue(string input, string algorithm = "SHA-1")
        {
            // Convert the input string to a byte array using UTF-8 encoding
            byte[] dataToHash = Encoding.UTF8.GetBytes(input);
            byte[] hashValue;

            // Check the algorithm parameter to determine the hash algorithm to use
            if (algorithm == "SHA-1")
            {
                // Using SHA-1 hashing algorithm to compute the hash value
                using (var sha1 = SHA1.Create())
                {
                    hashValue = sha1.ComputeHash(dataToHash);
                }
            }
            else if (algorithm == "SHA-256")
            {
                // Using SHA-256 hashing algorithm to compute the hash value
                using (var sha256 = SHA256.Create())
                {
                    hashValue = sha256.ComputeHash(dataToHash);
                }
            }
            else
            {
                // Throw an exception if the specified algorithm is not supported
                throw new ArgumentException("The specified algorithm is not supported.");
            }

            // Convert the hash value byte array to a base64 encoded string before returning
            return Convert.ToBase64String(hashValue);
        }
    }
}
