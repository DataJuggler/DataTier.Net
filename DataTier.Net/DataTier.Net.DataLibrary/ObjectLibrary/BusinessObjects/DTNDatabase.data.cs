

#region using statements

using System;
using ObjectLibrary.Enumerations;
using DataJuggler.Net.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class DTNDatabase
    public partial class DTNDatabase
    {

        #region Private Variables
        private int authenticationType;
        private string connectionString;
        private int databaseId;
        private string databaseName;
        private int databaseType;
        private string dBPassword;
        private int exclude;
        private string path;
        private int projectId;
        private bool serializable;
        private string serverName;
        private string userId;
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

                // AuthenticationType

                sb.Append(AuthenticationType);

                // Add a comma
                sb.Append(comma);

                // ConnectionString

                sb.Append(singleQuote);
                sb.Append(ConnectionString);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DatabaseName

                sb.Append(singleQuote);
                sb.Append(DatabaseName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // DatabaseType

                sb.Append(DatabaseType);

                // Add a comma
                sb.Append(comma);

                // DBPassword

                sb.Append(singleQuote);
                sb.Append(DBPassword);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // Exclude

                sb.Append(Exclude);

                // Add a comma
                sb.Append(comma);

                // Path

                sb.Append(singleQuote);
                sb.Append(Path);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ProjectId

                sb.Append(ProjectId);

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

                // ServerName

                sb.Append(singleQuote);
                sb.Append(ServerName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // UserId

                sb.Append(singleQuote);
                sb.Append(UserId);
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
                string insertSQL = "INSERT INTO [DTNDatabase] (AuthenticationType,ConnectionString,DatabaseName,DatabaseType,DBPassword,Exclude,Path,ProjectId,Serializable,ServerName,UserId) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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
                    case "AuthenticationType":

                        // set the value
                        value = this.AuthenticationType;

                        // required
                        break;

                    case "ConnectionString":

                        // set the value
                        value = this.ConnectionString;

                        // required
                        break;

                    case "DatabaseId":

                        // set the value
                        value = this.DatabaseId;

                        // required
                        break;

                    case "DatabaseName":

                        // set the value
                        value = this.DatabaseName;

                        // required
                        break;

                    case "DatabaseType":

                        // set the value
                        value = this.DatabaseType;

                        // required
                        break;

                    case "DBPassword":

                        // set the value
                        value = this.DBPassword;

                        // required
                        break;

                    case "Exclude":

                        // set the value
                        value = this.Exclude;

                        // required
                        break;

                    case "Path":

                        // set the value
                        value = this.Path;

                        // required
                        break;

                    case "ProjectId":

                        // set the value
                        value = this.ProjectId;

                        // required
                        break;

                    case "Serializable":

                        // set the value
                        value = this.Serializable;

                        // required
                        break;

                    case "ServerName":

                        // set the value
                        value = this.ServerName;

                        // required
                        break;

                    case "UserId":

                        // set the value
                        value = this.UserId;

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
                this.databaseId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int AuthenticationType
            public int AuthenticationType
            {
                get
                {
                    return authenticationType;
                }
                set
                {
                    authenticationType = value;
                }
            }
            #endregion

            #region string ConnectionString
            public string ConnectionString
            {
                get
                {
                    return connectionString;
                }
                set
                {
                    connectionString = value;
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
            }
            #endregion

            #region string DatabaseName
            public string DatabaseName
            {
                get
                {
                    return databaseName;
                }
                set
                {
                    databaseName = value;
                }
            }
            #endregion

            #region int DatabaseType
            public int DatabaseType
            {
                get
                {
                    return databaseType;
                }
                set
                {
                    databaseType = value;
                }
            }
            #endregion

            #region string DBPassword
            public string DBPassword
            {
                get
                {
                    return dBPassword;
                }
                set
                {
                    dBPassword = value;
                }
            }
            #endregion

            #region int Exclude
            public int Exclude
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

            #region string Path
            public string Path
            {
                get
                {
                    return path;
                }
                set
                {
                    path = value;
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

            #region string ServerName
            public string ServerName
            {
                get
                {
                    return serverName;
                }
                set
                {
                    serverName = value;
                }
            }
            #endregion

            #region string UserId
            public string UserId
            {
                get
                {
                    return userId;
                }
                set
                {
                    userId = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.DatabaseId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
