

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

    #region class FieldViewReader
    /// <summary>
    /// This class loads a single 'FieldView' object or a list of type <FieldView>.
    /// </summary>
    public class FieldViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'FieldView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'FieldView' DataObject.</returns>
            public static FieldView Load(DataRow dataRow)
            {
                // Initial Value
                FieldView fieldView = new FieldView();

                // Create field Integers
                int dataTypefield = 0;
                int excludefield = 1;
                int fieldNamefield = 2;
                int isNullablefield = 3;
                int projectIdfield = 4;
                int tableIdfield = 5;
                int tableNamefield = 6;

                try
                {
                    // Load Each field
                    fieldView.DataType = (DataTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[dataTypefield], 0);
                    fieldView.Exclude = DataHelper.ParseBoolean(dataRow.ItemArray[excludefield], false);
                    fieldView.FieldName = DataHelper.ParseString(dataRow.ItemArray[fieldNamefield]);
                    fieldView.IsNullable = DataHelper.ParseInteger(dataRow.ItemArray[isNullablefield], 0);
                    fieldView.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    fieldView.TableId = DataHelper.ParseInteger(dataRow.ItemArray[tableIdfield], 0);
                    fieldView.TableName = DataHelper.ParseString(dataRow.ItemArray[tableNamefield]);
                }
                catch
                {
                }

                // return value
                return fieldView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'FieldView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A FieldView Collection.</returns>
            public static List<FieldView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<FieldView> fieldViews = new List<FieldView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'FieldView' from rows
                        FieldView fieldView = Load(row);

                        // Add this object to collection
                        fieldViews.Add(fieldView);
                    }
                }
                catch
                {
                }

                // return value
                return fieldViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
