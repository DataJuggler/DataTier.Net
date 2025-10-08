

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace DataJuggler.Core.UltimateHelper
{

    #region class BooleanHelper
    /// <summary>
    /// This 
    /// </summary>
    public class BooleanHelper
    {
        
        #region Methods

            #region ParseBoolean(string sourceString, bool defaultValue, bool errorValue)
            /// <summary>
            /// This method returns the Boolean value for the source string given.
            /// </summary>
            public static bool ParseBoolean(string sourceString, bool defaultValue, bool errorValue)
            {
                // initial value
                bool boolValue = defaultValue;

                try
                {
                    // if the string exists
                    if (TextHelper.Exists(sourceString))
                    {
                        // perform the parse
                        boolValue = Boolean.Parse(sourceString);
                    }
                }
                catch (Exception error)
                {
                    // for debugging only
                    string err = error.ToString();

                    // set the return value to the errorValue
                    boolValue = errorValue;
                }

                // return value
                return boolValue;
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
