

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindUIObjectStoredProcedure
    /// <summary>
    /// This class is used to Find a 'UIObject' object.
    /// </summary>
    public class FindUIObjectStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindUIObjectStoredProcedure' object.
        /// </summary>
        public FindUIObjectStoredProcedure()
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
                this.ProcedureName = "UIObject_Find";

                // Set tableName
                this.TableName = "UIObject";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
