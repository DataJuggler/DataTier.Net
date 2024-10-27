

#region using statements

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

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'AdminController' object.
        /// </summary>
        public AdminController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

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

            #region Delete(Admin tempAdmin)
            /// <summary>
            /// Deletes a 'Admin' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Admin_Delete'.
            /// </summary>
            /// <param name='admin'>The 'Admin' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Admin tempAdmin)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteAdmin";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempadmin exists before attemptintg to delete
                    if(tempAdmin != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteAdminMethod = this.AppController.DataBridge.DataOperations.AdminMethods.DeleteAdmin;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAdminParameter(tempAdmin);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteAdminMethod, parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(Admin tempAdmin)
            /// <summary>
            /// This method fetches a collection of 'Admin' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Admin_FetchAll'.</summary>
            /// <param name='tempAdmin'>A temporary Admin for passing values.</param>
            /// <returns>A collection of 'Admin' objects.</returns>
            public List<Admin> FetchAll(Admin tempAdmin)
            {
                // Initial value
                List<Admin> adminList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.AdminMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateAdminParameter(tempAdmin);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Admin> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        adminList = (List<Admin>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return adminList;
            }
            #endregion

            #region Find(Admin tempAdmin)
            /// <summary>
            /// Finds a 'Admin' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Admin_Find'</param>
            /// </summary>
            /// <param name='tempAdmin'>A temporary Admin for passing values.</param>
            /// <returns>A 'Admin' object if found else a null 'Admin'.</returns>
            public Admin Find(Admin tempAdmin)
            {
                // Initial values
                Admin admin = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempAdmin != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.AdminMethods.FindAdmin;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAdminParameter(tempAdmin);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return admin;
            }
            #endregion

            #region Insert(Admin admin)
            /// <summary>
            /// Insert a 'Admin' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Admin_Insert'.</param>
            /// </summary>
            /// <param name='admin'>The 'Admin' object to insert.</param>
            /// <returns>The id (int) of the new  'Admin' object that was inserted.</returns>
            public int Insert(Admin admin)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Adminexists
                    if(admin != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.AdminMethods.InsertAdmin;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAdminParameter(admin);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref Admin admin)
            /// <summary>
            /// Saves a 'Admin' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='admin'>The 'Admin' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Admin admin)
            {
                // Initial value
                bool saved = false;

                // If the admin exists.
                if(admin != null)
                {
                    // Is this a new Admin
                    if(admin.IsNew)
                    {
                        // Insert new Admin
                        int newIdentity = this.Insert(admin);

                        // if insert was successful
                        if(newIdentity > 0)
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
                        saved = this.Update(admin);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Admin admin)
            /// <summary>
            /// This method Updates a 'Admin' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Admin_Update'.</param>
            /// </summary>
            /// <param name='admin'>The 'Admin' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Admin admin)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(admin != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.AdminMethods.UpdateAdmin;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateAdminParameter(admin);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
