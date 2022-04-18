

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertControlInfoDetailStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'ControlInfoDetail' object.
    /// </summary>
    public class InsertControlInfoDetailStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertControlInfoDetailStoredProcedure' object.
        /// </summary>
        public InsertControlInfoDetailStoredProcedure()
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
                this.ProcedureName = "ControlInfoDetail_Insert";

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
