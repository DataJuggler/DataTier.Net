

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllEnumerationsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Enumeration' objects.
    /// </summary>
    public class FetchAllEnumerationsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllEnumerationsStoredProcedure' object.
        /// </summary>
        public FetchAllEnumerationsStoredProcedure()
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
                this.ProcedureName = "Enumeration_FetchAll";

                // Set tableName
                this.TableName = "Enumeration";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
