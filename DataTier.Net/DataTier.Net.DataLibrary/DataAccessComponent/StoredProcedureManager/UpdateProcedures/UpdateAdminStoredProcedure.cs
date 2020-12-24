

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateAdminStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Admin' object.
    /// </summary>
    public class UpdateAdminStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateAdminStoredProcedure' object.
        /// </summary>
        public UpdateAdminStoredProcedure()
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
                this.ProcedureName = "Admin_Update";

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
