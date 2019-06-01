

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataJuggler.Core.UltimateHelper;
using DataJuggler.Core.UltimateHelper.Objects;

#endregion

namespace DataTierClient.Objects
{

    #region class GatewayInfo
    /// <summary>
    /// This class is used to contain the MethodInfo list and the list of Lines
    /// </summary>
    public class GatewayInfo
    {

        #region Private Variables
        private List<GatewayMethodInfo> methodInformation;
        private List<TextLine> textLines;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a GatewayInfo object
        /// </summary>
        public GatewayInfo()
        {
            // Create both lists
            this.MethodInformation = new List<GatewayMethodInfo>();
            this.TextLines = new List<TextLine>();
        }
        #endregion

        #region Properties

            #region HasMethodInformation
            /// <summary>
            /// This property returns true if this object has a 'MethodInformation'.
            /// </summary>
            public bool HasMethodInformation
            {
                get
                {
                    // initial value
                    bool hasMethodInformation = (this.MethodInformation != null);
                    
                    // return value
                    return hasMethodInformation;
                }
            }
            #endregion
            
            #region HasTextLines
            /// <summary>
            /// This property returns true if this object has a 'TextLines'.
            /// </summary>
            public bool HasTextLines
            {
                get
                {
                    // initial value
                    bool hasTextLines = (this.TextLines != null);
                    
                    // return value
                    return hasTextLines;
                }
            }
            #endregion
            
            #region MethodInformation
            /// <summary>
            /// This property gets or sets the value for 'MethodInformation'.
            /// </summary>
            public List<GatewayMethodInfo> MethodInformation
            {
                get { return methodInformation; }
                set { methodInformation = value; }
            }
            #endregion
            
            #region TextLines
            /// <summary>
            /// This property gets or sets the value for 'TextLines'.
            /// </summary>
            public List<TextLine> TextLines
            {
                get { return textLines; }
                set { textLines = value; }
            }
            #endregion
            
        #endregion

    }
    #endregion

}
