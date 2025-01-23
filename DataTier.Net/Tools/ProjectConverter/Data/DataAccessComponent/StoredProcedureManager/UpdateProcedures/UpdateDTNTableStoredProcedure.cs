

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateDTNTableStoredProcedure
    /// <summary>
    /// This class is used to Update a 'DTNTable' object.
    /// </summary>
    public class UpdateDTNTableStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateDTNTableStoredProcedure' object.
        /// </summary>
        public UpdateDTNTableStoredProcedure()
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
                this.ProcedureName = "DTNTable_Update";

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
