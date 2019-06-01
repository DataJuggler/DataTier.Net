

#region using statements

using System;
using System.Text;
using System.Security.Cryptography;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class CryptographyHelper
    /// <summary>
    /// This object hands all encryption for this application.
    /// </summary>
    public class CryptographyHelper
	{	
	
	    #region Methods

            #region EncryptString(string  stringToEncrypt, string password)
            /// <summary>
			/// Encrypts a strings passed in using Electronic Code Book Cipher
			/// </summary>
			/// <param customerName="stringToEncrypt">String to encrypt</param>
			/// <param customerName="productPassword">productPassword needed to unlock encrypted string</param>
			/// <returns>A new string that must have the same productPassword passed in to unlock.</returns>
            public static string EncryptString(string stringToEncrypt, string password)
			{
			    // Initial Value
			    string encryptedString = null;

                try
                {
                    // Verify String Does Exist
                    if (!String.IsNullOrEmpty(stringToEncrypt))
                    {

                        TripleDESCryptoServiceProvider des;
                        MD5CryptoServiceProvider hashmd5;
                        byte[] pwdhash;
                        byte[] buff;

                        hashmd5 = new MD5CryptoServiceProvider();
                        pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                        hashmd5 = null;

                        //implement DES3 encryption
                        des = new TripleDESCryptoServiceProvider();

                        //the key is the secret productPassword hash.
                        des.Key = pwdhash;

                        // Electronic Code Book Cipher
                        des.Mode = CipherMode.ECB; //CBC, CFB

                        // Set Buffer To StringToEncrypt
                        buff = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt);

                        // Get Encrypted String
                        encryptedString = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));
                    }
                }
                catch
                {   
                }
	            	
				// Return Encrypted String
				return encryptedString;
	            
			}
			#endregion

            #region EncryptString(string stringToEncrypt)
            /// <summary>
            /// Encrypts a strings passed in using Electronic Code Book Cipher
            /// </summary>
            /// <param customerName="stringToEncrypt">String to encrypt</param>
            /// <returns>A new string that must have the same productPassword passed in to unlock.</returns>
            public static string EncryptString(string stringToEncrypt)
            {
                // Initial Value
                string encryptedString = null;

                // locals
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider hashmd5;
                byte[] pwdhash;
                byte[] buff;
                
                // authorization code needed to decrypt productPassword.
                string authorizationCode = "worldclass";
                
                try
                {

                    // Verify String Does Exist and is not null
                    if (!String.IsNullOrEmpty(stringToEncrypt))
                    {
                        // encrypted system productPassword here
                        string systemPassword = "KKxEmCUlNi6c0s7etwQclA==";

                        // now decrypt productPassword 
                        string password = CryptographyHelper.DecryptString(systemPassword, authorizationCode);
                        
                        // create MD5 Service 
                        hashmd5 = new MD5CryptoServiceProvider();
                        
                        // compute productPassword has
                        pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                        
                        // dispose of hashmd5
                        hashmd5 = null;

                        // implement DES3 encryption
                        des = new TripleDESCryptoServiceProvider();

                        // the key is the secret productPassword hash.
                        des.Key = pwdhash;

                        // Electronic Code Book Cipher (CBC, CFB)
                        des.Mode = CipherMode.ECB; 

                        // Set Buffer To stringToEncrypt
                        buff = ASCIIEncoding.ASCII.GetBytes(stringToEncrypt);

                        // Get Encrypted String
                        encryptedString = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));
                    }
                }
                catch
                {
                }

                // Return Encrypted String
                return encryptedString;

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
			    string decryptedString = null;

                try
                {
                    TripleDESCryptoServiceProvider des;
                    MD5CryptoServiceProvider hashmd5;
                    byte[] pwdhash;
                    byte[] buff;

                    hashmd5 = new MD5CryptoServiceProvider();
                    pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                    hashmd5 = null;

                    //implement DES3 encryption
                    des = new TripleDESCryptoServiceProvider();

                    //the key is the secret productPassword hash.
                    des.Key = pwdhash;

                    // Electronic Code Book Cipher
                    des.Mode = CipherMode.ECB; //CBC, CFB

                    // Decrypt String
                    buff = Convert.FromBase64String(stringToDecrypt);

                    //decrypt DES 3 encrypted byte buffer and return ASCII string
                    decryptedString = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));
                }
                catch 
                {
                    
                    
                }
					
				// Return Value
				return decryptedString;
					
			}
			#endregion

            #region DecryptString(string  stringToDecrypt)
            /// <summary>
            /// Decrypts a string passed in.
            /// </summary>
            /// <param customerName="stringToDecrypt">String that needs to be deciphered.</param>
            /// <returns></returns>
            public static string DecryptString(string stringToDecrypt)
            {

                // initial value
                string decryptedString = null;

                // locals
                TripleDESCryptoServiceProvider des;
                MD5CryptoServiceProvider hashmd5;
                byte[] pwdhash;
                byte[] buff;

                // authorization code needed to decrypt productPassword.
                string authorizationCode = "worldclass";

                try
                {
                    // encrypted system productPassword here
                    string systemPassword = "KKxEmCUlNi6c0s7etwQclA==";
                    
                    // now decrypt productPassword 
                    string password = CryptographyHelper.DecryptString(systemPassword, authorizationCode);
                
                    // Create MD5 CryptoServiceProvider
                    hashmd5 = new MD5CryptoServiceProvider();
                    
                    // computer productPassword hash
                    pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                    
                    // dispose of object
                    hashmd5 = null;

                    //implement DES3 encryption
                    des = new TripleDESCryptoServiceProvider();

                    //the key is the secret productPassword hash.
                    des.Key = pwdhash;

                    // Electronic Code Book Cipher (CBC, CFB)
                    des.Mode = CipherMode.ECB; 

                    // Decrypt String
                    buff = Convert.FromBase64String(stringToDecrypt);

                    //decrypt DES 3 encrypted byte buffer and return ASCII string
                    decryptedString = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));
                }
                catch
                {


                }

                // Return Value
                return decryptedString;

            }
            #endregion
			
		#endregion
		
	}
	#endregion

}
