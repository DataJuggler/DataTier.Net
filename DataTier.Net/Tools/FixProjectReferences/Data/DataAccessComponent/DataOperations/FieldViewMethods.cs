

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.DataBridge;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class FieldViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'FieldView' object.
    /// </summary>
    public class FieldViewMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'FieldViewMethods' object.
        /// </summary>
        public FieldViewMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'FieldView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldView' to delete.
            /// <returns>A PolymorphicObject object with all  'FieldViews' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<FieldView> fieldViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllFieldViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get FieldViewParameter
                    // Declare Parameter
                    FieldView paramFieldView = null;

                    // verify the first parameters is a(n) 'FieldView'.
                    if (parameters[0].ObjectValue as FieldView != null)
                    {
                        // Get FieldViewParameter
                        paramFieldView = (FieldView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllFieldViewsProc from FieldViewWriter
                    fetchAllProc = FieldViewWriter.CreateFetchAllFieldViewsStoredProcedure(paramFieldView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    fieldViewListCollection = this.DataManager.FieldViewManager.FetchAllFieldViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(fieldViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = fieldViewListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
