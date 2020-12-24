

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteDTNProcedureStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'DTNProcedure' object.
    /// </summary>
    public class DeleteDTNProcedureStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteDTNProcedureStoredProcedure' object.
        /// </summary>
        public DeleteDTNProcedureStoredProcedure()
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
                this.ProcedureName = "DTNProcedure_Delete";

                // Set tableName
                this.TableName = "DTNProcedure";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
