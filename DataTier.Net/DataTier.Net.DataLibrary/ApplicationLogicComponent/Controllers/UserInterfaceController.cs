

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;
using DataJuggler.Net.Enumerations;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class UserInterfaceController
    /// <summary>
    /// This class controls a(n) 'UserInterface' object.
    /// </summary>
    public class UserInterfaceController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'UserInterfaceController' object.
        /// </summary>
        public UserInterfaceController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateUserInterfaceParameter
            /// <summary>
            /// This method creates the parameter for a 'UserInterface' data operation.
            /// </summary>
            /// <param name='userinterface'>The 'UserInterface' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateUserInterfaceParameter(UserInterface userInterface)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = userInterface;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(UserInterface tempUserInterface)
            /// <summary>
            /// Deletes a 'UserInterface' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'UserInterface_Delete'.
            /// </summary>
            /// <param name='userinterface'>The 'UserInterface' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(UserInterface tempUserInterface)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteUserInterface";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempuserInterface exists before attemptintg to delete
                    if(tempUserInterface != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteUserInterfaceMethod = this.AppController.DataBridge.DataOperations.UserInterfaceMethods.DeleteUserInterface;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUserInterfaceParameter(tempUserInterface);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteUserInterfaceMethod, parameters);

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

            #region FetchAll(UserInterface tempUserInterface)
            /// <summary>
            /// This method fetches a collection of 'UserInterface' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'UserInterface_FetchAll'.</summary>
            /// <param name='tempUserInterface'>A temporary UserInterface for passing values.</param>
            /// <returns>A collection of 'UserInterface' objects.</returns>
            public List<UserInterface> FetchAll(UserInterface tempUserInterface)
            {
                // Initial value
                List<UserInterface> userInterfaceList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.UserInterfaceMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateUserInterfaceParameter(tempUserInterface);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<UserInterface> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        userInterfaceList = (List<UserInterface>) returnObject.ObjectValue;
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
                return userInterfaceList;
            }
            #endregion

            #region Find(UserInterface tempUserInterface)
            /// <summary>
            /// Finds a 'UserInterface' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'UserInterface_Find'</param>
            /// </summary>
            /// <param name='tempUserInterface'>A temporary UserInterface for passing values.</param>
            /// <returns>A 'UserInterface' object if found else a null 'UserInterface'.</returns>
            public UserInterface Find(UserInterface tempUserInterface)
            {
                // Initial values
                UserInterface userInterface = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempUserInterface != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.UserInterfaceMethods.FindUserInterface;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUserInterfaceParameter(tempUserInterface);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as UserInterface != null))
                        {
                            // Get ReturnObject
                            userInterface = (UserInterface) returnObject.ObjectValue;
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
                return userInterface;
            }
            #endregion

            #region Insert(UserInterface userInterface)
            /// <summary>
            /// Insert a 'UserInterface' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'UserInterface_Insert'.</param>
            /// </summary>
            /// <param name='userInterface'>The 'UserInterface' object to insert.</param>
            /// <returns>The id (int) of the new  'UserInterface' object that was inserted.</returns>
            public int Insert(UserInterface userInterface)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If UserInterfaceexists
                    if(userInterface != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.UserInterfaceMethods.InsertUserInterface;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUserInterfaceParameter(userInterface);

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

            #region Save(ref UserInterface userInterface)
            /// <summary>
            /// Saves a 'UserInterface' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='userInterface'>The 'UserInterface' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref UserInterface userInterface)
            {
                // Initial value
                bool saved = false;

                // If the userInterface exists.
                if(userInterface != null)
                {
                    // Is this a new UserInterface
                    if(userInterface.IsNew)
                    {
                        // Insert new UserInterface
                        int newIdentity = this.Insert(userInterface);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            userInterface.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update UserInterface
                        saved = this.Update(userInterface);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(UserInterface userInterface)
            /// <summary>
            /// This method Updates a 'UserInterface' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'UserInterface_Update'.</param>
            /// </summary>
            /// <param name='userInterface'>The 'UserInterface' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(UserInterface userInterface)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(userInterface != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.UserInterfaceMethods.UpdateUserInterface;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateUserInterfaceParameter(userInterface);
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
