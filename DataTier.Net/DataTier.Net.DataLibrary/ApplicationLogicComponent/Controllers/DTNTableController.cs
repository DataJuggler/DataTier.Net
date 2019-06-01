

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

    #region class DTNTableController
    /// <summary>
    /// This class controls a(n) 'DTNTable' object.
    /// </summary>
    public class DTNTableController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'DTNTableController' object.
        /// </summary>
        public DTNTableController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateDTNTableParameter
            /// <summary>
            /// This method creates the parameter for a 'DTNTable' data operation.
            /// </summary>
            /// <param name='dtntable'>The 'DTNTable' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateDTNTableParameter(DTNTable dTNTable)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = dTNTable;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(DTNTable tempDTNTable)
            /// <summary>
            /// Deletes a 'DTNTable' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'DTNTable_Delete'.
            /// </summary>
            /// <param name='dtntable'>The 'DTNTable' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(DTNTable tempDTNTable)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDTNTable";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempdTNTable exists before attemptintg to delete
                    if(tempDTNTable != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDTNTableMethod = this.AppController.DataBridge.DataOperations.DTNTableMethods.DeleteDTNTable;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNTableParameter(tempDTNTable);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteDTNTableMethod, parameters);

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

            #region FetchAll(DTNTable tempDTNTable)
            /// <summary>
            /// This method fetches a collection of 'DTNTable' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DTNTable_FetchAll'.</summary>
            /// <param name='tempDTNTable'>A temporary DTNTable for passing values.</param>
            /// <returns>A collection of 'DTNTable' objects.</returns>
            public List<DTNTable> FetchAll(DTNTable tempDTNTable)
            {
                // Initial value
                List<DTNTable> dTNTableList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.DTNTableMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDTNTableParameter(tempDTNTable);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DTNTable> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        dTNTableList = (List<DTNTable>) returnObject.ObjectValue;
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
                return dTNTableList;
            }
            #endregion

            #region Find(DTNTable tempDTNTable)
            /// <summary>
            /// Finds a 'DTNTable' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DTNTable_Find'</param>
            /// </summary>
            /// <param name='tempDTNTable'>A temporary DTNTable for passing values.</param>
            /// <returns>A 'DTNTable' object if found else a null 'DTNTable'.</returns>
            public DTNTable Find(DTNTable tempDTNTable)
            {
                // Initial values
                DTNTable dTNTable = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempDTNTable != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.DTNTableMethods.FindDTNTable;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNTableParameter(tempDTNTable);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as DTNTable != null))
                        {
                            // Get ReturnObject
                            dTNTable = (DTNTable) returnObject.ObjectValue;
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
                return dTNTable;
            }
            #endregion

            #region Insert(DTNTable dTNTable)
            /// <summary>
            /// Insert a 'DTNTable' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DTNTable_Insert'.</param>
            /// </summary>
            /// <param name='dTNTable'>The 'DTNTable' object to insert.</param>
            /// <returns>The id (int) of the new  'DTNTable' object that was inserted.</returns>
            public int Insert(DTNTable dTNTable)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If DTNTableexists
                    if(dTNTable != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.DTNTableMethods.InsertDTNTable;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNTableParameter(dTNTable);

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

            #region Save(ref DTNTable dTNTable)
            /// <summary>
            /// Saves a 'DTNTable' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='dTNTable'>The 'DTNTable' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref DTNTable dTNTable)
            {
                // Initial value
                bool saved = false;

                // If the dTNTable exists.
                if(dTNTable != null)
                {
                    // Is this a new DTNTable
                    if(dTNTable.IsNew)
                    {
                        // Insert new DTNTable
                        int newIdentity = this.Insert(dTNTable);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            dTNTable.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update DTNTable
                        saved = this.Update(dTNTable);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(DTNTable dTNTable)
            /// <summary>
            /// This method Updates a 'DTNTable' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DTNTable_Update'.</param>
            /// </summary>
            /// <param name='dTNTable'>The 'DTNTable' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(DTNTable dTNTable)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(dTNTable != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.DTNTableMethods.UpdateDTNTable;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNTableParameter(dTNTable);
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
