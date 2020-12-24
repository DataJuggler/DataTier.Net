

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertUIFieldStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'UIField' object.
    /// </summary>
    public class InsertUIFieldStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertUIFieldStoredProcedure' object.
        /// </summary>
        public InsertUIFieldStoredProcedure()
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
                this.ProcedureName = "UIField_Insert";

                // Set tableName
                this.TableName = "UIField";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
