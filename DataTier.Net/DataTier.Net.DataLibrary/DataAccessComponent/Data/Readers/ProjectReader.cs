

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
                int addIGridValueInterfacefield = 0;
                int autoFillPathsfield = 1;
                int controllerFolderfield = 2;
                int controllerNamespacefield = 3;
                int controllerReferencesSetIdfield = 4;
                int dataManagerFolderfield = 5;
                int dataManagerNamespacefield = 6;
                int dataManagerReferencesSetIdfield = 7;
                int dataOperationsFolderfield = 8;
                int dataOperationsNamespacefield = 9;
                int dataOperationsReferencesSetIdfield = 10;
                int dataWriterFolderfield = 11;
                int dataWriterNamespacefield = 12;
                int dataWriterReferencesSetIdfield = 13;
                int dateModifiedfield = 14;
                int gatewayNamespacefield = 15;
                int gatewayPathfield = 16;
                int objectFolderfield = 17;
                int objectNamespacefield = 18;
                int objectReferencesSetIdfield = 19;
                int projectFolderfield = 20;
                int projectIdfield = 21;
                int projectNamefield = 22;
                int readerFolderfield = 23;
                int readerNamespacefield = 24;
                int readerReferencesSetIdfield = 25;
                int storedProcedureObjectFolderfield = 26;
                int storedProcedureObjectNamespacefield = 27;
                int storedProcedureReferencesSetIdfield = 28;
                int storedProcsFolderfield = 29;
                int targetFrameworkfield = 30;
                int templateVersionfield = 31;

                try
                {
                    // Load Each field
                    project.AddIGridValueInterface = DataHelper.ParseBoolean(dataRow.ItemArray[addIGridValueInterfacefield], false);
                    project.AutoFillPaths = DataHelper.ParseBoolean(dataRow.ItemArray[autoFillPathsfield], false);
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
                    project.GatewayNamespace = DataHelper.ParseString(dataRow.ItemArray[gatewayNamespacefield]);
                    project.GatewayPath = DataHelper.ParseString(dataRow.ItemArray[gatewayPathfield]);
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
