

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllFieldSetFieldsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'FieldSetField' objects.
    /// </summary>
    public class FetchAllFieldSetFieldsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllFieldSetFieldsStoredProcedure' object.
        /// </summary>
        public FetchAllFieldSetFieldsStoredProcedure()
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
                this.ProcedureName = "FieldSetField_FetchAll";

                // Set tableName
                this.TableName = "FieldSetField";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
