

#region using statements

using System;
using System.Collections.Generic;
using System.Data;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using DataJuggler.Net.Enumerations;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class ProjectReferencesViewReader
    /// <summary>
    /// This class loads a single 'ProjectReferencesView' object or a list of type <ProjectReferencesView>.
    /// </summary>
    public class ProjectReferencesViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ProjectReferencesView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ProjectReferencesView' DataObject.</returns>
            public static ProjectReferencesView Load(DataRow dataRow)
            {
                // Initial Value
                ProjectReferencesView projectReferencesView = new ProjectReferencesView();

                // Create field Integers
                int controllerReferencesSetIdfield = 0;
                int dataManagerReferencesSetIdfield = 1;
                int dataWriterReferencesSetIdfield = 2;
                int objectReferencesSetIdfield = 3;
                int projectIdfield = 4;
                int projectNamefield = 5;
                int readerReferencesSetIdfield = 6;
                int referenceNamefield = 7;
                int referencesIdfield = 8;
                int referencesSetIdfield = 9;
                int referencesSetNamefield = 10;
                int storedProcedureReferencesSetIdfield = 11;

                try
                {
                    // Load Each field
                    projectReferencesView.ControllerReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[controllerReferencesSetIdfield], 0);
                    projectReferencesView.DataManagerReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[dataManagerReferencesSetIdfield], 0);
                    projectReferencesView.DataWriterReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[dataWriterReferencesSetIdfield], 0);
                    projectReferencesView.ObjectReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[objectReferencesSetIdfield], 0);
                    projectReferencesView.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    projectReferencesView.ProjectName = DataHelper.ParseString(dataRow.ItemArray[projectNamefield]);
                    projectReferencesView.ReaderReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[readerReferencesSetIdfield], 0);
                    projectReferencesView.ReferenceName = DataHelper.ParseString(dataRow.ItemArray[referenceNamefield]);
                    projectReferencesView.ReferencesId = DataHelper.ParseInteger(dataRow.ItemArray[referencesIdfield], 0);
                    projectReferencesView.ReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[referencesSetIdfield], 0);
                    projectReferencesView.ReferencesSetName = DataHelper.ParseString(dataRow.ItemArray[referencesSetNamefield]);
                    projectReferencesView.StoredProcedureReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[storedProcedureReferencesSetIdfield], 0);
                }
                catch
                {
                }

                // return value
                return projectReferencesView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ProjectReferencesView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ProjectReferencesView Collection.</returns>
            public static List<ProjectReferencesView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ProjectReferencesView> projectReferencesViews = new List<ProjectReferencesView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ProjectReferencesView' from rows
                        ProjectReferencesView projectReferencesView = Load(row);

                        // Add this object to collection
                        projectReferencesViews.Add(projectReferencesView);
                    }
                }
                catch
                {
                }

                // return value
                return projectReferencesViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
