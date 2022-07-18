

#region using statements

using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;
using System.Collections.Generic;
using System.Text;
using System;

#endregion

namespace DataTierClient.ClientUtil
{

    #region class TextLineHelper
    /// <summary>
    /// This class is here because I am too lazy to move this class to an archived Nuget package.
    /// This method is part DataJuggler.UltimateHelper.TextHelper for .NET6.
    /// </summary>
    internal class TextLineHelper
    {
        
        #region Private Variables
        #endregion
        
        #region Methods
            
            #region ExportTextLines(List<TextLine> lines, string mustContainText = "", string mustNotContainText = "")
            /// <summary>
            /// This method returns the Text Lines, with Environment.NewLine appended after each line.
            /// </summary>
            /// <param name="lines">A collection of TextLines to rebuild into a file or block'</param>
            /// <param name="mustContainText">If present, a line must have this to be added.</param>
            /// <param name="mustNotContainText">If present, a line with will not be added</param>
            public static string ExportTextLines(List<TextLine> lines, string mustContainText = "", string mustNotContainText = "")
            {
                // initial value
                string result = "";
                
                // locals
                bool mustContain = TextHelper.Exists(mustContainText);
                bool mustNotContain = TextHelper.Exists(mustNotContainText);
                bool addLine = false;
                
                // If the lines collection exists and has one or more items
                if (ListHelper.HasOneOrMoreItems(lines))
                {
                    // Create a new instance of a 'StringBuilder' object.
                    StringBuilder sb = new StringBuilder();
                    
                    // Iterate the collection of TextLine objects
                    foreach (TextLine line in lines)
                    {
                        // reset, default to true
                        addLine = true;
                        
                        // if the value for mustContain is true
                        if (mustContain)
                        {
                            // add line is true if this string contains the mustContainText
                            addLine = line.Text.Contains(mustContainText);
                        }
                        
                        // if addLine is true,a nd the mustNotContain is true
                        if (addLine && mustNotContain)
                        {
                            // if the line contains the mustNotContainText
                            if (line.Text.Contains(mustNotContainText))
                            {
                                // do not add this line
                                addLine = false;
                            }
                        }
                        
                        // if addLine is true
                        if (addLine)
                        {
                            // Add this line
                            sb.Append(line.Text);
                            
                            // Add a NewLine char
                            sb.Append(Environment.NewLine);
                        }
                    }
                    
                    // Set the result
                    result = sb.ToString();
                }
                
                // return value
                return result;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
