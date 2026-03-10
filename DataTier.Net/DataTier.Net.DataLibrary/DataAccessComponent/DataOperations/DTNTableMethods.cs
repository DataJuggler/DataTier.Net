

#region using statements

using System;
using System.Collections.Generic;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class DTNTableMethods
    /// <summary>
    /// This class contains methods for modifying a 'DTNTable' object.
    /// </summary>
    public static class DTNTableMethods
    {

        #region Methods

            #region DeleteDTNTable(DTNTable)
            /// <summary>
            /// This method deletes a 'DTNTable' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNTable' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteDTNTable(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteDTNTableStoredProcedure deleteDTNTableProc = null;

                    // verify the first parameters is a(n) 'DTNTable'.
                    if (parameters[0].ObjectValue as DTNTable != null)
                    {
                        // Create DTNTable
                        DTNTable dTNTable = (DTNTable) parameters[0].ObjectValue;

                        // verify dTNTable exists
                        if(dTNTable != null)
                        {
                            // Now create deleteDTNTableProc from DTNTableWriter
                            // The DataWriter converts the 'DTNTable'
                            // to the SqlParameter[] array needed to delete a 'DTNTable'.
                            deleteDTNTableProc = DTNTableWriter.CreateDeleteDTNTableStoredProcedure(dTNTable);
                        }
                    }

                    // Verify deleteDTNTableProc exists
                    if(deleteDTNTableProc != null)
                    {
                        // Execute Delete Stored Procedure
                        result.Success = DTNTableManager.DeleteDTNTable(deleteDTNTableProc, dataConnector);

                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return result;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'DTNTable' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNTable' to delete.
            /// <returns>A PolymorphicObject object with all  'DTNTables' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                List<DTNTable> dTNTableListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllDTNTablesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get DTNTableParameter
                    // Declare Parameter
                    DTNTable paramDTNTable = null;

                    // verify the first parameters is a(n) 'DTNTable'.
                    if (parameters[0].ObjectValue as DTNTable != null)
                    {
                        // Get DTNTableParameter
                        paramDTNTable = (DTNTable) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllDTNTablesProc from DTNTableWriter
                    fetchAllProc = DTNTableWriter.CreateFetchAllDTNTablesStoredProcedure(paramDTNTable);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    dTNTableListCollection = DTNTableManager.FetchAllDTNTables(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(dTNTableListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = dTNTableListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return result;
            }
            #endregion

            #region FindDTNTable(DTNTable)
            /// <summary>
            /// This method finds a 'DTNTable' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNTable' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindDTNTable(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                DTNTable dTNTable = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindDTNTableStoredProcedure findDTNTableProc = null;

                    // verify the first parameters is a 'DTNTable'.
                    if (parameters[0].ObjectValue as DTNTable != null)
                    {
                        // Get DTNTableParameter
                        DTNTable paramDTNTable = (DTNTable) parameters[0].ObjectValue;

                        // verify paramDTNTable exists
                        if(paramDTNTable != null)
                        {
                            // Now create findDTNTableProc from DTNTableWriter
                            // The DataWriter converts the 'DTNTable'
                            // to the SqlParameter[] array needed to find a 'DTNTable'.
                            findDTNTableProc = DTNTableWriter.CreateFindDTNTableStoredProcedure(paramDTNTable);
                        }

                        // Verify findDTNTableProc exists
                        if(findDTNTableProc != null)
                        {
                            // Execute Find Stored Procedure
                            dTNTable = DTNTableManager.FindDTNTable(findDTNTableProc, dataConnector);

                            // if dataObject exists
                            if(dTNTable != null)
                            {
                                // set result.ObjectValue
                                result.ObjectValue = dTNTable;
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
                return result;
            }
            #endregion

            #region InsertDTNTable (DTNTable)
            /// <summary>
            /// This method inserts a 'DTNTable' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNTable' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertDTNTable(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                DTNTable dTNTable = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertDTNTableStoredProcedure insertDTNTableProc = null;

                    // verify the first parameters is a(n) 'DTNTable'.
                    if (parameters[0].ObjectValue as DTNTable != null)
                    {
                        // Create DTNTable Parameter
                        dTNTable = (DTNTable) parameters[0].ObjectValue;

                        // verify dTNTable exists
                        if(dTNTable != null)
                        {
                            // Now create insertDTNTableProc from DTNTableWriter
                            // The DataWriter converts the 'DTNTable'
                            // to the SqlParameter[] array needed to insert a 'DTNTable'.
                            insertDTNTableProc = DTNTableWriter.CreateInsertDTNTableStoredProcedure(dTNTable);
                        }

                        // Verify insertDTNTableProc exists
                        if(insertDTNTableProc != null)
                        {
                            // Execute Insert Stored Procedure
                            result.IntegerValue = DTNTableManager.InsertDTNTable(insertDTNTableProc, dataConnector);

                            // Set the value for Sucess based on if the Insert was Successful
                            result.Success = result.HasIntegerValue;
                        }
                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region UpdateDTNTable (DTNTable)
            /// <summary>
            /// This method updates a 'DTNTable' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNTable' to update.
            /// <returns>A PolymorphicObject object.
            internal static PolymorphicObject UpdateDTNTable(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                DTNTable dTNTable = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateDTNTableStoredProcedure updateDTNTableProc = null;

                    // verify the first parameters is a(n) 'DTNTable'.
                    if (parameters[0].ObjectValue as DTNTable != null)
                    {
                        // Create DTNTable Parameter
                        dTNTable = (DTNTable) parameters[0].ObjectValue;

                        // verify dTNTable exists
                        if(dTNTable != null)
                        {
                            // Now create updateDTNTableProc from DTNTableWriter
                            // The DataWriter converts the 'DTNTable'
                            // to the SqlParameter[] array needed to update a 'DTNTable'.
                            updateDTNTableProc = DTNTableWriter.CreateUpdateDTNTableStoredProcedure(dTNTable);
                        }

                        // Verify updateDTNTableProc exists
                        if(updateDTNTableProc != null)
                        {
                            // Execute Update Stored Procedure
                            result.Success = DTNTableManager.UpdateDTNTable(updateDTNTableProc, dataConnector);
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return result;
            }
            #endregion

        #endregion

    }
    #endregion

}
