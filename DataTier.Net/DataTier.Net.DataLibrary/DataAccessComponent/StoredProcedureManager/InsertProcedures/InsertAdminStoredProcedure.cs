

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertAdminStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Admin' object.
    /// </summary>
    public class InsertAdminStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertAdminStoredProcedure' object.
        /// </summary>
        public InsertAdminStoredProcedure()
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
                this.ProcedureName = "Admin_Insert";

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
