using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace KryptoNite
{
    /// <summary>
    /// Provides the standard 4 types of symmetric encryption
    /// methods supported by the .net framework.
    /// </summary>
    public enum EncryptionType
    {
        /// <summary>
        /// Data Encryption Standard algorithm, created in 1977.
        /// The standard encryption strength of DES is 56bit. The
        /// algorithm has been cracked using 100,00 PCs (combined power via the
        /// internet) in 22 hours 15 minutes!
        /// A detailed explanation can be found at:
        /// http://www.tropsoft.com/strongenc/des.htm
        /// </summary>
        DES,
        /// <summary>
        /// RC2 was created by RSA as a proposed replacement for
        /// the DES encryption standard. Its strength is 64bit
        /// (64bit block sizes). The RFC for the standard can 
        /// be found at: 
        /// http://www.networksorcery.com/enp/rfc/rfc2268.txt
        /// </summary>
        RC2,
        /// <summary>
        /// Rijndael is the encryption algorithm used for 
        /// the Advanced Encryption Standard (AES), the standard
        /// symmetric encryption method used by US Government organisations.
        /// The block size can be 128, 192, or 256 bits.
        /// Further information can be found at:
        /// http://csrc.nist.gov/CryptoToolkit/aes/rijndael/
        /// </summary>
        Rijndael,
        /// <summary>
        /// Triple DES is a more powerful form of the original DES standard,
        /// encrypting data using 364bit keys, giving Triple DES a strength
        /// of 192bits. The data is encrypted with the first key, 
        /// decrypted with the second key, and finally encrypted again with 
        /// the third key.
        /// A detailed explaination of the algorithm can be found at:
        /// http://www.tropsoft.com/strongenc/des3.htm
        /// </summary>
        TripleDES

        //RC4
    }


    /// <summary>
    /// SymmetricEncryption is a wrapper of System.Security.Cryptography.SymmetricAlgorithm 
    /// classes and simplifies the interface. Symmetric encryption involves a private
    /// key to encrypt the data, which enables the data to be de-crypted by other
    /// clients, providing they have the private key.
    /// 
    /// This class is based on Frank Fang's 'SymmCrypto' class, found at: 
    /// http://www.codeproject.com/dotnet/encryption_decryption.asp
    /// </summary>
    public class SymmetricEncryption
    {
        private string _initialIV = "1Ef24g6jK8se3G0e";
        private SymmetricAlgorithm _symmetricAlgorithm;

        public string InitialIV
        {
            get
            {
                return _initialIV;
            }
            set
            {
                _initialIV = value;
            }
        }

        /// <summary>
        /// Creates a new SymmetricEncryption class with the EncryptionType provided.
        /// </summary>
        /// <param name="Type">The type of symmetric encryption to use.</param>
        public SymmetricEncryption(EncryptionType Type)
        {
            switch (Type)
            {
                case EncryptionType.DES:
                    _symmetricAlgorithm = new DESCryptoServiceProvider();
                    break;
                case EncryptionType.RC2:
                    _symmetricAlgorithm = new RC2CryptoServiceProvider();
                    break;
                case EncryptionType.Rijndael:
                    _symmetricAlgorithm = new RijndaelManaged();
                    break;
                case EncryptionType.TripleDES:
                    _symmetricAlgorithm = new TripleDESCryptoServiceProvider();
                    break;
            }
        }

        /// <summary>
        /// Creates a new SymmetricEncryption class with the SymmetricAlgorithm
        /// provided (which could include an implementation of an algorithm
        /// not provided in the standard .net fcl).
        /// </summary>
        /// <param name="ServiceProvider">A</param>
        public SymmetricEncryption(SymmetricAlgorithm ServiceProvider)
        {
            _symmetricAlgorithm = ServiceProvider;
        }

        /// <summary>
        /// Encrypts data using the key provided, and the algorithm
        /// specified in the constructor of the class.
        /// </summary>
        /// <param name="contents">The data to encrypt.</param>
        /// <param name="key">The key to encrypt the data with. The longer
        /// and more random the key, the stronger the encryption is.</param>
        /// <returns>A string containing the contents, encrypted using the
        /// key and the algorithm specified in the constructor of the class.</returns>
        public string Encrypt(string contents, string key)
        {
            // Change to Unicode if you're using a wide character set
            byte[] buffer = Encoding.UTF8.GetBytes(contents);

            // Create a MemoryStream so that the process can be done without I/O files
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Set the private key
                _symmetricAlgorithm.Key = GetLegalKey(key);
                _symmetricAlgorithm.IV = GetLegalIV();

                // Create an Encryptor from the Provider Service instance
                using (ICryptoTransform transform = _symmetricAlgorithm.CreateEncryptor())
                {
                    // Create Crypto Stream that transforms a stream using the encryption
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
                    {
                        // write out encrypted content into MemoryStream
                        cryptoStream.Write(buffer, 0, buffer.Length);
                        cryptoStream.FlushFinalBlock();

                        memoryStream.Close();
                        byte[] result = memoryStream.ToArray();

                        // Convert into Base64 so that the result is XML or web safe
                        return Convert.ToBase64String(result);
                    }
                }
            }
        }

        /// <summary>
        /// Decrypts data using the key provided, and the algorithm
        /// specified in the constructor of the class.
        /// </summary>
        /// <param name="contents">The data to decrypt.</param>
        /// <param name="key">The key to decrypt the data with.</param>
        /// <returns>A string containing the contents, decrypted using the
        /// key and the algorithm specified in the constructor of the class.</returns>
        public string Decrypt(string contents, string key)
        {
            try
            {
                // Convert from Base64 to binary
                byte[] buffer = Convert.FromBase64String(contents);

                // Create a MemoryStream with the input
                using (MemoryStream memorystream = new MemoryStream(buffer, 0, buffer.Length))
                {
                    // Set the private key
                    _symmetricAlgorithm.Key = GetLegalKey(key);
                    _symmetricAlgorithm.IV = GetLegalIV();

                    // Create a Decryptor from the Provider Service instance
                    using (ICryptoTransform transform = _symmetricAlgorithm.CreateDecryptor())
                    {
                        // Create Crypto Stream that transforms a stream using the decryption
                        using (CryptoStream cryptoStream = new CryptoStream(memorystream, transform, CryptoStreamMode.Read))
                        {
                            // Read out the result from the Crypto Stream. Change to Unicode if you're using a wide character set
                            using (StreamReader reader = new StreamReader(cryptoStream, Encoding.UTF8))
                            {
                                return reader.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch { }
            return "Failure to decrypt message";
        }

        private byte[] GetLegalKey(string Key)
        {
            string sTemp = Key;
            _symmetricAlgorithm.GenerateKey();
            byte[] bytTemp = _symmetricAlgorithm.Key;
            int KeyLength = bytTemp.Length;

            if (sTemp.Length > KeyLength)
                sTemp = sTemp.Substring(0, KeyLength);
            else if (sTemp.Length < KeyLength)
                sTemp = sTemp.PadRight(KeyLength, ' ');

            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

        private byte[] GetLegalIV()
        {
            // The initial string of IV may be modified with any data you like
            string sTemp = _initialIV;
            _symmetricAlgorithm.GenerateIV();
            byte[] bytTemp = _symmetricAlgorithm.IV;
            int IVLength = bytTemp.Length;

            if (sTemp.Length > IVLength)
                sTemp = sTemp.Substring(0, IVLength);
            else if (sTemp.Length < IVLength)
                sTemp = sTemp.PadRight(IVLength, ' ');

            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }
    }

    /// <summary>
    /// This class uses a symmetric key algorithm (Rijndael/AES) to encrypt and 
    /// decrypt data. As long as encryption and decryption routines use the same
    /// parameters to generate the keys, the keys are guaranteed to be the same.
    /// The class uses static functions with duplicate code to make it easier to
    /// demonstrate encryption and decryption logic. In a real-life application, 
    /// this may not be the most efficient way of handling encryption, so - as
    /// soon as you feel comfortable with it - you may want to redesign this class.
    /// </summary>
    public class KryptoMemory
    {
        /// <summary>
        /// Encrypts specified plaintext using Rijndael symmetric key algorithm
        /// and returns a base64-encoded result.
        /// </summary>
        /// <param name="plainText">
        /// Plaintext value to be encrypted.
        /// </param>
        /// <param name="passPhrase">
        /// Passphrase from which a pseudo-random password will be derived. The
        /// derived password will be used to generate the encryption key.
        /// Passphrase can be any string. In this example we assume that this
        /// passphrase is an ASCII string.
        /// </param>
        /// <param name="saltValue">
        /// Salt value used along with passphrase to generate password. Salt can
        /// be any string. In this example we assume that salt is an ASCII string.
        /// </param>
        /// <param name="hashAlgorithm">
        /// Hash algorithm used to generate password. Allowed values are: "MD5" and
        /// "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
        /// </param>
        /// <param name="passwordIterations">
        /// Number of iterations used to generate password. One or two iterations
        /// should be enough.
        /// </param>
        /// <param name="initVector">
        /// Initialization vector (or IV). This value is required to encrypt the
        /// first block of plaintext data. For RijndaelManaged class IV must be 
        /// exactly 16 ASCII characters long.
        /// </param>
        /// <param name="keySize">
        /// Size of encryption key in bits. Allowed values are: 128, 192, and 256. 
        /// Longer keys are more secure than shorter keys.
        /// </param>
        /// <returns>
        /// Encrypted value formatted as a base64-encoded string.
        /// </returns>
        public static string Encrypt(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations,
                                     string initVector, int keySize)
        {
            // Convert strings into byte arrays.
            // Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8 
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // Convert our plaintext into a byte array.
            // Let us assume that plaintext contains UTF8-encoded characters.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // First, we must create a password, from which the key will be derived.
            // This password will be generated from the specified passphrase and 
            // salt value. The password will be created using the specified hash 
            // algorithm. Password creation can be done in several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                            passPhrase,
                                                            saltValueBytes,
                                                            hashAlgorithm,
                                                            passwordIterations);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate encryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                             keyBytes,
                                                             initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream();

            // Define cryptographic stream (always use Write mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         encryptor,
                                                         CryptoStreamMode.Write);
            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherTextBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            // Return encrypted string.
            return cipherText;
        }

        /// <summary>
        /// Decrypts specified ciphertext using Rijndael symmetric key algorithm.
        /// </summary>
        /// <param name="cipherText">
        /// Base64-formatted ciphertext value.
        /// </param>
        /// <param name="passPhrase">
        /// Passphrase from which a pseudo-random password will be derived. The
        /// derived password will be used to generate the encryption key.
        /// Passphrase can be any string. In this example we assume that this
        /// passphrase is an ASCII string.
        /// </param>
        /// <param name="saltValue">
        /// Salt value used along with passphrase to generate password. Salt can
        /// be any string. In this example we assume that salt is an ASCII string.
        /// </param>
        /// <param name="hashAlgorithm">
        /// Hash algorithm used to generate password. Allowed values are: "MD5" and
        /// "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
        /// </param>
        /// <param name="passwordIterations">
        /// Number of iterations used to generate password. One or two iterations
        /// should be enough.
        /// </param>
        /// <param name="initVector">
        /// Initialization vector (or IV). This value is required to encrypt the
        /// first block of plaintext data. For RijndaelManaged class IV must be
        /// exactly 16 ASCII characters long.
        /// </param>
        /// <param name="keySize">
        /// Size of encryption key in bits. Allowed values are: 128, 192, and 256.
        /// Longer keys are more secure than shorter keys.
        /// </param>
        /// <returns>
        /// Decrypted string value.
        /// </returns>
        /// <remarks>
        /// Most of the logic in this function is similar to the Encrypt
        /// logic. In order for decryption to work, all parameters of this function
        /// - except cipherText value - must match the corresponding parameters of
        /// the Encrypt function which was called to generate the
        /// ciphertext.
        /// </remarks>
        public static string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations,
                                     string initVector, int keySize)
        {
            string plainText = "Failure to Decrypt text.";
            try
            {
                // Convert strings defining encryption key characteristics into byte
                // arrays. Let us assume that strings only contain ASCII codes.
                // If strings include Unicode characters, use Unicode, UTF7, or UTF8
                // encoding.
                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

                // Convert our ciphertext into a byte array.
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                // First, we must create a password, from which the key will be 
                // derived. This password will be generated from the specified 
                // passphrase and salt value. The password will be created using
                // the specified hash algorithm. Password creation can be done in
                // several iterations.
                PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                                passPhrase,
                                                                saltValueBytes,
                                                                hashAlgorithm,
                                                                passwordIterations);

                // Use the password to generate pseudo-random bytes for the encryption
                // key. Specify the size of the key in bytes (instead of bits).
                byte[] keyBytes = password.GetBytes(keySize / 8);

                // Create uninitialized Rijndael encryption object.
                RijndaelManaged symmetricKey = new RijndaelManaged();

                // It is reasonable to set encryption mode to Cipher Block Chaining
                // (CBC). Use default options for other symmetric key parameters.
                symmetricKey.Mode = CipherMode.CBC;

                // Generate decryptor from the existing key bytes and initialization 
                // vector. Key size will be defined based on the number of the key 
                // bytes.
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                                 keyBytes,
                                                                 initVectorBytes);

                // Define memory stream which will be used to hold encrypted data.
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);

                // Define cryptographic stream (always use Read mode for encryption).
                CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                              decryptor,
                                                              CryptoStreamMode.Read);

                // Since at this point we don't know what the size of decrypted data
                // will be, allocate the buffer long enough to hold ciphertext;
                // plaintext is never longer than ciphertext.
                byte[] plainTextBytes = new byte[cipherTextBytes.Length];

                // Start decrypting.
                int decryptedByteCount = cryptoStream.Read(plainTextBytes,
                                                           0,
                                                           plainTextBytes.Length);

                // Close both streams.
                memoryStream.Close();
                cryptoStream.Close();

                // Convert decrypted data into a string. 
                // Let us assume that the original plaintext string was UTF8-encoded.
                plainText = Encoding.UTF8.GetString(plainTextBytes,
                                                           0,
                                                           decryptedByteCount);
            }
            catch { }

            // Return decrypted string.   
            return plainText;
        }
    }
}