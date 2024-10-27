

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateMethodStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Method' object.
    /// </summary>
    public class UpdateMethodStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateMethodStoredProcedure' object.
        /// </summary>
        public UpdateMethodStoredProcedure()
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
                this.ProcedureName = "Method_Update";

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
