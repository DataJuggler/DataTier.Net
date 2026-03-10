

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

    #region class MethodMethods
    /// <summary>
    /// This class contains methods for modifying a 'Method' object.
    /// </summary>
    public static class MethodMethods
    {

        #region Methods

            #region DeleteMethod(Method)
            /// <summary>
            /// This method deletes a 'Method' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Method' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteMethod(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteMethodStoredProcedure deleteMethodProc = null;

                    // verify the first parameters is a(n) 'Method'.
                    if (parameters[0].ObjectValue as Method != null)
                    {
                        // Create Method
                        Method method = (Method) parameters[0].ObjectValue;

                        // verify method exists
                        if(method != null)
                        {
                            // Now create deleteMethodProc from MethodWriter
                            // The DataWriter converts the 'Method'
                            // to the SqlParameter[] array needed to delete a 'Method'.
                            deleteMethodProc = MethodWriter.CreateDeleteMethodStoredProcedure(method);
                        }
                    }

                    // Verify deleteMethodProc exists
                    if(deleteMethodProc != null)
                    {
                        // Execute Delete Stored Procedure
                        result.Success = MethodManager.DeleteMethod(deleteMethodProc, dataConnector);

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
            /// This method fetches all 'Method' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Method' to delete.
            /// <returns>A PolymorphicObject object with all  'Methods' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                List<Method> methodListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllMethodsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get MethodParameter
                    // Declare Parameter
                    Method paramMethod = null;

                    // verify the first parameters is a(n) 'Method'.
                    if (parameters[0].ObjectValue as Method != null)
                    {
                        // Get MethodParameter
                        paramMethod = (Method) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllMethodsProc from MethodWriter
                    fetchAllProc = MethodWriter.CreateFetchAllMethodsStoredProcedure(paramMethod);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    methodListCollection = MethodManager.FetchAllMethods(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(methodListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = methodListCollection;
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

            #region FindMethod(Method)
            /// <summary>
            /// This method finds a 'Method' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Method' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindMethod(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                Method method = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindMethodStoredProcedure findMethodProc = null;

                    // verify the first parameters is a 'Method'.
                    if (parameters[0].ObjectValue as Method != null)
                    {
                        // Get MethodParameter
                        Method paramMethod = (Method) parameters[0].ObjectValue;

                        // verify paramMethod exists
                        if(paramMethod != null)
                        {
                            // Now create findMethodProc from MethodWriter
                            // The DataWriter converts the 'Method'
                            // to the SqlParameter[] array needed to find a 'Method'.
                            findMethodProc = MethodWriter.CreateFindMethodStoredProcedure(paramMethod);
                        }

                        // Verify findMethodProc exists
                        if(findMethodProc != null)
                        {
                            // Execute Find Stored Procedure
                            method = MethodManager.FindMethod(findMethodProc, dataConnector);

                            // if dataObject exists
                            if(method != null)
                            {
                                // set result.ObjectValue
                                result.ObjectValue = method;
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

            #region InsertMethod (Method)
            /// <summary>
            /// This method inserts a 'Method' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Method' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertMethod(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                Method method = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertMethodStoredProcedure insertMethodProc = null;

                    // verify the first parameters is a(n) 'Method'.
                    if (parameters[0].ObjectValue as Method != null)
                    {
                        // Create Method Parameter
                        method = (Method) parameters[0].ObjectValue;

                        // verify method exists
                        if(method != null)
                        {
                            // Now create insertMethodProc from MethodWriter
                            // The DataWriter converts the 'Method'
                            // to the SqlParameter[] array needed to insert a 'Method'.
                            insertMethodProc = MethodWriter.CreateInsertMethodStoredProcedure(method);
                        }

                        // Verify insertMethodProc exists
                        if(insertMethodProc != null)
                        {
                            // Execute Insert Stored Procedure
                            result.IntegerValue = MethodManager.InsertMethod(insertMethodProc, dataConnector);

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

            #region UpdateMethod (Method)
            /// <summary>
            /// This method updates a 'Method' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Method' to update.
            /// <returns>A PolymorphicObject object.
            internal static PolymorphicObject UpdateMethod(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                Method method = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateMethodStoredProcedure updateMethodProc = null;

                    // verify the first parameters is a(n) 'Method'.
                    if (parameters[0].ObjectValue as Method != null)
                    {
                        // Create Method Parameter
                        method = (Method) parameters[0].ObjectValue;

                        // verify method exists
                        if(method != null)
                        {
                            // Now create updateMethodProc from MethodWriter
                            // The DataWriter converts the 'Method'
                            // to the SqlParameter[] array needed to update a 'Method'.
                            updateMethodProc = MethodWriter.CreateUpdateMethodStoredProcedure(method);
                        }

                        // Verify updateMethodProc exists
                        if(updateMethodProc != null)
                        {
                            // Execute Update Stored Procedure
                            result.Success = MethodManager.UpdateMethod(updateMethodProc, dataConnector);
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
