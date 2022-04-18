

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllControlInfoDetailsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ControlInfoDetail' objects.
    /// </summary>
    public class FetchAllControlInfoDetailsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllControlInfoDetailsStoredProcedure' object.
        /// </summary>
        public FetchAllControlInfoDetailsStoredProcedure()
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
                this.ProcedureName = "ControlInfoDetail_FetchAll";

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
