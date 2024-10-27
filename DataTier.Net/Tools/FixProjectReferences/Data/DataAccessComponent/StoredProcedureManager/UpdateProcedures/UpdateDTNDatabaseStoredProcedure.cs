

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateDTNDatabaseStoredProcedure
    /// <summary>
    /// This class is used to Update a 'DTNDatabase' object.
    /// </summary>
    public class UpdateDTNDatabaseStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateDTNDatabaseStoredProcedure' object.
        /// </summary>
        public UpdateDTNDatabaseStoredProcedure()
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
                this.ProcedureName = "DTNDatabase_Update";

                // Set tableName
                this.TableName = "DTNDatabase";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
