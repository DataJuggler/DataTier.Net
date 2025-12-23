

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Enumeration
    public partial class Enumeration
    {

        #region Private Variables
        private int enumerationId;
        private string enumerationName;
        private string fieldName;
        private int projectId;
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

                // EnumerationName

                sb.Append(singleQuote);
                sb.Append(EnumerationName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // FieldName

                sb.Append(singleQuote);
                sb.Append(FieldName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ProjectId

                sb.Append(ProjectId);

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
                string insertSQL = "INSERT INTO [Enumeration] (EnumerationName,FieldName,ProjectId) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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
                    case "EnumerationId":

                        // set the value
                        value = this.EnumerationId;

                        // required
                        break;

                    case "EnumerationName":

                        // set the value
                        value = this.EnumerationName;

                        // required
                        break;

                    case "FieldName":

                        // set the value
                        value = this.FieldName;

                        // required
                        break;

                    case "ProjectId":

                        // set the value
                        value = this.ProjectId;

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
                this.enumerationId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int EnumerationId
            public int EnumerationId
            {
                get
                {
                    return enumerationId;
                }
            }
            #endregion

            #region string EnumerationName
            public string EnumerationName
            {
                get
                {
                    return enumerationName;
                }
                set
                {
                    enumerationName = value;
                }
            }
            #endregion

            #region string FieldName
            public string FieldName
            {
                get
                {
                    return fieldName;
                }
                set
                {
                    fieldName = value;
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

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.EnumerationId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
