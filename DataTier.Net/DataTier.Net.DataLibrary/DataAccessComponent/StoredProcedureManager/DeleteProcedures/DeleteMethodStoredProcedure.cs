

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteMethodStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Method' object.
    /// </summary>
    public class DeleteMethodStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteMethodStoredProcedure' object.
        /// </summary>
        public DeleteMethodStoredProcedure()
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
                this.ProcedureName = "Method_Delete";

                // Set tableName
                this.TableName = "Method";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
