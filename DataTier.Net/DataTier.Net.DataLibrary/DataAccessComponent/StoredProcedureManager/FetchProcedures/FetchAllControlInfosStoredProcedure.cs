

namespace DataAccessComponent.StoredProcedureManager.FetchProcedures
{

    #region class FetchAllControlInfosStoredProcedure
    /// <summary>
    /// This class is used to FetchAll 'ControlInfo' objects.
    /// </summary>
    public class FetchAllControlInfosStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'FetchAllControlInfosStoredProcedure' object.
        /// </summary>
        public FetchAllControlInfosStoredProcedure()
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
                this.ProcedureName = "ControlInfo_FetchAll";

                // Set tableName
                this.TableName = "ControlInfo";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
