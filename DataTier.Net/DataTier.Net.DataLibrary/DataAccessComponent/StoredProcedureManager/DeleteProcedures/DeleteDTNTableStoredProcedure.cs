

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteDTNTableStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'DTNTable' object.
    /// </summary>
    public class DeleteDTNTableStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteDTNTableStoredProcedure' object.
        /// </summary>
        public DeleteDTNTableStoredProcedure()
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
                this.ProcedureName = "DTNTable_Delete";

                // Set tableName
                this.TableName = "DTNTable";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
