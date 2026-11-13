

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteBuildExcludesStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'BuildExcludes' object.
    /// </summary>
    public class DeleteBuildExcludesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteBuildExcludesStoredProcedure' object.
        /// </summary>
        public DeleteBuildExcludesStoredProcedure()
        {
            // Perform Initialization
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Set Procedure Properties
            /// </summary>
            private void Init()
            {
                // Set Properties For This Proc

                // Set ProcedureName
                this.ProcedureName = "BuildExcludes_Delete";

                // Set tableName
                this.TableName = "BuildExcludes";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
