

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
using DataJuggler.Net.Enumerations;

#endregion


namespace ApplicationLogicComponent.DataOperations
{

    #region class UIFieldMethods
    /// <summary>
    /// This class contains methods for modifying a 'UIField' object.
    /// </summary>
    public class UIFieldMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'UIFieldMethods' object.
        /// </summary>
        public UIFieldMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteUIField(UIField)
            /// <summary>
            /// This method deletes a 'UIField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UIField' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteUIField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteUIFieldStoredProcedure deleteUIFieldProc = null;

                    // verify the first parameters is a(n) 'UIField'.
                    if (parameters[0].ObjectValue as UIField != null)
                    {
                        // Create UIField
                        UIField uIField = (UIField) parameters[0].ObjectValue;

                        // verify uIField exists
                        if(uIField != null)
                        {
                            // Now create deleteUIFieldProc from UIFieldWriter
                            // The DataWriter converts the 'UIField'
                            // to the SqlParameter[] array needed to delete a 'UIField'.
                            deleteUIFieldProc = UIFieldWriter.CreateDeleteUIFieldStoredProcedure(uIField);
                        }
                    }

                    // Verify deleteUIFieldProc exists
                    if(deleteUIFieldProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.UIFieldManager.DeleteUIField(deleteUIFieldProc, dataConnector);

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
            /// This method fetches all 'UIField' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UIField' to delete.
            /// <returns>A PolymorphicObject object with all  'UIFields' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<UIField> uIFieldListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllUIFieldsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get UIFieldParameter
                    // Declare Parameter
                    UIField paramUIField = null;

                    // verify the first parameters is a(n) 'UIField'.
                    if (parameters[0].ObjectValue as UIField != null)
                    {
                        // Get UIFieldParameter
                        paramUIField = (UIField) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllUIFieldsProc from UIFieldWriter
                    fetchAllProc = UIFieldWriter.CreateFetchAllUIFieldsStoredProcedure(paramUIField);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    uIFieldListCollection = this.DataManager.UIFieldManager.FetchAllUIFields(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(uIFieldListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = uIFieldListCollection;
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

            #region FindUIField(UIField)
            /// <summary>
            /// This method finds a 'UIField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UIField' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindUIField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                UIField uIField = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindUIFieldStoredProcedure findUIFieldProc = null;

                    // verify the first parameters is a 'UIField'.
                    if (parameters[0].ObjectValue as UIField != null)
                    {
                        // Get UIFieldParameter
                        UIField paramUIField = (UIField) parameters[0].ObjectValue;

                        // verify paramUIField exists
                        if(paramUIField != null)
                        {
                            // Now create findUIFieldProc from UIFieldWriter
                            // The DataWriter converts the 'UIField'
                            // to the SqlParameter[] array needed to find a 'UIField'.
                            findUIFieldProc = UIFieldWriter.CreateFindUIFieldStoredProcedure(paramUIField);
                        }

                        // Verify findUIFieldProc exists
                        if(findUIFieldProc != null)
                        {
                            // Execute Find Stored Procedure
                            uIField = this.DataManager.UIFieldManager.FindUIField(findUIFieldProc, dataConnector);

                            // if dataObject exists
                            if(uIField != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = uIField;
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

            #region InsertUIField (UIField)
            /// <summary>
            /// This method inserts a 'UIField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UIField' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertUIField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                UIField uIField = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertUIFieldStoredProcedure insertUIFieldProc = null;

                    // verify the first parameters is a(n) 'UIField'.
                    if (parameters[0].ObjectValue as UIField != null)
                    {
                        // Create UIField Parameter
                        uIField = (UIField) parameters[0].ObjectValue;

                        // verify uIField exists
                        if(uIField != null)
                        {
                            // Now create insertUIFieldProc from UIFieldWriter
                            // The DataWriter converts the 'UIField'
                            // to the SqlParameter[] array needed to insert a 'UIField'.
                            insertUIFieldProc = UIFieldWriter.CreateInsertUIFieldStoredProcedure(uIField);
                        }

                        // Verify insertUIFieldProc exists
                        if(insertUIFieldProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.UIFieldManager.InsertUIField(insertUIFieldProc, dataConnector);
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

            #region UpdateUIField (UIField)
            /// <summary>
            /// This method updates a 'UIField' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UIField' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateUIField(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                UIField uIField = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateUIFieldStoredProcedure updateUIFieldProc = null;

                    // verify the first parameters is a(n) 'UIField'.
                    if (parameters[0].ObjectValue as UIField != null)
                    {
                        // Create UIField Parameter
                        uIField = (UIField) parameters[0].ObjectValue;

                        // verify uIField exists
                        if(uIField != null)
                        {
                            // Now create updateUIFieldProc from UIFieldWriter
                            // The DataWriter converts the 'UIField'
                            // to the SqlParameter[] array needed to update a 'UIField'.
                            updateUIFieldProc = UIFieldWriter.CreateUpdateUIFieldStoredProcedure(uIField);
                        }

                        // Verify updateUIFieldProc exists
                        if(updateUIFieldProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.UIFieldManager.UpdateUIField(updateUIFieldProc, dataConnector);

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
