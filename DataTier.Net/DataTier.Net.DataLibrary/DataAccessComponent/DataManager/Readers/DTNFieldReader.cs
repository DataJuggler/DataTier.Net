

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.DataManager.Readers
{

    #region class DTNFieldReader
    /// <summary>
    /// This class loads a single 'DTNField' object or a list of type <DTNField>.
    /// </summary>
    public class DTNFieldReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'DTNField' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'DTNField' DataObject.</returns>
            public static DTNField Load(DataRow dataRow)
            {
                // Initial Value
                DTNField dTNField = new DTNField();

                // Create field Integers
                int accessModefield = 0;
                int captionfield = 1;
                int databaseIdfield = 2;
                int dataTypefield = 3;
                int decimalPlacesfield = 4;
                int defaultValuefield = 5;
                int enumDataTypeNamefield = 6;
                int excludefield = 7;
                int fieldIdfield = 8;
                int fieldNamefield = 9;
                int fieldOrdinalfield = 10;
                int fieldSizefield = 11;
                int isEnumerationfield = 12;
                int isNullablefield = 13;
                int primaryKeyfield = 14;
                int projectIdfield = 15;
                int requiredfield = 16;
                int scopefield = 17;
                int tableIdfield = 18;

                try
                {
                    // Load Each field
                    dTNField.AccessMode = (AccessModeEnum) DataHelper.ParseInteger(dataRow.ItemArray[accessModefield], 0);
                    dTNField.Caption = DataHelper.ParseString(dataRow.ItemArray[captionfield]);
                    dTNField.DatabaseId = DataHelper.ParseInteger(dataRow.ItemArray[databaseIdfield], 0);
                    dTNField.DataType = (DataTypeEnum) DataHelper.ParseInteger(dataRow.ItemArray[dataTypefield], 0);
                    dTNField.DecimalPlaces = DataHelper.ParseInteger(dataRow.ItemArray[decimalPlacesfield], 0);
                    dTNField.DefaultValue = DataHelper.ParseString(dataRow.ItemArray[defaultValuefield]);
                    dTNField.EnumDataTypeName = DataHelper.ParseString(dataRow.ItemArray[enumDataTypeNamefield]);
                    dTNField.Exclude = DataHelper.ParseBoolean(dataRow.ItemArray[excludefield], false);
                    dTNField.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[fieldIdfield], 0));
                    dTNField.FieldName = DataHelper.ParseString(dataRow.ItemArray[fieldNamefield]);
                    dTNField.FieldOrdinal = DataHelper.ParseInteger(dataRow.ItemArray[fieldOrdinalfield], 0);
                    dTNField.FieldSize = DataHelper.ParseInteger(dataRow.ItemArray[fieldSizefield], 0);
                    dTNField.IsEnumeration = DataHelper.ParseBoolean(dataRow.ItemArray[isEnumerationfield], false);
                    dTNField.IsNullable = DataHelper.ParseInteger(dataRow.ItemArray[isNullablefield], 0);
                    dTNField.PrimaryKey = DataHelper.ParseBoolean(dataRow.ItemArray[primaryKeyfield], false);
                    dTNField.ProjectId = DataHelper.ParseInteger(dataRow.ItemArray[projectIdfield], 0);
                    dTNField.Required = DataHelper.ParseBoolean(dataRow.ItemArray[requiredfield], false);
                    dTNField.Scope = (ScopeEnum) DataHelper.ParseInteger(dataRow.ItemArray[scopefield], 0);
                    dTNField.TableId = DataHelper.ParseInteger(dataRow.ItemArray[tableIdfield], 0);
                }
                catch
                {
                }

                // return value
                return dTNField;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'DTNField' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A DTNField Collection.</returns>
            public static List<DTNField> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<DTNField> dTNFields = new List<DTNField>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'DTNField' from rows
                        DTNField dTNField = Load(row);

                        // Add this object to collection
                        dTNFields.Add(dTNField);
                    }
                }
                catch
                {
                }

                // return value
                return dTNFields;
            }
            #endregion

        #endregion

    }
    #endregion

}
