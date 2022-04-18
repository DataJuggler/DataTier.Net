

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateControlInfoStoredProcedure
    /// <summary>
    /// This class is used to Update a 'ControlInfo' object.
    /// </summary>
    public class UpdateControlInfoStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateControlInfoStoredProcedure' object.
        /// </summary>
        public UpdateControlInfoStoredProcedure()
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
                this.ProcedureName = "ControlInfo_Update";

                // Set tableName
                this.TableName = "ControlInfo";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
