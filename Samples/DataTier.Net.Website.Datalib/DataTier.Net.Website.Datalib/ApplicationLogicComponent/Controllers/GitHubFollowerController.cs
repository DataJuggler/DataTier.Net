

#region using statements

using ApplicationLogicComponent.DataBridge;
using ApplicationLogicComponent.DataOperations;
using ApplicationLogicComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace ApplicationLogicComponent.Controllers
{

    #region class GitHubFollowerController
    /// <summary>
    /// This class controls a(n) 'GitHubFollower' object.
    /// </summary>
    public class GitHubFollowerController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'GitHubFollowerController' object.
        /// </summary>
        public GitHubFollowerController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateGitHubFollowerParameter
            /// <summary>
            /// This method creates the parameter for a 'GitHubFollower' data operation.
            /// </summary>
            /// <param name='githubfollower'>The 'GitHubFollower' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private List<PolymorphicObject> CreateGitHubFollowerParameter(GitHubFollower gitHubFollower)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = gitHubFollower;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region Delete(GitHubFollower tempGitHubFollower)
            /// <summary>
            /// Deletes a 'GitHubFollower' from the database
            /// This method calls the DataBridgeManager to execute the delete using the
            /// procedure 'GitHubFollower_Delete'.
            /// </summary>
            /// <param name='githubfollower'>The 'GitHubFollower' to delete.</param>
            /// <returns>True if the delete is successful or false if not.</returns>
            public bool Delete(GitHubFollower tempGitHubFollower)
            {
                // locals
                bool deleted = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "DeleteGitHubFollower";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // verify tempgitHubFollower exists before attemptintg to delete
                    if(tempGitHubFollower != null)
                    {
                        // Create Delegate For DataOperation
                        ApplicationController.DataOperationMethod deleteGitHubFollowerMethod = this.AppController.DataBridge.DataOperations.GitHubFollowerMethods.DeleteGitHubFollower;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateGitHubFollowerParameter(tempGitHubFollower);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, deleteGitHubFollowerMethod, parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Test For True
                            if (returnObject.Boolean.Value == NullableBooleanEnum.True)
                            {
                                // Set Deleted To True
                                deleted = true;
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return deleted;
            }
            #endregion

            #region FetchAll(GitHubFollower tempGitHubFollower)
            /// <summary>
            /// This method fetches a collection of 'GitHubFollower' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'GitHubFollower_FetchAll'.</summary>
            /// <param name='tempGitHubFollower'>A temporary GitHubFollower for passing values.</param>
            /// <returns>A collection of 'GitHubFollower' objects.</returns>
            public List<GitHubFollower> FetchAll(GitHubFollower tempGitHubFollower)
            {
                // Initial value
                List<GitHubFollower> gitHubFollowerList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.GitHubFollowerMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateGitHubFollowerParameter(tempGitHubFollower);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<GitHubFollower> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        gitHubFollowerList = (List<GitHubFollower>) returnObject.ObjectValue;
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return gitHubFollowerList;
            }
            #endregion

            #region Find(GitHubFollower tempGitHubFollower)
            /// <summary>
            /// Finds a 'GitHubFollower' object by the primary key.
            /// This method used the DataBridgeManager to execute the 'Find' using the
            /// procedure 'GitHubFollower_Find'</param>
            /// </summary>
            /// <param name='tempGitHubFollower'>A temporary GitHubFollower for passing values.</param>
            /// <returns>A 'GitHubFollower' object if found else a null 'GitHubFollower'.</returns>
            public GitHubFollower Find(GitHubFollower tempGitHubFollower)
            {
                // Initial values
                GitHubFollower gitHubFollower = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Find";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If object exists
                    if(tempGitHubFollower != null)
                    {
                        // Create DataOperation
                        ApplicationController.DataOperationMethod findMethod = this.AppController.DataBridge.DataOperations.GitHubFollowerMethods.FindGitHubFollower;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateGitHubFollowerParameter(tempGitHubFollower);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, findMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.ObjectValue as GitHubFollower != null))
                        {
                            // Get ReturnObject
                            gitHubFollower = (GitHubFollower) returnObject.ObjectValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return gitHubFollower;
            }
            #endregion

            #region Insert(GitHubFollower gitHubFollower)
            /// <summary>
            /// Insert a 'GitHubFollower' object into the database.
            /// This method uses the DataBridgeManager to execute the 'Insert' using the
            /// procedure 'GitHubFollower_Insert'.</param>
            /// </summary>
            /// <param name='gitHubFollower'>The 'GitHubFollower' object to insert.</param>
            /// <returns>The id (int) of the new  'GitHubFollower' object that was inserted.</returns>
            public int Insert(GitHubFollower gitHubFollower)
            {
                // Initial values
                int newIdentity = -1;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Insert";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // If GitHubFollowerexists
                    if(gitHubFollower != null)
                    {
                        ApplicationController.DataOperationMethod insertMethod = this.AppController.DataBridge.DataOperations.GitHubFollowerMethods.InsertGitHubFollower;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateGitHubFollowerParameter(gitHubFollower);

                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, insertMethod , parameters);

                        // If return object exists
                        if (returnObject != null)
                        {
                            // Set return value
                            newIdentity = returnObject.IntegerValue;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return newIdentity;
            }
            #endregion

            #region Save(ref GitHubFollower gitHubFollower)
            /// <summary>
            /// Saves a 'GitHubFollower' object into the database.
            /// This method calls the 'Insert' or 'Update' method.
            /// </summary>
            /// <param name='gitHubFollower'>The 'GitHubFollower' object to save.</param>
            /// <returns>True if successful or false if not.</returns>
            public bool Save(ref GitHubFollower gitHubFollower)
            {
                // Initial value
                bool saved = false;

                // If the gitHubFollower exists.
                if(gitHubFollower != null)
                {
                    // Is this a new GitHubFollower
                    if(gitHubFollower.IsNew)
                    {
                        // Insert new GitHubFollower
                        int newIdentity = this.Insert(gitHubFollower);

                        // if insert was successful
                        if(newIdentity > 0)
                        {
                            // Update Identity
                            gitHubFollower.UpdateIdentity(newIdentity);

                            // Set return value
                            saved = true;
                        }
                    }
                    else
                    {
                        // Update GitHubFollower
                        saved = this.Update(gitHubFollower);
                    }
                }

                // return value
                return saved;
            }
            #endregion

            #region Update(GitHubFollower gitHubFollower)
            /// <summary>
            /// This method Updates a 'GitHubFollower' object in the database.
            /// This method used the DataBridgeManager to execute the 'Update' using the
            /// procedure 'GitHubFollower_Update'.</param>
            /// </summary>
            /// <param name='gitHubFollower'>The 'GitHubFollower' object to update.</param>
            /// <returns>True if successful else false if not.</returns>
            public bool Update(GitHubFollower gitHubFollower)
            {
                // Initial value
                bool saved = false;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "Update";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    if(gitHubFollower != null)
                    {
                        // Create Delegate
                        ApplicationController.DataOperationMethod updateMethod = this.AppController.DataBridge.DataOperations.GitHubFollowerMethods.UpdateGitHubFollower;

                        // Create parameters for this method
                        List<PolymorphicObject> parameters = CreateGitHubFollowerParameter(gitHubFollower);
                        // Perform DataOperation
                        PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, updateMethod , parameters);

                        // If return object exists
                        if ((returnObject != null) && (returnObject.Boolean != null) && (returnObject.Boolean.Value == NullableBooleanEnum.True))
                        {
                            // Set saved to true
                            saved = true;
                        }
                    }
                }
                catch (Exception error)
                {
                    // If ErrorProcessor exists
                    if (this.ErrorProcessor != null)
                    {
                        // Log the current error
                        this.ErrorProcessor.LogError(methodName, objectName, error);
                    }
                }

                // return value
                return saved;
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
