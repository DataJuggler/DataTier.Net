

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DTNTable
    public partial class DTNTable
    {

        #region Private Variables
        private string classFileName;
        private string className;
        private int databaseId;
        private bool exclude;
        private bool excluded;
        private bool isView;
        private int projectId;
        private ScopeEnum scope;
        private bool serializable;
        private int tableId;
        private string tableName;
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

                // ClassFileName

                sb.Append(singleQuote);
                sb.Append(ClassFileName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ClassName

                sb.Append(singleQuote);
                sb.Append(ClassName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DatabaseId

                sb.Append(DatabaseId);

                // Add a comma
                sb.Append(comma);

                // Exclude

                // If Exclude is true
                if (Exclude)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // Excluded

                // If Excluded is true
                if (Excluded)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // IsView

                // If IsView is true
                if (IsView)
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

                // Scope

                sb.Append(Scope);

                // Add a comma
                sb.Append(comma);

                // Serializable

                // If Serializable is true
                if (Serializable)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // TableName

                sb.Append(singleQuote);
                sb.Append(TableName);
                sb.Append(singleQuote);

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
                string insertSQL = "INSERT INTO [DTNTable] (ClassFileName,ClassName,DatabaseId,Exclude,Excluded,IsView,ProjectId,Scope,Serializable,TableName) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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
                    case "ClassFileName":

                        // set the value
                        value = this.ClassFileName;

                        // required
                        break;

                    case "ClassName":

                        // set the value
                        value = this.ClassName;

                        // required
                        break;

                    case "DatabaseId":

                        // set the value
                        value = this.DatabaseId;

                        // required
                        break;

                    case "Exclude":

                        // set the value
                        value = this.Exclude;

                        // required
                        break;

                    case "Excluded":

                        // set the value
                        value = this.Excluded;

                        // required
                        break;

                    case "IsView":

                        // set the value
                        value = this.IsView;

                        // required
                        break;

                    case "ProjectId":

                        // set the value
                        value = this.ProjectId;

                        // required
                        break;

                    case "Scope":

                        // set the value
                        value = this.Scope;

                        // required
                        break;

                    case "Serializable":

                        // set the value
                        value = this.Serializable;

                        // required
                        break;

                    case "TableId":

                        // set the value
                        value = this.TableId;

                        // required
                        break;

                    case "TableName":

                        // set the value
                        value = this.TableName;

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
                this.tableId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region string ClassFileName
            public string ClassFileName
            {
                get
                {
                    return classFileName;
                }
                set
                {
                    classFileName = value;
                }
            }
            #endregion

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

            #region bool Exclude
            public bool Exclude
            {
                get
                {
                    return exclude;
                }
                set
                {
                    exclude = value;
                }
            }
            #endregion

            #region bool Excluded
            public bool Excluded
            {
                get
                {
                    return excluded;
                }
                set
                {
                    excluded = value;
                }
            }
            #endregion

            #region bool IsView
            public bool IsView
            {
                get
                {
                    return isView;
                }
                set
                {
                    isView = value;
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

            #region ScopeEnum Scope
            public ScopeEnum Scope
            {
                get
                {
                    return scope;
                }
                set
                {
                    scope = value;
                }
            }
            #endregion

            #region bool Serializable
            public bool Serializable
            {
                get
                {
                    return serializable;
                }
                set
                {
                    serializable = value;
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
            }
            #endregion

            #region string TableName
            public string TableName
            {
                get
                {
                    return tableName;
                }
                set
                {
                    tableName = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.TableId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
