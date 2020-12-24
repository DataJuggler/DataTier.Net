

namespace DataAccessComponent.StoredProcedureManager.DeleteProcedures
{

    #region class DeleteProjectStoredProcedure
    /// <summary>
    /// This class is used to Delete a 'Project' object.
    /// </summary>
    public class DeleteProjectStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'DeleteProjectStoredProcedure' object.
        /// </summary>
        public DeleteProjectStoredProcedure()
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
                this.ProcedureName = "Project_Delete";

                // Set tableName
                this.TableName = "Project";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
