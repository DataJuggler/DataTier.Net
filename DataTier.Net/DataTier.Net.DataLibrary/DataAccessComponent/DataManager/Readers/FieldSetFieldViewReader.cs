

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class FieldSetFieldViewReader
    /// <summary>
    /// This class loads a single 'FieldSetFieldView' object or a list of type <FieldSetFieldView>.
    /// </summary>
    public class FieldSetFieldViewReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'FieldSetFieldView' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'FieldSetFieldView' DataObject.</returns>
            public static FieldSetFieldView Load(DataRow dataRow)
            {
                // Initial Value
                FieldSetFieldView fieldSetFieldView = new FieldSetFieldView();

                // Create field Integers
                int databaseIdfield = 0;
                int dataTypefield = 1;
                int decimalPlacesfield = 2;
                int defaultValuefield = 3;
                int enumDataTypeNamefield = 4;
                int fieldIdfield = 5;
                int fieldNamefield = 6;
                int fieldOrdinalfield = 7;
                int fieldSetFieldIdfield = 8;
                int fieldSetIdfield = 9;
                int fieldSetNamefield = 10;
                int fieldSizefield = 11;
                int isEnumerationfield = 12;
                int isNullablefield = 13;
                int orderByDescendingfield = 14;
                int parameterModefield = 15;
                int primaryKeyfield = 16;
                int projectIdfield = 17;
                int requiredfield = 18;
                int scopefield = 19;
                int tableIdfield = 20;

                try
                {
                    // Load Each field
                    fieldSetFieldView.DatabaseId = DataHelper.ParseInteger(dataRow.ItemArray[databaseIdfield], 0);
                    fieldSetFieldView.DataType = (DataTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[dataTypefield], 0);
                    fieldSetFieldView.DecimalPlaces = DataHelper.ParseInteger(dataRow.ItemArray[decimalPlacesfield], 0);
                    fieldSetFieldView.DefaultValue = DataHelper.ParseString(dataRow.ItemArray[defaultValuefield]);
                    fieldSetFieldView.EnumDataTypeName = DataHelper.ParseString(dataRow.ItemArray[enumDataTypeNamefield]);
                    fieldSetFieldView.FieldId = DataHelper.ParseInteger(dataRow.ItemArray[fieldIdfield], 0);
                    fieldSetFieldView.FieldName = DataHelper.ParseString(dataRow.ItemArray[fieldNamefield]);
                    fieldSetFieldView.FieldOrdinal = DataHelper.ParseInteger(dataRow.ItemArray[fieldOrdinalfield], 0);
                    fieldSetFieldView.FieldSetFieldId = DataHelper.ParseInteger(dataRow.ItemArray[fieldSetFieldIdfield], 0);
                    fieldSetFieldView.FieldSetId = DataHelper.ParseInteger(dataRow.ItemArray[fieldSetIdfield], 0);
                    fieldSetFieldView.FieldSetName = DataHelper.ParseString(dataRow.ItemArray[fieldSetNamefield]);
                    fieldSetFieldView.FieldSize = DataHelper.ParseInteger(dataRow.ItemArray[fieldSizefield], 0);
                    fieldSetFieldView.IsEnumeration = DataHelper.ParseBoolean(dataRow.ItemArray[isEnumerationfield], false);
                    fieldSetFieldView.IsNullable = DataHelper.ParseInteger(dataRow.ItemArray[isNullablefield], 0);
                    fieldSetFieldView.OrderByDescending = DataHelper.ParseBoolean(dataRow.ItemArray[orderByDescendingfield], false);
                    fieldSetFieldView.ParameterMode = DataHelper.ParseBoolean(dataRow.ItemArray[parameterModefield], false);
                    fieldSetFieldView.PrimaryKey = DataHelper.ParseBoolean(dataRow.ItemArray[primaryKeyfield], false);
                    fieldSetFieldView.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    fieldSetFieldView.Required = DataHelper.ParseBoolean(dataRow.ItemArray[requiredfield], false);
                    fieldSetFieldView.Scope = (ScopeEnum) DataHelper.ParseInteger(dataRow.ItemArray[scopefield], 0);
                    fieldSetFieldView.TableId = DataHelper.ParseInteger(dataRow.ItemArray[tableIdfield], 0);
                }
                catch
                {
                }

                // return value
                return fieldSetFieldView;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'FieldSetFieldView' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A FieldSetFieldView Collection.</returns>
            public static List<FieldSetFieldView> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<FieldSetFieldView> fieldSetFieldViews = new List<FieldSetFieldView>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'FieldSetFieldView' from rows
                        FieldSetFieldView fieldSetFieldView = Load(row);

                        // Add this object to collection
                        fieldSetFieldViews.Add(fieldSetFieldView);
                    }
                }
                catch
                {
                }

                // return value
                return fieldSetFieldViews;
            }
            #endregion

        #endregion

    }
    #endregion

}
