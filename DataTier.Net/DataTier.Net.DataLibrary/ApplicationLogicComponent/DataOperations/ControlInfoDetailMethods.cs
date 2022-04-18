

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

    #region class ControlInfoDetailMethods
    /// <summary>
    /// This class contains methods for modifying a 'ControlInfoDetail' object.
    /// </summary>
    public class ControlInfoDetailMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ControlInfoDetailMethods' object.
        /// </summary>
        public ControlInfoDetailMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteControlInfoDetail(ControlInfoDetail)
            /// <summary>
            /// This method deletes a 'ControlInfoDetail' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ControlInfoDetail' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteControlInfoDetail(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteControlInfoDetailStoredProcedure deleteControlInfoDetailProc = null;

                    // verify the first parameters is a(n) 'ControlInfoDetail'.
                    if (parameters[0].ObjectValue as ControlInfoDetail != null)
                    {
                        // Create ControlInfoDetail
                        ControlInfoDetail controlInfoDetail = (ControlInfoDetail) parameters[0].ObjectValue;

                        // verify controlInfoDetail exists
                        if(controlInfoDetail != null)
                        {
                            // Now create deleteControlInfoDetailProc from ControlInfoDetailWriter
                            // The DataWriter converts the 'ControlInfoDetail'
                            // to the SqlParameter[] array needed to delete a 'ControlInfoDetail'.
                            deleteControlInfoDetailProc = ControlInfoDetailWriter.CreateDeleteControlInfoDetailStoredProcedure(controlInfoDetail);
                        }
                    }

                    // Verify deleteControlInfoDetailProc exists
                    if(deleteControlInfoDetailProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.ControlInfoDetailManager.DeleteControlInfoDetail(deleteControlInfoDetailProc, dataConnector);

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
            /// This method fetches all 'ControlInfoDetail' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ControlInfoDetail' to delete.
            /// <returns>A PolymorphicObject object with all  'ControlInfoDetails' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ControlInfoDetail> controlInfoDetailListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllControlInfoDetailsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ControlInfoDetailParameter
                    // Declare Parameter
                    ControlInfoDetail paramControlInfoDetail = null;

                    // verify the first parameters is a(n) 'ControlInfoDetail'.
                    if (parameters[0].ObjectValue as ControlInfoDetail != null)
                    {
                        // Get ControlInfoDetailParameter
                        paramControlInfoDetail = (ControlInfoDetail) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllControlInfoDetailsProc from ControlInfoDetailWriter
                    fetchAllProc = ControlInfoDetailWriter.CreateFetchAllControlInfoDetailsStoredProcedure(paramControlInfoDetail);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    controlInfoDetailListCollection = this.DataManager.ControlInfoDetailManager.FetchAllControlInfoDetails(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(controlInfoDetailListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = controlInfoDetailListCollection;
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

            #region FindControlInfoDetail(ControlInfoDetail)
            /// <summary>
            /// This method finds a 'ControlInfoDetail' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ControlInfoDetail' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindControlInfoDetail(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ControlInfoDetail controlInfoDetail = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindControlInfoDetailStoredProcedure findControlInfoDetailProc = null;

                    // verify the first parameters is a 'ControlInfoDetail'.
                    if (parameters[0].ObjectValue as ControlInfoDetail != null)
                    {
                        // Get ControlInfoDetailParameter
                        ControlInfoDetail paramControlInfoDetail = (ControlInfoDetail) parameters[0].ObjectValue;

                        // verify paramControlInfoDetail exists
                        if(paramControlInfoDetail != null)
                        {
                            // Now create findControlInfoDetailProc from ControlInfoDetailWriter
                            // The DataWriter converts the 'ControlInfoDetail'
                            // to the SqlParameter[] array needed to find a 'ControlInfoDetail'.
                            findControlInfoDetailProc = ControlInfoDetailWriter.CreateFindControlInfoDetailStoredProcedure(paramControlInfoDetail);
                        }

                        // Verify findControlInfoDetailProc exists
                        if(findControlInfoDetailProc != null)
                        {
                            // Execute Find Stored Procedure
                            controlInfoDetail = this.DataManager.ControlInfoDetailManager.FindControlInfoDetail(findControlInfoDetailProc, dataConnector);

                            // if dataObject exists
                            if(controlInfoDetail != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = controlInfoDetail;
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

            #region InsertControlInfoDetail (ControlInfoDetail)
            /// <summary>
            /// This method inserts a 'ControlInfoDetail' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ControlInfoDetail' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertControlInfoDetail(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ControlInfoDetail controlInfoDetail = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertControlInfoDetailStoredProcedure insertControlInfoDetailProc = null;

                    // verify the first parameters is a(n) 'ControlInfoDetail'.
                    if (parameters[0].ObjectValue as ControlInfoDetail != null)
                    {
                        // Create ControlInfoDetail Parameter
                        controlInfoDetail = (ControlInfoDetail) parameters[0].ObjectValue;

                        // verify controlInfoDetail exists
                        if(controlInfoDetail != null)
                        {
                            // Now create insertControlInfoDetailProc from ControlInfoDetailWriter
                            // The DataWriter converts the 'ControlInfoDetail'
                            // to the SqlParameter[] array needed to insert a 'ControlInfoDetail'.
                            insertControlInfoDetailProc = ControlInfoDetailWriter.CreateInsertControlInfoDetailStoredProcedure(controlInfoDetail);
                        }

                        // Verify insertControlInfoDetailProc exists
                        if(insertControlInfoDetailProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.ControlInfoDetailManager.InsertControlInfoDetail(insertControlInfoDetailProc, dataConnector);
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

            #region UpdateControlInfoDetail (ControlInfoDetail)
            /// <summary>
            /// This method updates a 'ControlInfoDetail' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ControlInfoDetail' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateControlInfoDetail(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ControlInfoDetail controlInfoDetail = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateControlInfoDetailStoredProcedure updateControlInfoDetailProc = null;

                    // verify the first parameters is a(n) 'ControlInfoDetail'.
                    if (parameters[0].ObjectValue as ControlInfoDetail != null)
                    {
                        // Create ControlInfoDetail Parameter
                        controlInfoDetail = (ControlInfoDetail) parameters[0].ObjectValue;

                        // verify controlInfoDetail exists
                        if(controlInfoDetail != null)
                        {
                            // Now create updateControlInfoDetailProc from ControlInfoDetailWriter
                            // The DataWriter converts the 'ControlInfoDetail'
                            // to the SqlParameter[] array needed to update a 'ControlInfoDetail'.
                            updateControlInfoDetailProc = ControlInfoDetailWriter.CreateUpdateControlInfoDetailStoredProcedure(controlInfoDetail);
                        }

                        // Verify updateControlInfoDetailProc exists
                        if(updateControlInfoDetailProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.ControlInfoDetailManager.UpdateControlInfoDetail(updateControlInfoDetailProc, dataConnector);

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
