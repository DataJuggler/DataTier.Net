

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

    #region class FieldSetFieldViewController
    /// <summary>
    /// This class controls a(n) 'FieldSetFieldView' object.
    /// </summary>
    public class FieldSetFieldViewController
    {

        #region Methods

            #region CreateFieldSetFieldViewParameter
            /// <summary>
            /// This method creates the parameter for a 'FieldSetFieldView' data operation.
            /// </summary>
            /// <param name='fieldsetfieldview'>The 'FieldSetFieldView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateFieldSetFieldViewParameter(FieldSetFieldView fieldSetFieldView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = fieldSetFieldView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(FieldSetFieldView tempFieldSetFieldView, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'FieldSetFieldView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'FieldSetFieldView_FetchAll'.</summary>
            /// <param name='tempFieldSetFieldView'>A temporary FieldSetFieldView for passing values.</param>
            /// <returns>A collection of 'FieldSetFieldView' objects.</returns>
            public static List<FieldSetFieldView> FetchAll(FieldSetFieldView tempFieldSetFieldView, DataManager dataManager)
            {
                // Initial value
                List<FieldSetFieldView> fieldSetFieldViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = FieldSetFieldViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateFieldSetFieldViewParameter(tempFieldSetFieldView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<FieldSetFieldView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        fieldSetFieldViewList = (List<FieldSetFieldView>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return fieldSetFieldViewList;
            }
            #endregion

        #endregion

    }
    #endregion

}
