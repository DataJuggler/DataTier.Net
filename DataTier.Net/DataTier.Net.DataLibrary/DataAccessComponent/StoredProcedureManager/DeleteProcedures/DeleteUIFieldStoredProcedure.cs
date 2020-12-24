

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteUIFieldStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'UIField' object.
    /// </summary>
    public class DeleteUIFieldStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteUIFieldStoredProcedure' object.
        /// </summary>
        public DeleteUIFieldStoredProcedure()
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
                this.ProcedureName = "UIField_Delete";

                // Set tableName
                this.TableName = "UIField";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
