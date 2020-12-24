

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindUserInterfaceStoredProcedure
    /// <summary>
    /// This class is used to Find a 'UserInterface' object.
    /// </summary>
    public class FindUserInterfaceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindUserInterfaceStoredProcedure' object.
        /// </summary>
        public FindUserInterfaceStoredProcedure()
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
                this.ProcedureName = "UserInterface_Find";

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
