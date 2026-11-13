

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateBuildExcludesStoredProcedure
    /// <summary>
    /// This class is used to Update a 'BuildExcludes' object.
    /// </summary>
    public class UpdateBuildExcludesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateBuildExcludesStoredProcedure' object.
        /// </summary>
        public UpdateBuildExcludesStoredProcedure()
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
                this.ProcedureName = "BuildExcludes_Update";

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
