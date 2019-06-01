

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace $safeprojectname$.Security
{

    #region class TextHelper
    /// <summary>
    /// This class contains helper methods for dealing with strings.
    /// </summary>
    public class TextHelper
    {
        
        #region Methods

            #region CombineStrings(string string1, string string2)
            /// <summary>
            /// This method appends string2 to the end of string1
            /// </summary>
            public static string CombineStrings(string string1, string string2)
            {
                // initial value
                string combinedString = "";

                // Create a StringBuilder
                StringBuilder sb = new StringBuilder(string1);

                // append string2
                sb.Append(string2);

                // set the return value
                combinedString = sb.ToString();

                // return value
                return combinedString;
            }
            #endregion

            #region CombineStrings(string string1, string string2, string string3)
            /// <summary>
            /// This method appends string3 and string 2 to the end of string1
            /// </summary>
            public static string CombineStrings(string string1, string string2, string string3)
            {
                // initial value
                string combinedString = "";

                // Create a StringBuilder
                StringBuilder sb = new StringBuilder(string1);

                // append string2
                sb.Append(string2);

                // append string3
                sb.Append(string3);

                // set the return value
                combinedString = sb.ToString();

                // return value
                return combinedString;
            }
            #endregion

            #region CombineStrings(string string1, string string2, string string3, string string4)
            /// <summary>
            /// This method appends string2, string3 and string4 to the end of string1
            /// </summary>
            public static string CombineStrings(string string1, string string2, string string3, string string4)
            {
                // initial value
                string combinedString = "";

                // Create a StringBuilder
                StringBuilder sb = new StringBuilder(string1);

                // append string2
                sb.Append(string2);

                // append string3
                sb.Append(string3);

                // append string4
                sb.Append(string4);

                // set the return value
                combinedString = sb.ToString();

                // return value
                return combinedString;
            }
            #endregion

            #region CombineStringsEx(string string1, string string2, string seperator = "")
            /// <summary>
            /// This method appends string2 to the end of string1
            /// </summary>
            public static string CombineStringsEx(string string1, string string2, string seperator = "")
            {
                // initial value
                string combinedString = "";

                // Create a StringBuilder
                StringBuilder sb = new StringBuilder(string1);

                // if the seperator exists
                if (Exists(seperator))
                {
                    // add the seperator
                    sb.Append(seperator);
                }

                // append string2
                sb.Append(string2);

                // set the return value
                combinedString = sb.ToString();

                // return value
                return combinedString;
            }
            #endregion

            #region CombineStringsEx(string string1, string string2, string string3, string seperator = "")
            /// <summary>
            /// This method appends string3 and string 2 to the end of string1
            /// </summary>
            public static string CombineStringsEx(string string1, string string2, string string3, string seperator = "")
            {
                // initial value
                string combinedString = "";

                // Create a StringBuilder
                StringBuilder sb = new StringBuilder(string1);

                // if the seperator exists
                if (Exists(seperator))
                {
                    // add the seperator
                    sb.Append(seperator);
                }

                // append string2
                sb.Append(string2);

                // if the seperator exists
                if (Exists(seperator))
                {
                    // add the seperator
                    sb.Append(seperator);
                }

                // append string3
                sb.Append(string3);

                // set the return value
                combinedString = sb.ToString();

                // return value
                return combinedString;
            }
            #endregion

            #region CombineStringsEx(string string1, string string2, string string3, string string4, string seperator = "")
            /// <summary>
            /// This method appends string2, string3 and string4 to the end of string1
            /// </summary>
            public static string CombineStringsEx(string string1, string string2, string string3, string string4, string seperator = "")
            {
                // initial value
                string combinedString = "";

                // Create a StringBuilder
                StringBuilder sb = new StringBuilder(string1);

                // if the seperator exists
                if (Exists(seperator))
                {
                    // add the seperator
                    sb.Append(seperator);
                }

                // append string2
                sb.Append(string2);

                // if the seperator exists
                if (Exists(seperator))
                {
                    // add the seperator
                    sb.Append(seperator);
                }

                // append string3
                sb.Append(string3);

                // if the seperator exists
                if (Exists(seperator))
                {
                    // add the seperator
                    sb.Append(seperator);
                }

                // append string4
                sb.Append(string4);

                // set the return value
                combinedString = sb.ToString();

                // return value
                return combinedString;
            }
            #endregion

            #region Exists
            
                #region Exists(string string1)
                /// <summary>
                /// This method returns true if string given exists
                /// </summary>
                public static bool Exists(string string1)
                {
                    // initial value
                    bool exists = false;

                    // test if the string exists
                    exists = (!String.IsNullOrEmpty(string1));
                
                    // return value
                    return exists;
                }
                #endregion

                #region Exists(string string1, string string2)
                /// <summary>
                /// This method returns true if BOTH strings given exist
                /// </summary>
                public static bool Exists(string string1, string string2)
                {
                    // initial value
                    bool exists = false;

                    // this method returns true if both strings exist
                    bool string1Exists = Exists(string1);
                    bool string2Exists = Exists(string2);

                    // set the return value
                    exists = ((string1Exists) && (string2Exists));

                    // return value
                    return exists;
                }
                #endregion

                #region Exists(string string1, string string2, string string3)
                /// <summary>
                /// This method returns true if ALL THREE strings given exist
                /// </summary>
                public static bool Exists(string string1, string string2, string string3)
                {
                    // initial value
                    bool exists = false;

                    // this method returns true if all three strings exist
                    bool string1Exists = Exists(string1);
                    bool string2Exists = Exists(string2);
                    bool string3Exists = Exists(string3);

                    // set the return value
                    exists = ((string1Exists) && (string2Exists) && (string3Exists));

                    // return value
                    return exists;
                }
                #endregion

                #region Exists(string string1, string string2, string string3, string string4)
                /// <summary>
                /// This method returns true if ALL FOUR strings given exist
                /// </summary>
                public static bool Exists(string string1, string string2, string string3, string string4)
                {
                    // initial value
                    bool exists = false;

                    // this method returns true if all four strings exist
                    bool string1Exists = Exists(string1);
                    bool string2Exists = Exists(string2);
                    bool string3Exists = Exists(string3);
                    bool string4Exists = Exists(string4);

                    // set the return value
                    exists = ((string1Exists) && (string2Exists) && (string3Exists) && (string4Exists));

                    // return value
                    return exists;
                }
                #endregion

                #region Exists(string string1, string string2, string string3, string string4, string string5)
                /// <summary>
                /// This method returns true if ALL Five strings given exist
                /// </summary>
                public static bool Exists(string string1, string string2, string string3, string string4, string string5)
                {
                    // initial value
                    bool exists = false;

                    // this method returns true if all five strings exist
                    bool string1Exists = Exists(string1);
                    bool string2Exists = Exists(string2);
                    bool string3Exists = Exists(string3);
                    bool string4Exists = Exists(string4);
                    bool string5Exists = Exists(string5);

                    // set the return value
                    exists = ((string1Exists) && (string2Exists) && (string3Exists) && (string4Exists) && (string5Exists));

                    // return value
                    return exists;
                }
                #endregion

            #endregion

            #region CapitalizeFirstChar(string word, bool lowerCase = false)
            /// <summary>
            /// This method capitalizes the first character of a word.
            /// </summary>
            /// <param name="word">The word to capitalize the first character of.</param>
            /// <param name="lowerCase">(Optional) If true the word is returned lower</param>
            /// <returns></returns>
            public static string CapitalizeFirstChar(string word, bool lowerCase = false)
            {
                // set the newWord
                string newWord = "";

                // If Null String
                if (String.IsNullOrEmpty(word))
                {
                    // Return Null String
                    return newWord;
                }

                // Create Char Array
                Char[] letters = word.ToCharArray();

                // if lower case
                if (lowerCase)
                {
                    // if this word is less than 3
                    if (word.Length < 3)
                    {
                        // go with all lower case here
                        newWord = word.ToLower();

                        // return the newWord
                        return newWord;
                    }
                    else
                    {
                        // Capitalize First Character
                        letters[0] = Char.ToLower(letters[0]);
                    }
                }
                else
                {
                    // Capitalize First Character
                    letters[0] = Char.ToUpper(letters[0]);
                }

                // set the newWord
                newWord = new string(letters);

                // return new string
                return newWord;

            }
            #endregion

            #region Indent(int indent)
            /// <summary>
            /// This method is used to indent a string with x number of preceding spaces.
            /// This is used when writing out the Xml for the XmlWriter
            /// </summary>
            /// <param name="indent"></param>
            /// <returns></returns>
            public static string Indent(int indentSpaces)
            {
                // initial value
                string indent = "";

                // Create a new instance of a 'StringBuilder' object.
                StringBuilder sb = new StringBuilder();

                // If the value for indentSpaces is greater than zero
                if (indentSpaces > 0)
                {
                    // iterate up to the number of spaces to indent
                    for (int x = 0; x < indentSpaces; x++)
                    {
                        // Add a space
                        sb.Append(" ");
                    }
                }

                // set the return value
                indent = sb.ToString();

                // return value
                return indent;
            }
            #endregion

            #region IsEqual(string sourceString, string sourceString2, bool textMustExist = true, bool caseMustMatch = false))
            /// <summary>
            /// This method returns true if the two strings given are equal.
            /// </summary>
            /// <param name="sourceString">The source string</param>
            /// <param name="sourceString2">The string to be compared to.</param>
            /// <param name="textMustExist">This defaults to true; if true both strings must exist or false is returned even if the strings match.</param>
            /// <param name="caseMustMatch">This defaults to false; if true the comparison will be a case sensitive comparison.
            /// <returns></returns>
            public static bool IsEqual(string sourceString, string sourceString2, bool textMustExist = true, bool caseMustMatch = false)
            {
                // initial value
                bool isEqual = false;

                // local s
                bool abort = false;
                int compare = 0;

                // if the text must exist
                if (textMustExist)
                {
                    // if both strings do not exist than abort will be set to true
                    abort = (!Exists(sourceString, sourceString2));
                }

                //if we should continue
                if (!abort)
                {
                    // if we need to a Case Sensitive Comparison
                    if (caseMustMatch)
                    {
                        // the case must match
                        compare = String.Compare(sourceString, sourceString2, false);
                    }
                    else
                    {
                        // the case must match
                        compare = String.Compare(sourceString, sourceString2, true);
                    }
                    
                    // set the return value
                    isEqual = (compare == 0);      
                }

                // return value
                return isEqual;
            }
            #endregion

            #region  StartsWithAVowel(string word)
            /// <summary>
            /// Does this string start with a vowel
            /// </summary>
            /// <param name="word"></param>
            /// <returns></returns>
            public static bool StartsWithAVowel(string word)
            {
                // initial value
                bool startsWithAVowel = false;

                // if the word exists
                if (TextHelper.Exists(word))
                {
                    // get the firstCharacter
                    string firstCharacter = word[0].ToString().ToLower();

                    // determine if a vowel
                    switch (firstCharacter)
                    {
                        case "a":
                        case "e":
                        case "i":
                        case "o":
                        case "u":

                            // set to true
                            startsWithAVowel = true;

                            // required
                            break;
                    }
                }

                // return value
                return startsWithAVowel;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
