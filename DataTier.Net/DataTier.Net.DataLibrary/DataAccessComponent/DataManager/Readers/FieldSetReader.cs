

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

    #region class FieldSetReader
    /// <summary>
    /// This class loads a single 'FieldSet' object or a list of type <FieldSet>.
    /// </summary>
    public class FieldSetReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'FieldSet' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'FieldSet' DataObject.</returns>
            public static FieldSet Load(DataRow dataRow)
            {
                // Initial Value
                FieldSet fieldSet = new FieldSet();

                // Create field Integers
                int databaseIdfield = 0;
                int fieldSetIdfield = 1;
                int namefield = 2;
                int orderByModefield = 3;
                int parameterModefield = 4;
                int projectIdfield = 5;
                int readerModefield = 6;
                int tableIdfield = 7;

                try
                {
                    // Load Each field
                    fieldSet.DatabaseId = DataHelper.ParseInteger(dataRow.ItemArray[databaseIdfield], 0);
                    fieldSet.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[fieldSetIdfield], 0));
                    fieldSet.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    fieldSet.OrderByMode = DataHelper.ParseBoolean(dataRow.ItemArray[orderByModefield], false);
                    fieldSet.ParameterMode = DataHelper.ParseBoolean(dataRow.ItemArray[parameterModefield], false);
                    fieldSet.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    fieldSet.ReaderMode = DataHelper.ParseBoolean(dataRow.ItemArray[readerModefield], false);
                    fieldSet.TableId = DataHelper.ParseInteger(dataRow.ItemArray[tableIdfield], 0);
                }
                catch
                {
                }

                // return value
                return fieldSet;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'FieldSet' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A FieldSet Collection.</returns>
            public static List<FieldSet> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<FieldSet> fieldSets = new List<FieldSet>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'FieldSet' from rows
                        FieldSet fieldSet = Load(row);

                        // Add this object to collection
                        fieldSets.Add(fieldSet);
                    }
                }
                catch
                {
                }

                // return value
                return fieldSets;
            }
            #endregion

        #endregion

    }
    #endregion

}
