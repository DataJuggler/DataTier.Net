

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllCustomReadersStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'CustomReader' objects.
    /// </summary>
    public class FetchAllCustomReadersStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllCustomReadersStoredProcedure' object.
        /// </summary>
        public FetchAllCustomReadersStoredProcedure()
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
                this.ProcedureName = "CustomReader_FetchAll";

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
