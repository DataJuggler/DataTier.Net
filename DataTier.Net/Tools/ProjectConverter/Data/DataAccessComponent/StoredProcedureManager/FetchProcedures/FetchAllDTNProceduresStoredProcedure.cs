

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllDTNProceduresStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'DTNProcedure' objects.
    /// </summary>
    public class FetchAllDTNProceduresStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllDTNProceduresStoredProcedure' object.
        /// </summary>
        public FetchAllDTNProceduresStoredProcedure()
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
                this.ProcedureName = "DTNProcedure_FetchAll";

                // Set tableName
                this.TableName = "DTNProcedure";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
