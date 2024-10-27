

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FindCustomReaderStoredProcedure
    /// <summary>
    /// This class is used to Find a 'CustomReader' object.
    /// </summary>
    public class FindCustomReaderStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FindCustomReaderStoredProcedure' object.
        /// </summary>
        public FindCustomReaderStoredProcedure()
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
                this.ProcedureName = "CustomReader_Find";

                // Set tableName
                this.TableName = "CustomReader";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
