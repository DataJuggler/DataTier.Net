

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class Admin
    public partial class Admin
    {

        #region Private Variables
        private int adminId;
        private bool checkForUpdates;
        private string codeVersion;
        private string gitCommit;
        private DateTime lastUpdated;
        private string schemaHash;
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

                // CheckForUpdates

                // If CheckForUpdates is true
                if (CheckForUpdates)
                {
                    sb.Append(1);
                }
                else
                {
                    sb.Append(0);
                }

                // Add a comma
                sb.Append(comma);

                // CodeVersion

                sb.Append(singleQuote);
                sb.Append(CodeVersion);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // GitCommit

                sb.Append(singleQuote);
                sb.Append(GitCommit);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // LastUpdated

                // If a valid date
                if (LastUpdated.Year > 1900)
                {
                    sb.Append(singleQuote);
                    sb.Append(LastUpdated.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(singleQuote);
                }
                else
                {
                    sb.Append("NULL");
                }

                // Add a comma
                sb.Append(comma);

                // SchemaHash

                sb.Append(singleQuote);
                sb.Append(SchemaHash);
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
                string insertSQL = "INSERT INTO [Admin] (CheckForUpdates,CodeVersion,GitCommit,LastUpdated,SchemaHash) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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
                    case "AdminId":

                        // set the value
                        value = this.AdminId;

                        // required
                        break;

                    case "CheckForUpdates":

                        // set the value
                        value = this.CheckForUpdates;

                        // required
                        break;

                    case "CodeVersion":

                        // set the value
                        value = this.CodeVersion;

                        // required
                        break;

                    case "GitCommit":

                        // set the value
                        value = this.GitCommit;

                        // required
                        break;

                    case "LastUpdated":

                        // set the value
                        value = this.LastUpdated;

                        // required
                        break;

                    case "SchemaHash":

                        // set the value
                        value = this.SchemaHash;

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
                this.adminId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region int AdminId
            public int AdminId
            {
                get
                {
                    return adminId;
                }
            }
            #endregion

            #region bool CheckForUpdates
            public bool CheckForUpdates
            {
                get
                {
                    return checkForUpdates;
                }
                set
                {
                    checkForUpdates = value;
                }
            }
            #endregion

            #region string CodeVersion
            public string CodeVersion
            {
                get
                {
                    return codeVersion;
                }
                set
                {
                    codeVersion = value;
                }
            }
            #endregion

            #region string GitCommit
            public string GitCommit
            {
                get
                {
                    return gitCommit;
                }
                set
                {
                    gitCommit = value;
                }
            }
            #endregion

            #region DateTime LastUpdated
            public DateTime LastUpdated
            {
                get
                {
                    return lastUpdated;
                }
                set
                {
                    lastUpdated = value;
                }
            }
            #endregion

            #region string SchemaHash
            public string SchemaHash
            {
                get
                {
                    return schemaHash;
                }
                set
                {
                    schemaHash = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.AdminId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
