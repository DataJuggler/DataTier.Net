

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class FieldViewController
    /// <summary>
    /// This class controls a(n) 'FieldView' object.
    /// </summary>
    public class FieldViewController
    {

        #region Methods

            #region CreateFieldViewParameter
            /// <summary>
            /// This method creates the parameter for a 'FieldView' data operation.
            /// </summary>
            /// <param name='fieldview'>The 'FieldView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateFieldViewParameter(FieldView fieldView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = fieldView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(FieldView tempFieldView, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'FieldView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'FieldView_FetchAll'.</summary>
            /// <param name='tempFieldView'>A temporary FieldView for passing values.</param>
            /// <returns>A collection of 'FieldView' objects.</returns>
            public static List<FieldView> FetchAll(FieldView tempFieldView, DataManager dataManager)
            {
                // Initial value
                List<FieldView> fieldViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = FieldViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateFieldViewParameter(tempFieldView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<FieldView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        fieldViewList = (List<FieldView>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return fieldViewList;
            }
            #endregion

        #endregion

    }
    #endregion

}
