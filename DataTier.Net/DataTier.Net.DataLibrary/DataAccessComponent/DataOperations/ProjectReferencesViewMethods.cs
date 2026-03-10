

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

    #region class ProjectReferencesViewMethods
    /// <summary>
    /// This class contains methods for modifying a 'ProjectReferencesView' object.
    /// </summary>
    public static class ProjectReferencesViewMethods
    {

        #region Methods

            #region FetchAll()
            /// <summary>
            /// This method fetches all 'ProjectReferencesView' objects.
            /// </summary>
            /// <param name='List<PolymorphicObject>'>The 'ProjectReferencesView' to delete.
            /// <returns>A PolymorphicObject object with all  'ProjectReferencesViews' objects.
            internal static PolymorphicObject FetchAll(List<PolymorphicObject> parameters, DataConnector dataConnector)
            {
                // Initial Value
                PolymorphicObject result = new PolymorphicObject();

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
                    projectReferencesViewListCollection = ProjectReferencesViewManager.FetchAllProjectReferencesViews(fetchAllProc, dataConnector);

                    // if dataObjectCollection exists
                    if(projectReferencesViewListCollection != null)
                    {
                        // set result.ObjectValue
                        result.ObjectValue = projectReferencesViewListCollection;
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

        #endregion

    }
    #endregion

}
