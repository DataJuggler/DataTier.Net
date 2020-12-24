

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteDTNDatabaseStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'DTNDatabase' object.
    /// </summary>
    public class DeleteDTNDatabaseStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteDTNDatabaseStoredProcedure' object.
        /// </summary>
        public DeleteDTNDatabaseStoredProcedure()
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
                this.ProcedureName = "DTNDatabase_Delete";

                // Set tableName
                this.TableName = "DTNDatabase";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
