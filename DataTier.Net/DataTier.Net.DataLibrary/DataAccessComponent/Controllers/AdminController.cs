

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

    #region class AdminController
    /// <summary>
    /// This class controls a(n) 'Admin' object.
    /// </summary>
    public class AdminController
    {

        #region Methods

            #region CreateAdminParameter
            /// <summary>
            /// This method creates the parameter for a 'Admin' data operation.
            /// </summary>
            /// <param name='admin'>The 'Admin' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateAdminParameter(Admin admin)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = admin;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Admin tempAdmin, DataManager dataManager)
            /// <summary>
            /// Deletes a 'Admin' from the database
            /// This method calls the DataBridgeManager to execute the delete
            /// procedure 'Admin_Delete'.
            /// </summary>
            /// <param name='admin'>The 'Admin' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public static bool Delete(Admin tempAdmin, DataManager dataManager)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteAdmin";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // verify tempadmin exists before attemptintg to delete
                    if (tempAdmin != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteAdminMethod = AdminMethods.DeleteAdmin;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAdminParameter(tempAdmin);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, deleteAdminMethod, parameters, dataManager);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // if the dataManager exists and has an ErrorHandler
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Log the error
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(Admin tempAdmin, DataManager dataManager)
            /// <summary>
            /// This method fetches a collection of 'Admin' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Admin_FetchAll'.</summary>
            /// <param name='tempAdmin'>A temporary Admin for passing values.</param>
            /// <returns>A collection of 'Admin' objects.</returns>
            public static List<Admin> FetchAll(Admin tempAdmin, DataManager dataManager)
            {
                // Initial value
                List<Admin> adminList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = AdminMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateAdminParameter(tempAdmin);

                    // Perform DataOperation
                    PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters, dataManager);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Admin> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        adminList = (List<Admin>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // if the dataManager exists and has an ErrorHandler
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Log the error
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return adminList;
            }
            #endregion

            #region Find(Admin tempAdmin, DataManager dataManager)
            /// <summary>
            /// Finds a 'Admin' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Admin_Find'</param>
            /// </summary>
            /// <param name='tempAdmin'>A temporary Admin for passing values.</param>
            /// <returns>A 'Admin' object if found else a null 'Admin'.</returns>
            public static Admin Find(Admin tempAdmin, DataManager dataManager)
            {
                // Initial values
                Admin admin = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If object exists
                    if (tempAdmin != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = AdminMethods.FindAdmin;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAdminParameter(tempAdmin);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, findMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Admin != null))
                        {
                            // Get ReturnObject
                            admin = (Admin) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // if the dataManager exists and has an ErrorHandler
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Log the error
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return admin;
            }
            #endregion

            #region Insert(Admin admin, DataManager dataManager)
            /// <summary>
            /// Insert a 'Admin' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Admin_Insert'.</param>
            /// </summary>
            /// <param name='admin'>The 'Admin' object to insert.</param>
            /// <returns>The id (int) of the new  'Admin' object that was inserted.</returns>
            public static int Insert(Admin admin, DataManager dataManager)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    // If Adminexists
                    if (admin != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = AdminMethods.InsertAdmin;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAdminParameter(admin);

                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, insertMethod , parameters, dataManager);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // if the dataManager exists and has an ErrorHandler
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Log the error
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref Admin admin, DataManager dataManager)
            /// <summary>
            /// Saves a 'Admin' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='admin'>The 'Admin' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public static bool Save(ref Admin admin, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // If the admin exists.
                if (admin != null)
                {
                    // Is this a new Admin
                    if (admin.IsNew)
                    {
                        // Insert new Admin
                        int newIdentity = Insert(admin, dataManager);

                        // if insert was successful
                        if (newIdentity > 0)
                        {
                            // Update Identity
                            admin.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Admin
                        saved = Update(admin, dataManager);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Admin admin, DataManager dataManager)
            /// <summary>
            /// This method Updates a 'Admin' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Admin_Update'.</param>
            /// </summary>
            /// <param name='admin'>The 'Admin' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public static bool Update(Admin admin, DataManager dataManager)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "DataAccessComponent.Controllers";

                try
                {
                    if (admin != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = AdminMethods.UpdateAdmin;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAdminParameter(admin);
                        // Perform DataOperation
                        PolymorphicObject returnObject = DataBridgeManager.PerformDataOperation(methodName, objectName, updateMethod , parameters, dataManager);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // if the dataManager exists and has an ErrorHandler
                    if ((dataManager != null) && (dataManager.HasErrorHandler))
                    {
                        // Log the error
                        dataManager.ErrorHandler.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

    }
    #endregion

}