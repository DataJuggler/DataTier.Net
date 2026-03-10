

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

    #region class EnumerationMethods
    /// <summary>
    /// This class contains methods for modifying a 'Enumeration' object.
    /// </summary>
    public static class EnumerationMethods
    {

        #region Methods

            #region DeleteEnumeration(Enumeration)
            /// <summary>
            /// This method deletes a 'Enumeration' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Enumeration' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteEnumeration(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteEnumerationStoredProcedure deleteEnumerationProc = null;

                    // verify the first parameters is a(n) 'Enumeration'.
                    if (parameters[0].ObjectValue as Enumeration != null)
                    {
                        // Create Enumeration
                        Enumeration enumeration = (Enumeration) parameters[0].ObjectValue;

                        // verify enumeration exists
                        if(enumeration != null)
                        {
                            // Now create deleteEnumerationProc from EnumerationWriter
                            // The DataWriter converts the 'Enumeration'
                            // to the SqlParameter[] array needed to delete a 'Enumeration'.
                            deleteEnumerationProc = EnumerationWriter.CreateDeleteEnumerationStoredProcedure(enumeration);
                        }
                    }

                    // Verify deleteEnumerationProc exists
                    if(deleteEnumerationProc != null)
                    {
                        // Execute Delete Stored Procedure
                        result.Success = EnumerationManager.DeleteEnumeration(deleteEnumerationProc, dataConnector);

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
            /// This method fetches all 'Enumeration' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Enumeration' to delete.
            /// <returns>A PolymorphicObject object with all  'Enumerations' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                List<Enumeration> enumerationListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllEnumerationsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get EnumerationParameter
                    // Declare Parameter
                    Enumeration paramEnumeration = null;

                    // verify the first parameters is a(n) 'Enumeration'.
                    if (parameters[0].ObjectValue as Enumeration != null)
                    {
                        // Get EnumerationParameter
                        paramEnumeration = (Enumeration) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllEnumerationsProc from EnumerationWriter
                    fetchAllProc = EnumerationWriter.CreateFetchAllEnumerationsStoredProcedure(paramEnumeration);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    enumerationListCollection = EnumerationManager.FetchAllEnumerations(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(enumerationListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = enumerationListCollection;
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

            #region FindEnumeration(Enumeration)
            /// <summary>
            /// This method finds a 'Enumeration' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Enumeration' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindEnumeration(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                Enumeration enumeration = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindEnumerationStoredProcedure findEnumerationProc = null;

                    // verify the first parameters is a 'Enumeration'.
                    if (parameters[0].ObjectValue as Enumeration != null)
                    {
                        // Get EnumerationParameter
                        Enumeration paramEnumeration = (Enumeration) parameters[0].ObjectValue;

                        // verify paramEnumeration exists
                        if(paramEnumeration != null)
                        {
                            // Now create findEnumerationProc from EnumerationWriter
                            // The DataWriter converts the 'Enumeration'
                            // to the SqlParameter[] array needed to find a 'Enumeration'.
                            findEnumerationProc = EnumerationWriter.CreateFindEnumerationStoredProcedure(paramEnumeration);
                        }

                        // Verify findEnumerationProc exists
                        if(findEnumerationProc != null)
                        {
                            // Execute Find Stored Procedure
                            enumeration = EnumerationManager.FindEnumeration(findEnumerationProc, dataConnector);

                            // if dataObject exists
                            if(enumeration != null)
                            {
                                // set result.ObjectValue
                                result.ObjectValue = enumeration;
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

            #region InsertEnumeration (Enumeration)
            /// <summary>
            /// This method inserts a 'Enumeration' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Enumeration' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertEnumeration(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                Enumeration enumeration = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertEnumerationStoredProcedure insertEnumerationProc = null;

                    // verify the first parameters is a(n) 'Enumeration'.
                    if (parameters[0].ObjectValue as Enumeration != null)
                    {
                        // Create Enumeration Parameter
                        enumeration = (Enumeration) parameters[0].ObjectValue;

                        // verify enumeration exists
                        if(enumeration != null)
                        {
                            // Now create insertEnumerationProc from EnumerationWriter
                            // The DataWriter converts the 'Enumeration'
                            // to the SqlParameter[] array needed to insert a 'Enumeration'.
                            insertEnumerationProc = EnumerationWriter.CreateInsertEnumerationStoredProcedure(enumeration);
                        }

                        // Verify insertEnumerationProc exists
                        if(insertEnumerationProc != null)
                        {
                            // Execute Insert Stored Procedure
                            result.IntegerValue = EnumerationManager.InsertEnumeration(insertEnumerationProc, dataConnector);

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

            #region UpdateEnumeration (Enumeration)
            /// <summary>
            /// This method updates a 'Enumeration' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Enumeration' to update.
            /// <returns>A PolymorphicObject object.
            internal static PolymorphicObject UpdateEnumeration(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                Enumeration enumeration = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateEnumerationStoredProcedure updateEnumerationProc = null;

                    // verify the first parameters is a(n) 'Enumeration'.
                    if (parameters[0].ObjectValue as Enumeration != null)
                    {
                        // Create Enumeration Parameter
                        enumeration = (Enumeration) parameters[0].ObjectValue;

                        // verify enumeration exists
                        if(enumeration != null)
                        {
                            // Now create updateEnumerationProc from EnumerationWriter
                            // The DataWriter converts the 'Enumeration'
                            // to the SqlParameter[] array needed to update a 'Enumeration'.
                            updateEnumerationProc = EnumerationWriter.CreateUpdateEnumerationStoredProcedure(enumeration);
                        }

                        // Verify updateEnumerationProc exists
                        if(updateEnumerationProc != null)
                        {
                            // Execute Update Stored Procedure
                            result.Success = EnumerationManager.UpdateEnumeration(updateEnumerationProc, dataConnector);
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
