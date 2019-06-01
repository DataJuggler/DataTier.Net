

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class MethodController
    /// <summary>
    /// This class controls a(n) 'Method' object.
    /// </summary>
    public class MethodController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'MethodController' object.
        /// </summary>
        public MethodController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateMethodParameter
            /// <summary>
            /// This method creates the parameter for a 'Method' data operation.
            /// </summary>
            /// <param name='method'>The 'Method' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateMethodParameter(Method method)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = method;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(Method tempMethod)
            /// <summary>
            /// Deletes a 'Method' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Method_Delete'.
            /// </summary>
            /// <param name='method'>The 'Method' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Method tempMethod)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteMethod";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempmethod exists before attemptintg to delete
                    if(tempMethod != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteMethodMethod = this.AppController.DataBridge.DataOperations.MethodMethods.DeleteMethod;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateMethodParameter(tempMethod);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteMethodMethod, parameters);

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

            #region FetchAll(Method tempMethod)
            /// <summary>
            /// This method fetches a collection of 'Method' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Method_FetchAll'.</summary>
            /// <param name='tempMethod'>A temporary Method for passing values.</param>
            /// <returns>A collection of 'Method' objects.</returns>
            public List<Method> FetchAll(Method tempMethod)
            {
                // Initial value
                List<Method> methodList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.MethodMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateMethodParameter(tempMethod);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Method> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        methodList = (List<Method>) returnObject.ObjectValue;
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
                return methodList;
            }
            #endregion

            #region Find(Method tempMethod)
            /// <summary>
            /// Finds a 'Method' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Method_Find'</param>
            /// </summary>
            /// <param name='tempMethod'>A temporary Method for passing values.</param>
            /// <returns>A 'Method' object if found else a null 'Method'.</returns>
            public Method Find(Method tempMethod)
            {
                // Initial values
                Method method = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempMethod != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.MethodMethods.FindMethod;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateMethodParameter(tempMethod);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as Method != null))
                        {
                            // Get ReturnObject
                            method = (Method) returnObject.ObjectValue;
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
                return method;
            }
            #endregion

            #region Insert(Method method)
            /// <summary>
            /// Insert a 'Method' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Method_Insert'.</param>
            /// </summary>
            /// <param name='method'>The 'Method' object to insert.</param>
            /// <returns>The id (int) of the new  'Method' object that was inserted.</returns>
            public int Insert(Method method)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Methodexists
                    if(method != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.MethodMethods.InsertMethod;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateMethodParameter(method);

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

            #region Save(ref Method method)
            /// <summary>
            /// Saves a 'Method' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='method'>The 'Method' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Method method)
            {
                // Initial value
                bool saved = false;

                // If the method exists.
                if(method != null)
                {
                    // Is this a new Method
                    if(method.IsNew)
                    {
                        // Insert new Method
                        int newIdentity = this.Insert(method);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            method.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Method
                        saved = this.Update(method);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Method method)
            /// <summary>
            /// This method Updates a 'Method' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Method_Update'.</param>
            /// </summary>
            /// <param name='method'>The 'Method' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Method method)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(method != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.MethodMethods.UpdateMethod;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateMethodParameter(method);
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
