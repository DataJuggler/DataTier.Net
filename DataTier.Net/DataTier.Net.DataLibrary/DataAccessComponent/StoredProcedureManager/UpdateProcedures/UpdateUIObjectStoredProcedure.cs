

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateUIObjectStoredProcedure
    /// <summary>
    /// This class is used to Update a 'UIObject' object.
    /// </summary>
    public class UpdateUIObjectStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateUIObjectStoredProcedure' object.
        /// </summary>
        public UpdateUIObjectStoredProcedure()
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
                this.ProcedureName = "UIObject_Update";

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
