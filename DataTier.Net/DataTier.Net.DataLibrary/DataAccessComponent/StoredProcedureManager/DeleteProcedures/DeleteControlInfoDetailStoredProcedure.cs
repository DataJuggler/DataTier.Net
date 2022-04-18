

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteControlInfoDetailStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'ControlInfoDetail' object.
    /// </summary>
    public class DeleteControlInfoDetailStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteControlInfoDetailStoredProcedure' object.
        /// </summary>
        public DeleteControlInfoDetailStoredProcedure()
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
                this.ProcedureName = "ControlInfoDetail_Delete";

                // Set tableName
                this.TableName = "ControlInfoDetail";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
