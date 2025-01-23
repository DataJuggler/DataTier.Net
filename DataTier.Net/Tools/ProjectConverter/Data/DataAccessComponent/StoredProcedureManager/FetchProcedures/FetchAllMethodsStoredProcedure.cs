

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllMethodsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Method' objects.
    /// </summary>
    public class FetchAllMethodsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllMethodsStoredProcedure' object.
        /// </summary>
        public FetchAllMethodsStoredProcedure()
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
                this.ProcedureName = "Method_FetchAll";

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
