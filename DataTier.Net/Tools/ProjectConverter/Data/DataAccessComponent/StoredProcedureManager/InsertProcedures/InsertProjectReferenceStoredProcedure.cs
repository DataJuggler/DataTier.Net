

namespace DataAccessComponent.StoredProcedureManager.InsertProcedures
{

    #region class InsertProjectReferenceStoredProcedure
    /// <summary>
    /// This class is used to Insert a 'ProjectReference' object.
    /// </summary>
    public class InsertProjectReferenceStoredProcedure : StoredProcedure
    {

        #region Private Variables
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a 'InsertProjectReferenceStoredProcedure' object.
        /// </summary>
        public InsertProjectReferenceStoredProcedure()
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
                this.ProcedureName = "ProjectReference_Insert";

                // Set tableName
                this.TableName = "ProjectReference";
            }
            #endregion

        #endregion

        #region Properties

        #endregion

    }
    #endregion

}
