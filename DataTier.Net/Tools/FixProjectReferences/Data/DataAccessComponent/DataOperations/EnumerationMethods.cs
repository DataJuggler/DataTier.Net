

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

    #region class EnumerationMethods
    /// <summary>
    /// This class contains methods for modifying a 'Enumeration' object.
    /// </summary>
    public class EnumerationMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'EnumerationMethods' object.
        /// </summary>
        public EnumerationMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteEnumeration(Enumeration)
            /// <summary>
            /// This method deletes a 'Enumeration' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Enumeration' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteEnumeration(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                        bool deleted = this.DataManager.EnumerationManager.DeleteEnumeration(deleteEnumerationProc, dataConnector);

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
            /// This method fetches all 'Enumeration' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Enumeration' to delete.
            /// <returns>A PolymorphicObject object with all  'Enumerations' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                    enumerationListCollection = this.DataManager.EnumerationManager.FetchAllEnumerations(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(enumerationListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = enumerationListCollection;
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

            #region FindEnumeration(Enumeration)
            /// <summary>
            /// This method finds a 'Enumeration' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Enumeration' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindEnumeration(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            enumeration = this.DataManager.EnumerationManager.FindEnumeration(findEnumerationProc, dataConnector);

                            // if dataObject exists
                            if(enumeration != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = enumeration;
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

            #region InsertEnumeration (Enumeration)
            /// <summary>
            /// This method inserts a 'Enumeration' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Enumeration' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertEnumeration(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            returnObject.IntegerValue = this.DataManager.EnumerationManager.InsertEnumeration(insertEnumerationProc, dataConnector);
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

            #region UpdateEnumeration (Enumeration)
            /// <summary>
            /// This method updates a 'Enumeration' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'Enumeration' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateEnumeration(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            bool saved = this.DataManager.EnumerationManager.UpdateEnumeration(updateEnumerationProc, dataConnector);

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
