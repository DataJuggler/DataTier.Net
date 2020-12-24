

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateProjectStoredProcedure
    /// <summary>
    /// This class is used to Update a 'Project' object.
    /// </summary>
    public class UpdateProjectStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateProjectStoredProcedure' object.
        /// </summary>
        public UpdateProjectStoredProcedure()
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
                this.ProcedureName = "Project_Update";

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
