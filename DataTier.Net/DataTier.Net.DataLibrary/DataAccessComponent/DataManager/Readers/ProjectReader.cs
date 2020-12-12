

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;
using DataJuggler.Net.Enumerations;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class ProjectReader
    /// <summary>
    /// This class loads a single 'Project' object or a list of type <Project>.
    /// </summary>
    public class ProjectReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'Project' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'Project' DataObject.</returns>
            public static Project Load(DataRow dataRow)
            {
                // Initial Value
                Project project = new Project();

                // Create field Integers
                int bindingCallbackOptionfield = 0;
                int controllerFolderfield = 1;
                int controllerNamespacefield = 2;
                int controllerReferencesSetIdfield = 3;
                int dataManagerFolderfield = 4;
                int dataManagerNamespacefield = 5;
                int dataManagerReferencesSetIdfield = 6;
                int dataOperationsFolderfield = 7;
                int dataOperationsNamespacefield = 8;
                int dataOperationsReferencesSetIdfield = 9;
                int dataWriterFolderfield = 10;
                int dataWriterNamespacefield = 11;
                int dataWriterReferencesSetIdfield = 12;
                int dateModifiedfield = 13;
                int dotNet5field = 14;
                int enableBlazorFeaturesfield = 15;
                int objectFolderfield = 16;
                int objectNamespacefield = 17;
                int objectReferencesSetIdfield = 18;
                int projectFolderfield = 19;
                int projectIdfield = 20;
                int projectNamefield = 21;
                int readerFolderfield = 22;
                int readerNamespacefield = 23;
                int readerReferencesSetIdfield = 24;
                int servicesFolderfield = 25;
                int storedProcedureObjectFolderfield = 26;
                int storedProcedureObjectNamespacefield = 27;
                int storedProcedureReferencesSetIdfield = 28;
                int storedProcsFolderfield = 29;

                try
                {
                    // Load Each field
                    project.BindingCallbackOption = (BindingCallbackOptionEnum) DataHelper.ParseInteger(dataRow.ItemArray[bindingCallbackOptionfield], 0);
                    project.ControllerFolder = DataHelper.ParseString(dataRow.ItemArray[controllerFolderfield]);
                    project.ControllerNamespace = DataHelper.ParseString(dataRow.ItemArray[controllerNamespacefield]);
                    project.ControllerReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[controllerReferencesSetIdfield], 0);
                    project.DataManagerFolder = DataHelper.ParseString(dataRow.ItemArray[dataManagerFolderfield]);
                    project.DataManagerNamespace = DataHelper.ParseString(dataRow.ItemArray[dataManagerNamespacefield]);
                    project.DataManagerReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[dataManagerReferencesSetIdfield], 0);
                    project.DataOperationsFolder = DataHelper.ParseString(dataRow.ItemArray[dataOperationsFolderfield]);
                    project.DataOperationsNamespace = DataHelper.ParseString(dataRow.ItemArray[dataOperationsNamespacefield]);
                    project.DataOperationsReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[dataOperationsReferencesSetIdfield], 0);
                    project.DataWriterFolder = DataHelper.ParseString(dataRow.ItemArray[dataWriterFolderfield]);
                    project.DataWriterNamespace = DataHelper.ParseString(dataRow.ItemArray[dataWriterNamespacefield]);
                    project.DataWriterReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[dataWriterReferencesSetIdfield], 0);
                    project.DateModified = DataHelper.ParseDate(dataRow.ItemArray[dateModifiedfield]);
                    project.DotNet5 = DataHelper.ParseBoolean(dataRow.ItemArray[dotNet5field], false);
                    project.EnableBlazorFeatures = DataHelper.ParseBoolean(dataRow.ItemArray[enableBlazorFeaturesfield], false);
                    project.ObjectFolder = DataHelper.ParseString(dataRow.ItemArray[objectFolderfield]);
                    project.ObjectNamespace = DataHelper.ParseString(dataRow.ItemArray[objectNamespacefield]);
                    project.ObjectReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[objectReferencesSetIdfield], 0);
                    project.ProjectFolder = DataHelper.ParseString(dataRow.ItemArray[projectFolderfield]);
                    project.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0));
                    project.ProjectName = DataHelper.ParseString(dataRow.ItemArray[projectNamefield]);
                    project.ReaderFolder = DataHelper.ParseString(dataRow.ItemArray[readerFolderfield]);
                    project.ReaderNamespace = DataHelper.ParseString(dataRow.ItemArray[readerNamespacefield]);
                    project.ReaderReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[readerReferencesSetIdfield], 0);
                    project.ServicesFolder = DataHelper.ParseString(dataRow.ItemArray[servicesFolderfield]);
                    project.StoredProcedureObjectFolder = DataHelper.ParseString(dataRow.ItemArray[storedProcedureObjectFolderfield]);
                    project.StoredProcedureObjectNamespace = DataHelper.ParseString(dataRow.ItemArray[storedProcedureObjectNamespacefield]);
                    project.StoredProcedureReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[storedProcedureReferencesSetIdfield], 0);
                    project.StoredProcsFolder = DataHelper.ParseString(dataRow.ItemArray[storedProcsFolderfield]);
                }
                catch
                {
                }

                // return value
                return project;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'Project' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A Project Collection.</returns>
            public static List<Project> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<Project> projects = new List<Project>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'Project' from rows
                        Project project = Load(row);

                        // Add this object to collection
                        projects.Add(project);
                    }
                }
                catch
                {
                }

                // return value
                return projects;
            }
            #endregion

        #endregion

    }
    #endregion

}
