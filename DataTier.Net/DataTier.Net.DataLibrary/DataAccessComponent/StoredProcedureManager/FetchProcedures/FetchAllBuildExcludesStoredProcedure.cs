

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllBuildExcludesStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'BuildExcludes' objects.
    /// </summary>
    public class FetchAllBuildExcludesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllBuildExcludesStoredProcedure' object.
        /// </summary>
        public FetchAllBuildExcludesStoredProcedure()
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
                this.ProcedureName = "BuildExcludes_FetchAll";

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
