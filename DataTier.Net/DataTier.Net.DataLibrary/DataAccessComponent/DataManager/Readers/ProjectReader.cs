

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

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
                int controllerFolderfield = 0;
                int controllerNamespacefield = 1;
                int controllerReferencesSetIdfield = 2;
                int dataManagerFolderfield = 3;
                int dataManagerNamespacefield = 4;
                int dataManagerReferencesSetIdfield = 5;
                int dataOperationsFolderfield = 6;
                int dataOperationsNamespacefield = 7;
                int dataOperationsReferencesSetIdfield = 8;
                int dataWriterFolderfield = 9;
                int dataWriterNamespacefield = 10;
                int dataWriterReferencesSetIdfield = 11;
                int dateModifiedfield = 12;
                int objectFolderfield = 13;
                int objectNamespacefield = 14;
                int objectReferencesSetIdfield = 15;
                int projectFolderfield = 16;
                int projectIdfield = 17;
                int projectNamefield = 18;
                int readerFolderfield = 19;
                int readerNamespacefield = 20;
                int readerReferencesSetIdfield = 21;
                int storedProcedureObjectFolderfield = 22;
                int storedProcedureObjectNamespacefield = 23;
                int storedProcedureReferencesSetIdfield = 24;
                int storedProcsFolderfield = 25;
                int targetFrameworkfield = 26;
                int templateVersionfield = 27;

                try
                {
                    // Load Each field
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
                    project.ObjectFolder = DataHelper.ParseString(dataRow.ItemArray[objectFolderfield]);
                    project.ObjectNamespace = DataHelper.ParseString(dataRow.ItemArray[objectNamespacefield]);
                    project.ObjectReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[objectReferencesSetIdfield], 0);
                    project.ProjectFolder = DataHelper.ParseString(dataRow.ItemArray[projectFolderfield]);
                    project.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0));
                    project.ProjectName = DataHelper.ParseString(dataRow.ItemArray[projectNamefield]);
                    project.ReaderFolder = DataHelper.ParseString(dataRow.ItemArray[readerFolderfield]);
                    project.ReaderNamespace = DataHelper.ParseString(dataRow.ItemArray[readerNamespacefield]);
                    project.ReaderReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[readerReferencesSetIdfield], 0);
                    project.StoredProcedureObjectFolder = DataHelper.ParseString(dataRow.ItemArray[storedProcedureObjectFolderfield]);
                    project.StoredProcedureObjectNamespace = DataHelper.ParseString(dataRow.ItemArray[storedProcedureObjectNamespacefield]);
                    project.StoredProcedureReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[storedProcedureReferencesSetIdfield], 0);
                    project.StoredProcsFolder = DataHelper.ParseString(dataRow.ItemArray[storedProcsFolderfield]);
                    project.TargetFramework = (TargetFrameworkEnum) DataHelper.ParseInteger(dataRow.ItemArray[targetFrameworkfield], 0);
                    project.TemplateVersion = DataHelper.ParseInteger(dataRow.ItemArray[templateVersionfield], 0);
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
