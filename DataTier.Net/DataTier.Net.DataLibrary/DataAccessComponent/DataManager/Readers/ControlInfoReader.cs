

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

    #region class ControlInfoReader
    /// <summary>
    /// This class loads a single 'ControlInfo' object or a list of type <ControlInfo>.
    /// </summary>
    public class ControlInfoReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'ControlInfo' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'ControlInfo' DataObject.</returns>
            public static ControlInfo Load(DataRow dataRow)
            {
                // Initial Value
                ControlInfo controlInfo = new ControlInfo();

                // Create field Integers
                int idfield = 0;
                int namefield = 1;
                int packageNamefield = 2;

                try
                {
                    // Load Each field
                    controlInfo.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    controlInfo.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    controlInfo.PackageName = DataHelper.ParseString(dataRow.ItemArray[packageNamefield]);
                }
                catch
                {
                }

                // return value
                return controlInfo;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'ControlInfo' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A ControlInfo Collection.</returns>
            public static List<ControlInfo> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<ControlInfo> controlInfos = new List<ControlInfo>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'ControlInfo' from rows
                        ControlInfo controlInfo = Load(row);

                        // Add this object to collection
                        controlInfos.Add(controlInfo);
                    }
                }
                catch
                {
                }

                // return value
                return controlInfos;
            }
            #endregion

        #endregion

    }
    #endregion

}
