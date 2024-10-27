

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindEnumerationStoredProcedure
    /// <summary>
    /// This class is used to Find a 'Enumeration' object.
    /// </summary>
    public class FindEnumerationStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindEnumerationStoredProcedure' object.
        /// </summary>
        public FindEnumerationStoredProcedure()
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
                this.ProcedureName = "Enumeration_Find";

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
