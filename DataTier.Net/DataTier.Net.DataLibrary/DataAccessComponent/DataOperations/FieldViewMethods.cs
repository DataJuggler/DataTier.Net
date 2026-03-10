

#region using statements

using System;
using System.Collections.Generic;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class FieldViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'FieldView' object.
    /// </summary>
    public static class FieldViewMethods
    {

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'FieldView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldView' to delete.
            /// <returns>A PolymorphicObject object with all  'FieldViews' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                    fieldViewListCollection = FieldViewManager.FetchAllFieldViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(fieldViewListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = fieldViewListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return result;
            }
            #endregion

        #endregion

    }
    #endregion

}
