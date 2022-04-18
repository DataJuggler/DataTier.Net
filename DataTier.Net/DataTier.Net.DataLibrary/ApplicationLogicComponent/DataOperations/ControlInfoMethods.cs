

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

    #region class ControlInfoMethods
    /// <summary>
    /// This class contains methods for modifying a 'ControlInfo' object.
    /// </summary>
    public class ControlInfoMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ControlInfoMethods' object.
        /// </summary>
        public ControlInfoMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteControlInfo(ControlInfo)
            /// <summary>
            /// This method deletes a 'ControlInfo' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ControlInfo' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteControlInfo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteControlInfoStoredProcedure deleteControlInfoProc = null;

                    // verify the first parameters is a(n) 'ControlInfo'.
                    if (parameters[0].ObjectValue as ControlInfo != null)
                    {
                        // Create ControlInfo
                        ControlInfo controlInfo = (ControlInfo) parameters[0].ObjectValue;

                        // verify controlInfo exists
                        if(controlInfo != null)
                        {
                            // Now create deleteControlInfoProc from ControlInfoWriter
                            // The DataWriter converts the 'ControlInfo'
                            // to the SqlParameter[] array needed to delete a 'ControlInfo'.
                            deleteControlInfoProc = ControlInfoWriter.CreateDeleteControlInfoStoredProcedure(controlInfo);
                        }
                    }

                    // Verify deleteControlInfoProc exists
                    if(deleteControlInfoProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.ControlInfoManager.DeleteControlInfo(deleteControlInfoProc, dataConnector);

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
            /// This method fetches all 'ControlInfo' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ControlInfo' to delete.
            /// <returns>A PolymorphicObject object with all  'ControlInfos' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ControlInfo> controlInfoListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllControlInfosStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ControlInfoParameter
                    // Declare Parameter
                    ControlInfo paramControlInfo = null;

                    // verify the first parameters is a(n) 'ControlInfo'.
                    if (parameters[0].ObjectValue as ControlInfo != null)
                    {
                        // Get ControlInfoParameter
                        paramControlInfo = (ControlInfo) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllControlInfosProc from ControlInfoWriter
                    fetchAllProc = ControlInfoWriter.CreateFetchAllControlInfosStoredProcedure(paramControlInfo);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    controlInfoListCollection = this.DataManager.ControlInfoManager.FetchAllControlInfos(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(controlInfoListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = controlInfoListCollection;
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

            #region FindControlInfo(ControlInfo)
            /// <summary>
            /// This method finds a 'ControlInfo' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ControlInfo' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindControlInfo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ControlInfo controlInfo = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindControlInfoStoredProcedure findControlInfoProc = null;

                    // verify the first parameters is a 'ControlInfo'.
                    if (parameters[0].ObjectValue as ControlInfo != null)
                    {
                        // Get ControlInfoParameter
                        ControlInfo paramControlInfo = (ControlInfo) parameters[0].ObjectValue;

                        // verify paramControlInfo exists
                        if(paramControlInfo != null)
                        {
                            // Now create findControlInfoProc from ControlInfoWriter
                            // The DataWriter converts the 'ControlInfo'
                            // to the SqlParameter[] array needed to find a 'ControlInfo'.
                            findControlInfoProc = ControlInfoWriter.CreateFindControlInfoStoredProcedure(paramControlInfo);
                        }

                        // Verify findControlInfoProc exists
                        if(findControlInfoProc != null)
                        {
                            // Execute Find Stored Procedure
                            controlInfo = this.DataManager.ControlInfoManager.FindControlInfo(findControlInfoProc, dataConnector);

                            // if dataObject exists
                            if(controlInfo != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = controlInfo;
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

            #region InsertControlInfo (ControlInfo)
            /// <summary>
            /// This method inserts a 'ControlInfo' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ControlInfo' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertControlInfo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ControlInfo controlInfo = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertControlInfoStoredProcedure insertControlInfoProc = null;

                    // verify the first parameters is a(n) 'ControlInfo'.
                    if (parameters[0].ObjectValue as ControlInfo != null)
                    {
                        // Create ControlInfo Parameter
                        controlInfo = (ControlInfo) parameters[0].ObjectValue;

                        // verify controlInfo exists
                        if(controlInfo != null)
                        {
                            // Now create insertControlInfoProc from ControlInfoWriter
                            // The DataWriter converts the 'ControlInfo'
                            // to the SqlParameter[] array needed to insert a 'ControlInfo'.
                            insertControlInfoProc = ControlInfoWriter.CreateInsertControlInfoStoredProcedure(controlInfo);
                        }

                        // Verify insertControlInfoProc exists
                        if(insertControlInfoProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.ControlInfoManager.InsertControlInfo(insertControlInfoProc, dataConnector);
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

            #region UpdateControlInfo (ControlInfo)
            /// <summary>
            /// This method updates a 'ControlInfo' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ControlInfo' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateControlInfo(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ControlInfo controlInfo = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateControlInfoStoredProcedure updateControlInfoProc = null;

                    // verify the first parameters is a(n) 'ControlInfo'.
                    if (parameters[0].ObjectValue as ControlInfo != null)
                    {
                        // Create ControlInfo Parameter
                        controlInfo = (ControlInfo) parameters[0].ObjectValue;

                        // verify controlInfo exists
                        if(controlInfo != null)
                        {
                            // Now create updateControlInfoProc from ControlInfoWriter
                            // The DataWriter converts the 'ControlInfo'
                            // to the SqlParameter[] array needed to update a 'ControlInfo'.
                            updateControlInfoProc = ControlInfoWriter.CreateUpdateControlInfoStoredProcedure(controlInfo);
                        }

                        // Verify updateControlInfoProc exists
                        if(updateControlInfoProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.ControlInfoManager.UpdateControlInfo(updateControlInfoProc, dataConnector);

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
