

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindMethodStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Method' object.
    /// </summary>
    public class FindMethodStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindMethodStoredProcedure' object.
        /// </summary>
        public FindMethodStoredProcedure()
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
                this.ProcedureName = "Method_Find";

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
