

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindFieldSetStoredProcedure
    /// <summary>
    /// This class is used to Find a 'FieldSet' object.
    /// </summary>
    public class FindFieldSetStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindFieldSetStoredProcedure' object.
        /// </summary>
        public FindFieldSetStoredProcedure()
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
                this.ProcedureName = "FieldSet_Find";

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
