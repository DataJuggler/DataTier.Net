

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteUserInterfaceStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'UserInterface' object.
    /// </summary>
    public class DeleteUserInterfaceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteUserInterfaceStoredProcedure' object.
        /// </summary>
        public DeleteUserInterfaceStoredProcedure()
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
                this.ProcedureName = "UserInterface_Delete";

                // Set tableName
                this.TableName = "UserInterface";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
