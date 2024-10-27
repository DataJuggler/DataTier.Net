

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

    #region class DTNFieldMethods
    /// <summary>
    /// This class contains methods for modifying a 'DTNField' object.
    /// </summary>
    public class DTNFieldMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'DTNFieldMethods' object.
        /// </summary>
        public DTNFieldMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteDTNField(DTNField)
            /// <summary>
            /// This method deletes a 'DTNField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNField' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteDTNField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                        bool deleted = this.DataManager.DTNFieldManager.DeleteDTNField(deleteDTNFieldProc, dataConnector);

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
            /// This method fetches all 'DTNField' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNField' to delete.
            /// <returns>A PolymorphicObject object with all  'DTNFields' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                    dTNFieldListCollection = this.DataManager.DTNFieldManager.FetchAllDTNFields(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(dTNFieldListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = dTNFieldListCollection;
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

            #region FindDTNField(DTNField)
            /// <summary>
            /// This method finds a 'DTNField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNField' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindDTNField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            dTNField = this.DataManager.DTNFieldManager.FindDTNField(findDTNFieldProc, dataConnector);

                            // if dataObject exists
                            if(dTNField != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = dTNField;
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

            #region InsertDTNField (DTNField)
            /// <summary>
            /// This method inserts a 'DTNField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNField' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertDTNField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            returnObject.IntegerValue = this.DataManager.DTNFieldManager.InsertDTNField(insertDTNFieldProc, dataConnector);
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

            #region UpdateDTNField (DTNField)
            /// <summary>
            /// This method updates a 'DTNField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'DTNField' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateDTNField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

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
                            bool saved = this.DataManager.DTNFieldManager.UpdateDTNField(updateDTNFieldProc, dataConnector);

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
