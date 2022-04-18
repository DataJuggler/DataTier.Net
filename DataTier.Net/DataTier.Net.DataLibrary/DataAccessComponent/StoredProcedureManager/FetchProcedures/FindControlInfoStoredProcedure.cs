

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindControlInfoStoredProcedure
    /// <summary>
    /// This class is used to Find a 'ControlInfo' object.
    /// </summary>
    public class FindControlInfoStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindControlInfoStoredProcedure' object.
        /// </summary>
        public FindControlInfoStoredProcedure()
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
                this.ProcedureName = "ControlInfo_Find";

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
