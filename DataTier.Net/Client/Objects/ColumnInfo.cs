

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.Objects
{

    #region class ColumnInfo
    /// <summary>
    /// This class contains an Index and a boolean value for selected or not
    /// </summary>
    public class ColumnInfo
    {
        
        #region Private Variables
        private int index;
        private bool selected;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'ColumnInfo' object.
        /// </summary>
        public ColumnInfo(int index, bool selected)
        {
            // store the args
            this.Index = index;
            this.Selected = selected;
        }
        #endregion
        
        #region Properties
            
            #region Index
            /// <summary>
            /// This property gets or sets the value for 'Index'.
            /// </summary>
            public int Index
            {
                get { return index; }
                set { index = value; }
            }
            #endregion
            
            #region Selected
            /// <summary>
            /// This property gets or sets the value for 'Selected'.
            /// </summary>
            public bool Selected
            {
                get { return selected; }
                set { selected = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
