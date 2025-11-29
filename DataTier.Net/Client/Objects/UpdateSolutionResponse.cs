

#region using statements

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DataTierClient.Objects
{

    #region class UpdateSolutionResponse
    /// <summary>
    /// This class is used so the Visual Studio Helper can return without an error
    /// if no new files were added.
    /// </summary>
    internal class UpdateSolutionResponse
    {
        
        #region Private Variables
        private Exception exception;
        private int includedFilesCount;
        private int missingFilesCount;
        private List<UpdateProjectResponse> projectResponses;
        private int removedFilesCount;
        private bool success;
        #endregion
        
        #region Constructor
        /// <summary>
        /// Create a new instance of an UpdateSolutionResponse
        /// </summary>
        internal UpdateSolutionResponse()
        {
            // Create a new collection of 'UpdateProjectResponse' objects.
            ProjectResponses = new List<UpdateProjectResponse>();
        }
        #endregion

        #region Properties
            
            #region Exception
            /// <summary>
            /// This property gets or sets the value for 'Exception'.
            /// </summary>
            public Exception Exception
            {
                get { return exception; }
                set { exception = value; }
            }
            #endregion
            
            #region FatalError
            /// <summary>
            /// This read only property returns true if any of the ProjectResponses have uneven items of
            /// AttemptedFiles and Added or Removed Files
            /// </summary>
            public bool FatalError
            {
                get
                {
                    // initial value
                    bool fatalError = false;

                    // If the Exception object exists
                    if (this.HasException)
                    {
                        // if ProjectResponses exists
                        if (ProjectResponses != null)
                        {
                            // Iterate the collection of UpdateProjectResponse objects
                            foreach (UpdateProjectResponse response in ProjectResponses)
                            {
                                // if in RemoveMode
                                if (response.RemoveMode)
                                {
                                    // if the files don't match
                                    if (response.FilesAttempted != response.FilesRemoved)
                                    {
                                        // this needs a message
                                        fatalError = true;

                                        // break out of the loop
                                        break;
                                    }
                                }
                                else
                                {
                                    // if the files don't match
                                    if (response.FilesAttempted != response.FilesAdded)
                                    {
                                        // this needs a message
                                        fatalError = true;

                                        // break out of the loop
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    // return value
                    return fatalError;
                }
            }
            #endregion

            #region HasException
            /// <summary>
            /// This property returns true if this object has an 'Exception'.
            /// </summary>
            public bool HasException
            {
                get
                {
                    // initial value
                    bool hasException = (Exception != null);

                    // return value
                    return hasException;
                }
            }
            #endregion
            
            #region HasProjectResponses
            /// <summary>
            /// This property returns true if this object has a 'ProjectResponses'.
            /// </summary>
            public bool HasProjectResponses
            {
                get
                {
                    // initial value
                    bool hasProjectResponses = (ProjectResponses != null);

                    // return value
                    return hasProjectResponses;
                }
            }
            #endregion
            
            #region IncludedFilesCount
            /// <summary>
            /// This property gets or sets the value for 'IncludedFilesCount'.
            /// </summary>
            public int IncludedFilesCount
            {
                get { return includedFilesCount; }
                set { includedFilesCount = value; }
            }
            #endregion
            
            #region MissingFilesCount
            /// <summary>
            /// This property gets or sets the value for 'MissingFilesCount'.
            /// </summary>
            public int MissingFilesCount
            {
                get { return missingFilesCount; }
                set { missingFilesCount = value; }
            }
            #endregion
            
            #region ProjectResponses
            /// <summary>
            /// This property gets or sets the value for 'ProjectResponses'.
            /// </summary>
            public List<UpdateProjectResponse> ProjectResponses
            {
                get { return projectResponses; }
                set { projectResponses = value; }
            }
            #endregion
            
            #region RemovedFilesCount
            /// <summary>
            /// This property gets or sets the value for 'RemovedFilesCount'.
            /// </summary>
            public int RemovedFilesCount
            {
                get { return removedFilesCount; }
                set { removedFilesCount = value; }
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