

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertEnumerationStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'Enumeration' object.
    /// </summary>
    public class InsertEnumerationStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertEnumerationStoredProcedure' object.
        /// </summary>
        public InsertEnumerationStoredProcedure()
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
                this.ProcedureName = "Enumeration_Insert";

                // Set tableName
                this.TableName = "Enumeration";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
