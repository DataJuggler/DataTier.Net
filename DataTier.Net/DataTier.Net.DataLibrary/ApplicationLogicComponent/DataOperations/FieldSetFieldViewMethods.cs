

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class FieldSetFieldViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'FieldSetFieldView' object.
    /// </summary>
    public class FieldSetFieldViewMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'FieldSetFieldViewMethods' object.
        /// </summary>
        public FieldSetFieldViewMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'FieldSetFieldView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSetFieldView' to delete.
            /// <returns>A PolymorphicObject object with all  'FieldSetFieldViews' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<FieldSetFieldView> fieldSetFieldViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllFieldSetFieldViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get FieldSetFieldViewParameter
                    // Declare Parameter
                    FieldSetFieldView paramFieldSetFieldView = null;

                    // verify the first parameters is a(n) 'FieldSetFieldView'.
                    if (parameters[0].ObjectValue as FieldSetFieldView != null)
                    {
                        // Get FieldSetFieldViewParameter
                        paramFieldSetFieldView = (FieldSetFieldView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllFieldSetFieldViewsProc from FieldSetFieldViewWriter
                    fetchAllProc = FieldSetFieldViewWriter.CreateFetchAllFieldSetFieldViewsStoredProcedure(paramFieldSetFieldView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    fieldSetFieldViewListCollection = this.DataManager.FieldSetFieldViewManager.FetchAllFieldSetFieldViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(fieldSetFieldViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = fieldSetFieldViewListCollection;
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
