

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

    #region class DTNTableReader
    /// <summary>
    /// This class loads a single 'DTNTable' object or a list of type <DTNTable>.
    /// </summary>
    public class DTNTableReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'DTNTable' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'DTNTable' DataObject.</returns>
            public static DTNTable Load(DataRow dataRow)
            {
                // Initial Value
                DTNTable dTNTable = new DTNTable();

                // Create field Integers
                int classFileNamefield = 0;
                int classNamefield = 1;
                int createBindingCallbackfield = 2;
                int databaseIdfield = 3;
                int excludefield = 4;
                int isViewfield = 5;
                int projectIdfield = 6;
                int scopefield = 7;
                int serializablefield = 8;
                int tableIdfield = 9;
                int tableNamefield = 10;

                try
                {
                    // Load Each field
                    dTNTable.ClassFileName = DataHelper.ParseString(dataRow.ItemArray[classFileNamefield]);
                    dTNTable.ClassName = DataHelper.ParseString(dataRow.ItemArray[classNamefield]);
                    dTNTable.CreateBindingCallback = DataHelper.ParseBoolean(dataRow.ItemArray[createBindingCallbackfield], false);
                    dTNTable.DatabaseId = DataHelper.ParseInteger(dataRow.ItemArray[databaseIdfield], 0);
                    dTNTable.Exclude = DataHelper.ParseBoolean(dataRow.ItemArray[excludefield], false);
                    dTNTable.IsView = DataHelper.ParseBoolean(dataRow.ItemArray[isViewfield], false);
                    dTNTable.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    dTNTable.Scope = (ScopeEnum) DataHelper.ParseInteger(dataRow.ItemArray[scopefield], 0);
                    dTNTable.Serializable = DataHelper.ParseBoolean(dataRow.ItemArray[serializablefield], false);
                    dTNTable.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[tableIdfield], 0));
                    dTNTable.TableName = DataHelper.ParseString(dataRow.ItemArray[tableNamefield]);
                }
                catch
                {
                }

                // return value
                return dTNTable;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'DTNTable' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A DTNTable Collection.</returns>
            public static List<DTNTable> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<DTNTable> dTNTables = new List<DTNTable>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'DTNTable' from rows
                        DTNTable dTNTable = Load(row);

                        // Add this object to collection
                        dTNTables.Add(dTNTable);
                    }
                }
                catch
                {
                }

                // return value
                return dTNTables;
            }
            #endregion

        #endregion

    }
    #endregion

}
