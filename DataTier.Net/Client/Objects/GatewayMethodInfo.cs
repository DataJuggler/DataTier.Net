

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.Objects
{

    #region class GatewayMethodInfo
    /// <summary>
    /// This class is used to hold the StartIndex and EndIndex of TextLines in the Gateway.cs class file for a given Method.
    /// </summary>
    public class GatewayMethodInfo
    {

        #region Private Variables
        private int startIndex;
        private int endIndex;
        private string name;
        #endregion

        #region Methods

            #region ToString()
            /// <summary>
            /// This method returns the MethodName when ToString() is called
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                // return the name of this method
                return "Method Info: Name = " + this.Name;
            }
            #endregion

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
            
            #region HasEndIndex
            /// <summary>
            /// This property returns true if the 'EndIndex' is set.
            /// </summary>
            public bool HasEndIndex
            {
                get
                {
                    // initial value
                    bool hasEndIndex = (this.EndIndex > 0);
                    
                    // return value
                    return hasEndIndex;
                }
            }
            #endregion
            
            #region HasStartIndex
            /// <summary>
            /// This property returns true if the 'StartIndex' is set.
            /// </summary>
            public bool HasStartIndex
            {
                get
                {
                    // initial value
                    bool hasStartIndex = (this.StartIndex > 0);
                    
                    // return value
                    return hasStartIndex;
                }
            }
            #endregion
            
            #region Name
            /// <summary>
            /// This property gets or sets the value for 'Name'.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value; }
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
