

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

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
