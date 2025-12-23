

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ReferencesSet
    public partial class ReferencesSet
    {

        #region Private Variables
        private int projectId;
        private int referencesSetId;
        private string referencesSetName;
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

                // ProjectId

                sb.Append(ProjectId);

                // Add a comma
                sb.Append(comma);

                // ReferencesSetName

                sb.Append(singleQuote);
                sb.Append(ReferencesSetName);
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
                string insertSQL = "INSERT INTO [ReferencesSet] (ProjectId,ReferencesSetName) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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
                    case "ProjectId":

                        // set the value
                        value = this.ProjectId;

                        // required
                        break;

                    case "ReferencesSetId":

                        // set the value
                        value = this.ReferencesSetId;

                        // required
                        break;

                    case "ReferencesSetName":

                        // set the value
                        value = this.ReferencesSetName;

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
                this.referencesSetId = id;
            }
            #endregion

        #endregion

        #region Properties

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

            #region int ReferencesSetId
            public int ReferencesSetId
            {
                get
                {
                    return referencesSetId;
                }
            }
            #endregion

            #region string ReferencesSetName
            public string ReferencesSetName
            {
                get
                {
                    return referencesSetName;
                }
                set
                {
                    referencesSetName = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.ReferencesSetId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
