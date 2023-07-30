

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

    #region class CodeLineHelper
    /// <summary>
    /// This class is used to convert a list of TextLine objects to CodeLine objects
    /// </summary>
    public class CodeLineHelper
    {

        #region Private Variables
        public const string OverrideMessage = "// Write any overrides or custom methods here.";
        #endregion

        #region Methods

            #region Contains(List<CodeLine> method, string text)
            /// <summary>
            /// This method returns true if the text exists in the codeLines
            /// </summary>
            public static bool Contains(List<CodeLine> codeLines, string text)
            {
                // initial value
                bool contains = false;

                // if the method has one or more code lines and the text string exists
                if ((ListHelper.HasOneOrMoreItems(codeLines)) && (TextHelper.Exists(text)))
                {   
                    // Iterate the collection of CodeLine objects
                    foreach (CodeLine codeLine in codeLines)
                    {
                        // if the readerName exists in the method
                        if (codeLine.Text.Contains(text))
                        {
                            // set the return value
                            contains = true;

                            // break out of the loop
                            break;
                        }
                    }
                }
                
                // return value
                return contains;
            }
            #endregion

            #region CreateCodeLines(string filePath)
            /// <summary>
            /// This method returns a list of Code Lines
            /// </summary>
            public static List<CodeLine> CreateCodeLines(string filePath)
            {
                // initial value
                List<CodeLine> codeLines = null;

                // if the filePath exists 
                if ((TextHelper.Exists(filePath)) && (File.Exists(filePath)))
                {
                    // get the text for the path
                    string text = File.ReadAllText(filePath);

                    // get the textLines
                    List<TextLine> textLines = TextHelper.GetTextLines(text);

                    // set the return value
                    codeLines = CreateCodeLines(textLines);
                }
                
                // return value
                return codeLines;
            }
            #endregion
            
            #region CreateCodeLines(List<TextLine> textLines)
            /// <summary>
            /// This method returns a list of Code Lines
            /// </summary>
            public static List<CodeLine> CreateCodeLines(List<TextLine> textLines)
            {
                // initial value
                List<CodeLine> codeLines = null;

                // If the textLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(textLines))
                {
                    // Create a new collection of 'CodeLine' objects.
                    codeLines = new List<CodeLine>();

                    // Iterate the collection of TextLine objects
                    foreach (TextLine textLine in textLines)
                    {
                        // create the codeLine
                        CodeLine codeLine = new CodeLine(textLine);

                        // Add this line
                        codeLines.Add(codeLine);
                    }
                }
                
                // return value
                return codeLines;
            }
            #endregion

            #region CreateCodeLinesFromText(string text)
            /// <summary>
            /// This method returns a list of Code Lines
            /// </summary>
            public static List<CodeLine> CreateCodeLinesFromText(string text)
            {
                // initial value
                List<CodeLine> codeLines = null;
                List<TextLine> textLines = null;

                // If the text string exists
                if (TextHelper.Exists(text))
                {
                    // get the textLines
                    textLines = TextHelper.GetTextLines(text);
                }

                // now create the codeLines from the textLines
                codeLines = CreateCodeLines(textLines);

                // return value
                return codeLines;
            }
            #endregion

            #region ExportCodeLines(ExportCodeLines(List<CodeLine> codeLines))
            /// <summary>
            /// This method returns the Code Lines
            /// </summary>
            public static string ExportCodeLines(List<CodeLine> codeLines)
            {
                // initial value
                string exportedText = "";

                // locals
                int index = -1;

                // Create a new instance of a 'StringBuilder' object.
                StringBuilder sb = new StringBuilder();

                // Iterate the collection of CodeLine objects
                foreach (CodeLine codeLine in codeLines)
                {
                    // Increment the value for index
                    index++;

                    // Append this line
                    sb.Append(codeLine.Text);

                    // if this is not the last line
                    if (index < (codeLines.Count - 1))
                    {
                        // Add a new line
                        sb.Append(Environment.NewLine);
                    }
                }

                // get the fileText
                exportedText = sb.ToString(); 

                // return value
                return exportedText;
            }
            #endregion
            
            #region GetIndex(List<CodeLine> codeLines, string startsWithText, bool mustMatchExactly = false)
            /// <summary>
            /// This method returns the Index
            /// </summary>
            public static int GetIndex(List<CodeLine> codeLines, string startsWithText, bool mustMatchExactly = false)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // Iterate the collection of CodeLine objects
                    foreach (CodeLine codeLine in codeLines)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if mustMatchExactly is true
                        if (mustMatchExactly)
                        {
                            // if this is an exact match after trimming
                            if (TextHelper.IsEqual(codeLine.Text.Trim(), startsWithText.Trim()))
                            {
                                // set the return value
                                index = tempIndex;

                                // break out of this loop
                                break;
                            }
                        }
                        // if this is the item being sought
                        else if (codeLine.Text.Trim().StartsWith(startsWithText.Trim()))
                        {
                            // set the return value
                            index = tempIndex;

                            // break out of this loop
                            break;
                        }
                    }
                }
                
                // return value
                return index;
            }
            #endregion

            #region GetIndex(List<CodeLine> codeLines, Guid lineId)
            /// <summary>
            /// This method returns the Index
            /// </summary>
            public static int GetIndex(List<CodeLine> codeLines, Guid lineId)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // Iterate the collection of CodeLine objects
                    foreach (CodeLine codeLine in codeLines)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;
                       
                        // if this is the line being sought
                        if (codeLine.Id == lineId)
                        {
                            // set the return value
                            index = tempIndex;

                            // break out of this loop
                            break;
                        }
                    }
                }
                
                // return value
                return index;
            }
            #endregion
            
            #region GetInsertIndexForMethod(List<CodeLine> codeLines, string methodName)
            /// <summary>
            /// This method returns the Insert Index For a Method
            /// </summary>
            public static int GetInsertIndexForMethod(List<CodeLine> codeLines, string methodName)
            {
                // initial value
                int insertIndex = -1;

                 // locals
                bool methodRegionsOn = false;
                int tempIndex = -1;
                int regionCount = 0;

                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // Iterate the collection of CodeLine objects
                    foreach (CodeLine codeLine in codeLines)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if the methods region is currently on
                        if (methodRegionsOn)
                        {
                            // if this is a Region line
                            if (codeLine.IsRegion)
                            {
                                // increment the value for regionCount
                                regionCount++;

                                // get the compare value
                                int compare = String.Compare(codeLine.RegionName, methodName);

                                // if this region is after the propertyName, this is where to insert
                                if (compare > 0)
                                {
                                    // set the return value
                                    insertIndex = tempIndex;

                                    // break out of this loop
                                    break;
                                }
                            }
                            // if this is an EndRegion line
                            else if (codeLine.IsEndRegion)
                            {
                                // Decrement the value for regionCount
                                regionCount--;

                                // if the regionCount is below zero
                                if (regionCount < 0)
                                {
                                    // this is the insertIndex if no methods were found
                                    insertIndex = tempIndex;

                                    // break out of this loop
                                    break;
                                }
                            }
                        }
                        else
                        {  
                            // If the value for the property codeLine.IsRegion is true and the name of the Region is Properties
                            if ((codeLine.IsRegion) && ((codeLine.RegionName == "Methods") || (codeLine.RegionName == "Static Methods")))
                            {
                                // we have reached the Methods region
                                methodRegionsOn = true;
                            }
                        }
                    }
                }
                
                // return value
                return insertIndex;
            }
            #endregion

            #region GetInsertIndexForProperty(List<CodeLine> codeLines, string propertyName, ref int spacesCount, ref int existingPropertiesCount)
            /// <summary>
            /// This method returns the Insert Index For a Property
            /// </summary>
            public static int GetInsertIndexForProperty(List<CodeLine> codeLines, string propertyName, ref int spacesCount, ref int existingPropertiesCount)
            {
                // initial value
                int insertIndex = -1;

                 // locals
                bool propertiesRegionOn = false;
                int tempIndex = -1;
                int regionCount = 0;
                
                // set the initial value
                existingPropertiesCount = 0;

                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // Iterate the collection of CodeLine objects
                    foreach (CodeLine codeLine in codeLines)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if the properties region is currently on
                        if (propertiesRegionOn)
                        {
                            // if this is a Region line
                            if (codeLine.IsRegion)
                            {
                                // Increment the value for regionCount
                                regionCount++;

                                // Increment the value for existingPropertiesCount
                                existingPropertiesCount++;

                                // if this is the first existing property
                                if (existingPropertiesCount == 1)
                                {
                                    // set the spacesCount (subtract 4 here, because 4 is added when the property is inserted
                                    spacesCount = TextHelper.GetSpacesCount(codeLine.Text) - 4;
                                }

                                // get the compare value
                                int compare = String.Compare(codeLine.RegionName, propertyName);

                                // if this region is after the propertyName, this is where to insert
                                if (compare > 0)
                                {
                                    // set the return value
                                    insertIndex = tempIndex;

                                    // break out of this loop
                                    break;
                                }
                            }
                            // if this is an EndRegion line
                            else if (codeLine.IsEndRegion)
                            {
                                // Decrement the value for regionCount
                                regionCount--;

                                 // if the regionCount is below zero
                                if (regionCount < 0)
                                {
                                    // if no existing properties were found
                                    if (existingPropertiesCount == 0)
                                    {
                                        // set the spacesCount
                                        spacesCount = TextHelper.GetSpacesCount(codeLine.Text);
                                    }

                                    // this is the insertIndex 
                                    insertIndex = tempIndex;

                                    // break out of this loop
                                    break;
                                }
                            }
                        }
                        else
                        {  
                            // If the value for the property codeLine.IsRegion is true 
                            if (codeLine.IsRegion) 
                            {
                                // This was written all in one line above where it checks for EndRegion, but it is easier
                                // to debug broken out as two if statements
                                if (codeLine.RegionName == "Properties")
                                {
                                    // we have reached the private variables region
                                    propertiesRegionOn = true;
                                }
                            }
                        }
                    }
                }
                
                // return value
                return insertIndex;
            }
            #endregion

            #region GetLastMostIndentedCloseBracketIndex(List<CodeLine> codeLines)
            /// <summary>
            /// This method returns the Last Most Indented Close Bracket Index
            /// </summary>
            public static int GetLastMostIndentedCloseBracketIndex(List<CodeLine> codeLines)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;
                int maxSpaces = 0;

                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // Iterate the collection of CodeLine objects
                    foreach(CodeLine codeLine in codeLines)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;
                            
                        // if this is a close bracket
                        if (codeLine.Text.Trim() == "}")
                        {
                            // get the spacesCount
                            int spaces = TextHelper.GetSpacesCount(codeLine.Text);

                            // if the new spaces is higher than the max
                             if (spaces >= maxSpaces)
                             {
                                // set the new max
                                maxSpaces = spaces;

                                // set the new index
                                index = tempIndex;
                             }
                        }
                    }
                }
                
                // return value
                return index;
            }
            #endregion
            
            #region GetMethod(List<CodeLine> codeLines, string methodName)
            /// <summary>
            /// This method returns the Method
            /// </summary>
            public static List<CodeLine> GetMethod(List<CodeLine> codeLines, string methodName)
            {
                // initial value
                List<CodeLine> method = null;

                // locals
                bool methodRegionOn = false;

                // if there are one or more codeLines and the methodName exists
                if ((ListHelper.HasOneOrMoreItems(codeLines)) && (TextHelper.Exists(methodName)))
                {
                    // Iterate the collection of CodeLine objects
                    foreach (CodeLine codeLine in codeLines)
                    {  
                        // if the methodRegion is currentlyOn
                        if (methodRegionOn)
                        {
                            // add this line
                            method.Add(codeLine);

                            // if this is the endRegion
                            if (codeLine.IsEndRegion)
                            {
                                // break out of the loop
                                break;
                            }
                        }
                        else
                        {
                            // if the regionName contains the methodName
                            if (codeLine.RegionName.Contains(methodName))
                            {
                                // toggle to true
                                methodRegionOn = true;

                                // Create a new collection of 'CodeLine' objects.
                                method = new List<CodeLine>();

                                // Add this line
                                method.Add(codeLine);
                            }
                        }
                    }
                }
                
                // return value
                return method;
            }
            #endregion
            
            #region GetPrivateVariablesRegionInfo(List<CodeLine> codeLines)
            /// <summary>
            /// This method returns the Private Variables End Region Index
            /// </summary>
            public static RegionInfo GetPrivateVariablesRegionInfo(List<CodeLine> codeLines)
            {
                // initial value
                RegionInfo regionInfo = new RegionInfo();

                // locals
                bool privateVariablesRegionOn = false;
                int index = -1;
                
                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // Iterate the collection of CodeLine objects
                    foreach (CodeLine codeLine in codeLines)
                    {
                        // Increment the value for index
                        index++;

                        // if the private variables region is currently on
                        if (privateVariablesRegionOn)
                        {
                            // if this is an EndRegion
                            if (codeLine.IsEndRegion)
                            {
                                // set the return value
                                regionInfo.EndIndex = index;

                                // break out of the loop
                                break;
                            }
                        }
                        else
                        {  
                            // If the value for the property codeLine.IsRegion is true
                            if (codeLine.IsRegion) 
                            {
                                // get the regionName
                                string regionName = codeLine.RegionName;

                                // if this is the Private Variables region
                                if (regionName == "Private Variables")
                                {
                                    // we have reached the private variables region
                                    privateVariablesRegionOn = true;

                                    // Set the startIndex
                                    regionInfo.StartIndex = index;
                                }
                            }
                        }
                    }
                }

                // return value
                return regionInfo;
            }
            #endregion

            #region GetSubset(List<CodeLine> codeLines, int startIndex, int endIndex)
            /// <summary>
            /// This method returns a list of Subset
            /// </summary>
            public static List<CodeLine> GetSubset(List<CodeLine> codeLines, int startIndex, int endIndex)
            {
                // initial value
                List<CodeLine> subset = null;

                // If the codeLines collection exists and has one or more items
                if ((ListHelper.HasOneOrMoreItems(codeLines)) && (startIndex > 0) && (endIndex > startIndex) && (endIndex < codeLines.Count))
                {
                    // Create a new collection of 'CodeLine' objects.
                    subset = new List<CodeLine>();

                    // Increment the value for for
                    for (int x = startIndex; x < endIndex; x++)    
                    {
                        // get the codeLine
                        CodeLine codeLine = codeLines[x];

                        // add the codeLine
                        subset.Add(codeLine);
                    }
                }
                
                // return value
                return subset;
            }
            #endregion
            
            #region InsertCodeLine(ref List<CodeLine> codeLines, string lineText, int insertIndex, string tag = "")
            /// <summary>
            /// This method returns the Code Line
            /// </summary>
            public static int InsertCodeLine(ref List<CodeLine> codeLines, string lineText, int insertIndex, string tag = "")
            {
                // if there are one or more codeLines and the insertIndex is in range
                if ((ListHelper.HasOneOrMoreItems(codeLines)) && (insertIndex >= 0) && (insertIndex < codeLines.Count))
                {
                    // Create a new instance of a 'CodeLine' object.
                    CodeLine codeLine = new CodeLine(lineText);

                    // set the tag
                    codeLine.Tag = tag;

                    // insert this codeLine
                    codeLines.Insert(insertIndex, codeLine);

                    // increment the value for insertIndex
                    insertIndex++;
                }
                
                // return value
                return insertIndex;
            }
            #endregion
            
            #region InsertCodeLines(ref List<CodeLine> codeLines, List<CodeLine> subSet, int index)
            /// <summary>
            /// This method Inserts a collection of codeLines into another collection
            /// </summary>
            public static void InsertCodeLines(ref List<CodeLine> codeLines, List<CodeLine> subSet, int index)
            {
                // If the codeLines collection exists and has one or more items
                if ((ListHelper.HasOneOrMoreItems(codeLines, subSet)) && (index > 0) && (index < codeLines.Count))
                {
                    // iterate the codeLines in method
                    foreach (CodeLine codeLine in subSet)
                    {
                        // Insert this line
                        codeLines.Insert(index, codeLine);

                        // Increment the value for index
                        index++;
                    }
                }
            }
            #endregion
            
            #region IsOverridesWarningPresent(List<CodeLine> codeLines)
            /// <summary>
            /// This method returns the Overrides Warning Present
            /// </summary>
            public static bool IsOverridesWarningPresent(List<CodeLine> codeLines)
            {
                // initial value
                bool isOverridesWarningPresent = false;

                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // Iterate the collection of CodeLine objects
                    foreach (CodeLine codeLine in codeLines)
                    {
                        // if this file has not been customized yet
                        if ((codeLine.IsComment) && (codeLine.Text.Contains(OverrideMessage)))
                        {
                            // set the return value
                            isOverridesWarningPresent = true;

                            // break out of this loop
                            break;
                        }
                    }
                }
                
                // return value
                return isOverridesWarningPresent;
            }
            #endregion
            
            #region RemoveConsecutiveBlankLines(List<CodeLine> codeLines, int maxBlankLinesAllowed)
            /// <summary>
            /// This method returns a list of Consecutive Blank Lines
            /// </summary>
            /// <param name="codeLines"></param>
            /// <param name="maxBlankLinesAllowed">The maximum number of allowed blank lines.</param>
            /// With this method, if maxBlankLinesAllowed equals 2 for example, than the first two consecutive blank lines
            /// are copies and any subsequent blank lines are ignored until the next non blank line is encountered.
            /// This cleans up extra blank lines left from the Template files up near the using statements and sometimes
            /// the code generation adds a blank line after a blank line, and this is an easy way to fix code generation formatting errors.
            public static List<CodeLine> RemoveConsecutiveBlankLines(List<CodeLine> codeLines, int maxBlankLinesAllowed)
            {
                // initial value
                List<CodeLine> newCodeLines = null;

                // local
                int blankCount = 0;

                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // Create a new collection of 'CodeLine' objects.
                    newCodeLines = new List<CodeLine>();

                    // Iterate the collection of CodeLine objects
                    foreach (CodeLine codeLine in codeLines)
                    {
                        // if this is a blank line
                        if (codeLine.IsBlankLine)
                        {
                            // Increment the value for blankCount
                            blankCount++;

                            // if this item is up to or before the maximum allowed consecutive blank lines
                            if (blankCount <= maxBlankLinesAllowed)
                            {
                                // Add this line
                                newCodeLines.Add(codeLine);
                            }
                        }
                        else
                        {
                            // reset the value for blankCount
                            blankCount = 0;

                            // Add this line
                            newCodeLines.Add(codeLine);
                        }
                    }
                }
                
                // return value
                return newCodeLines;
            }
            #endregion
            
            #region RemoveDoubleBlankLines(string)
            /// <summary>
            /// This method Remove Double Blank Lines
            /// </summary>
            public static string RemoveDoubleBlankLines(string text)
            {
                // locals
                string updatedText = "";
                
                // If the text string exists
                if (TextHelper.Exists(text))
                {
                    // Create the codeLines
                    List<CodeLine> codeLines = CreateCodeLinesFromText(text);

                    // If the codeLines collection exists and has one or more items
                    if (ListHelper.HasOneOrMoreItems(codeLines))
                    {
                        // remove any blank codeLines
                        codeLines = RemoveConsecutiveBlankLines(codeLines, 1);
                    }

                    // set the updatedText
                    updatedText = ExportCodeLines(codeLines);
                }

                // return value
                return updatedText;
            }
            #endregion
            
            #region RemoveOverridesMessage(List<CodeLine> codeLines)
            /// <summary>
            /// This method Remove Overrides Message
            /// </summary>
            public static int RemoveOverridesMessage(List<CodeLine> codeLines)
            {
                // initial value
                int index = -1;

                // local
                int tempIndex = -1;

                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // Iterate the collection of CodeLine objects
                    foreach (CodeLine codeLine in codeLines)
                    {
                        // Increment the value for tempIndex
                        tempIndex++;

                        // if this file has not been customized yet
                        if ((codeLine.IsComment) && (codeLine.Text.Contains(OverrideMessage)))
                        {
                            // set the return value
                            index = tempIndex - 1;

                            // break out of this loop
                            break;
                        }
                    }

                    // if the index was found
                    if (index >= 0)
                    {
                        // remove the 3 lines that make up the warning
                        codeLines.RemoveAt(index + 2);
                        codeLines.RemoveAt(index + 1);
                        codeLines.RemoveAt(index);
                    }
                }

                // return value
                return index;
            }
            #endregion
            
            #region WriteFileText(List<CodeLine> codeLines, string fileName, bool deleteExistingFile, bool removeDoubleBlankLines = true)
            /// <summary>
            /// This method returns the File Text
            /// </summary>
            public static string WriteFileText(List<CodeLine> codeLines, string fileName, bool deleteExistingFile, bool removeDoubleBlankLines = true)
            {
                // initial value
                string fileText = "";
                
                // If the codeLines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(codeLines))
                {
                    // if the value for removeDoubleBlankLines is true
                    if (removeDoubleBlankLines)
                    {
                        // remove any blank lines after the first one
                        codeLines = CodeLineHelper.RemoveConsecutiveBlankLines(codeLines, 1);
                    }

                    // get the fileText
                    fileText = ExportCodeLines(codeLines);

                    // if the file already exists
                    if ((System.IO.File.Exists(fileName)) && (deleteExistingFile))
                    {
                        // Delete the existing file
                        File.Delete(fileName);
                    }

                    // verify the file no longer exists
                    if (!System.IO.File.Exists(fileName))
                    {
                        // Write out the file
                        File.WriteAllText(fileName, fileText);
                    }
                }
                
                // return value
                return fileText;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
