

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllReferencesSetsStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ReferencesSet' objects.
    /// </summary>
    public class FetchAllReferencesSetsStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllReferencesSetsStoredProcedure' object.
        /// </summary>
        public FetchAllReferencesSetsStoredProcedure()
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
                this.ProcedureName = "ReferencesSet_FetchAll";

                // Set tableName
                this.TableName = "ReferencesSet";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
