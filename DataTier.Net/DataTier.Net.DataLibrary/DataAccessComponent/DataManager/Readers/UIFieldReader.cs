

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
                int controlTypefield = 1;
                int dataTypefield = 2;
                int defaultValuefield = 3;
                int displayOrderfield = 4;
                int dTNFieldIdfield = 5;
                int fieldOrdinalfield = 6;
                int heightfield = 7;
                int idfield = 8;
                int leftfield = 9;
                int maxLengthfield = 10;
                int maxRangefield = 11;
                int minLengthfield = 12;
                int minRangefield = 13;
                int requiredfield = 14;
                int requiredMessagefield = 15;
                int topfield = 16;
                int uIObjectIdfield = 17;
                int userInterfaceIdfield = 18;
                int validationMessagefield = 19;
                int widthfield = 20;

                try
                {
                    // Load Each field
                    uIField.Caption = DataHelper.ParseString(dataRow.ItemArray[captionfield]);
                    uIField.ControlType = DataHelper.ParseInteger(dataRow.ItemArray[controlTypefield], 0);
                    uIField.DataType = (DataTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[dataTypefield], 0);
                    uIField.DefaultValue = DataHelper.ParseString(dataRow.ItemArray[defaultValuefield]);
                    uIField.DisplayOrder = DataHelper.ParseInteger(dataRow.ItemArray[displayOrderfield], 0);
                    uIField.DTNFieldId = DataHelper.ParseInteger(dataRow.ItemArray[dTNFieldIdfield], 0);
                    uIField.FieldOrdinal = DataHelper.ParseInteger(dataRow.ItemArray[fieldOrdinalfield], 0);
                    uIField.Height = DataHelper.ParseInteger(dataRow.ItemArray[heightfield], 0);
                    uIField.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[idfield], 0));
                    uIField.Left = DataHelper.ParseInteger(dataRow.ItemArray[leftfield], 0);
                    uIField.MaxLength = DataHelper.ParseInteger(dataRow.ItemArray[maxLengthfield], 0);
                    uIField.MaxRange = DataHelper.ParseDouble(dataRow.ItemArray[maxRangefield], 0);
                    uIField.MinLength = DataHelper.ParseInteger(dataRow.ItemArray[minLengthfield], 0);
                    uIField.MinRange = DataHelper.ParseDouble(dataRow.ItemArray[minRangefield], 0);
                    uIField.Required = DataHelper.ParseBoolean(dataRow.ItemArray[requiredfield], false);
                    uIField.RequiredMessage = DataHelper.ParseString(dataRow.ItemArray[requiredMessagefield]);
                    uIField.Top = DataHelper.ParseInteger(dataRow.ItemArray[topfield], 0);
                    uIField.UIObjectId = DataHelper.ParseInteger(dataRow.ItemArray[uIObjectIdfield], 0);
                    uIField.UserInterfaceId = DataHelper.ParseInteger(dataRow.ItemArray[userInterfaceIdfield], 0);
                    uIField.ValidationMessage = DataHelper.ParseString(dataRow.ItemArray[validationMessagefield]);
                    uIField.Width = DataHelper.ParseInteger(dataRow.ItemArray[widthfield], 0);
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
