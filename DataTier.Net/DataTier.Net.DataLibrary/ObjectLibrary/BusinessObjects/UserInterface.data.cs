

#region using statements

using DataJuggler.Net.Enumerations;
using ObjectLibrary.Enumerations;
using System;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class UserInterface
    public partial class UserInterface
    {

        #region Private Variables
        private string dataSourceName;
        private int dataSourceType;
        private int id;
        private string name;
        private string path;
        private int projectId;
        private int uIType;
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
                this.id = id;
            }
            #endregion

        #endregion

        #region Properties

            #region string DataSourceName
            public string DataSourceName
            {
                get
                {
                    return dataSourceName;
                }
                set
                {
                    dataSourceName = value;
                }
            }
            #endregion

            #region int DataSourceType
            public int DataSourceType
            {
                get
                {
                    return dataSourceType;
                }
                set
                {
                    dataSourceType = value;
                }
            }
            #endregion

            #region int Id
            public int Id
            {
                get
                {
                    return id;
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

            #region int UIType
            public int UIType
            {
                get
                {
                    return uIType;
                }
                set
                {
                    uIType = value;
                }
            }
            #endregion

            #region bool IsNew
            public bool IsNew
            {
                get
                {
                    // Initial Value
                    bool isNew = (this.Id < 1);

                    // return value
                    return isNew;
                }
            }
            #endregion

        #endregion

    }
    #endregion

}
