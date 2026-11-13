

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

    #region class BuildExcludesMethods
    /// <summary>
    /// This class contains methods for modifying a 'BuildExcludes' object.
    /// </summary>
    public static class BuildExcludesMethods
    {

        #region Methods

            #region DeleteBuildExcludes(BuildExcludes)
            /// <summary>
            /// This method deletes a 'BuildExcludes' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'BuildExcludes' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject DeleteBuildExcludes(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteBuildExcludesStoredProcedure deleteBuildExcludesProc = null;

                    // verify the first parameters is a(n) 'BuildExcludes'.
                    if (parameters[0].ObjectValue as BuildExcludes != null)
                    {
                        // Create BuildExcludes
                        BuildExcludes buildExcludes = (BuildExcludes) parameters[0].ObjectValue;

                        // verify buildExcludes exists
                        if(buildExcludes != null)
                        {
                            // Now create deleteBuildExcludesProc from BuildExcludesWriter
                            // The DataWriter converts the 'BuildExcludes'
                            // to the SqlParameter[] array needed to delete a 'BuildExcludes'.
                            deleteBuildExcludesProc = BuildExcludesWriter.CreateDeleteBuildExcludesStoredProcedure(buildExcludes);
                        }
                    }

                    // Verify deleteBuildExcludesProc exists
                    if(deleteBuildExcludesProc != null)
                    {
                        // Execute Delete Stored Procedure
                        result.Success = BuildExcludesManager.DeleteBuildExcludes(deleteBuildExcludesProc, dataConnector);
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
            /// This method fetches all 'BuildExcludes' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'BuildExcludes' to delete.
            /// <returns>A PolymorphicObject object with all  'BuildExcludes' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                List<BuildExcludes> buildExcludesListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllBuildExcludesStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get BuildExcludesParameter
                    // Declare Parameter
                    BuildExcludes paramBuildExcludes = null;

                    // verify the first parameters is a(n) 'BuildExcludes'.
                    if (parameters[0].ObjectValue as BuildExcludes != null)
                    {
                        // Get BuildExcludesParameter
                        paramBuildExcludes = (BuildExcludes) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllBuildExcludesProc from BuildExcludesWriter
                    fetchAllProc = BuildExcludesWriter.CreateFetchAllBuildExcludesStoredProcedure(paramBuildExcludes);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    buildExcludesListCollection = BuildExcludesManager.FetchAllBuildExcludes(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(buildExcludesListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = buildExcludesListCollection;
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

            #region FindBuildExcludes(BuildExcludes)
            /// <summary>
            /// This method finds a 'BuildExcludes' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'BuildExcludes' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject FindBuildExcludes(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                BuildExcludes buildExcludes = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindBuildExcludesStoredProcedure findBuildExcludesProc = null;

                    // verify the first parameters is a 'BuildExcludes'.
                    if (parameters[0].ObjectValue as BuildExcludes != null)
                    {
                        // Get BuildExcludesParameter
                        BuildExcludes paramBuildExcludes = (BuildExcludes) parameters[0].ObjectValue;

                        // verify paramBuildExcludes exists
                        if(paramBuildExcludes != null)
                        {
                            // Now create findBuildExcludesProc from BuildExcludesWriter
                            // The DataWriter converts the 'BuildExcludes'
                            // to the SqlParameter[] array needed to find a 'BuildExcludes'.
                            findBuildExcludesProc = BuildExcludesWriter.CreateFindBuildExcludesStoredProcedure(paramBuildExcludes);
                        }

                        // Verify findBuildExcludesProc exists
                        if(findBuildExcludesProc != null)
                        {
                            // Execute Find Stored Procedure
                            buildExcludes = BuildExcludesManager.FindBuildExcludes(findBuildExcludesProc, dataConnector);

                            // if dataObject exists
                            if(buildExcludes != null)
                            {
                                // set result.ObjectValue
                                result.ObjectValue = buildExcludes;
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

            #region InsertBuildExcludes (BuildExcludes)
            /// <summary>
            /// This method inserts a 'BuildExcludes' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'BuildExcludes' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal static PolymorphicObject InsertBuildExcludes(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                BuildExcludes buildExcludes = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertBuildExcludesStoredProcedure insertBuildExcludesProc = null;

                    // verify the first parameters is a(n) 'BuildExcludes'.
                    if (parameters[0].ObjectValue as BuildExcludes != null)
                    {
                        // Create BuildExcludes Parameter
                        buildExcludes = (BuildExcludes) parameters[0].ObjectValue;

                        // verify buildExcludes exists
                        if(buildExcludes != null)
                        {
                            // Now create insertBuildExcludesProc from BuildExcludesWriter
                            // The DataWriter converts the 'BuildExcludes'
                            // to the SqlParameter[] array needed to insert a 'BuildExcludes'.
                            insertBuildExcludesProc = BuildExcludesWriter.CreateInsertBuildExcludesStoredProcedure(buildExcludes);
                        }

                        // Verify insertBuildExcludesProc exists
                        if(insertBuildExcludesProc != null)
                        {
                            // Execute Insert Stored Procedure
                            result.IntegerValue = BuildExcludesManager.InsertBuildExcludes(insertBuildExcludesProc, dataConnector);

                            {
                                // Set Success to true if result.IntegerValue is greater than zero
                                result.Success = result.HasIntegerValue;
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

            #region UpdateBuildExcludes (BuildExcludes)
            /// <summary>
            /// This method updates a 'BuildExcludes' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'BuildExcludes' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal static PolymorphicObject UpdateBuildExcludes(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

                // locals
                BuildExcludes buildExcludes = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateBuildExcludesStoredProcedure updateBuildExcludesProc = null;

                    // verify the first parameters is a(n) 'BuildExcludes'.
                    if (parameters[0].ObjectValue as BuildExcludes != null)
                    {
                        // Create BuildExcludes Parameter
                        buildExcludes = (BuildExcludes) parameters[0].ObjectValue;

                        // verify buildExcludes exists
                        if(buildExcludes != null)
                        {
                            // Now create updateBuildExcludesProc from BuildExcludesWriter
                            // The DataWriter converts the 'BuildExcludes'
                            // to the SqlParameter[] array needed to update a 'BuildExcludes'.
                            updateBuildExcludesProc = BuildExcludesWriter.CreateUpdateBuildExcludesStoredProcedure(buildExcludes);
                        }

                        // Verify updateBuildExcludesProc exists
                        if(updateBuildExcludesProc != null)
                        {
                            // Execute Update Stored Procedure
                            result.Success = BuildExcludesManager.UpdateBuildExcludes(updateBuildExcludesProc, dataConnector);
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
