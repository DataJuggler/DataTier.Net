

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertReferencesSetStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'ReferencesSet' object.
    /// </summary>
    public class InsertReferencesSetStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertReferencesSetStoredProcedure' object.
        /// </summary>
        public InsertReferencesSetStoredProcedure()
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
                this.ProcedureName = "ReferencesSet_Insert";

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
