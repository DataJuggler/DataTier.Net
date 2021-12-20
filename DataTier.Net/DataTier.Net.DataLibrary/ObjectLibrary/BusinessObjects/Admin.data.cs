

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
