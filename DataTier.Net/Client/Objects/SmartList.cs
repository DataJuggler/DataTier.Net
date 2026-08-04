

#region using statements

using DataJuggler.Core.UltimateHelper.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.Objects
{

    #region class SmartList
    /// <summary>
    /// This class is used to make it simpler to update a list. 
    /// </summary>
    public class SmartList
    {
        
        #region Private Variables
        private List<TextLine> lines;
        private int insertIndex;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a SmartList object
        /// </summary>
        /// <param name="lines"></param>
        public SmartList(List<TextLine> lines)
        {
            // store the args
            this.Lines = lines;
        }
        #endregion
        
        #region Methods
            
            #region Insert(int insertIndex, TextLine textLine)
            /// <summary>
            /// returns the
            /// </summary>
            public int Insert(int insertIndex, TextLine textLine)
            {
                // initial value
                lines.Insert(insertIndex, textLine);

                // Increment the value for insertIndex
                insertIndex++;

                // return value
                return insertIndex;
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region HasLines
            /// <summary>
            /// This property returns true if this object has a 'Lines'.
            /// </summary>
            public bool HasLines
            {
                get
                {
                    // initial value
                    bool hasLines = (Lines != null);

                    // return value
                    return hasLines;
                }
            }
            #endregion
            
            #region InsertIndex
            /// <summary>
            /// This property gets or sets the value for 'InsertIndex'.
            /// </summary>
            public int InsertIndex
            {
                get { return insertIndex; }
                set { insertIndex = value; }
            }
            #endregion
            
            #region Lines
            /// <summary>
            /// This property gets or sets the value for 'Lines'.
            /// </summary>
            public List<TextLine> Lines
            {
                get { return lines; }
                set { lines = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
