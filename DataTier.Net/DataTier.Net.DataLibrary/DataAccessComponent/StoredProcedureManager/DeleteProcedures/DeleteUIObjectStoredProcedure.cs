

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteUIObjectStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'UIObject' object.
    /// </summary>
    public class DeleteUIObjectStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteUIObjectStoredProcedure' object.
        /// </summary>
        public DeleteUIObjectStoredProcedure()
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
                this.ProcedureName = "UIObject_Delete";

                // Set tableName
                this.TableName = "UIObject";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
