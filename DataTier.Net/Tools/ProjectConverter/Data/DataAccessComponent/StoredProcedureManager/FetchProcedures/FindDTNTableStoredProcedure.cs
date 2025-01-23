

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindDTNTableStoredProcedure
    /// <summary>
    /// This class is used to Find a 'DTNTable' object.
    /// </summary>
    public class FindDTNTableStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindDTNTableStoredProcedure' object.
        /// </summary>
        public FindDTNTableStoredProcedure()
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
                this.ProcedureName = "DTNTable_Find";

                // Set tableName
                this.TableName = "DTNTable";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
