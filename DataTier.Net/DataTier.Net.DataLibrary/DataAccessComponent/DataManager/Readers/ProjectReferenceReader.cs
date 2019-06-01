

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class ProjectReferenceReader
    /// <summary>
    /// This class loads a single 'ProjectReference' object or a list of type <ProjectReference>.
    /// </summary>
    public class ProjectReferenceReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ProjectReference' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ProjectReference' DataObject.</returns>
            public static ProjectReference Load(DataRow dataRow)
            {
                // Initial Value
                ProjectReference projectReference = new ProjectReference();

                // Create field Integers
                int referenceNamefield = 0;
                int referencesIdfield = 1;
                int referencesSetIdfield = 2;

                try
                {
                    // Load Each field
                    projectReference.ReferenceName = DataHelper.ParseString(dataRow.ItemArray[referenceNamefield]);
                    projectReference.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[referencesIdfield], 0));
                    projectReference.ReferencesSetId = DataHelper.ParseInteger(dataRow.ItemArray[referencesSetIdfield], 0);
                }
                catch
                {
                }

                // return value
                return projectReference;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ProjectReference' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ProjectReference Collection.</returns>
            public static List<ProjectReference> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ProjectReference> projectReferences = new List<ProjectReference>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ProjectReference' from rows
                        ProjectReference projectReference = Load(row);

                        // Add this object to collection
                        projectReferences.Add(projectReference);
                    }
                }
                catch
                {
                }

                // return value
                return projectReferences;
            }
            #endregion

        #endregion

    }
    #endregion

}
