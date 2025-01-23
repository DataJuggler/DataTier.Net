

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllDTNFieldsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'DTNField' objects.
    /// </summary>
    public class FetchAllDTNFieldsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllDTNFieldsStoredProcedure' object.
        /// </summary>
        public FetchAllDTNFieldsStoredProcedure()
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
                this.ProcedureName = "DTNField_FetchAll";

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
