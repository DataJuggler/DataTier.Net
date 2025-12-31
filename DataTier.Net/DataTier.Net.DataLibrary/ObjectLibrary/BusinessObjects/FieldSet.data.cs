

#region using statements

using System;
using ObjectLibrary.Enumerations;
using DataJuggler.Net.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class FieldSet
    public partial class FieldSet
    {

        #region Private Variables
        private int databaseId;
        private int fieldSetId;
        private string name;
        private bool orderByMode;
        private bool parameterMode;
        private int projectId;
        private bool readerMode;
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

                // DatabaseId

                sb.Append(DatabaseId);

                // Add a comma
                sb.Append(comma);

                // Name

                sb.Append(singleQuote);
                sb.Append(Name);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // OrderByMode

                // If OrderByMode is true
                if (OrderByMode)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // ParameterMode

                // If ParameterMode is true
                if (ParameterMode)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // ProjectId

                sb.Append(ProjectId);

                // Add a comma
                sb.Append(comma);

                // ReaderMode

                // If ReaderMode is true
                if (ReaderMode)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

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
                string insertSQL = "INSERT INTO [FieldSet] (DatabaseId,Name,OrderByMode,ParameterMode,ProjectId,ReaderMode,TableId) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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
                    case "DatabaseId":

                        // set the value
                        value = this.DatabaseId;

                        // required
                        break;

                    case "FieldSetId":

                        // set the value
                        value = this.FieldSetId;

                        // required
                        break;

                    case "Name":

                        // set the value
                        value = this.Name;

                        // required
                        break;

                    case "OrderByMode":

                        // set the value
                        value = this.OrderByMode;

                        // required
                        break;

                    case "ParameterMode":

                        // set the value
                        value = this.ParameterMode;

                        // required
                        break;

                    case "ProjectId":

                        // set the value
                        value = this.ProjectId;

                        // required
                        break;

                    case "ReaderMode":

                        // set the value
                        value = this.ReaderMode;

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
                this.fieldSetId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int DatabaseId
            public int DatabaseId
            {
                get
                {
                    return databaseId;
                }
                set
                {
                    databaseId = value;
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
            }
            #endregion

            #region string Name
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
            #endregion

            #region bool OrderByMode
            public bool OrderByMode
            {
                get
                {
                    return orderByMode;
                }
                set
                {
                    orderByMode = value;
                }
            }
            #endregion

            #region bool ParameterMode
            public bool ParameterMode
            {
                get
                {
                    return parameterMode;
                }
                set
                {
                    parameterMode = value;
                }
            }
            #endregion

            #region int ProjectId
            public int ProjectId
            {
                get
                {
                    return projectId;
                }
                set
                {
                    projectId = value;
                }
            }
            #endregion

            #region bool ReaderMode
            public bool ReaderMode
            {
                get
                {
                    return readerMode;
                }
                set
                {
                    readerMode = value;
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
                    bool isNew = (this.FieldSetId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
