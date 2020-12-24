

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllUserInterfacesStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'UserInterface' objects.
    /// </summary>
    public class FetchAllUserInterfacesStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllUserInterfacesStoredProcedure' object.
        /// </summary>
        public FetchAllUserInterfacesStoredProcedure()
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
                this.ProcedureName = "UserInterface_FetchAll";

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
