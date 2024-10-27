

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllFieldSetsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'FieldSet' objects.
    /// </summary>
    public class FetchAllFieldSetsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllFieldSetsStoredProcedure' object.
        /// </summary>
        public FetchAllFieldSetsStoredProcedure()
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
                this.ProcedureName = "FieldSet_FetchAll";

                // Set tableName
                this.TableName = "FieldSet";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
