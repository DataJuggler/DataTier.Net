

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateControlInfoDetailStoredProcedure
    /// <summary>
    /// This class is used to Update a 'ControlInfoDetail' object.
    /// </summary>
    public class UpdateControlInfoDetailStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateControlInfoDetailStoredProcedure' object.
        /// </summary>
        public UpdateControlInfoDetailStoredProcedure()
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
                this.ProcedureName = "ControlInfoDetail_Update";

                // Set tableName
                this.TableName = "ControlInfoDetail";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
