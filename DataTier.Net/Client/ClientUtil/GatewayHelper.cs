

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using DataTierClient.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class GatewayHelper
    /// <summary>
    /// This class is used to update the Gateway
    /// </summary>
    public class GatewayHelper
    {

        #region Methods

            #region ExportWords(List<Word> words)
            /// <summary>
            /// returns the Words
            /// </summary>
            public static string ExportWords(List<Word> words)
            {
                // initial value
                string phrase = "";
                
                // If the words collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(words))
                {
                    // Iterate the collection of Word objects
                    foreach (Word word in words)
                    {
                        // Add a space
                        phrase += word.Text + " ";
                    }

                    // Trim the string
                    phrase = phrase.Trim();
                }

                // return value
                return phrase;
            }
            #endregion

            #region GetStringFromCapitalLetters(string sourceText)
            /// <summary>
            /// returns a list of Words From Capital Letters
            /// </summary>
            public static string GetStringFromCapitalLetters(string sourceText)
            {
                // initial value
                string phrase = "";

                // Get the words
                List<Word> words = GetWordsFromCapitalLetters(sourceText);

                // local
                phrase = ExportWords(words);

                // return value
                return phrase;
            }
            #endregion
            
            #region GetWordsFromCapitalLetters(string sourceText, bool formatForDescription = true)
            /// <summary>
            /// returns a list of Words From Capital Letters
            /// </summary>
            public static List<Word> GetWordsFromCapitalLetters(string sourceText, bool formatForDescription = true)
            {
                // initial value
                List<Word> words = new List<Word>();

                // locals
                Word word = null;
                
                // If the sourceText string exists
                if (TextHelper.Exists(sourceText))
                {
                    // Iterate the collection of char objects
                    foreach(char c in sourceText)
                    {
                        // if UpperCase
                        if (Char.IsUpper(c))
                        {
                            // Create a new instance of a 'Word' object.
                            word = new Word();

                            // Set the initial vaue
                            word.Text = c.ToString();

                            // if the firstWord
                            if ((words.Count == 0) && (formatForDescription))
                            {
                                // Add an s and the. Turns GetPerson to Get The Person. Better than nothing
                                word.Text += "s the ";
                            }

                            // Add this word
                            words.Add(word);
                        }
                        else if (word != null)
                        {
                            // Add to the existing word
                            word.Text += c;
                        }
                    }
                }

                // return value
                return words;
            }
            #endregion

            #region GetGatewayInfo(string gatewayFilePath, List<string> methodNames)
            /// <summary>
            /// This method returns a GatewayInfo object
            /// </summary>
            public static GatewayInfo GetGatewayInfo(string gatewayFilePath, List<string> methodNames)
            {
                // initial value
                GatewayInfo gatewayInfo = new GatewayInfo();
                
                // locals
                List<GatewayMethodInfo> methodInformation = new List<GatewayMethodInfo>();
                int index = -1;
                bool methodRegionOn = false;
                GatewayMethodInfo methodInfo = null;

                // Set the MethodInformation
                gatewayInfo.MethodInformation = methodInformation;
                
                // if the gatewayFilePath exists
                if ((TextHelper.Exists(gatewayFilePath)) && (File.Exists(gatewayFilePath)) && (ListHelper.HasOneOrMoreItems(methodNames)))
                {
                    // Get the fileText
                    string fileText = File.ReadAllText(gatewayFilePath);

                    // If the fileText string exists
                    if (TextHelper.Exists(fileText))
                    {
                        // Parse the lines
                        List<TextLine> lines = TextHelper.GetTextLines(fileText);

                        // If the lines collection exists and has one or more items
                        if (ListHelper.HasOneOrMoreItems(lines))
                        {
                            // set the lines
                            gatewayInfo.TextLines = lines;

                            // Iterate the collection of string objects
                            foreach (string methodName in methodNames)
                            {
                                // reset
                                methodRegionOn = false;
                                index = -1;

                                // Iterate the collection of TextLine objects
                                foreach (TextLine line in lines)
                                {
                                    // Increment the value for index
                                    index++;

                                    // Create a codeLine
                                    CodeLine codeLine = new CodeLine(line.Text);

                                    // if the TextLine exists
                                    if (codeLine.HasTextLine) 
                                    {
                                        // Get the words for this line
                                        codeLine.TextLine.Words = TextHelper.GetWords(line.Text);
                                    }

                                    // if the value for methodRegionOn is true
                                    if (methodRegionOn)
                                    {
                                        // if this is the 
                                        if ((codeLine.IsEndRegion) && (NullHelper.Exists(methodInfo)))
                                        {
                                            // turn this off
                                            methodRegionOn = false;

                                            // Set the methodInfo
                                            methodInfo.EndIndex = index;

                                            // break out of the loop
                                            break;
                                        }
                                    }
                                    else
                                    {
                                         // if this is a Region
                                        if (codeLine.IsRegion)
                                        {
                                            // if this is the method being sought
                                            if (methodName == codeLine.RegionName)
                                            {
                                                // set to true
                                                methodRegionOn = true;

                                                // Create a new instance of a 'MethodInfo' object.
                                                methodInfo = new GatewayMethodInfo();

                                                // Set the methodName
                                                methodInfo.Name = methodName;

                                                // Set the startIndex
                                                methodInfo.StartIndex = index;

                                                // Add this item
                                                methodInformation.Add(methodInfo);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
                // return value
                return gatewayInfo;
            }
            #endregion
            
            #region RemoveMethods(string fileName, string gatewayFilePath, List<string> methodNames)
            /// <summary>
            /// This method is used to remove the lines of code that make up a Method
            /// </summary>
            /// <param name="gatewayFilePath">The path to the Gateway.cs for this project.</param>
            /// <param name="methodNames">The list of methods to remove</param>
            public static bool RemoveMethods(string gatewayFilePath, List<string> methodNames)
            {
                // initial value
                bool removed = false;

                // locals
                GatewayInfo gatewayInfo = GetGatewayInfo(gatewayFilePath, methodNames);

                // If the methodInformation collection exists and has one or more items
                if ((NullHelper.Exists(gatewayInfo)) && (ListHelper.HasOneOrMoreItems(gatewayInfo.MethodInformation)) && (gatewayInfo.HasTextLines))
                {
                    // Sort the methodInformation by the EndIndex descending
                    gatewayInfo.MethodInformation =  gatewayInfo.MethodInformation.OrderByDescending(x => x.EndIndex).ToList();

                    // Iterate the collection of MethodInfo objects
                    foreach (GatewayMethodInfo methodInfo in gatewayInfo.MethodInformation)
                    {
                        // get the length + 2 for the line after the end index
                        int count = methodInfo.EndIndex - methodInfo.StartIndex + 2;

                        // remove the range of lines
                        gatewayInfo.TextLines.RemoveRange(methodInfo.StartIndex - 1, count);
                    }

                    // Now delete the original file
                    if (File.Exists(gatewayFilePath))
                    {
                        // Delete the file
                        File.Delete(gatewayFilePath);
                    }

                    // Create a new instance of a 'StringBuilder' object.
                    StringBuilder sb = new StringBuilder();

                    // iterate the TextLines
                    foreach (TextLine textLine in gatewayInfo.TextLines)
                    {
                        // Add this line
                        sb.Append(textLine.Text);

                        // Append a new line character
                        sb.Append(Environment.NewLine);
                    }

                    // set the fileText
                    string fileText = sb.ToString();

                    // Write the fileText
                    File.AppendAllText(gatewayFilePath, fileText);
                }

                // return value
                return removed;
            }
            #endregion

        #endregion

    }
    #endregion

}
