

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class ProjectReference
    public partial class ProjectReference
    {

        #region Private Variables
        private string referenceName;
        private int referencesId;
        private int referencesSetId;
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

                // ReferenceName

                sb.Append(singleQuote);
                sb.Append(ReferenceName);
                sb.Append(singleQuote);

                // Add a comma
                sb.Append(comma);

                // ReferencesSetId

                sb.Append(ReferencesSetId);

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
                string insertSQL = "INSERT INTO [ProjectReference] (ReferenceName,ReferencesSetId) VALUES (" + valuesList + ") " + Environment.NewLine + "SELECT SCOPE_IDENTITY()" + Environment.NewLine;

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
                    case "ReferenceName":

                        // set the value
                        value = this.ReferenceName;

                        // required
                        break;

                    case "ReferencesId":

                        // set the value
                        value = this.ReferencesId;

                        // required
                        break;

                    case "ReferencesSetId":

                        // set the value
                        value = this.ReferencesSetId;

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
                this.referencesId = id;
            }
            #endregion

        #endregion

        #region Properties

            #region string ReferenceName
            public string ReferenceName
            {
                get
                {
                    return referenceName;
                }
                set
                {
                    referenceName = value;
                }
            }
            #endregion

            #region int ReferencesId
            public int ReferencesId
            {
                get
                {
                    return referencesId;
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
                set
                {
                    referencesSetId = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.ReferencesId < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
