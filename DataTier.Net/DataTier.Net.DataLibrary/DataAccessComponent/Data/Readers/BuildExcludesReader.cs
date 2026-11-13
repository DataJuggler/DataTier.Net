

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

    #region class BuildExcludesReader
    /// <summary>
    /// This class loads a single 'BuildExcludes' object or a list of type <BuildExcludes>.
    /// </summary>
    public class BuildExcludesReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'BuildExcludes' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'BuildExcludes' DataObject.</returns>
            public static BuildExcludes Load(DataRow dataRow)
            {
                // Initial Value
                BuildExcludes buildExcludes = new BuildExcludes();

                // Create field Integers
                int databaseIdfield = 0;
                int excludeDeletefield = 1;
                int excludeFetchAllfield = 2;
                int excludeFindfield = 3;
                int excludeInsertfield = 4;
                int excludeUpdatefield = 5;
                int idfield = 6;
                int projectIdfield = 7;
                int tableIdfield = 8;

                try
                {
                    // Load Each field
                    buildExcludes.DatabaseId = DataHelper.ParseInteger(dataRow.ItemArray[databaseIdfield], 0);
                    buildExcludes.ExcludeDelete = DataHelper.ParseBoolean(dataRow.ItemArray[excludeDeletefield], false);
                    buildExcludes.ExcludeFetchAll = DataHelper.ParseBoolean(dataRow.ItemArray[excludeFetchAllfield], false);
                    buildExcludes.ExcludeFind = DataHelper.ParseBoolean(dataRow.ItemArray[excludeFindfield], false);
                    buildExcludes.ExcludeInsert = DataHelper.ParseBoolean(dataRow.ItemArray[excludeInsertfield], false);
                    buildExcludes.ExcludeUpdate = DataHelper.ParseBoolean(dataRow.ItemArray[excludeUpdatefield], false);
                    buildExcludes.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    buildExcludes.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    buildExcludes.TableId = DataHelper.ParseInteger(dataRow.ItemArray[tableIdfield], 0);
                }
                catch
                {
                }

                // return value
                return buildExcludes;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'BuildExcludes' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A BuildExcludes Collection.</returns>
            public static List<BuildExcludes> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<BuildExcludes> buildExcludes = new List<BuildExcludes>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'BuildExcludes' from rows
                        BuildExcludes buildExclude = Load(row);

                        // Add this object to collection
                        buildExcludes.Add(buildExclude);
                    }
                }
                catch
                {
                }

                // return value
                return buildExcludes;
            }
            #endregion

        #endregion

    }
    #endregion

}
