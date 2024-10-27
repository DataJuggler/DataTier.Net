

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateDTNFieldStoredProcedure
    /// <summary>
    /// This class is used to Update a 'DTNField' object.
    /// </summary>
    public class UpdateDTNFieldStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateDTNFieldStoredProcedure' object.
        /// </summary>
        public UpdateDTNFieldStoredProcedure()
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
                this.ProcedureName = "DTNField_Update";

                // Set tableName
                this.TableName = "DTNField";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
