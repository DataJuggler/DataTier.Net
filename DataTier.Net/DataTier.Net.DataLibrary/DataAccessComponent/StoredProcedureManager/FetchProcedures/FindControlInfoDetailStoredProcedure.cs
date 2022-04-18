

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindControlInfoDetailStoredProcedure
    /// <summary>
    /// This class is used to Find a 'ControlInfoDetail' object.
    /// </summary>
    public class FindControlInfoDetailStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindControlInfoDetailStoredProcedure' object.
        /// </summary>
        public FindControlInfoDetailStoredProcedure()
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
                this.ProcedureName = "ControlInfoDetail_Find";

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
