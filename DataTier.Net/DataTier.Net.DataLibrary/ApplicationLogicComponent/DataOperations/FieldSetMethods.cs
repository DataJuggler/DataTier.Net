

#region using statements

using ApplicationLogicComponent.DataBridge;
using DataAccessComponent.DataManager;
using DataAccessComponent.DataManager.Writers;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class FieldSetMethods
    /// <summary>
    /// This class contains methods for modifying a 'FieldSet' object.
    /// </summary>
    public class FieldSetMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'FieldSetMethods' object.
        /// </summary>
        public FieldSetMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteFieldSet(FieldSet)
            /// <summary>
            /// This method deletes a 'FieldSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSet' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteFieldSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteFieldSetStoredProcedure deleteFieldSetProc = null;

                    // verify the first parameters is a(n) 'FieldSet'.
                    if (parameters[0].ObjectValue as FieldSet != null)
                    {
                        // Create FieldSet
                        FieldSet fieldSet = (FieldSet) parameters[0].ObjectValue;

                        // verify fieldSet exists
                        if(fieldSet != null)
                        {
                            // Now create deleteFieldSetProc from FieldSetWriter
                            // The DataWriter converts the 'FieldSet'
                            // to the SqlParameter[] array needed to delete a 'FieldSet'.
                            deleteFieldSetProc = FieldSetWriter.CreateDeleteFieldSetStoredProcedure(fieldSet);
                        }
                    }

                    // Verify deleteFieldSetProc exists
                    if(deleteFieldSetProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.FieldSetManager.DeleteFieldSet(deleteFieldSetProc, dataConnector);

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
            /// This method fetches all 'FieldSet' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSet' to delete.
            /// <returns>A PolymorphicObject object with all  'FieldSets' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<FieldSet> fieldSetListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllFieldSetsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get FieldSetParameter
                    // Declare Parameter
                    FieldSet paramFieldSet = null;

                    // verify the first parameters is a(n) 'FieldSet'.
                    if (parameters[0].ObjectValue as FieldSet != null)
                    {
                        // Get FieldSetParameter
                        paramFieldSet = (FieldSet) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllFieldSetsProc from FieldSetWriter
                    fetchAllProc = FieldSetWriter.CreateFetchAllFieldSetsStoredProcedure(paramFieldSet);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    fieldSetListCollection = this.DataManager.FieldSetManager.FetchAllFieldSets(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(fieldSetListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = fieldSetListCollection;
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

            #region FindFieldSet(FieldSet)
            /// <summary>
            /// This method finds a 'FieldSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSet' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindFieldSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                FieldSet fieldSet = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindFieldSetStoredProcedure findFieldSetProc = null;

                    // verify the first parameters is a 'FieldSet'.
                    if (parameters[0].ObjectValue as FieldSet != null)
                    {
                        // Get FieldSetParameter
                        FieldSet paramFieldSet = (FieldSet) parameters[0].ObjectValue;

                        // verify paramFieldSet exists
                        if(paramFieldSet != null)
                        {
                            // Now create findFieldSetProc from FieldSetWriter
                            // The DataWriter converts the 'FieldSet'
                            // to the SqlParameter[] array needed to find a 'FieldSet'.
                            findFieldSetProc = FieldSetWriter.CreateFindFieldSetStoredProcedure(paramFieldSet);
                        }

                        // Verify findFieldSetProc exists
                        if(findFieldSetProc != null)
                        {
                            // Execute Find Stored Procedure
                            fieldSet = this.DataManager.FieldSetManager.FindFieldSet(findFieldSetProc, dataConnector);

                            // if dataObject exists
                            if(fieldSet != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = fieldSet;
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

            #region InsertFieldSet (FieldSet)
            /// <summary>
            /// This method inserts a 'FieldSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSet' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertFieldSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                FieldSet fieldSet = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertFieldSetStoredProcedure insertFieldSetProc = null;

                    // verify the first parameters is a(n) 'FieldSet'.
                    if (parameters[0].ObjectValue as FieldSet != null)
                    {
                        // Create FieldSet Parameter
                        fieldSet = (FieldSet) parameters[0].ObjectValue;

                        // verify fieldSet exists
                        if(fieldSet != null)
                        {
                            // Now create insertFieldSetProc from FieldSetWriter
                            // The DataWriter converts the 'FieldSet'
                            // to the SqlParameter[] array needed to insert a 'FieldSet'.
                            insertFieldSetProc = FieldSetWriter.CreateInsertFieldSetStoredProcedure(fieldSet);
                        }

                        // Verify insertFieldSetProc exists
                        if(insertFieldSetProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.FieldSetManager.InsertFieldSet(insertFieldSetProc, dataConnector);
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

            #region UpdateFieldSet (FieldSet)
            /// <summary>
            /// This method updates a 'FieldSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSet' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateFieldSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                FieldSet fieldSet = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateFieldSetStoredProcedure updateFieldSetProc = null;

                    // verify the first parameters is a(n) 'FieldSet'.
                    if (parameters[0].ObjectValue as FieldSet != null)
                    {
                        // Create FieldSet Parameter
                        fieldSet = (FieldSet) parameters[0].ObjectValue;

                        // verify fieldSet exists
                        if(fieldSet != null)
                        {
                            // Now create updateFieldSetProc from FieldSetWriter
                            // The DataWriter converts the 'FieldSet'
                            // to the SqlParameter[] array needed to update a 'FieldSet'.
                            updateFieldSetProc = FieldSetWriter.CreateUpdateFieldSetStoredProcedure(fieldSet);
                        }

                        // Verify updateFieldSetProc exists
                        if(updateFieldSetProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.FieldSetManager.UpdateFieldSet(updateFieldSetProc, dataConnector);

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
