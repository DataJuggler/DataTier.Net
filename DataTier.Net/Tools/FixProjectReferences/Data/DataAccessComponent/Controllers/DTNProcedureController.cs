

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

    #region class DTNProcedureController
    /// <summary>
    /// This class controls a(n) 'DTNProcedure' object.
    /// </summary>
    public class DTNProcedureController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'DTNProcedureController' object.
        /// </summary>
        public DTNProcedureController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateDTNProcedureParameter
            /// <summary>
            /// This method creates the parameter for a 'DTNProcedure' data operation.
            /// </summary>
            /// <param name='dtnprocedure'>The 'DTNProcedure' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateDTNProcedureParameter(DTNProcedure dTNProcedure)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = dTNProcedure;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(DTNProcedure tempDTNProcedure)
            /// <summary>
            /// Deletes a 'DTNProcedure' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'DTNProcedure_Delete'.
            /// </summary>
            /// <param name='dtnprocedure'>The 'DTNProcedure' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(DTNProcedure tempDTNProcedure)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteDTNProcedure";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempdTNProcedure exists before attemptintg to delete
                    if(tempDTNProcedure != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteDTNProcedureMethod = this.AppController.DataBridge.DataOperations.DTNProcedureMethods.DeleteDTNProcedure;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNProcedureParameter(tempDTNProcedure);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteDTNProcedureMethod, parameters);

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

            #region FetchAll(DTNProcedure tempDTNProcedure)
            /// <summary>
            /// This method fetches a collection of 'DTNProcedure' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'DTNProcedure_FetchAll'.</summary>
            /// <param name='tempDTNProcedure'>A temporary DTNProcedure for passing values.</param>
            /// <returns>A collection of 'DTNProcedure' objects.</returns>
            public List<DTNProcedure> FetchAll(DTNProcedure tempDTNProcedure)
            {
                // Initial value
                List<DTNProcedure> dTNProcedureList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.DTNProcedureMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateDTNProcedureParameter(tempDTNProcedure);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<DTNProcedure> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        dTNProcedureList = (List<DTNProcedure>) returnObject.ObjectValue;
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
                return dTNProcedureList;
            }
            #endregion

            #region Find(DTNProcedure tempDTNProcedure)
            /// <summary>
            /// Finds a 'DTNProcedure' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'DTNProcedure_Find'</param>
            /// </summary>
            /// <param name='tempDTNProcedure'>A temporary DTNProcedure for passing values.</param>
            /// <returns>A 'DTNProcedure' object if found else a null 'DTNProcedure'.</returns>
            public DTNProcedure Find(DTNProcedure tempDTNProcedure)
            {
                // Initial values
                DTNProcedure dTNProcedure = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempDTNProcedure != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.DTNProcedureMethods.FindDTNProcedure;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNProcedureParameter(tempDTNProcedure);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as DTNProcedure != null))
                        {
                            // Get ReturnObject
                            dTNProcedure = (DTNProcedure) returnObject.ObjectValue;
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
                return dTNProcedure;
            }
            #endregion

            #region Insert(DTNProcedure dTNProcedure)
            /// <summary>
            /// Insert a 'DTNProcedure' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'DTNProcedure_Insert'.</param>
            /// </summary>
            /// <param name='dTNProcedure'>The 'DTNProcedure' object to insert.</param>
            /// <returns>The id (int) of the new  'DTNProcedure' object that was inserted.</returns>
            public int Insert(DTNProcedure dTNProcedure)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If DTNProcedureexists
                    if(dTNProcedure != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.DTNProcedureMethods.InsertDTNProcedure;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNProcedureParameter(dTNProcedure);

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

            #region Save(ref DTNProcedure dTNProcedure)
            /// <summary>
            /// Saves a 'DTNProcedure' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='dTNProcedure'>The 'DTNProcedure' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref DTNProcedure dTNProcedure)
            {
                // Initial value
                bool saved = false;

                // If the dTNProcedure exists.
                if(dTNProcedure != null)
                {
                    // Is this a new DTNProcedure
                    if(dTNProcedure.IsNew)
                    {
                        // Insert new DTNProcedure
                        int newIdentity = this.Insert(dTNProcedure);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            dTNProcedure.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update DTNProcedure
                        saved = this.Update(dTNProcedure);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(DTNProcedure dTNProcedure)
            /// <summary>
            /// This method Updates a 'DTNProcedure' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'DTNProcedure_Update'.</param>
            /// </summary>
            /// <param name='dTNProcedure'>The 'DTNProcedure' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(DTNProcedure dTNProcedure)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(dTNProcedure != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.DTNProcedureMethods.UpdateDTNProcedure;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateDTNProcedureParameter(dTNProcedure);
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
