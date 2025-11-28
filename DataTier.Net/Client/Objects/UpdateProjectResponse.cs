

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.Objects
{

    #region class UpdateProjectResponse
    /// <summary>
    /// This class is used with the VisualStudioHelper to trap needless errors
    /// </summary>
    internal class UpdateProjectResponse
    {
        
        #region Private Variables
        private List<Exception> exceptions;
        private int filesAdded;
        private int filesAttempted;
        private int filesRemoved;
        private bool success;
        private bool isDirty;
        private bool removeMode;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateProjectResponse' object.
        /// </summary>
        internal UpdateProjectResponse()
        {
            // Create a new collection of 'Exception' objects.
            Exceptions = new List<Exception>();
        }
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods
            
        #endregion
        
        #region Properties
            
            #region Exceptions
            /// <summary>
            /// This property gets or sets the value for 'Exceptions'.
            /// </summary>
            public List<Exception> Exceptions
            {
                get { return exceptions; }
                set { exceptions = value; }
            }
            #endregion
            
            #region FilesAdded
            /// <summary>
            /// This property gets or sets the value for 'FilesAdded'.
            /// </summary>
            public int FilesAdded
            {
                get { return filesAdded; }
                set { filesAdded = value; }
            }
            #endregion
            
            #region FilesAttempted
            /// <summary>
            /// This property gets or sets the value for 'FilesAttempted'.
            /// </summary>
            public int FilesAttempted
            {
                get { return filesAttempted; }
                set { filesAttempted = value; }
            }
            #endregion
            
            #region FilesRemoved
            /// <summary>
            /// This property gets or sets the value for 'FilesRemoved'.
            /// </summary>
            public int FilesRemoved
            {
                get { return filesRemoved; }
                set { filesRemoved = value; }
            }
            #endregion
            
            #region HasExceptions
            /// <summary>
            /// This property returns true if this object has an 'Exceptions'.
            /// </summary>
            public bool HasExceptions
            {
                get
                {
                    // initial value
                    bool hasExceptions = (Exceptions != null);

                    // return value
                    return hasExceptions;
                }
            }
            #endregion
            
            #region IsDirty
            /// <summary>
            /// This property gets or sets the value for 'IsDirty'.
            /// </summary>
            public bool IsDirty
            {
                get { return isDirty; }
                set { isDirty = value; }
            }
            #endregion
            
            #region RemoveMode
            /// <summary>
            /// This property gets or sets the value for 'RemoveMode'.
            /// </summary>
            public bool RemoveMode
            {
                get { return removeMode; }
                set { removeMode = value; }
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
