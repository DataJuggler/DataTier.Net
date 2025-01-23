

#region using statements

using DataAccessComponent.Data;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.DataBridge;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class DTNDatabaseMethods
    /// <summary>
    /// This class contains methods for modifying a 'DTNDatabase' object.
    /// </summary>
    public static class DTNDatabaseMethods
    {

        #region Methods

            #region DeleteDTNDatabase(DTNDatabase)
            /// <summary>
            /// This method deletes a 'DTNDatabase' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNDatabase' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteDTNDatabase(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteDTNDatabaseStoredProcedure deleteDTNDatabaseProc = null;

                    // verify the first parameters is a(n) 'DTNDatabase'.
                    if (parameters[0].ObjectValue as DTNDatabase != null)
                    {
                        // Create DTNDatabase
                        DTNDatabase dTNDatabase = (DTNDatabase) parameters[0].ObjectValue;

                        // verify dTNDatabase exists
                        if(dTNDatabase != null)
                        {
                            // Now create deleteDTNDatabaseProc from DTNDatabaseWriter
                            // The DataWriter converts the 'DTNDatabase'
                            // to the SqlParameter[] array needed to delete a 'DTNDatabase'.
                            deleteDTNDatabaseProc = DTNDatabaseWriter.CreateDeleteDTNDatabaseStoredProcedure(dTNDatabase);
                        }
                    }

                    // Verify deleteDTNDatabaseProc exists
                    if(deleteDTNDatabaseProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = DTNDatabaseManager.DeleteDTNDatabase(deleteDTNDatabaseProc, dataConnector);

                        // Create returnObject.Boolean
                        returnObject.Boolean = new NullableBoolean();

                        // If delete was successful
                        if(deleted)
                        {
                            // Set returnObject.Boolean.Value to true
                            returnObject.Boolean.Value = NullableBooleanEnum.True;
                        }
                        else
                        {
                            // Set returnObject.Boolean.Value to false
                            returnObject.Boolean.Value = NullableBooleanEnum.False;
                        }
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'DTNDatabase' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNDatabase' to delete.
            /// <returns>A PolymorphicObject object with all  'DTNDatabases' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<DTNDatabase> dTNDatabaseListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllDTNDatabasesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get DTNDatabaseParameter
                    // Declare Parameter
                    DTNDatabase paramDTNDatabase = null;

                    // verify the first parameters is a(n) 'DTNDatabase'.
                    if (parameters[0].ObjectValue as DTNDatabase != null)
                    {
                        // Get DTNDatabaseParameter
                        paramDTNDatabase = (DTNDatabase) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllDTNDatabasesProc from DTNDatabaseWriter
                    fetchAllProc = DTNDatabaseWriter.CreateFetchAllDTNDatabasesStoredProcedure(paramDTNDatabase);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    dTNDatabaseListCollection = DTNDatabaseManager.FetchAllDTNDatabases(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(dTNDatabaseListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = dTNDatabaseListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return returnObject;
            }
            #endregion

            #region FindDTNDatabase(DTNDatabase)
            /// <summary>
            /// This method finds a 'DTNDatabase' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNDatabase' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindDTNDatabase(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                DTNDatabase dTNDatabase = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindDTNDatabaseStoredProcedure findDTNDatabaseProc = null;

                    // verify the first parameters is a 'DTNDatabase'.
                    if (parameters[0].ObjectValue as DTNDatabase != null)
                    {
                        // Get DTNDatabaseParameter
                        DTNDatabase paramDTNDatabase = (DTNDatabase) parameters[0].ObjectValue;

                        // verify paramDTNDatabase exists
                        if(paramDTNDatabase != null)
                        {
                            // Now create findDTNDatabaseProc from DTNDatabaseWriter
                            // The DataWriter converts the 'DTNDatabase'
                            // to the SqlParameter[] array needed to find a 'DTNDatabase'.
                            findDTNDatabaseProc = DTNDatabaseWriter.CreateFindDTNDatabaseStoredProcedure(paramDTNDatabase);
                        }

                        // Verify findDTNDatabaseProc exists
                        if(findDTNDatabaseProc != null)
                        {
                            // Execute Find Stored Procedure
                            dTNDatabase = DTNDatabaseManager.FindDTNDatabase(findDTNDatabaseProc, dataConnector);

                            // if dataObject exists
                            if(dTNDatabase != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = dTNDatabase;
                            }
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region InsertDTNDatabase (DTNDatabase)
            /// <summary>
            /// This method inserts a 'DTNDatabase' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNDatabase' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertDTNDatabase(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                DTNDatabase dTNDatabase = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertDTNDatabaseStoredProcedure insertDTNDatabaseProc = null;

                    // verify the first parameters is a(n) 'DTNDatabase'.
                    if (parameters[0].ObjectValue as DTNDatabase != null)
                    {
                        // Create DTNDatabase Parameter
                        dTNDatabase = (DTNDatabase) parameters[0].ObjectValue;

                        // verify dTNDatabase exists
                        if(dTNDatabase != null)
                        {
                            // Now create insertDTNDatabaseProc from DTNDatabaseWriter
                            // The DataWriter converts the 'DTNDatabase'
                            // to the SqlParameter[] array needed to insert a 'DTNDatabase'.
                            insertDTNDatabaseProc = DTNDatabaseWriter.CreateInsertDTNDatabaseStoredProcedure(dTNDatabase);
                        }

                        // Verify insertDTNDatabaseProc exists
                        if(insertDTNDatabaseProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = DTNDatabaseManager.InsertDTNDatabase(insertDTNDatabaseProc, dataConnector);
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

            #region UpdateDTNDatabase (DTNDatabase)
            /// <summary>
            /// This method updates a 'DTNDatabase' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNDatabase' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateDTNDatabase(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                DTNDatabase dTNDatabase = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateDTNDatabaseStoredProcedure updateDTNDatabaseProc = null;

                    // verify the first parameters is a(n) 'DTNDatabase'.
                    if (parameters[0].ObjectValue as DTNDatabase != null)
                    {
                        // Create DTNDatabase Parameter
                        dTNDatabase = (DTNDatabase) parameters[0].ObjectValue;

                        // verify dTNDatabase exists
                        if(dTNDatabase != null)
                        {
                            // Now create updateDTNDatabaseProc from DTNDatabaseWriter
                            // The DataWriter converts the 'DTNDatabase'
                            // to the SqlParameter[] array needed to update a 'DTNDatabase'.
                            updateDTNDatabaseProc = DTNDatabaseWriter.CreateUpdateDTNDatabaseStoredProcedure(dTNDatabase);
                        }

                        // Verify updateDTNDatabaseProc exists
                        if(updateDTNDatabaseProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = DTNDatabaseManager.UpdateDTNDatabase(updateDTNDatabaseProc, dataConnector);

                            // Create returnObject.Boolean
                            returnObject.Boolean = new NullableBoolean();

                            // If save was successful
                            if(saved)
                            {
                                // Set returnObject.Boolean.Value to true
                                returnObject.Boolean.Value = NullableBooleanEnum.True;
                            }
                            else
                            {
                                // Set returnObject.Boolean.Value to false
                                returnObject.Boolean.Value = NullableBooleanEnum.False;
                            }
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return returnObject;
            }
            #endregion

        #endregion

    }
    #endregion

}
