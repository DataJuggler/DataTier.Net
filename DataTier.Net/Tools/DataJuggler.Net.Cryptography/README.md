# DataJuggler.Net.Cryptography
This package is a port of DataJuggler.Core.Cryptography for dot net core. It uses using Konscious.Security.Cryptography.Argon2 by Keef Aragaon.

CryptographyHelper was included in the library DataJugger.Core.UltimateHelper, which will soon be renamed to DataJuggler.Net.UltimateHelper to clear up the confusing between DataJuggler.UltimateHelper.Core for dot net core.

# Nuget Package Name: DataJuggler.Net.Cryptography

.Net Framework 4.61

# DataJuggler...Cryptography
This class uses System.Security.AesManaged for encryption / decryption and Konscious.Security.Cryptography.Argon2 by Keef Aragon for password hashing.  

This class was included DataJuggler.Core.UltimateHelper, but Nuget adds more dependencies than I 
care for with Argon2, so I moved this class to its own library.

To use this package: 

Install Package: DataJuggler.Net.Cryptography

There are two main functions for the project:

1. Encryption / Decryption, with or without an encryption key using System.Security.Cryptography.AesManaged
2. Password Hashing using Konscious.Security.Cryptography.Argon2

To use in your own projects after you install the package via Nuget

using DataJuggler.Net.Cryptography;

There is a constant available called DefaultPassword. The Encryption / Decryption methods and the GeneratePasswordHash
methods contain overrides that allow you to supply your own keyCode or you may use the DefaultPassword:

# Default Password

public const string DefaultPassword = "NotASecret";

# Encryption

public static string EncryptString(string stringToEncrypt, string password)

To encrypt a string, call the EncryptString method

To use your own password

string encrypted = CryptographyHelper.EncryptString(stringToEncrypt, password);

To use default password

string encrypted = CryptographyHelper.EncryptString(stringToEncrypt);

The encryption algorithm will return a different result every time you encrypt a string. 

# Decryption

public static string DecryptString(string stringToDecrypt, string password)

You muse use the same password key to decrypt a string that you used to encrypt.

To use your own password

string decrypted = CryptographyHelper.DecryptString(stringToDecrypt, password);

To use default password

string decrypted = CryptographyHelper.DecryptString(stringToDecrypt);

# Password Hashing

public static string GeneratePasswordHash(string password, string keyCode)

This method hashes the password using Konscious.Security.Cryptography's implementation of Argon2 by Keef Aragon.

# Salt

Source: https://learncryptography.com/hash-functions/password-salting

Password salting is the process of securing password hashes from something called a Rainbow Table attack. The problem with non-salted passwords is that they do not have a property that is unique to themselves – that is, if someone had a precomputed rainbow table of common password hashes, they could easily compare them to a database and see who had used which common password. A rainbow table is a pre-generated list of hash inputs to outputs, to quickly be able to look up an input (in this case, a password), from its hash. However, a rainbow table attack is only possible because the output of a hash function is always the same with the same input.

(I didn't want to try and define salt because I knew I would not do it justice).

The salt is returned with the password separated by 4 | pipe characters.

You can decrypt the encrypted password hash to determine the password hash and salt, but you
cannot decrypt from password hash back to the original password.

# To generate a Password Hash using your own keyCode

string passwordHash = CryptographyHelper.GeneratePasswordHash(password, keyCode);

# To generate a Password Hash using your the default keyCode

string passwordHash = CryptographyHelper.GeneratePasswordHash(password);

# VerifyHash

public static bool VerifyHash(string userTypedPassword, string keyCode, string storedPasswordHash)

To implement login functionality you need to verify the user typed in password can verify against your stored password hash.

If you supplied a keyCode to generate a password hash you must supply the same keyCode to verify.

To verify using your own keyCode

bool verifiedLogin = CryptographyHelper.VerifyHash(userTypedInPassword, keyCode, storedPasswordHash);

To verify using default keyCode

bool verifiedLogin = CryptographyHelper.VerifyHash(userTypedInPassword, storedPasswordHash);

# How VerifyHash works

Your storedPasswordHash is first decrypted using either the supplied keyCode or the DefaultPassword of NotASecret depending on which override you called.

The result will then contain a string made up of the passwordHash followed by a separator of 4 pipe characters in a row |||| and then the salt.

This is an example, just to show the decrypted text of the password hash uses Unicode characters

憭紷줧悐纴Ꮄ⫘||||䣿別坵ࠀ恆쁿냞 

Next the PasswordHash is determined from the left half of the 4 pipe characters.

The salty string is the characters after the 4 pipe characters.

Both salt and storedHash are both byte arrays.

byte[] salt = null;<br/>
byte[] storedHash = null;

// get the index<br/>
int index = decryptedHash.IndexOf("||||");

// if the index was found<br/>
if (index >= 0)<br/>
{<br/>
    &nbsp;&nbsp;&nbsp;&nbsp;// get the password<br/>
    &nbsp;&nbsp;&nbsp;&nbsp;password = decryptedHash.Substring(0, index);<br/>
    &nbsp;&nbsp;&nbsp;&nbsp;salty = decryptedHash.Substring(index + 4);<br/>
    &nbsp;&nbsp;&nbsp;&nbsp;salt = Encoding.Unicode.GetBytes(salty);<br/>
    &nbsp;&nbsp;&nbsp;&nbsp;storedHash = Encoding.Unicode.GetBytes(password);<br/>
}<br/>
<br/>
At this point, the salt and storedHash should be loaded, so we can call another verifyHash override.

public static bool VerifyHash(string password, byte[] salt, byte[] storedHash)

The verifyHash method creates a new passwordHash and compares it to the storedHash using Linq.

// generate the loginHash again<br/><br/>
var newHash = HashPassword(password,  salt);<br/>

// set the return value<br/>
verified = storedHash.SequenceEqual(newHash);<br/>
<br/>
# Dot Net Core Sample:
I just built a Blazor.Crypto sample, but I wanted to publish the Nuget package first.

The sample is located here:

https://github.com/DataJuggler/Blazor.Crypto





