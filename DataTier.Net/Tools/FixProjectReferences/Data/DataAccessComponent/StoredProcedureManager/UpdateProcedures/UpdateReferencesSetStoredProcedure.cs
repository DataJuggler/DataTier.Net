

namespace DataAccessComponent.StoredProcedureManager.UpdateProcedures
{

    #region class UpdateReferencesSetStoredProcedure
    /// <summary>
    /// This class is used to Update a 'ReferencesSet' object.
    /// </summary>
    public class UpdateReferencesSetStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'UpdateReferencesSetStoredProcedure' object.
        /// </summary>
        public UpdateReferencesSetStoredProcedure()
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
                this.ProcedureName = "ReferencesSet_Update";

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
