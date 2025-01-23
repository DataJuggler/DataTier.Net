

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllProjectReferencesStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ProjectReference' objects.
    /// </summary>
    public class FetchAllProjectReferencesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllProjectReferencesStoredProcedure' object.
        /// </summary>
        public FetchAllProjectReferencesStoredProcedure()
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
                this.ProcedureName = "ProjectReference_FetchAll";

                // Set tableName
                this.TableName = "ProjectReference";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
