

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

    #region class FieldSetFieldMethods
    /// <summary>
    /// This class contains methods for modifying a 'FieldSetField' object.
    /// </summary>
    public static class FieldSetFieldMethods
    {

        #region Methods

            #region DeleteFieldSetField(FieldSetField)
            /// <summary>
            /// This method deletes a 'FieldSetField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSetField' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteFieldSetField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteFieldSetFieldStoredProcedure deleteFieldSetFieldProc = null;

                    // verify the first parameters is a(n) 'FieldSetField'.
                    if (parameters[0].ObjectValue as FieldSetField != null)
                    {
                        // Create FieldSetField
                        FieldSetField fieldSetField = (FieldSetField) parameters[0].ObjectValue;

                        // verify fieldSetField exists
                        if(fieldSetField != null)
                        {
                            // Now create deleteFieldSetFieldProc from FieldSetFieldWriter
                            // The DataWriter converts the 'FieldSetField'
                            // to the SqlParameter[] array needed to delete a 'FieldSetField'.
                            deleteFieldSetFieldProc = FieldSetFieldWriter.CreateDeleteFieldSetFieldStoredProcedure(fieldSetField);
                        }
                    }

                    // Verify deleteFieldSetFieldProc exists
                    if(deleteFieldSetFieldProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = FieldSetFieldManager.DeleteFieldSetField(deleteFieldSetFieldProc, dataConnector);

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
            /// This method fetches all 'FieldSetField' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSetField' to delete.
            /// <returns>A PolymorphicObject object with all  'FieldSetFields' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<FieldSetField> fieldSetFieldListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllFieldSetFieldsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get FieldSetFieldParameter
                    // Declare Parameter
                    FieldSetField paramFieldSetField = null;

                    // verify the first parameters is a(n) 'FieldSetField'.
                    if (parameters[0].ObjectValue as FieldSetField != null)
                    {
                        // Get FieldSetFieldParameter
                        paramFieldSetField = (FieldSetField) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllFieldSetFieldsProc from FieldSetFieldWriter
                    fetchAllProc = FieldSetFieldWriter.CreateFetchAllFieldSetFieldsStoredProcedure(paramFieldSetField);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    fieldSetFieldListCollection = FieldSetFieldManager.FetchAllFieldSetFields(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(fieldSetFieldListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = fieldSetFieldListCollection;
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

            #region FindFieldSetField(FieldSetField)
            /// <summary>
            /// This method finds a 'FieldSetField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSetField' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindFieldSetField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                FieldSetField fieldSetField = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindFieldSetFieldStoredProcedure findFieldSetFieldProc = null;

                    // verify the first parameters is a 'FieldSetField'.
                    if (parameters[0].ObjectValue as FieldSetField != null)
                    {
                        // Get FieldSetFieldParameter
                        FieldSetField paramFieldSetField = (FieldSetField) parameters[0].ObjectValue;

                        // verify paramFieldSetField exists
                        if(paramFieldSetField != null)
                        {
                            // Now create findFieldSetFieldProc from FieldSetFieldWriter
                            // The DataWriter converts the 'FieldSetField'
                            // to the SqlParameter[] array needed to find a 'FieldSetField'.
                            findFieldSetFieldProc = FieldSetFieldWriter.CreateFindFieldSetFieldStoredProcedure(paramFieldSetField);
                        }

                        // Verify findFieldSetFieldProc exists
                        if(findFieldSetFieldProc != null)
                        {
                            // Execute Find Stored Procedure
                            fieldSetField = FieldSetFieldManager.FindFieldSetField(findFieldSetFieldProc, dataConnector);

                            // if dataObject exists
                            if(fieldSetField != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = fieldSetField;
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

            #region InsertFieldSetField (FieldSetField)
            /// <summary>
            /// This method inserts a 'FieldSetField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSetField' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertFieldSetField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                FieldSetField fieldSetField = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertFieldSetFieldStoredProcedure insertFieldSetFieldProc = null;

                    // verify the first parameters is a(n) 'FieldSetField'.
                    if (parameters[0].ObjectValue as FieldSetField != null)
                    {
                        // Create FieldSetField Parameter
                        fieldSetField = (FieldSetField) parameters[0].ObjectValue;

                        // verify fieldSetField exists
                        if(fieldSetField != null)
                        {
                            // Now create insertFieldSetFieldProc from FieldSetFieldWriter
                            // The DataWriter converts the 'FieldSetField'
                            // to the SqlParameter[] array needed to insert a 'FieldSetField'.
                            insertFieldSetFieldProc = FieldSetFieldWriter.CreateInsertFieldSetFieldStoredProcedure(fieldSetField);
                        }

                        // Verify insertFieldSetFieldProc exists
                        if(insertFieldSetFieldProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = FieldSetFieldManager.InsertFieldSetField(insertFieldSetFieldProc, dataConnector);
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

            #region UpdateFieldSetField (FieldSetField)
            /// <summary>
            /// This method updates a 'FieldSetField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'FieldSetField' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateFieldSetField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                FieldSetField fieldSetField = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateFieldSetFieldStoredProcedure updateFieldSetFieldProc = null;

                    // verify the first parameters is a(n) 'FieldSetField'.
                    if (parameters[0].ObjectValue as FieldSetField != null)
                    {
                        // Create FieldSetField Parameter
                        fieldSetField = (FieldSetField) parameters[0].ObjectValue;

                        // verify fieldSetField exists
                        if(fieldSetField != null)
                        {
                            // Now create updateFieldSetFieldProc from FieldSetFieldWriter
                            // The DataWriter converts the 'FieldSetField'
                            // to the SqlParameter[] array needed to update a 'FieldSetField'.
                            updateFieldSetFieldProc = FieldSetFieldWriter.CreateUpdateFieldSetFieldStoredProcedure(fieldSetField);
                        }

                        // Verify updateFieldSetFieldProc exists
                        if(updateFieldSetFieldProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = FieldSetFieldManager.UpdateFieldSetField(updateFieldSetFieldProc, dataConnector);

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
