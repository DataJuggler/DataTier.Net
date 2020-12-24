

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertDTNTableStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'DTNTable' object.
    /// </summary>
    public class InsertDTNTableStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertDTNTableStoredProcedure' object.
        /// </summary>
        public InsertDTNTableStoredProcedure()
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
                this.ProcedureName = "DTNTable_Insert";

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
