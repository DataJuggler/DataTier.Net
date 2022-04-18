

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

    #region class UIObjectReader
    /// <summary>
    /// This class loads a single 'UIObject' object or a list of type <UIObject>.
    /// </summary>
    public class UIObjectReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'UIObject' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'UIObject' DataObject.</returns>
            public static UIObject Load(DataRow dataRow)
            {
                // Initial Value
                UIObject uIObject = new UIObject();

                // Create field Integers
                int controlTypefield = 0;
                int displayOrderfield = 1;
                int formTypefield = 2;
                int heightfield = 3;
                int idfield = 4;
                int isControlfield = 5;
                int isFormfield = 6;
                int leftfield = 7;
                int namefield = 8;
                int parentIdfield = 9;
                int topfield = 10;
                int widthfield = 11;

                try
                {
                    // Load Each field
                    uIObject.ControlType = DataHelper.ParseInteger(dataRow.ItemArray[controlTypefield], 0);
                    uIObject.DisplayOrder = DataHelper.ParseInteger(dataRow.ItemArray[displayOrderfield], 0);
                    uIObject.FormType = DataHelper.ParseInteger(dataRow.ItemArray[formTypefield], 0);
                    uIObject.Height = DataHelper.ParseInteger(dataRow.ItemArray[heightfield], 0);
                    uIObject.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    uIObject.IsControl = DataHelper.ParseBoolean(dataRow.ItemArray[isControlfield], false);
                    uIObject.IsForm = DataHelper.ParseBoolean(dataRow.ItemArray[isFormfield], false);
                    uIObject.Left = DataHelper.ParseInteger(dataRow.ItemArray[leftfield], 0);
                    uIObject.Name = DataHelper.ParseString(dataRow.ItemArray[namefield]);
                    uIObject.ParentId = DataHelper.ParseInteger(dataRow.ItemArray[parentIdfield], 0);
                    uIObject.Top = DataHelper.ParseInteger(dataRow.ItemArray[topfield], 0);
                    uIObject.Width = DataHelper.ParseInteger(dataRow.ItemArray[widthfield], 0);
                }
                catch
                {
                }

                // return value
                return uIObject;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'UIObject' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A UIObject Collection.</returns>
            public static List<UIObject> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<UIObject> uIObjects = new List<UIObject>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'UIObject' from rows
                        UIObject uIObject = Load(row);

                        // Add this object to collection
                        uIObjects.Add(uIObject);
                    }
                }
                catch
                {
                }

                // return value
                return uIObjects;
            }
            #endregion

        #endregion

    }
    #endregion

}
