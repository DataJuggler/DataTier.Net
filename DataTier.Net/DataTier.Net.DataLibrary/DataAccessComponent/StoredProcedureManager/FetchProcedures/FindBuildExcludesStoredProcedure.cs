

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindBuildExcludesStoredProcedure
    /// <summary>
    /// This class is used to Find a 'BuildExcludes' object.
    /// </summary>
    public class FindBuildExcludesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindBuildExcludesStoredProcedure' object.
        /// </summary>
        public FindBuildExcludesStoredProcedure()
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
                this.ProcedureName = "BuildExcludes_Find";

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
