

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

    #region class DTNProcedureMethods
    /// <summary>
    /// This class contains methods for modifying a 'DTNProcedure' object.
    /// </summary>
    public static class DTNProcedureMethods
    {

        #region Methods

            #region DeleteDTNProcedure(DTNProcedure)
            /// <summary>
            /// This method deletes a 'DTNProcedure' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNProcedure' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteDTNProcedure(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteDTNProcedureStoredProcedure deleteDTNProcedureProc = null;

                    // verify the first parameters is a(n) 'DTNProcedure'.
                    if (parameters[0].ObjectValue as DTNProcedure != null)
                    {
                        // Create DTNProcedure
                        DTNProcedure dTNProcedure = (DTNProcedure) parameters[0].ObjectValue;

                        // verify dTNProcedure exists
                        if(dTNProcedure != null)
                        {
                            // Now create deleteDTNProcedureProc from DTNProcedureWriter
                            // The DataWriter converts the 'DTNProcedure'
                            // to the SqlParameter[] array needed to delete a 'DTNProcedure'.
                            deleteDTNProcedureProc = DTNProcedureWriter.CreateDeleteDTNProcedureStoredProcedure(dTNProcedure);
                        }
                    }

                    // Verify deleteDTNProcedureProc exists
                    if(deleteDTNProcedureProc != null)
                    {
                        // Execute Delete Stored Procedure
                        result.Success = DTNProcedureManager.DeleteDTNProcedure(deleteDTNProcedureProc, dataConnector);

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
            /// This method fetches all 'DTNProcedure' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNProcedure' to delete.
            /// <returns>A PolymorphicObject object with all  'DTNProcedures' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                List<DTNProcedure> dTNProcedureListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllDTNProceduresStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get DTNProcedureParameter
                    // Declare Parameter
                    DTNProcedure paramDTNProcedure = null;

                    // verify the first parameters is a(n) 'DTNProcedure'.
                    if (parameters[0].ObjectValue as DTNProcedure != null)
                    {
                        // Get DTNProcedureParameter
                        paramDTNProcedure = (DTNProcedure) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllDTNProceduresProc from DTNProcedureWriter
                    fetchAllProc = DTNProcedureWriter.CreateFetchAllDTNProceduresStoredProcedure(paramDTNProcedure);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    dTNProcedureListCollection = DTNProcedureManager.FetchAllDTNProcedures(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(dTNProcedureListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = dTNProcedureListCollection;
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

            #region FindDTNProcedure(DTNProcedure)
            /// <summary>
            /// This method finds a 'DTNProcedure' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNProcedure' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindDTNProcedure(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                DTNProcedure dTNProcedure = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindDTNProcedureStoredProcedure findDTNProcedureProc = null;

                    // verify the first parameters is a 'DTNProcedure'.
                    if (parameters[0].ObjectValue as DTNProcedure != null)
                    {
                        // Get DTNProcedureParameter
                        DTNProcedure paramDTNProcedure = (DTNProcedure) parameters[0].ObjectValue;

                        // verify paramDTNProcedure exists
                        if(paramDTNProcedure != null)
                        {
                            // Now create findDTNProcedureProc from DTNProcedureWriter
                            // The DataWriter converts the 'DTNProcedure'
                            // to the SqlParameter[] array needed to find a 'DTNProcedure'.
                            findDTNProcedureProc = DTNProcedureWriter.CreateFindDTNProcedureStoredProcedure(paramDTNProcedure);
                        }

                        // Verify findDTNProcedureProc exists
                        if(findDTNProcedureProc != null)
                        {
                            // Execute Find Stored Procedure
                            dTNProcedure = DTNProcedureManager.FindDTNProcedure(findDTNProcedureProc, dataConnector);

                            // if dataObject exists
                            if(dTNProcedure != null)
                            {
                                // set result.ObjectValue
                                result.ObjectValue = dTNProcedure;
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

            #region InsertDTNProcedure (DTNProcedure)
            /// <summary>
            /// This method inserts a 'DTNProcedure' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNProcedure' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertDTNProcedure(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                DTNProcedure dTNProcedure = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertDTNProcedureStoredProcedure insertDTNProcedureProc = null;

                    // verify the first parameters is a(n) 'DTNProcedure'.
                    if (parameters[0].ObjectValue as DTNProcedure != null)
                    {
                        // Create DTNProcedure Parameter
                        dTNProcedure = (DTNProcedure) parameters[0].ObjectValue;

                        // verify dTNProcedure exists
                        if(dTNProcedure != null)
                        {
                            // Now create insertDTNProcedureProc from DTNProcedureWriter
                            // The DataWriter converts the 'DTNProcedure'
                            // to the SqlParameter[] array needed to insert a 'DTNProcedure'.
                            insertDTNProcedureProc = DTNProcedureWriter.CreateInsertDTNProcedureStoredProcedure(dTNProcedure);
                        }

                        // Verify insertDTNProcedureProc exists
                        if(insertDTNProcedureProc != null)
                        {
                            // Execute Insert Stored Procedure
                            result.IntegerValue = DTNProcedureManager.InsertDTNProcedure(insertDTNProcedureProc, dataConnector);

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

            #region UpdateDTNProcedure (DTNProcedure)
            /// <summary>
            /// This method updates a 'DTNProcedure' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNProcedure' to update.
            /// <returns>A PolymorphicObject object.
            internal static PolymorphicObject UpdateDTNProcedure(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                DTNProcedure dTNProcedure = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateDTNProcedureStoredProcedure updateDTNProcedureProc = null;

                    // verify the first parameters is a(n) 'DTNProcedure'.
                    if (parameters[0].ObjectValue as DTNProcedure != null)
                    {
                        // Create DTNProcedure Parameter
                        dTNProcedure = (DTNProcedure) parameters[0].ObjectValue;

                        // verify dTNProcedure exists
                        if(dTNProcedure != null)
                        {
                            // Now create updateDTNProcedureProc from DTNProcedureWriter
                            // The DataWriter converts the 'DTNProcedure'
                            // to the SqlParameter[] array needed to update a 'DTNProcedure'.
                            updateDTNProcedureProc = DTNProcedureWriter.CreateUpdateDTNProcedureStoredProcedure(dTNProcedure);
                        }

                        // Verify updateDTNProcedureProc exists
                        if(updateDTNProcedureProc != null)
                        {
                            // Execute Update Stored Procedure
                            result.Success = DTNProcedureManager.UpdateDTNProcedure(updateDTNProcedureProc, dataConnector);
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
