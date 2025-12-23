

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FieldSetField
    public partial class FieldSetField
    {

        #region Private Variables
        private int fieldId;
        private int fieldOrdinal;
        private int fieldSetFieldId;
        private int fieldSetId;
        private bool orderByDescending;
        #endregion

        #region Methods

            #region CreateValuesList
            // <summary>
            // This method creates the ValuesList for an Insert SQL Statement.'
            // </summary>
            public string CreateValuesList()
            {
                // initial value
                string valuesList = "";

                // locals
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                string comma = ",";

                // FieldId

                sb.Append(FieldId);

                // Add a comma
                sb.Append(comma);

                // FieldOrdinal

                sb.Append(FieldOrdinal);

                // Add a comma
                sb.Append(comma);

                // FieldSetId

                sb.Append(FieldSetId);

                // Add a comma
                sb.Append(comma);

                // OrderByDescending

                // If OrderByDescending is true
                if (OrderByDescending)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Set the return value
                valuesList = sb.ToString();

                // Return Value
                return valuesList;
            }
            #endregion

            #region GenerateInsertSQL
            // <summary>
            // This method generates a SQL Insert statement for ah object loaded.'
            // </summary>
            public string GenerateInsertSQL()
            {
                // local
                string valuesList = CreateValuesList();

                // Set the return Value
                string insertSQL = "INSERT INTO [FieldSetField] (FieldId,FieldOrdinal,FieldSetId,OrderByDescending) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

                // Return Value
                return insertSQL;
            }
            #endregion

            #region GetValue(string fieldName)
            // <summary>
            // This method returns the value for the fieldName given
            // </summary>
            public object GetValue(string fieldName)
            {
                // initial value
                object value = "";

                // // Determine the action by the fieldName
                switch (fieldName)
                {
                    case "FieldId":

                        // set the value
                        value = this.FieldId;

                        // required
                        break;

                    case "FieldOrdinal":

                        // set the value
                        value = this.FieldOrdinal;

                        // required
                        break;

                    case "FieldSetFieldId":

                        // set the value
                        value = this.FieldSetFieldId;

                        // required
                        break;

                    case "FieldSetId":

                        // set the value
                        value = this.FieldSetId;

                        // required
                        break;

                    case "OrderByDescending":

                        // set the value
                        value = this.OrderByDescending;

                        // required
                        break;

                }

                // return value
                return value;
            }
            #endregion

            #region UpdateIdentity(int id)
            // <summary>
            // This method provides a 'setter'
            // functionality for the Identity field.
            // </summary>
            public void UpdateIdentity(int id)
            {
                // Update The Identity field
                this.fieldSetFieldId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int FieldId
            public int FieldId
            {
                get
                {
                    return fieldId;
                }
                set
                {
                    fieldId = value;
                }
            }
            #endregion

            #region int FieldOrdinal
            public int FieldOrdinal
            {
                get
                {
                    return fieldOrdinal;
                }
                set
                {
                    fieldOrdinal = value;
                }
            }
            #endregion

            #region int FieldSetFieldId
            public int FieldSetFieldId
            {
                get
                {
                    return fieldSetFieldId;
                }
            }
            #endregion

            #region int FieldSetId
            public int FieldSetId
            {
                get
                {
                    return fieldSetId;
                }
                set
                {
                    fieldSetId = value;
                }
            }
            #endregion

            #region bool OrderByDescending
            public bool OrderByDescending
            {
                get
                {
                    return orderByDescending;
                }
                set
                {
                    orderByDescending = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.FieldSetFieldId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
