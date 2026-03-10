

#region using statements

using System;
using System.Collections.Generic;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.Logging;
using DataAccessComponent.DataOperations;
using DataAccessComponent.DataBridge;
using DataAccessComponent.Data;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class EnumerationController
    /// <summary>
    /// This class controls a(n) 'Enumeration' object.
    /// </summary>
    public class EnumerationController
    {

        #region Methods

            #region CreateEnumerationParameter
            /// <summary>
            /// This method creates the parameter for a 'Enumeration' data operation.
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateEnumerationParameter(Enumeration enumeration)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = enumeration;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Enumeration tempEnumeration, DataManager dataManager)
            /// <summary>
            /// Deletes a 'Enumeration' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'Enumeration_Delete'.
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static PolymorphicObject Delete(Enumeration tempEnumeration, DataManager dataManager)
            {
                // initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteEnumeration";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempenumeration exists before attemptintg to delete
                    if (tempEnumeration != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteEnumerationMethod = EnumerationMethods.DeleteEnumeration;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateEnumerationParameter(tempEnumeration);

                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteEnumerationMethod, parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
            }
            #endregion

            #region FetchAll(Enumeration tempEnumeration, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'Enumeration' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Enumeration_FetchAll'.</summary>
            /// <param name='tempEnumeration'>A temporary Enumeration for passing values.</param>
            /// <returns>A collection of 'Enumeration' objects.</returns>
            public static List<Enumeration> FetchAll(Enumeration tempEnumeration, DataManager dataManager)
            {
                // Initial value
                List<Enumeration> enumerationList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = EnumerationMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateEnumerationParameter(tempEnumeration);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Enumeration> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        enumerationList = (List<Enumeration>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return enumerationList;
            }
            #endregion

            #region Find(Enumeration tempEnumeration, DataManager dataManager)
            /// <summary>
            /// Finds a 'Enumeration' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Enumeration_Find'</param>
            /// </summary>
            /// <param name='tempEnumeration'>A temporary Enumeration for passing values.</param>
            /// <returns>A 'Enumeration' object if found else a null 'Enumeration'.</returns>
            public static Enumeration Find(Enumeration tempEnumeration, DataManager dataManager)
            {
                // Initial values
                Enumeration enumeration = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempEnumeration != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = EnumerationMethods.FindEnumeration;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateEnumerationParameter(tempEnumeration);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Enumeration != null))
                        {
                            // Get ReturnObject
                            enumeration = (Enumeration) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return enumeration;
            }
            #endregion

            #region Insert(Enumeration enumeration, DataManager dataManager)
            /// <summary>
            /// Insert a 'Enumeration' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Enumeration_Insert'.</param>
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' object to insert.</param>
            /// <returns>The a PolymorphicObject. This object contains an IntegerValue, which is the Identity value for the new 'Enumeration' object that was inserted.</returns>
            public static PolymorphicObject Insert(Enumeration enumeration, DataManager dataManager)
            {
                // Initial values
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If Enumerationexists
                    if (enumeration != null)
                    {
                        // Create the delegate to perform the insert
                        ApplicationController.DataOperationMethod insertMethod = EnumerationMethods.InsertEnumeration;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateEnumerationParameter(enumeration);

                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, insertMethod , parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
            }
            #endregion

            #region Save(ref Enumeration enumeration, DataManager dataManager)
            /// <summary>
            /// Saves a 'Enumeration' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static PolymorphicObject Save(ref Enumeration enumeration, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // If the enumeration exists.
                if (enumeration != null)
                {
                    // Is this a new Enumeration
                    if (enumeration.IsNew)
                    {
                        // Insert new Enumeration
                        result = Insert(enumeration, dataManager);

                        // if the insert was successful
                        if (result.HasIntegerValue)
                        {
                            // Update Identity
                            enumeration.UpdateIdentity(result.IntegerValue);

                        }
                    }
                    else
                    {
                        // Update Enumeration
                        result  = Update(enumeration, dataManager);
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region Update(Enumeration enumeration, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'Enumeration' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Enumeration_Update'.</param>
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static PolymorphicObject Update(Enumeration enumeration, DataManager dataManager)
            {
                // Initial value
                PolymorphicObject result = new PolymorphicObject();

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (enumeration != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = EnumerationMethods.UpdateEnumeration;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateEnumerationParameter(enumeration);
                        // Perform DataOperation
                        result = DataBridgeManager.PerformDataOperation(methodName, objectName, updateMethod , parameters, dataManager);
                    }
                }
                catch (Exception error)
                {
                    // Log the error
                    ErrorHandler.LogError(methodName, objectName, error);
                }

                // return value
                return result;
            }
            #endregion

        #endregion

    }
    #endregion

}
