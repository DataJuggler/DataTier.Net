

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

    #region class GitHubFollowerMethods
    /// <summary>
    /// This class contains methods for modifying a 'GitHubFollower' object.
    /// </summary>
    public class GitHubFollowerMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'GitHubFollowerMethods' object.
        /// </summary>
        public GitHubFollowerMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region DeleteGitHubFollower(GitHubFollower)
            /// <summary>
            /// This method deletes a 'GitHubFollower' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'GitHubFollower' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject DeleteGitHubFollower(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Delete StoredProcedure
                    DeleteGitHubFollowerStoredProcedure deleteGitHubFollowerProc = null;

                    // verify the first parameters is a(n) 'GitHubFollower'.
                    if (parameters[0].ObjectValue as GitHubFollower != null)
                    {
                        // Create GitHubFollower
                        GitHubFollower gitHubFollower = (GitHubFollower) parameters[0].ObjectValue;

                        // verify gitHubFollower exists
                        if(gitHubFollower != null)
                        {
                            // Now create deleteGitHubFollowerProc from GitHubFollowerWriter
                            // The DataWriter converts the 'GitHubFollower'
                            // to the SqlParameter[] array needed to delete a 'GitHubFollower'.
                            deleteGitHubFollowerProc = GitHubFollowerWriter.CreateDeleteGitHubFollowerStoredProcedure(gitHubFollower);
                        }
                    }

                    // Verify deleteGitHubFollowerProc exists
                    if(deleteGitHubFollowerProc != null)
                    {
                        // Execute Delete Stored Procedure
                        bool deleted = this.DataManager.GitHubFollowerManager.DeleteGitHubFollower(deleteGitHubFollowerProc, dataConnector);

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
            /// This method fetches all 'GitHubFollower' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'GitHubFollower' to delete.
            /// <returns>A PolymorphicObject object with all  'GitHubFollowers' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<GitHubFollower> gitHubFollowerListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllGitHubFollowersStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get GitHubFollowerParameter
                    // Declare Parameter
                    GitHubFollower paramGitHubFollower = null;

                    // verify the first parameters is a(n) 'GitHubFollower'.
                    if (parameters[0].ObjectValue as GitHubFollower != null)
                    {
                        // Get GitHubFollowerParameter
                        paramGitHubFollower = (GitHubFollower) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllGitHubFollowersProc from GitHubFollowerWriter
                    fetchAllProc = GitHubFollowerWriter.CreateFetchAllGitHubFollowersStoredProcedure(paramGitHubFollower);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    gitHubFollowerListCollection = this.DataManager.GitHubFollowerManager.FetchAllGitHubFollowers(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(gitHubFollowerListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = gitHubFollowerListCollection;
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

            #region FindGitHubFollower(GitHubFollower)
            /// <summary>
            /// This method finds a 'GitHubFollower' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'GitHubFollower' to delete.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject FindGitHubFollower(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                GitHubFollower gitHubFollower = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Find StoredProcedure
                    FindGitHubFollowerStoredProcedure findGitHubFollowerProc = null;

                    // verify the first parameters is a 'GitHubFollower'.
                    if (parameters[0].ObjectValue as GitHubFollower != null)
                    {
                        // Get GitHubFollowerParameter
                        GitHubFollower paramGitHubFollower = (GitHubFollower) parameters[0].ObjectValue;

                        // verify paramGitHubFollower exists
                        if(paramGitHubFollower != null)
                        {
                            // Now create findGitHubFollowerProc from GitHubFollowerWriter
                            // The DataWriter converts the 'GitHubFollower'
                            // to the SqlParameter[] array needed to find a 'GitHubFollower'.
                            findGitHubFollowerProc = GitHubFollowerWriter.CreateFindGitHubFollowerStoredProcedure(paramGitHubFollower);
                        }

                        // Verify findGitHubFollowerProc exists
                        if(findGitHubFollowerProc != null)
                        {
                            // Execute Find Stored Procedure
                            gitHubFollower = this.DataManager.GitHubFollowerManager.FindGitHubFollower(findGitHubFollowerProc, dataConnector);

                            // if dataObject exists
                            if(gitHubFollower != null)
                            {
                                // set returnObject.ObjectValue
                                returnObject.ObjectValue = gitHubFollower;
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

            #region InsertGitHubFollower (GitHubFollower)
            /// <summary>
            /// This method inserts a 'GitHubFollower' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'GitHubFollower' to insert.
            /// <returns>A PolymorphicObject object with a Boolean value.
            internal PolymorphicObject InsertGitHubFollower(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                GitHubFollower gitHubFollower = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Insert StoredProcedure
                    InsertGitHubFollowerStoredProcedure insertGitHubFollowerProc = null;

                    // verify the first parameters is a(n) 'GitHubFollower'.
                    if (parameters[0].ObjectValue as GitHubFollower != null)
                    {
                        // Create GitHubFollower Parameter
                        gitHubFollower = (GitHubFollower) parameters[0].ObjectValue;

                        // verify gitHubFollower exists
                        if(gitHubFollower != null)
                        {
                            // Now create insertGitHubFollowerProc from GitHubFollowerWriter
                            // The DataWriter converts the 'GitHubFollower'
                            // to the SqlParameter[] array needed to insert a 'GitHubFollower'.
                            insertGitHubFollowerProc = GitHubFollowerWriter.CreateInsertGitHubFollowerStoredProcedure(gitHubFollower);
                        }

                        // Verify insertGitHubFollowerProc exists
                        if(insertGitHubFollowerProc != null)
                        {
                            // Execute Insert Stored Procedure
                            returnObject.IntegerValue = this.DataManager.GitHubFollowerManager.InsertGitHubFollower(insertGitHubFollowerProc, dataConnector);
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

            #region UpdateGitHubFollower (GitHubFollower)
            /// <summary>
            /// This method updates a 'GitHubFollower' object.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'GitHubFollower' to update.
            /// <returns>A PolymorphicObject object with a value.
            internal PolymorphicObject UpdateGitHubFollower(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                GitHubFollower gitHubFollower = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Create Update StoredProcedure
                    UpdateGitHubFollowerStoredProcedure updateGitHubFollowerProc = null;

                    // verify the first parameters is a(n) 'GitHubFollower'.
                    if (parameters[0].ObjectValue as GitHubFollower != null)
                    {
                        // Create GitHubFollower Parameter
                        gitHubFollower = (GitHubFollower) parameters[0].ObjectValue;

                        // verify gitHubFollower exists
                        if(gitHubFollower != null)
                        {
                            // Now create updateGitHubFollowerProc from GitHubFollowerWriter
                            // The DataWriter converts the 'GitHubFollower'
                            // to the SqlParameter[] array needed to update a 'GitHubFollower'.
                            updateGitHubFollowerProc = GitHubFollowerWriter.CreateUpdateGitHubFollowerStoredProcedure(gitHubFollower);
                        }

                        // Verify updateGitHubFollowerProc exists
                        if(updateGitHubFollowerProc != null)
                        {
                            // Execute Update Stored Procedure
                            bool saved = this.DataManager.GitHubFollowerManager.UpdateGitHubFollower(updateGitHubFollowerProc, dataConnector);

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
