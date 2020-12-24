

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteCustomReaderStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'CustomReader' object.
    /// </summary>
    public class DeleteCustomReaderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteCustomReaderStoredProcedure' object.
        /// </summary>
        public DeleteCustomReaderStoredProcedure()
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
                this.ProcedureName = "CustomReader_Delete";

                // Set tableName
                this.TableName = "CustomReader";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
