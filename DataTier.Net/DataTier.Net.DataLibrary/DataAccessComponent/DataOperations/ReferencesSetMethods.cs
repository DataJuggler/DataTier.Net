

#region using statements

using System;
using System.Collections.Generic;
using DataAccessComponent.StoredProcedureManager.DeleteProcedures;
using DataAccessComponent.StoredProcedureManager.FetchProcedures;
using DataAccessComponent.StoredProcedureManager.InsertProcedures;
using DataAccessComponent.StoredProcedureManager.UpdateProcedures;
using ObjectLibrary.BusinessObjects;
using DataAccessComponent.Data.Writers;
using DataAccessComponent.Data;
using DataAccessComponent.DataBridge;

#endregion


namespace DataAccessComponent.DataOperations
{

    #region class ReferencesSetMethods
    /// <summary>
    /// This class contains methods for modifying a 'ReferencesSet' object.
    /// </summary>
    public static class ReferencesSetMethods
    {

        #region Methods

            #region DeleteReferencesSet(ReferencesSet)
            /// <summary>
            /// This method deletes a 'ReferencesSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ReferencesSet' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteReferencesSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                        result.Success = ReferencesSetManager.DeleteReferencesSet(deleteReferencesSetProc, dataConnector);

                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return result;
            }
            #endregion

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'ReferencesSet' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ReferencesSet' to delete.
            /// <returns>A PolymorphicObject object with all  'ReferencesSets' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                    referencesSetListCollection = ReferencesSetManager.FetchAllReferencesSets(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(referencesSetListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = referencesSetListCollection;
                    }
                }
                else
                {
                    // Raise Error Data Connection Not Available
                    throw new Exception("The database connection is not available.");
                }

                // return value
                return result;
            }
            #endregion

            #region FindReferencesSet(ReferencesSet)
            /// <summary>
            /// This method finds a 'ReferencesSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ReferencesSet' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindReferencesSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                            referencesSet = ReferencesSetManager.FindReferencesSet(findReferencesSetProc, dataConnector);

                            // if dataObject exists
                            if(referencesSet != null)
                            {
                                // set result.ObjectValue
                                result.ObjectValue = referencesSet;
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
                return result;
            }
            #endregion

            #region InsertReferencesSet (ReferencesSet)
            /// <summary>
            /// This method inserts a 'ReferencesSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ReferencesSet' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertReferencesSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                            result.IntegerValue = ReferencesSetManager.InsertReferencesSet(insertReferencesSetProc, dataConnector);

                            // Set the value for Sucess based on if the Insert was Successful
                            result.Success = result.HasIntegerValue;
                        }

                    }
                    else
                    {
                        // Raise Error Data Connection Not Available
                        throw new Exception("The database connection is not available.");
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region UpdateReferencesSet (ReferencesSet)
            /// <summary>
            /// This method updates a 'ReferencesSet' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ReferencesSet' to update.
            /// <returns>A PolymorphicObject object.
            internal static PolymorphicObject UpdateReferencesSet(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                            result.Success = ReferencesSetManager.UpdateReferencesSet(updateReferencesSetProc, dataConnector);
                        }
                        else
                        {
                            // Raise Error Data Connection Not Available
                            throw new Exception("The database connection is not available.");
                        }
                    }
                }

                // return value
                return result;
            }
            #endregion

        #endregion

    }
    #endregion

}
