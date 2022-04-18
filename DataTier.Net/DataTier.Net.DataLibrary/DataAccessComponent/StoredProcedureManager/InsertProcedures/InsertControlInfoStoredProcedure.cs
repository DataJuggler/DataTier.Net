

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertControlInfoStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'ControlInfo' object.
    /// </summary>
    public class InsertControlInfoStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertControlInfoStoredProcedure' object.
        /// </summary>
        public InsertControlInfoStoredProcedure()
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
                this.ProcedureName = "ControlInfo_Insert";

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
