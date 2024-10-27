

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

    #region class MethodMethods
    /// <summary>
    /// This class contains methods for modifying a 'Method' object.
    /// </summary>
    public class MethodMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'MethodMethods' object.
        /// </summary>
        public MethodMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteMethod(Method)
            /// <summary>
            /// This method deletes a 'Method' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Method' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteMethod(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                        bool deleted = this.DataManager.MethodManager.DeleteMethod(deleteMethodProc, dataConnector);

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
            /// This method fetches all 'Method' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Method' to delete.
            /// <returns>A PolymorphicObject object with all  'Methods' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                    methodListCollection = this.DataManager.MethodManager.FetchAllMethods(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(methodListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = methodListCollection;
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

            #region FindMethod(Method)
            /// <summary>
            /// This method finds a 'Method' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Method' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindMethod(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            method = this.DataManager.MethodManager.FindMethod(findMethodProc, dataConnector);

                            // if dataObject exists
                            if(method != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = method;
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

            #region InsertMethod (Method)
            /// <summary>
            /// This method inserts a 'Method' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Method' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertMethod(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            returnObject.IntegerValue = this.DataManager.MethodManager.InsertMethod(insertMethodProc, dataConnector);
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

            #region UpdateMethod (Method)
            /// <summary>
            /// This method updates a 'Method' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Method' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateMethod(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            bool saved = this.DataManager.MethodManager.UpdateMethod(updateMethodProc, dataConnector);

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

        #region Properties

            #region DataManager 
            public DataManager DataManager 
            {
                get { return dataManager; }
                set { dataManager = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
