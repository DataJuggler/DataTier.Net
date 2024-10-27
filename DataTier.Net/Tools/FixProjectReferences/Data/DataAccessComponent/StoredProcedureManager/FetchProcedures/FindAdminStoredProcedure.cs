

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindAdminStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Admin' object.
    /// </summary>
    public class FindAdminStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindAdminStoredProcedure' object.
        /// </summary>
        public FindAdminStoredProcedure()
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
                this.ProcedureName = "Admin_Find";

                // Set tableName
                this.TableName = "Admin";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
