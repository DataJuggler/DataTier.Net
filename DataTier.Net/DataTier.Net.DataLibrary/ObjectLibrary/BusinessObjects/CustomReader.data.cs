

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class CustomReader
    public partial class CustomReader
    {

        #region Private Variables
        private string className;
        private int customReaderId;
        private int fieldSetId;
        private string fileName;
        private string readerName;
        private int tableId;
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
                string singleQuote = "'";

                // ClassName

                sb.Append(singleQuote);
                sb.Append(ClassName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // FieldSetId

                sb.Append(FieldSetId);

                // Add a comma
                sb.Append(comma);

                // FileName

                sb.Append(singleQuote);
                sb.Append(FileName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ReaderName

                sb.Append(singleQuote);
                sb.Append(ReaderName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // TableId

                sb.Append(TableId);

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
                string insertSQL = "INSERT INTO [CustomReader] (ClassName,FieldSetId,FileName,ReaderName,TableId) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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
                    case "ClassName":

                        // set the value
                        value = this.ClassName;

                        // required
                        break;

                    case "CustomReaderId":

                        // set the value
                        value = this.CustomReaderId;

                        // required
                        break;

                    case "FieldSetId":

                        // set the value
                        value = this.FieldSetId;

                        // required
                        break;

                    case "FileName":

                        // set the value
                        value = this.FileName;

                        // required
                        break;

                    case "ReaderName":

                        // set the value
                        value = this.ReaderName;

                        // required
                        break;

                    case "TableId":

                        // set the value
                        value = this.TableId;

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
                this.customReaderId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region string ClassName
            public string ClassName
            {
                get
                {
                    return className;
                }
                set
                {
                    className = value;
                }
            }
            #endregion

            #region int CustomReaderId
            public int CustomReaderId
            {
                get
                {
                    return customReaderId;
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

            #region string FileName
            public string FileName
            {
                get
                {
                    return fileName;
                }
                set
                {
                    fileName = value;
                }
            }
            #endregion

            #region string ReaderName
            public string ReaderName
            {
                get
                {
                    return readerName;
                }
                set
                {
                    readerName = value;
                }
            }
            #endregion

            #region int TableId
            public int TableId
            {
                get
                {
                    return tableId;
                }
                set
                {
                    tableId = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.CustomReaderId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
