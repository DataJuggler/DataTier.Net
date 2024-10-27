

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

    #region class DTNDatabaseController
    /// <summary>
    /// This class controls a(n) 'DTNDatabase' object.
    /// </summary>
    public class DTNDatabaseController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'DTNDatabaseController' object.
        /// </summary>
        public DTNDatabaseController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateDTNDatabaseParameter
            /// <summary>
            /// This method creates the parameter for a 'DTNDatabase' data operation.
            /// </summary>
            /// <param name='dtndatabase'>The 'DTNDatabase' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateDTNDatabaseParameter(DTNDatabase dTNDatabase)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = dTNDatabase;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(DTNDatabase tempDTNDatabase)
            /// <summary>
            /// Deletes a 'DTNDatabase' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'DTNDatabase_Delete'.
            /// </summary>
            /// <param name='dtndatabase'>The 'DTNDatabase' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(DTNDatabase tempDTNDatabase)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDTNDatabase";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempdTNDatabase exists before attemptintg to delete
                    if(tempDTNDatabase != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDTNDatabaseMethod = this.AppController.DataBridge.DataOperations.DTNDatabaseMethods.DeleteDTNDatabase;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(tempDTNDatabase);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteDTNDatabaseMethod, parameters);

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

            #region FetchAll(DTNDatabase tempDTNDatabase)
            /// <summary>
            /// This method fetches a collection of 'DTNDatabase' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DTNDatabase_FetchAll'.</summary>
            /// <param name='tempDTNDatabase'>A temporary DTNDatabase for passing values.</param>
            /// <returns>A collection of 'DTNDatabase' objects.</returns>
            public List<DTNDatabase> FetchAll(DTNDatabase tempDTNDatabase)
            {
                // Initial value
                List<DTNDatabase> dTNDatabaseList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.DTNDatabaseMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(tempDTNDatabase);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DTNDatabase> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        dTNDatabaseList = (List<DTNDatabase>) returnObject.ObjectValue;
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
                return dTNDatabaseList;
            }
            #endregion

            #region Find(DTNDatabase tempDTNDatabase)
            /// <summary>
            /// Finds a 'DTNDatabase' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DTNDatabase_Find'</param>
            /// </summary>
            /// <param name='tempDTNDatabase'>A temporary DTNDatabase for passing values.</param>
            /// <returns>A 'DTNDatabase' object if found else a null 'DTNDatabase'.</returns>
            public DTNDatabase Find(DTNDatabase tempDTNDatabase)
            {
                // Initial values
                DTNDatabase dTNDatabase = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempDTNDatabase != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.DTNDatabaseMethods.FindDTNDatabase;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(tempDTNDatabase);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as DTNDatabase != null))
                        {
                            // Get ReturnObject
                            dTNDatabase = (DTNDatabase) returnObject.ObjectValue;
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
                return dTNDatabase;
            }
            #endregion

            #region Insert(DTNDatabase dTNDatabase)
            /// <summary>
            /// Insert a 'DTNDatabase' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DTNDatabase_Insert'.</param>
            /// </summary>
            /// <param name='dTNDatabase'>The 'DTNDatabase' object to insert.</param>
            /// <returns>The id (int) of the new  'DTNDatabase' object that was inserted.</returns>
            public int Insert(DTNDatabase dTNDatabase)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If DTNDatabaseexists
                    if(dTNDatabase != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.DTNDatabaseMethods.InsertDTNDatabase;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(dTNDatabase);

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

            #region Save(ref DTNDatabase dTNDatabase)
            /// <summary>
            /// Saves a 'DTNDatabase' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='dTNDatabase'>The 'DTNDatabase' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref DTNDatabase dTNDatabase)
            {
                // Initial value
                bool saved = false;

                // If the dTNDatabase exists.
                if(dTNDatabase != null)
                {
                    // Is this a new DTNDatabase
                    if(dTNDatabase.IsNew)
                    {
                        // Insert new DTNDatabase
                        int newIdentity = this.Insert(dTNDatabase);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            dTNDatabase.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update DTNDatabase
                        saved = this.Update(dTNDatabase);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(DTNDatabase dTNDatabase)
            /// <summary>
            /// This method Updates a 'DTNDatabase' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DTNDatabase_Update'.</param>
            /// </summary>
            /// <param name='dTNDatabase'>The 'DTNDatabase' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(DTNDatabase dTNDatabase)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(dTNDatabase != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.DTNDatabaseMethods.UpdateDTNDatabase;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNDatabaseParameter(dTNDatabase);
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
