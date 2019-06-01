
#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.Objects
{

    #region class RegionInfo
    /// <summary>
    /// This class contains information about a Region
    /// </summary>
    public class RegionInfo
    {

        #region Private Variables
        private int startIndex;
        private int endIndex;
        #endregion

        #region Properties

            #region EndIndex
            /// <summary>
            /// This property gets or sets the value for 'EndIndex'.
            /// </summary>
            public int EndIndex
            {
                get { return endIndex; }
                set { endIndex = value; }
            }
            #endregion
            
            #region IsValid
            /// <summary>
            /// This read only property returns the value for 'IsValid'.
            /// </summary>
            public bool IsValid
            {
                get
                {
                    // initial value
                    bool isValid = ((startIndex > 0) && (endIndex > startIndex));
                    
                    // return value
                    return isValid;
                }
            }
            #endregion
            
            #region StartIndex
            /// <summary>
            /// This property gets or sets the value for 'StartIndex'.
            /// </summary>
            public int StartIndex
            {
                get { return startIndex; }
                set { startIndex = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
