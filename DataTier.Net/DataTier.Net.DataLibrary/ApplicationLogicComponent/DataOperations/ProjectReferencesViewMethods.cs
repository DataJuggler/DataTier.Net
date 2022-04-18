

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

    #region class ProjectReferencesViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'ProjectReferencesView' object.
    /// </summary>
    public class ProjectReferencesViewMethods
    {

        #region Private Variables
        private DataManager dataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ProjectReferencesViewMethods' object.
        /// </summary>
        public ProjectReferencesViewMethods(DataManager dataManagerArg)
        {
            // Save Argument
            this.DataManager = dataManagerArg;
        }
        #endregion

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'ProjectReferencesView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ProjectReferencesView' to delete.
            /// <returns>A PolymorphicObject object with all  'ProjectReferencesViews' objects.
            internal PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject returnObject = new PolymorphicObject();

                // locals
                List<ProjectReferencesView> projectReferencesViewListCollection =  null;

                // Create FetchAll StoredProcedure
                FetchAllProjectReferencesViewsStoredProcedure fetchAllProc = null;

                // If the data connection is connected
                if ((dataConnector != null) && (dataConnector.Connected == true))
                {
                    // Get ProjectReferencesViewParameter
                    // Declare Parameter
                    ProjectReferencesView paramProjectReferencesView = null;

                    // verify the first parameters is a(n) 'ProjectReferencesView'.
                    if (parameters[0].ObjectValue as ProjectReferencesView != null)
                    {
                        // Get ProjectReferencesViewParameter
                        paramProjectReferencesView = (ProjectReferencesView) parameters[0].ObjectValue;
                    }

                    // Now create FetchAllProjectReferencesViewsProc from ProjectReferencesViewWriter
                    fetchAllProc = ProjectReferencesViewWriter.CreateFetchAllProjectReferencesViewsStoredProcedure(paramProjectReferencesView);
                }

                // Verify fetchAllProc exists
                if(fetchAllProc!= null)
                {
                    // Execute FetchAll Stored Procedure
                    projectReferencesViewListCollection = this.DataManager.ProjectReferencesViewManager.FetchAllProjectReferencesViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(projectReferencesViewListCollection != null)
                    {
                        // set returnObject.ObjectValue
                        returnObject.ObjectValue = projectReferencesViewListCollection;
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
