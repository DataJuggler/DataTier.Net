

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.Objects
{

    #region class UpdateFileResponse
    /// <summary>
    /// This class is used to get a response from did the file exist
    /// </summary>
    internal class UpdateFileResponse
    {
        
        #region Private Variables
        private bool fileExists;
        private bool success;
        private Exception error;        
        #endregion
        
        #region Properties
            
            #region Error
            /// <summary>
            /// This property gets or sets the value for 'Error'.
            /// </summary>
            public Exception Error
            {
                get { return error; }
                set { error = value; }
            }
            #endregion
            
            #region FileExists
            /// <summary>
            /// This property gets or sets the value for 'FileExists'.
            /// </summary>
            public bool FileExists
            {
                get { return fileExists; }
                set { fileExists = value; }
            }
            #endregion
            
            #region HasError
            /// <summary>
            /// This property returns true if this object has an 'Error'.
            /// </summary>
            public bool HasError
            {
                get
                {
                    // initial value
                    bool hasError = (Error != null);

                    // return value
                    return hasError;
                }
            }
            #endregion
            
            #region Success
            /// <summary>
            /// This property gets or sets the value for 'Success'.
            /// </summary>
            public bool Success
            {
                get { return success; }
                set { success = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
