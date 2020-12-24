

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

    #region class UserInterfaceReader
    /// <summary>
    /// This class loads a single 'UserInterface' object or a list of type <UserInterface>.
    /// </summary>
    public class UserInterfaceReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'UserInterface' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'UserInterface' DataObject.</returns>
            public static UserInterface Load(DataRow dataRow)
            {
                // Initial Value
                UserInterface userInterface = new UserInterface();

                // Create field Integers
                int idfield = 0;
                int namefield = 1;
                int pathfield = 2;
                int projectIdfield = 3;
                int tableNamefield = 4;
                int uITypefield = 5;

                try
                {
                    // Load Each field
                    userInterface.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    userInterface.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    userInterface.Path = DataHelper.ParseString(dataRow.ItemArray[pathfield]);
                    userInterface.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    userInterface.TableName = DataHelper.ParseString(dataRow.ItemArray[tableNamefield]);
                    userInterface.UIType = DataHelper.ParseInteger(dataRow.ItemArray[uITypefield], 0);
                }
                catch
                {
                }

                // return value
                return userInterface;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'UserInterface' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A UserInterface Collection.</returns>
            public static List<UserInterface> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<UserInterface> userInterfaces = new List<UserInterface>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'UserInterface' from rows
                        UserInterface userInterface = Load(row);

                        // Add this object to collection
                        userInterfaces.Add(userInterface);
                    }
                }
                catch
                {
                }

                // return value
                return userInterfaces;
            }
            #endregion

        #endregion

    }
    #endregion

}
