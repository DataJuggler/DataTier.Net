

#region using statements

using System;
using System.Text;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;
using System.Linq;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Net.Cryptography.Objects;

#endregion

namespace DataJuggler.Net.Cryptography
{

    #region class CryptographyHelper
    /// <summary>
    /// This object hands all encryption for this application.
    /// </summary>
    public class CryptographyHelper
	{

        #region Private Variables
        // We can use a fixed pepper for the PBKDF2 salt.
        private static byte[] _pepper = new byte[] { 0x04, 0xC5, 0x02, 0xF8, 0xD3, 0xD4, 0x23, 0xB9 };
        public const string DefaultPassword = "NotASecret";
        #endregion
	
	    #region Methods

            #region CreateSalt()
            /// <summary>
            /// This method creates a byte array to use
            /// </summary>
            /// <returns></returns>
            private static byte[] CreateSalt()
            {
                // initial value
                byte[] buffer = null;

                // Create a strong random number generator
                using (var rng = new RNGCryptoServiceProvider())
                {
                    buffer = new byte[16];
                    rng.GetBytes(buffer);
                }
                
                // return value
                return buffer;
            }
            #endregion

            #region DecryptString(string  stringToDecrypt, string password)
            /// <summary>
			/// Decrypts a string passed in.
			/// </summary>
			/// <param customerName="stringToDecrypt">String that needs to be deciphered.</param>
			/// <param customerName="ProductPassword">Code to unlock this productPassword.</param>
			/// <returns></returns>
            public static string DecryptString(string stringToDecrypt, string password)
			{
                // initial value
                string decryptedValue = "";

                try
                {
                    // if both strings exist
                    if (TextHelper.Exists(stringToDecrypt, password))
                    {
                        var ivAndCiphertext = Convert.FromBase64String(stringToDecrypt);
                        if (ivAndCiphertext.Length >= 16)
                        {
                            var iv = new byte[16];
                            var ciphertext = new byte[ivAndCiphertext.Length - 16];
                            Array.Copy(ivAndCiphertext, 0, iv, 0, iv.Length);
                            Array.Copy(ivAndCiphertext, iv.Length, ciphertext, 0, ciphertext.Length);

                            using (var aes = AesManaged.Create())
                            using (var pbkdf2 = new Rfc2898DeriveBytes(password, _pepper, 32767))
                            {
                                var key = pbkdf2.GetBytes(32);

                                aes.Mode = CipherMode.CBC;
                                aes.Padding = PaddingMode.PKCS7;
                                aes.Key = key;
                                aes.IV = iv;

                                // create a new Decryptor                            
                                using (var aesTransformer = aes.CreateDecryptor())
                                {
                                    // get a byte array of the plain text
                                    var plaintext = aesTransformer.TransformFinalBlock(ciphertext, 0, ciphertext.Length);

                                    // set the return value
                                    decryptedValue = Encoding.UTF8.GetString(plaintext);
                                }
                            }
                        }
                    }
                }
                catch
                {
                }

                // return value
                return decryptedValue;
            }
            #endregion

            #region DecryptString(string stringToDecrypt)
            /// <summary>
            /// This method decrypts a string using the default password.
            /// </summary>
            /// <param name="stringToDecrypt"></param>
            /// <returns></returns>
            public static string DecryptString(string stringToDecrypt)
            {
                // return value
                return DecryptString(stringToDecrypt, DefaultPassword);
            }
            #endregion

            #region EncryptString(string  stringToEncrypt, string password)
            /// <summary>
			/// Encrypts a strings passed in using CBC mode and a moderately decent KDF.  Does not provide integrity.
            /// This method will return a different value every time called, yet will still decrypt correctly.
			/// </summary>
			/// <param customerName="stringToEncrypt">String to encrypt</param>
			/// <param customerName="productPassword">productPassword needed to unlock encrypted string</param>
			/// <returns>A new string that must have the same productPassword passed in to unlock.</returns>
            public static string EncryptString(string stringToEncrypt, string password)
			{
                // initial value
                string encryptedString = "";

                try
                {
                    // if both strings exist
                    if (TextHelper.Exists(stringToEncrypt, password))
                    {
                        // Remember to dispose of types that implement IDisposable - this old code had lots of memory leaks.
                        using (var aes = AesManaged.Create())
                        using (var pbkdf2 = new Rfc2898DeriveBytes(password, _pepper, 32767)) // MD5 is insecure as KDF, we use PBKDF2 instead.
                        using (var rng = new RNGCryptoServiceProvider())
                        {
                            var key = pbkdf2.GetBytes(32); // Let's use AES-256.
                            var iv = new byte[16];
                            rng.GetBytes(iv); // We always create a new, random IV for each operation.

                            var plaintext = Encoding.UTF8.GetBytes(stringToEncrypt); // We use UTF8

                            aes.Mode = CipherMode.CBC;
                            aes.Padding = PaddingMode.PKCS7;
                            aes.Key = key;
                            aes.IV = iv;

                            using (var aesTransformer = aes.CreateEncryptor())
                            {
                                var ciphertext = aesTransformer.TransformFinalBlock(plaintext, 0, plaintext.Length);
                                var ivAndCiphertext = new byte[iv.Length + ciphertext.Length];
                                Array.Copy(iv, 0, ivAndCiphertext, 0, iv.Length);
                                Array.Copy(ciphertext, 0, ivAndCiphertext, iv.Length, ciphertext.Length);
                                encryptedString = Convert.ToBase64String(ivAndCiphertext);
                            }
                        }
                    }
                }
                catch
                {
                }

                // return value
                return encryptedString;
			}
			#endregion

            #region EncryptString(string stringToEncrypt)
            /// <summary>
            /// Override that uses default password
            /// </summary>
            /// <param name="stringToEncrypt"></param>
            /// <returns></returns>
            public static string EncryptString(string stringToEncrypt)
            {
                return EncryptString(stringToEncrypt, DefaultPassword);
            }
            #endregion

            #region GeneratePasswordHash(string password, int verifyRetries = 0)
            /// <summary>
            /// This method hashes the password using Konscious.Security.Cryptography's implementation of Argon2.
            /// The salt is returned with the password separated by 4 | (pipe characters I think is the name).
            /// You can decrypt from the encrypted password hash to determine the passwordhash and salt, but you cannot decrypt from 
            /// password hash back to the password.
            /// This method uses the default password, which is NotASecret.
            /// </summary>
            /// <param name="password">The password to create a hash for</param>
            /// <param name="verifyRetries">If verify retries is above 0, this method will attempt to verify
            /// the generated password hash with the same credentials. If it can't be verified, it will retry
            /// up until this value for retries count. The value must be between 0 and 3. After 3 it fails.</param>
            /// <returns></returns>
            public static string GeneratePasswordHash(string password, int verifyRetries = 0)
            {
                // call the override
                return GeneratePasswordHash(password, DefaultPassword, verifyRetries);
            }
            #endregion

            #region GeneratePasswordHash(string password, string keyCode, int verifyRetries = 0)
            /// <summary>
            /// This method hashes the password using Konscious.Security.Cryptography's implementation of Argon2.
            /// The salt is returned with the password separated by 4 | (pipe characters I think is the name).
            /// You can decrypt from the encrypted password hash to determine the passwordhash and salt, but you cannot decrypt from 
            /// password hash back to the password.
            /// </summary>
            /// <param name="password">The password to create a hash for</param>
            /// <param name="keyCode">A keycode string you create that is used to encrypt/decrypt the password hash 
            /// after it is created. You can decrypt from the encrypted password hash to determine the passwordhash and salt, but you cannot decrypt from 
            /// password hash back to the password.
            /// </param>
            /// <param name="verifyRetries">If verify retries is above 0, this method will attempt to verify
            /// the generated password hash with the same credentials. If it can't be verified, it will retry
            /// up until this value for retries count. The value must be between 0 and 3. After 3 it fails.</param>
            /// <returns></returns>
            public static string GeneratePasswordHash(string password, string keyCode, int verifyRetries = 0)
            {
                // get the passwordHash
                string passwordHash = null;

                // local
                bool verified = false;
                
                // if the password exists
                if (TextHelper.Exists(password, keyCode))
                {
                    // get the passwordHash
                    passwordHash = HashPart1(password, keyCode);

                    // it will only try up to 3 times, then it bails
                    if ((verifyRetries > 0) && (verifyRetries <= 3))
                    {
                        // try up to 3 times if verifyRetries is set to 3
                        for (int x = 0; x < verifyRetries; x++)
                        {
                            // if all 3 strings exist
                            if (TextHelper.Exists(password, password, keyCode))
                            {
                                // does 
                                verified = VerifyHash(password, keyCode, passwordHash);
                            }

                            // if the value for verified is true
                            if (verified)
                            {
                                // break out of the loop
                                break;
                            }

                            // get the passwordHash (again)
                            passwordHash = HashPart1(password, keyCode);
                        }

                        // if not veriified
                        if (!verified)
                        {
                            // password hash could not be created
                            passwordHash = "";
                        }
                    }
                }

                // return value
                return passwordHash;
            }
            #endregion

            #region HashPart1(string password, string keyCode)
            /// <summary>
            /// This method is used to call some portions of the GeneratePasswordHash
            /// multiple times.
            /// </summary>
            /// <param name="part1"></param>
            /// <param name="keyCode"></param>
            /// <returns></returns>
            private static string HashPart1(string password, string keyCode)
            {
                // initial value
                string part1 = "";

                try
                {
                     // Update 1.0.9 create the salt every time as the salt might be the problem (?)
                     byte[] salt = CreateSalt();

                    // get the byte array
                    byte[] passwordBits = HashPassword(password, salt);

                    // create the hashInfo
                    PasswordHashInfo hashInfo = new PasswordHashInfo(passwordBits, salt);

                    // get the hashInfo
                    string partI = hashInfo.ToString();

                    // set the return value
                    part1 = EncryptString(partI, keyCode);
                }
                catch (Exception error)
                {
                    // for debugging only for now, I may return a response one day
                    DebugHelper.WriteDebugError("HashPart1", "CryptographyHelper", error);

                    // explicit set to null
                    part1 = "";
                }

                // return value
                return part1;
            }
            #endregion

            #region HashPassword(string password, byte[] salt)
            /// <summary>
            /// Hash this password
            /// </summary>
            /// <param name="password"></param>
            /// <param name="keyCode"></param>
            /// <param name="salt"></param>
            /// <returns></returns>
            private static byte[] HashPassword(string password, byte[] salt)
            {
                // initial value
                byte[] hash = null;
                    
                // if all 3 strings exist
                if (TextHelper.Exists(password))
                {
                    // Create a new instance of an 'Argon2id' object.
                    var argon2 = new Argon2id(Encoding.Unicode.GetBytes(password));

                    argon2.Salt = salt;
                    argon2.DegreeOfParallelism = 8; // four cores
                    argon2.Iterations = 2;
                    argon2.MemorySize = 1024 * 1024; // 1 GB

                    // get the hash
                    hash = argon2.GetBytes(16);
                }

                // return value
                return hash;
            }
            #endregion

            #region VerifyHash(string userTypedPassword, string storedPasswordHash)
            /// <summary>
            /// This method is used to verify the Hash created is the same as a hash stored in the database.
            /// This method uses the default password, which is NotASecret. If you stored the password with a keycode
            /// you must use that keycode to decrypt and if you used the default value to encrypt you must use the default
            /// password to decrypt.
            /// </summary>
            /// <param name="userTypedPassword">The password typed in by a user for a login attempt.</param>
            /// <param name="storedPasswordHash">The password hash that is stored with the salt.</param>
            /// <returns></returns>
            public static bool VerifyHash(string userTypedPassword, string storedPasswordHash)
            {
                return VerifyHash(userTypedPassword, DefaultPassword, storedPasswordHash);
            }
            #endregion

            #region VerifyHash(string userTypedPassword, string keyCode, string storedPasswordHash)
            /// <summary>
            /// This method is used to verify the Hash created is the same as a hash stored in the database.
            /// </summary>
            /// <param name="password"></param>
            /// <param name="keyCode"></param>
            /// <param name="salt"></param>
            /// <returns></returns>
            public static bool VerifyHash(string userTypedPassword, string keyCode, string storedPasswordHash)
            {
                // initial value
                bool verified = false;

                try
                {
                    // locals
                    // get the password up until the separator
                    string password = "";
                    string salty = "";
                    byte[] salt = null;
                    byte[] storedHash = null;

                    // if all the parameters exist
                    if (TextHelper.Exists(userTypedPassword, keyCode, storedPasswordHash))
                    {
                        // we must first decrypt the storedPasswordHash with the keycode
                        string decryptedHash = DecryptString(storedPasswordHash, keyCode);

                        // if the decryptedHash exists
                        if (TextHelper.Exists(decryptedHash))
                        {
                            // get the index of the 4 pipe characters
                            int index = decryptedHash.IndexOf("||||");

                            // if the index was found
                            if (index >= 0)
                            {
                                // get the password
                                password = decryptedHash.Substring(0, index);
                                salty = decryptedHash.Substring(index + 4);
                                salt = Encoding.Unicode.GetBytes(salty);
                                storedHash = Encoding.Unicode.GetBytes(password);
                            }

                            // now verify with the override
                            verified = VerifyHash(userTypedPassword, salt, storedHash);
                        }
                    }
                }
                catch 
                {
                    
                }

                // return value
                return verified;
            }
            #endregion

            #region VerifyHash(string password, byte[] salt, byte[] storedHash)
            /// <summary>
            /// This method is used to verify the Hash created is the same as the 
            /// </summary>
            /// <param name="password"></param>
            /// <param name="keyCode"></param>
            /// <param name="salt"></param>
            /// <param name="newHash"></param>
            /// <returns></returns>
            public static bool VerifyHash(string password, byte[] salt, byte[] storedHash)
            {
                // initial value
                bool verified = false;

                // if all the parameters exist
                if (TextHelper.Exists(password) && (salt.Length > 0) && (storedHash.Length > 0))
                {
                    // generate the loginHash again
                    var newHash = HashPassword(password,  salt);

                    // set the return value
                    verified = storedHash.SequenceEqual(newHash);
                }

                // return value
                return verified;
            }
            #endregion

        #endregion

    }
	#endregion

}