

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class DebugHelper
    /// <summary>
    /// This method is used to make it simple to write to the debugger from any metho or event.
    /// </summary>
    public class DebugHelper
    {
        
        #region Private Variables
        #endregion
        
        #region Events
            
            #region WriteDebugError(string methodName, string objectName, Exception error)
            /// <summary>
            /// event is fired when Write Debug Line
            /// </summary>
            public static void WriteDebugError(string methodName, string objectName, Exception error)
            {
                // Create a StringBuilder
                StringBuilder sb = new StringBuilder();

                // locals
                string message = "An error occurred in the module '" + objectName + "'" + Environment.NewLine;

                // verify the objectName and the Exception both exist
                if ((TextHelper.Exists(objectName)) && (NullHelper.Exists(error)))
                {
                    // if the methodName exists
                    if (TextHelper.Exists(methodName))
                    {
                        // Write the first part
                        sb.Append("The error occurred in the method '");
                        sb.Append(methodName);
                      
                    }
                    
                    sb.Append("'");
                    sb.Append(Environment.NewLine);
                    sb.Append("Exception Details:");
                    sb.Append(error.ToString());

                    // Get the string to show the user
                    string completeMessage = sb.ToString();

                    // Write this line to the output window
                    Debug.WriteLine(completeMessage);
                }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
