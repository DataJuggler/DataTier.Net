

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

    #region class EnumerationController
    /// <summary>
    /// This class controls a(n) 'Enumeration' object.
    /// </summary>
    public class EnumerationController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'EnumerationController' object.
        /// </summary>
        public EnumerationController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateEnumerationParameter
            /// <summary>
            /// This method creates the parameter for a 'Enumeration' data operation.
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateEnumerationParameter(Enumeration enumeration)
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

            #region Delete(Enumeration tempEnumeration)
            /// <summary>
            /// Deletes a 'Enumeration' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'Enumeration_Delete'.
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(Enumeration tempEnumeration)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteEnumeration";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempenumeration exists before attemptintg to delete
                    if(tempEnumeration != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteEnumerationMethod = this.AppController.DataBridge.DataOperations.EnumerationMethods.DeleteEnumeration;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateEnumerationParameter(tempEnumeration);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteEnumerationMethod, parameters);

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

            #region FetchAll(Enumeration tempEnumeration)
            /// <summary>
            /// This method fetches a collection of 'Enumeration' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'Enumeration_FetchAll'.</summary>
            /// <param name='tempEnumeration'>A temporary Enumeration for passing values.</param>
            /// <returns>A collection of 'Enumeration' objects.</returns>
            public List<Enumeration> FetchAll(Enumeration tempEnumeration)
            {
                // Initial value
                List<Enumeration> enumerationList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.EnumerationMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateEnumerationParameter(tempEnumeration);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<Enumeration> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        enumerationList = (List<Enumeration>) returnObject.ObjectValue;
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
                return enumerationList;
            }
            #endregion

            #region Find(Enumeration tempEnumeration)
            /// <summary>
            /// Finds a 'Enumeration' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'Enumeration_Find'</param>
            /// </summary>
            /// <param name='tempEnumeration'>A temporary Enumeration for passing values.</param>
            /// <returns>A 'Enumeration' object if found else a null 'Enumeration'.</returns>
            public Enumeration Find(Enumeration tempEnumeration)
            {
                // Initial values
                Enumeration enumeration = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempEnumeration != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.EnumerationMethods.FindEnumeration;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateEnumerationParameter(tempEnumeration);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

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
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return enumeration;
            }
            #endregion

            #region Insert(Enumeration enumeration)
            /// <summary>
            /// Insert a 'Enumeration' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'Enumeration_Insert'.</param>
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' object to insert.</param>
            /// <returns>The id (int) of the new  'Enumeration' object that was inserted.</returns>
            public int Insert(Enumeration enumeration)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If Enumerationexists
                    if(enumeration != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.EnumerationMethods.InsertEnumeration;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateEnumerationParameter(enumeration);

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

            #region Save(ref Enumeration enumeration)
            /// <summary>
            /// Saves a 'Enumeration' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref Enumeration enumeration)
            {
                // Initial value
                bool saved = false;

                // If the enumeration exists.
                if(enumeration != null)
                {
                    // Is this a new Enumeration
                    if(enumeration.IsNew)
                    {
                        // Insert new Enumeration
                        int newIdentity = this.Insert(enumeration);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            enumeration.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update Enumeration
                        saved = this.Update(enumeration);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(Enumeration enumeration)
            /// <summary>
            /// This method Updates a 'Enumeration' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'Enumeration_Update'.</param>
            /// </summary>
            /// <param name='enumeration'>The 'Enumeration' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(Enumeration enumeration)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(enumeration != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.EnumerationMethods.UpdateEnumeration;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateEnumerationParameter(enumeration);
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
