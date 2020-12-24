

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteEnumerationStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Enumeration' object.
    /// </summary>
    public class DeleteEnumerationStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteEnumerationStoredProcedure' object.
        /// </summary>
        public DeleteEnumerationStoredProcedure()
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
                this.ProcedureName = "Enumeration_Delete";

                // Set tableName
                this.TableName = "Enumeration";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
