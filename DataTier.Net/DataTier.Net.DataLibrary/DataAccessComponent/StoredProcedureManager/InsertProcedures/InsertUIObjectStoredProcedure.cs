

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertUIObjectStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'UIObject' object.
    /// </summary>
    public class InsertUIObjectStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertUIObjectStoredProcedure' object.
        /// </summary>
        public InsertUIObjectStoredProcedure()
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
                this.ProcedureName = "UIObject_Insert";

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
