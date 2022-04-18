

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

    #region class UIObjectMethods
    /// <summary>
    /// This class contains methods for modifying a 'UIObject' object.
    /// </summary>
    public class UIObjectMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'UIObjectMethods' object.
        /// </summary>
        public UIObjectMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteUIObject(UIObject)
            /// <summary>
            /// This method deletes a 'UIObject' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UIObject' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteUIObject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteUIObjectStoredProcedure deleteUIObjectProc = null;

                    // verify the first parameters is a(n) 'UIObject'.
                    if (parameters[0].ObjectValue as UIObject != null)
                    {
                        // Create UIObject
                        UIObject uIObject = (UIObject) parameters[0].ObjectValue;

                        // verify uIObject exists
                        if(uIObject != null)
                        {
                            // Now create deleteUIObjectProc from UIObjectWriter
                            // The DataWriter converts the 'UIObject'
                            // to the SqlParameter[] array needed to delete a 'UIObject'.
                            deleteUIObjectProc = UIObjectWriter.CreateDeleteUIObjectStoredProcedure(uIObject);
                        }
                    }

                    // Verify deleteUIObjectProc exists
                    if(deleteUIObjectProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.UIObjectManager.DeleteUIObject(deleteUIObjectProc, dataConnector);

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
            /// This method fetches all 'UIObject' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UIObject' to delete.
            /// <returns>A PolymorphicObject object with all  'UIObjects' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<UIObject> uIObjectListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllUIObjectsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get UIObjectParameter
                    // Declare Parameter
                    UIObject paramUIObject = null;

                    // verify the first parameters is a(n) 'UIObject'.
                    if (parameters[0].ObjectValue as UIObject != null)
                    {
                        // Get UIObjectParameter
                        paramUIObject = (UIObject) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllUIObjectsProc from UIObjectWriter
                    fetchAllProc = UIObjectWriter.CreateFetchAllUIObjectsStoredProcedure(paramUIObject);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    uIObjectListCollection = this.DataManager.UIObjectManager.FetchAllUIObjects(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(uIObjectListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = uIObjectListCollection;
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

            #region FindUIObject(UIObject)
            /// <summary>
            /// This method finds a 'UIObject' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UIObject' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindUIObject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                UIObject uIObject = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindUIObjectStoredProcedure findUIObjectProc = null;

                    // verify the first parameters is a 'UIObject'.
                    if (parameters[0].ObjectValue as UIObject != null)
                    {
                        // Get UIObjectParameter
                        UIObject paramUIObject = (UIObject) parameters[0].ObjectValue;

                        // verify paramUIObject exists
                        if(paramUIObject != null)
                        {
                            // Now create findUIObjectProc from UIObjectWriter
                            // The DataWriter converts the 'UIObject'
                            // to the SqlParameter[] array needed to find a 'UIObject'.
                            findUIObjectProc = UIObjectWriter.CreateFindUIObjectStoredProcedure(paramUIObject);
                        }

                        // Verify findUIObjectProc exists
                        if(findUIObjectProc != null)
                        {
                            // Execute Find Stored Procedure
                            uIObject = this.DataManager.UIObjectManager.FindUIObject(findUIObjectProc, dataConnector);

                            // if dataObject exists
                            if(uIObject != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = uIObject;
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

            #region InsertUIObject (UIObject)
            /// <summary>
            /// This method inserts a 'UIObject' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UIObject' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertUIObject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                UIObject uIObject = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertUIObjectStoredProcedure insertUIObjectProc = null;

                    // verify the first parameters is a(n) 'UIObject'.
                    if (parameters[0].ObjectValue as UIObject != null)
                    {
                        // Create UIObject Parameter
                        uIObject = (UIObject) parameters[0].ObjectValue;

                        // verify uIObject exists
                        if(uIObject != null)
                        {
                            // Now create insertUIObjectProc from UIObjectWriter
                            // The DataWriter converts the 'UIObject'
                            // to the SqlParameter[] array needed to insert a 'UIObject'.
                            insertUIObjectProc = UIObjectWriter.CreateInsertUIObjectStoredProcedure(uIObject);
                        }

                        // Verify insertUIObjectProc exists
                        if(insertUIObjectProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.UIObjectManager.InsertUIObject(insertUIObjectProc, dataConnector);
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

            #region UpdateUIObject (UIObject)
            /// <summary>
            /// This method updates a 'UIObject' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'UIObject' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateUIObject(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                UIObject uIObject = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateUIObjectStoredProcedure updateUIObjectProc = null;

                    // verify the first parameters is a(n) 'UIObject'.
                    if (parameters[0].ObjectValue as UIObject != null)
                    {
                        // Create UIObject Parameter
                        uIObject = (UIObject) parameters[0].ObjectValue;

                        // verify uIObject exists
                        if(uIObject != null)
                        {
                            // Now create updateUIObjectProc from UIObjectWriter
                            // The DataWriter converts the 'UIObject'
                            // to the SqlParameter[] array needed to update a 'UIObject'.
                            updateUIObjectProc = UIObjectWriter.CreateUpdateUIObjectStoredProcedure(uIObject);
                        }

                        // Verify updateUIObjectProc exists
                        if(updateUIObjectProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.UIObjectManager.UpdateUIObject(updateUIObjectProc, dataConnector);

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
