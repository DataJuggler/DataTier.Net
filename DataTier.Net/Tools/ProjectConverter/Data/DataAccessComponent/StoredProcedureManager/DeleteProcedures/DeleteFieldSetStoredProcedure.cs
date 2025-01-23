

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteFieldSetStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'FieldSet' object.
    /// </summary>
    public class DeleteFieldSetStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteFieldSetStoredProcedure' object.
        /// </summary>
        public DeleteFieldSetStoredProcedure()
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
                this.ProcedureName = "FieldSet_Delete";

                // Set tableName
                this.TableName = "FieldSet";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
