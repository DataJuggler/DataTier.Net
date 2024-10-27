

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindDTNProcedureStoredProcedure
    /// <summary>
    /// This class is used to Find a 'DTNProcedure' object.
    /// </summary>
    public class FindDTNProcedureStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindDTNProcedureStoredProcedure' object.
        /// </summary>
        public FindDTNProcedureStoredProcedure()
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
                this.ProcedureName = "DTNProcedure_Find";

                // Set tableName
                this.TableName = "DTNProcedure";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
