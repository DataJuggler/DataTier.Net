

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllFieldViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'FieldView' objects.
    /// </summary>
    public class FetchAllFieldViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllFieldViewsStoredProcedure' object.
        /// </summary>
        public FetchAllFieldViewsStoredProcedure()
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
                this.ProcedureName = "FieldView_FetchAll";

                // Set tableName
                this.TableName = "FieldView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
