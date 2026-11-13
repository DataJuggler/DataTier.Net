

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertBuildExcludesStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'BuildExcludes' object.
    /// </summary>
    public class InsertBuildExcludesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertBuildExcludesStoredProcedure' object.
        /// </summary>
        public InsertBuildExcludesStoredProcedure()
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
                this.ProcedureName = "BuildExcludes_Insert";

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
