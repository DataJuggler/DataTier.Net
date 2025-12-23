

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class ReferencesSetReader
    /// <summary>
    /// This class loads a single 'ReferencesSet' object or a list of type <ReferencesSet>.
    /// </summary>
    public class ReferencesSetReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ReferencesSet' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ReferencesSet' DataObject.</returns>
            public static ReferencesSet Load(DataRow dataRow)
            {
                // Initial Value
                ReferencesSet referencesSet = new ReferencesSet();

                // Create field Integers
                int projectIdfield = 0;
                int referencesSetIdfield = 1;
                int referencesSetNamefield = 2;

                try
                {
                    // Load Each field
                    referencesSet.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    referencesSet.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[referencesSetIdfield], 0));
                    referencesSet.ReferencesSetName = DataHelper.ParseString(dataRow.ItemArray[referencesSetNamefield]);
                }
                catch
                {
                }

                // return value
                return referencesSet;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ReferencesSet' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ReferencesSet Collection.</returns>
            public static List<ReferencesSet> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ReferencesSet> referencesSets = new List<ReferencesSet>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ReferencesSet' from rows
                        ReferencesSet referencesSet = Load(row);

                        // Add this object to collection
                        referencesSets.Add(referencesSet);
                    }
                }
                catch
                {
                }

                // return value
                return referencesSets;
            }
            #endregion

        #endregion

    }
    #endregion

}
