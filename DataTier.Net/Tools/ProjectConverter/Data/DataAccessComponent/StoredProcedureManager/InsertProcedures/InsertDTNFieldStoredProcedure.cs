

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertDTNFieldStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'DTNField' object.
    /// </summary>
    public class InsertDTNFieldStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertDTNFieldStoredProcedure' object.
        /// </summary>
        public InsertDTNFieldStoredProcedure()
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
                this.ProcedureName = "DTNField_Insert";

                // Set tableName
                this.TableName = "DTNField";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
