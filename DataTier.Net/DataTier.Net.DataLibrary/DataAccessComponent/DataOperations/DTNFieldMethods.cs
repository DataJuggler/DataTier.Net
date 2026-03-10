

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

    #region class DTNFieldMethods
    /// <summary>
    /// This class contains methods for modifying a 'DTNField' object.
    /// </summary>
    public static class DTNFieldMethods
    {

        #region Methods

            #region DeleteDTNField(DTNField)
            /// <summary>
            /// This method deletes a 'DTNField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNField' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteDTNField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteDTNFieldStoredProcedure deleteDTNFieldProc = null;

                    // verify the first parameters is a(n) 'DTNField'.
                    if (parameters[0].ObjectValue as DTNField != null)
                    {
                        // Create DTNField
                        DTNField dTNField = (DTNField) parameters[0].ObjectValue;

                        // verify dTNField exists
                        if(dTNField != null)
                        {
                            // Now create deleteDTNFieldProc from DTNFieldWriter
                            // The DataWriter converts the 'DTNField'
                            // to the SqlParameter[] array needed to delete a 'DTNField'.
                            deleteDTNFieldProc = DTNFieldWriter.CreateDeleteDTNFieldStoredProcedure(dTNField);
                        }
                    }

                    // Verify deleteDTNFieldProc exists
                    if(deleteDTNFieldProc != null)
                    {
                        // Execute Delete Stored Procedure
                        result.Success = DTNFieldManager.DeleteDTNField(deleteDTNFieldProc, dataConnector);

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
            /// This method fetches all 'DTNField' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNField' to delete.
            /// <returns>A PolymorphicObject object with all  'DTNFields' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                List<DTNField> dTNFieldListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllDTNFieldsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get DTNFieldParameter
                    // Declare Parameter
                    DTNField paramDTNField = null;

                    // verify the first parameters is a(n) 'DTNField'.
                    if (parameters[0].ObjectValue as DTNField != null)
                    {
                        // Get DTNFieldParameter
                        paramDTNField = (DTNField) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllDTNFieldsProc from DTNFieldWriter
                    fetchAllProc = DTNFieldWriter.CreateFetchAllDTNFieldsStoredProcedure(paramDTNField);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    dTNFieldListCollection = DTNFieldManager.FetchAllDTNFields(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(dTNFieldListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = dTNFieldListCollection;
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

            #region FindDTNField(DTNField)
            /// <summary>
            /// This method finds a 'DTNField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNField' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindDTNField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                DTNField dTNField = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindDTNFieldStoredProcedure findDTNFieldProc = null;

                    // verify the first parameters is a 'DTNField'.
                    if (parameters[0].ObjectValue as DTNField != null)
                    {
                        // Get DTNFieldParameter
                        DTNField paramDTNField = (DTNField) parameters[0].ObjectValue;

                        // verify paramDTNField exists
                        if(paramDTNField != null)
                        {
                            // Now create findDTNFieldProc from DTNFieldWriter
                            // The DataWriter converts the 'DTNField'
                            // to the SqlParameter[] array needed to find a 'DTNField'.
                            findDTNFieldProc = DTNFieldWriter.CreateFindDTNFieldStoredProcedure(paramDTNField);
                        }

                        // Verify findDTNFieldProc exists
                        if(findDTNFieldProc != null)
                        {
                            // Execute Find Stored Procedure
                            dTNField = DTNFieldManager.FindDTNField(findDTNFieldProc, dataConnector);

                            // if dataObject exists
                            if(dTNField != null)
                            {
                                // set result.ObjectValue
                                result.ObjectValue = dTNField;
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

            #region InsertDTNField (DTNField)
            /// <summary>
            /// This method inserts a 'DTNField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNField' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertDTNField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                DTNField dTNField = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertDTNFieldStoredProcedure insertDTNFieldProc = null;

                    // verify the first parameters is a(n) 'DTNField'.
                    if (parameters[0].ObjectValue as DTNField != null)
                    {
                        // Create DTNField Parameter
                        dTNField = (DTNField) parameters[0].ObjectValue;

                        // verify dTNField exists
                        if(dTNField != null)
                        {
                            // Now create insertDTNFieldProc from DTNFieldWriter
                            // The DataWriter converts the 'DTNField'
                            // to the SqlParameter[] array needed to insert a 'DTNField'.
                            insertDTNFieldProc = DTNFieldWriter.CreateInsertDTNFieldStoredProcedure(dTNField);
                        }

                        // Verify insertDTNFieldProc exists
                        if(insertDTNFieldProc != null)
                        {
                            // Execute Insert Stored Procedure
                            result.IntegerValue = DTNFieldManager.InsertDTNField(insertDTNFieldProc, dataConnector);

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

            #region UpdateDTNField (DTNField)
            /// <summary>
            /// This method updates a 'DTNField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNField' to update.
            /// <returns>A PolymorphicObject object.
            internal static PolymorphicObject UpdateDTNField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                DTNField dTNField = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateDTNFieldStoredProcedure updateDTNFieldProc = null;

                    // verify the first parameters is a(n) 'DTNField'.
                    if (parameters[0].ObjectValue as DTNField != null)
                    {
                        // Create DTNField Parameter
                        dTNField = (DTNField) parameters[0].ObjectValue;

                        // verify dTNField exists
                        if(dTNField != null)
                        {
                            // Now create updateDTNFieldProc from DTNFieldWriter
                            // The DataWriter converts the 'DTNField'
                            // to the SqlParameter[] array needed to update a 'DTNField'.
                            updateDTNFieldProc = DTNFieldWriter.CreateUpdateDTNFieldStoredProcedure(dTNField);
                        }

                        // Verify updateDTNFieldProc exists
                        if(updateDTNFieldProc != null)
                        {
                            // Execute Update Stored Procedure
                            result.Success = DTNFieldManager.UpdateDTNField(updateDTNFieldProc, dataConnector);
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
