

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllUIObjectsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'UIObject' objects.
    /// </summary>
    public class FetchAllUIObjectsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllUIObjectsStoredProcedure' object.
        /// </summary>
        public FetchAllUIObjectsStoredProcedure()
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
                this.ProcedureName = "UIObject_FetchAll";

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
