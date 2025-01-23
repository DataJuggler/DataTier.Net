

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertMethodStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Method' object.
    /// </summary>
    public class InsertMethodStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertMethodStoredProcedure' object.
        /// </summary>
        public InsertMethodStoredProcedure()
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
                this.ProcedureName = "Method_Insert";

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
