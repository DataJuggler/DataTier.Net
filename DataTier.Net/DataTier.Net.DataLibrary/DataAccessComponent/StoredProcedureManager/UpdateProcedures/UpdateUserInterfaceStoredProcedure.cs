

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateUserInterfaceStoredProcedure
    /// <summary>
    /// This class is used to Update a 'UserInterface' object.
    /// </summary>
    public class UpdateUserInterfaceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateUserInterfaceStoredProcedure' object.
        /// </summary>
        public UpdateUserInterfaceStoredProcedure()
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
                this.ProcedureName = "UserInterface_Update";

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
