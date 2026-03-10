

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

    #region class CustomReaderMethods
    /// <summary>
    /// This class contains methods for modifying a 'CustomReader' object.
    /// </summary>
    public static class CustomReaderMethods
    {

        #region Methods

            #region DeleteCustomReader(CustomReader)
            /// <summary>
            /// This method deletes a 'CustomReader' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'CustomReader' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteCustomReader(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteCustomReaderStoredProcedure deleteCustomReaderProc = null;

                    // verify the first parameters is a(n) 'CustomReader'.
                    if (parameters[0].ObjectValue as CustomReader != null)
                    {
                        // Create CustomReader
                        CustomReader customReader = (CustomReader) parameters[0].ObjectValue;

                        // verify customReader exists
                        if(customReader != null)
                        {
                            // Now create deleteCustomReaderProc from CustomReaderWriter
                            // The DataWriter converts the 'CustomReader'
                            // to the SqlParameter[] array needed to delete a 'CustomReader'.
                            deleteCustomReaderProc = CustomReaderWriter.CreateDeleteCustomReaderStoredProcedure(customReader);
                        }
                    }

                    // Verify deleteCustomReaderProc exists
                    if(deleteCustomReaderProc != null)
                    {
                        // Execute Delete Stored Procedure
                        result.Success = CustomReaderManager.DeleteCustomReader(deleteCustomReaderProc, dataConnector);

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
            /// This method fetches all 'CustomReader' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'CustomReader' to delete.
            /// <returns>A PolymorphicObject object with all  'CustomReaders' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                List<CustomReader> customReaderListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllCustomReadersStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get CustomReaderParameter
                    // Declare Parameter
                    CustomReader paramCustomReader = null;

                    // verify the first parameters is a(n) 'CustomReader'.
                    if (parameters[0].ObjectValue as CustomReader != null)
                    {
                        // Get CustomReaderParameter
                        paramCustomReader = (CustomReader) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllCustomReadersProc from CustomReaderWriter
                    fetchAllProc = CustomReaderWriter.CreateFetchAllCustomReadersStoredProcedure(paramCustomReader);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    customReaderListCollection = CustomReaderManager.FetchAllCustomReaders(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(customReaderListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = customReaderListCollection;
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

            #region FindCustomReader(CustomReader)
            /// <summary>
            /// This method finds a 'CustomReader' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'CustomReader' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindCustomReader(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                CustomReader customReader = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindCustomReaderStoredProcedure findCustomReaderProc = null;

                    // verify the first parameters is a 'CustomReader'.
                    if (parameters[0].ObjectValue as CustomReader != null)
                    {
                        // Get CustomReaderParameter
                        CustomReader paramCustomReader = (CustomReader) parameters[0].ObjectValue;

                        // verify paramCustomReader exists
                        if(paramCustomReader != null)
                        {
                            // Now create findCustomReaderProc from CustomReaderWriter
                            // The DataWriter converts the 'CustomReader'
                            // to the SqlParameter[] array needed to find a 'CustomReader'.
                            findCustomReaderProc = CustomReaderWriter.CreateFindCustomReaderStoredProcedure(paramCustomReader);
                        }

                        // Verify findCustomReaderProc exists
                        if(findCustomReaderProc != null)
                        {
                            // Execute Find Stored Procedure
                            customReader = CustomReaderManager.FindCustomReader(findCustomReaderProc, dataConnector);

                            // if dataObject exists
                            if(customReader != null)
                            {
                                // set result.ObjectValue
                                result.ObjectValue = customReader;
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

            #region InsertCustomReader (CustomReader)
            /// <summary>
            /// This method inserts a 'CustomReader' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'CustomReader' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertCustomReader(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                CustomReader customReader = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertCustomReaderStoredProcedure insertCustomReaderProc = null;

                    // verify the first parameters is a(n) 'CustomReader'.
                    if (parameters[0].ObjectValue as CustomReader != null)
                    {
                        // Create CustomReader Parameter
                        customReader = (CustomReader) parameters[0].ObjectValue;

                        // verify customReader exists
                        if(customReader != null)
                        {
                            // Now create insertCustomReaderProc from CustomReaderWriter
                            // The DataWriter converts the 'CustomReader'
                            // to the SqlParameter[] array needed to insert a 'CustomReader'.
                            insertCustomReaderProc = CustomReaderWriter.CreateInsertCustomReaderStoredProcedure(customReader);
                        }

                        // Verify insertCustomReaderProc exists
                        if(insertCustomReaderProc != null)
                        {
                            // Execute Insert Stored Procedure
                            result.IntegerValue = CustomReaderManager.InsertCustomReader(insertCustomReaderProc, dataConnector);

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

            #region UpdateCustomReader (CustomReader)
            /// <summary>
            /// This method updates a 'CustomReader' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'CustomReader' to update.
            /// <returns>A PolymorphicObject object.
            internal static PolymorphicObject UpdateCustomReader(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                CustomReader customReader = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateCustomReaderStoredProcedure updateCustomReaderProc = null;

                    // verify the first parameters is a(n) 'CustomReader'.
                    if (parameters[0].ObjectValue as CustomReader != null)
                    {
                        // Create CustomReader Parameter
                        customReader = (CustomReader) parameters[0].ObjectValue;

                        // verify customReader exists
                        if(customReader != null)
                        {
                            // Now create updateCustomReaderProc from CustomReaderWriter
                            // The DataWriter converts the 'CustomReader'
                            // to the SqlParameter[] array needed to update a 'CustomReader'.
                            updateCustomReaderProc = CustomReaderWriter.CreateUpdateCustomReaderStoredProcedure(customReader);
                        }

                        // Verify updateCustomReaderProc exists
                        if(updateCustomReaderProc != null)
                        {
                            // Execute Update Stored Procedure
                            result.Success = CustomReaderManager.UpdateCustomReader(updateCustomReaderProc, dataConnector);
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
