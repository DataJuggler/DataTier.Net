

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllFieldSetFieldViewsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'FieldSetFieldView' objects.
    /// </summary>
    public class FetchAllFieldSetFieldViewsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllFieldSetFieldViewsStoredProcedure' object.
        /// </summary>
        public FetchAllFieldSetFieldViewsStoredProcedure()
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
                this.ProcedureName = "FieldSetFieldView_FetchAll";

                // Set tableName
                this.TableName = "FieldSetFieldView";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
