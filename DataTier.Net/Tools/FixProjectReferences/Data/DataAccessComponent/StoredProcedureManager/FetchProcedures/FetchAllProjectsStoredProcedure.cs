

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllProjectsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'Project' objects.
    /// </summary>
    public class FetchAllProjectsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllProjectsStoredProcedure' object.
        /// </summary>
        public FetchAllProjectsStoredProcedure()
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
                this.ProcedureName = "Project_FetchAll";

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
