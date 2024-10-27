

#region using statements

using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class ProjectReferencesViewController
    /// <summary>
    /// This class controls a(n) 'ProjectReferencesView' object.
    /// </summary>
    public class ProjectReferencesViewController
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new 'ProjectReferencesViewController' object.
        /// </summary>
        public ProjectReferencesViewController(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;
        }
        #endregion

        #region Methods

            #region CreateProjectReferencesViewParameter
            /// <summary>
            /// This method creates the parameter for a 'ProjectReferencesView' data operation.
            /// </summary>
            /// <param name='projectreferencesview'>The 'ProjectReferencesView' to use as the first
            /// parameter (parameters[0]).</param>
            /// <returns>A List<PolymorphicObject> collection.</returns>
            private static List<PolymorphicObject> CreateProjectReferencesViewParameter(ProjectReferencesView projectReferencesView)
            {
                // Initial Value
                List<PolymorphicObject> parameters = new List<PolymorphicObject>();

                // Create PolymorphicObject to hold the parameter
                PolymorphicObject parameter = new PolymorphicObject();

                // Set parameter.ObjectValue
                parameter.ObjectValue = projectReferencesView;

                // Add userParameter to parameters
                parameters.Add(parameter);

                // return value
                return parameters;
            }
            #endregion

            #region FetchAll(ProjectReferencesView tempProjectReferencesView)
            /// <summary>
            /// This method fetches a collection of 'ProjectReferencesView' objects.
            /// This method used the DataBridgeManager to execute the fetch all using the
            /// procedure 'ProjectReferencesView_FetchAll'.</summary>
            /// <param name='tempProjectReferencesView'>A temporary ProjectReferencesView for passing values.</param>
            /// <returns>A collection of 'ProjectReferencesView' objects.</returns>
            public List<ProjectReferencesView> FetchAll(ProjectReferencesView tempProjectReferencesView)
            {
                // Initial value
                List<ProjectReferencesView> projectReferencesViewList = null;

                // Get information for calling 'DataBridgeManager.PerformDataOperation' method.
                string methodName = "FetchAll";
                string objectName = "ApplicationLogicComponent.Controllers";

                try
                {
                    // Create DataOperation Method
                    ApplicationController.DataOperationMethod fetchAllMethod = this.AppController.DataBridge.DataOperations.ProjectReferencesViewMethods.FetchAll;

                    // Create parameters for this method
                    List<PolymorphicObject> parameters = CreateProjectReferencesViewParameter(tempProjectReferencesView);

                    // Perform DataOperation
                    PolymorphicObject returnObject = this.AppController.DataBridge.PerformDataOperation(methodName, objectName, fetchAllMethod , parameters);

                    // If return object exists
                    if ((returnObject != null) && (returnObject.ObjectValue as List<ProjectReferencesView> != null))
                    {
                        // Create Collection From ReturnObject.ObjectValue
                        projectReferencesViewList = (List<ProjectReferencesView>) returnObject.ObjectValue;
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
                return projectReferencesViewList;
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
