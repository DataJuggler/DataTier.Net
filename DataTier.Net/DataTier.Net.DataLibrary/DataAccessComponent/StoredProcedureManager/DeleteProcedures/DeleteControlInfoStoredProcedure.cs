

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteControlInfoStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'ControlInfo' object.
    /// </summary>
    public class DeleteControlInfoStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteControlInfoStoredProcedure' object.
        /// </summary>
        public DeleteControlInfoStoredProcedure()
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
                this.ProcedureName = "ControlInfo_Delete";

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
