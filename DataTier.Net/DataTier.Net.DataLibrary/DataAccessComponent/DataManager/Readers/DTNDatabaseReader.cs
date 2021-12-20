

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

    #region class DTNDatabaseReader
    /// <summary>
    /// This class loads a single 'DTNDatabase' object or a list of type <DTNDatabase>.
    /// </summary>
    public class DTNDatabaseReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'DTNDatabase' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'DTNDatabase' DataObject.</returns>
            public static DTNDatabase Load(DataRow dataRow)
            {
                // Initial Value
                DTNDatabase dTNDatabase = new DTNDatabase();

                // Create field Integers
                int authenticationTypefield = 0;
                int connectionStringfield = 1;
                int databaseIdfield = 2;
                int databaseNamefield = 3;
                int databaseTypefield = 4;
                int dBPasswordfield = 5;
                int excludefield = 6;
                int pathfield = 7;
                int projectIdfield = 8;
                int serializablefield = 9;
                int serverNamefield = 10;
                int userIdfield = 11;

                try
                {
                    // Load Each field
                    dTNDatabase.AuthenticationType = DataHelper.ParseInteger(dataRow.ItemArray[authenticationTypefield], 0);
                    dTNDatabase.ConnectionString = DataHelper.ParseString(dataRow.ItemArray[connectionStringfield]);
                    dTNDatabase.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[databaseIdfield], 0));
                    dTNDatabase.DatabaseName = DataHelper.ParseString(dataRow.ItemArray[databaseNamefield]);
                    dTNDatabase.DatabaseType = DataHelper.ParseInteger(dataRow.ItemArray[databaseTypefield], 0);
                    dTNDatabase.DBPassword = DataHelper.ParseString(dataRow.ItemArray[dBPasswordfield]);
                    dTNDatabase.Exclude = DataHelper.ParseInteger(dataRow.ItemArray[excludefield], 0);
                    dTNDatabase.Path = DataHelper.ParseString(dataRow.ItemArray[pathfield]);
                    dTNDatabase.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    dTNDatabase.Serializable = DataHelper.ParseBoolean(dataRow.ItemArray[serializablefield], false);
                    dTNDatabase.ServerName = DataHelper.ParseString(dataRow.ItemArray[serverNamefield]);
                    dTNDatabase.UserId = DataHelper.ParseString(dataRow.ItemArray[userIdfield]);
                }
                catch
                {
                }

                // return value
                return dTNDatabase;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'DTNDatabase' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A DTNDatabase Collection.</returns>
            public static List<DTNDatabase> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<DTNDatabase> dTNDatabases = new List<DTNDatabase>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'DTNDatabase' from rows
                        DTNDatabase dTNDatabase = Load(row);

                        // Add this object to collection
                        dTNDatabases.Add(dTNDatabase);
                    }
                }
                catch
                {
                }

                // return value
                return dTNDatabases;
            }
            #endregion

        #endregion

    }
    #endregion

}
