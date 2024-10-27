

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

    #region class ReferencesSetMethods
    /// <summary>
    /// This class contains methods for modifying a 'ReferencesSet' object.
    /// </summary>
    public class ReferencesSetMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ReferencesSetMethods' object.
        /// </summary>
        public ReferencesSetMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteReferencesSet(ReferencesSet)
            /// <summary>
            /// This method deletes a 'ReferencesSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ReferencesSet' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteReferencesSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteReferencesSetStoredProcedure deleteReferencesSetProc = null;

                    // verify the first parameters is a(n) 'ReferencesSet'.
                    if (parameters[0].ObjectValue as ReferencesSet != null)
                    {
                        // Create ReferencesSet
                        ReferencesSet referencesSet = (ReferencesSet) parameters[0].ObjectValue;

                        // verify referencesSet exists
                        if(referencesSet != null)
                        {
                            // Now create deleteReferencesSetProc from ReferencesSetWriter
                            // The DataWriter converts the 'ReferencesSet'
                            // to the SqlParameter[] array needed to delete a 'ReferencesSet'.
                            deleteReferencesSetProc = ReferencesSetWriter.CreateDeleteReferencesSetStoredProcedure(referencesSet);
                        }
                    }

                    // Verify deleteReferencesSetProc exists
                    if(deleteReferencesSetProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.ReferencesSetManager.DeleteReferencesSet(deleteReferencesSetProc, dataConnector);

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
            /// This method fetches all 'ReferencesSet' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ReferencesSet' to delete.
            /// <returns>A PolymorphicObject object with all  'ReferencesSets' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ReferencesSet> referencesSetListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllReferencesSetsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ReferencesSetParameter
                    // Declare Parameter
                    ReferencesSet paramReferencesSet = null;

                    // verify the first parameters is a(n) 'ReferencesSet'.
                    if (parameters[0].ObjectValue as ReferencesSet != null)
                    {
                        // Get ReferencesSetParameter
                        paramReferencesSet = (ReferencesSet) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllReferencesSetsProc from ReferencesSetWriter
                    fetchAllProc = ReferencesSetWriter.CreateFetchAllReferencesSetsStoredProcedure(paramReferencesSet);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    referencesSetListCollection = this.DataManager.ReferencesSetManager.FetchAllReferencesSets(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(referencesSetListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = referencesSetListCollection;
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

            #region FindReferencesSet(ReferencesSet)
            /// <summary>
            /// This method finds a 'ReferencesSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ReferencesSet' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindReferencesSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ReferencesSet referencesSet = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindReferencesSetStoredProcedure findReferencesSetProc = null;

                    // verify the first parameters is a 'ReferencesSet'.
                    if (parameters[0].ObjectValue as ReferencesSet != null)
                    {
                        // Get ReferencesSetParameter
                        ReferencesSet paramReferencesSet = (ReferencesSet) parameters[0].ObjectValue;

                        // verify paramReferencesSet exists
                        if(paramReferencesSet != null)
                        {
                            // Now create findReferencesSetProc from ReferencesSetWriter
                            // The DataWriter converts the 'ReferencesSet'
                            // to the SqlParameter[] array needed to find a 'ReferencesSet'.
                            findReferencesSetProc = ReferencesSetWriter.CreateFindReferencesSetStoredProcedure(paramReferencesSet);
                        }

                        // Verify findReferencesSetProc exists
                        if(findReferencesSetProc != null)
                        {
                            // Execute Find Stored Procedure
                            referencesSet = this.DataManager.ReferencesSetManager.FindReferencesSet(findReferencesSetProc, dataConnector);

                            // if dataObject exists
                            if(referencesSet != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = referencesSet;
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

            #region InsertReferencesSet (ReferencesSet)
            /// <summary>
            /// This method inserts a 'ReferencesSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ReferencesSet' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertReferencesSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ReferencesSet referencesSet = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertReferencesSetStoredProcedure insertReferencesSetProc = null;

                    // verify the first parameters is a(n) 'ReferencesSet'.
                    if (parameters[0].ObjectValue as ReferencesSet != null)
                    {
                        // Create ReferencesSet Parameter
                        referencesSet = (ReferencesSet) parameters[0].ObjectValue;

                        // verify referencesSet exists
                        if(referencesSet != null)
                        {
                            // Now create insertReferencesSetProc from ReferencesSetWriter
                            // The DataWriter converts the 'ReferencesSet'
                            // to the SqlParameter[] array needed to insert a 'ReferencesSet'.
                            insertReferencesSetProc = ReferencesSetWriter.CreateInsertReferencesSetStoredProcedure(referencesSet);
                        }

                        // Verify insertReferencesSetProc exists
                        if(insertReferencesSetProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.ReferencesSetManager.InsertReferencesSet(insertReferencesSetProc, dataConnector);
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

            #region UpdateReferencesSet (ReferencesSet)
            /// <summary>
            /// This method updates a 'ReferencesSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ReferencesSet' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateReferencesSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                ReferencesSet referencesSet = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateReferencesSetStoredProcedure updateReferencesSetProc = null;

                    // verify the first parameters is a(n) 'ReferencesSet'.
                    if (parameters[0].ObjectValue as ReferencesSet != null)
                    {
                        // Create ReferencesSet Parameter
                        referencesSet = (ReferencesSet) parameters[0].ObjectValue;

                        // verify referencesSet exists
                        if(referencesSet != null)
                        {
                            // Now create updateReferencesSetProc from ReferencesSetWriter
                            // The DataWriter converts the 'ReferencesSet'
                            // to the SqlParameter[] array needed to update a 'ReferencesSet'.
                            updateReferencesSetProc = ReferencesSetWriter.CreateUpdateReferencesSetStoredProcedure(referencesSet);
                        }

                        // Verify updateReferencesSetProc exists
                        if(updateReferencesSetProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.ReferencesSetManager.UpdateReferencesSet(updateReferencesSetProc, dataConnector);

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
