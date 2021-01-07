

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class UIFieldReader
    /// <summary>
    /// This class loads a single 'UIField' object or a list of type <UIField>.
    /// </summary>
    public class UIFieldReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'UIField' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'UIField' DataObject.</returns>
            public static UIField Load(DataRow dataRow)
            {
                // Initial Value
                UIField uIField = new UIField();

                // Create field Integers
                int captionfield = 0;
                int dataTypefield = 1;
                int dTNFieldIdfield = 2;
                int fieldOrdinalfield = 3;
                int idfield = 4;
                int maxLengthfield = 5;
                int maxRangefield = 6;
                int minLengthfield = 7;
                int minRangefield = 8;
                int requiredfield = 9;
                int userInterfaceIdfield = 10;

                try
                {
                    // Load Each field
                    uIField.Caption = DataHelper.ParseString(dataRow.ItemArray[captionfield]);
                    uIField.DataType = (DataTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[dataTypefield], 0);
                    uIField.DTNFieldId = DataHelper.ParseInteger(dataRow.ItemArray[dTNFieldIdfield], 0);
                    uIField.FieldOrdinal = DataHelper.ParseInteger(dataRow.ItemArray[fieldOrdinalfield], 0);
                    uIField.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    uIField.MaxLength = DataHelper.ParseInteger(dataRow.ItemArray[maxLengthfield], 0);
                    uIField.MaxRange = DataHelper.ParseDouble(dataRow.ItemArray[maxRangefield], 0);
                    uIField.MinLength = DataHelper.ParseInteger(dataRow.ItemArray[minLengthfield], 0);
                    uIField.MinRange = DataHelper.ParseDouble(dataRow.ItemArray[minRangefield], 0);
                    uIField.Required = DataHelper.ParseBoolean(dataRow.ItemArray[requiredfield], false);
                    uIField.UserInterfaceId = DataHelper.ParseInteger(dataRow.ItemArray[userInterfaceIdfield], 0);
                }
                catch
                {
                }

                // return value
                return uIField;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'UIField' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A UIField Collection.</returns>
            public static List<UIField> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<UIField> uIFields = new List<UIField>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'UIField' from rows
                        UIField uIField = Load(row);

                        // Add this object to collection
                        uIFields.Add(uIField);
                    }
                }
                catch
                {
                }

                // return value
                return uIFields;
            }
            #endregion

        #endregion

    }
    #endregion

}
