

#region using statements

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
        private int scope;
        private bool serializable;
        private int tableId;
        private string tableName;
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

            #region int Scope
            public int Scope
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
