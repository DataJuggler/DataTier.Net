

#region using statements

using ObjectLibrary.BusinessObjects;
using ObjectLibrary.Enumerations;
using System;
using System.Collections.Generic;
using System.Data;

#endregion


namespace DataAccessComponent.Data.Readers
{

    #region class FieldSetFieldReader
    /// <summary>
    /// This class loads a single 'FieldSetField' object or a list of type <FieldSetField>.
    /// </summary>
    public class FieldSetFieldReader
    {

        #region Static Methods

            #region Load(DataRow dataRow)
            /// <summary>
            /// This method loads a 'FieldSetField' object
            /// from the dataRow passed in.
            /// </summary>
            /// <param name='dataRow'>The 'DataRow' to load from.</param>
            /// <returns>A 'FieldSetField' DataObject.</returns>
            public static FieldSetField Load(DataRow dataRow)
            {
                // Initial Value
                FieldSetField fieldSetField = new FieldSetField();

                // Create field Integers
                int fieldIdfield = 0;
                int fieldOrdinalfield = 1;
                int fieldSetFieldIdfield = 2;
                int fieldSetIdfield = 3;
                int orderByDescendingfield = 4;

                try
                {
                    // Load Each field
                    fieldSetField.FieldId = DataHelper.ParseInteger(dataRow.ItemArray[fieldIdfield], 0);
                    fieldSetField.FieldOrdinal = DataHelper.ParseInteger(dataRow.ItemArray[fieldOrdinalfield], 0);
                    fieldSetField.UpdateIdentity(DataHelper.ParseInteger(dataRow.ItemArray[fieldSetFieldIdfield], 0));
                    fieldSetField.FieldSetId = DataHelper.ParseInteger(dataRow.ItemArray[fieldSetIdfield], 0);
                    fieldSetField.OrderByDescending = DataHelper.ParseBoolean(dataRow.ItemArray[orderByDescendingfield], false);
                }
                catch
                {
                }

                // return value
                return fieldSetField;
            }
            #endregion

            #region LoadCollection(DataTable dataTable)
            /// <summary>
            /// This method loads a collection of 'FieldSetField' objects.
            /// from the dataTable.Rows object passed in.
            /// </summary>
            /// <param name='dataTable'>The 'DataTable.Rows' to load from.</param>
            /// <returns>A FieldSetField Collection.</returns>
            public static List<FieldSetField> LoadCollection(DataTable dataTable)
            {
                // Initial Value
                List<FieldSetField> fieldSetFields = new List<FieldSetField>();

                try
                {
                    // Load Each row In DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Create 'FieldSetField' from rows
                        FieldSetField fieldSetField = Load(row);

                        // Add this object to collection
                        fieldSetFields.Add(fieldSetField);
                    }
                }
                catch
                {
                }

                // return value
                return fieldSetFields;
            }
            #endregion

        #endregion

    }
    #endregion

}
