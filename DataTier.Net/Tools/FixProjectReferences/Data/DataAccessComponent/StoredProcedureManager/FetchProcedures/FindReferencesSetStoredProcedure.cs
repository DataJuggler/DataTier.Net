

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindReferencesSetStoredProcedure
    /// <summary>
    /// This class is used to Find a 'ReferencesSet' object.
    /// </summary>
    public class FindReferencesSetStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindReferencesSetStoredProcedure' object.
        /// </summary>
        public FindReferencesSetStoredProcedure()
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
                this.ProcedureName = "ReferencesSet_Find";

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
