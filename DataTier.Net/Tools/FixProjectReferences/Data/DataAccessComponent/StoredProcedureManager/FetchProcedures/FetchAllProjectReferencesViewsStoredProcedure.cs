

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllProjectReferencesViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ProjectReferencesView' objects.
    /// </summary>
    public class FetchAllProjectReferencesViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllProjectReferencesViewsStoredProcedure' object.
        /// </summary>
        public FetchAllProjectReferencesViewsStoredProcedure()
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
                this.ProcedureName = "ProjectReferencesView_FetchAll";

                // Set tableName
                this.TableName = "ProjectReferencesView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
