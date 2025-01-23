

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateFieldSetFieldStoredProcedure
    /// <summary>
    /// This class is used to Update a 'FieldSetField' object.
    /// </summary>
    public class UpdateFieldSetFieldStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateFieldSetFieldStoredProcedure' object.
        /// </summary>
        public UpdateFieldSetFieldStoredProcedure()
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
                this.ProcedureName = "FieldSetField_Update";

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
