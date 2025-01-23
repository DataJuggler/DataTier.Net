

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindProjectReferenceStoredProcedure
    /// <summary>
    /// This class is used to Find a 'ProjectReference' object.
    /// </summary>
    public class FindProjectReferenceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindProjectReferenceStoredProcedure' object.
        /// </summary>
        public FindProjectReferenceStoredProcedure()
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
                this.ProcedureName = "ProjectReference_Find";

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
