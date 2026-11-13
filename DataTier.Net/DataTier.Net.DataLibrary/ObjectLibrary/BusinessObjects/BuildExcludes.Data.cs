

#region using statements

using System;
using ObjectLibrary.Enumerations;
using DataJuggler.Net.Enumerations;

#endregion


namespace ObjectLibrary.BusinessObjects
{

    #region class BuildExcludes
    public partial class BuildExcludes
    {

        #region Private Variables
        private int databaseId;
        private bool excludeDelete;
        private bool excludeFetchAll;
        private bool excludeFind;
        private bool excludeInsert;
        private bool excludeUpdate;
        private int id;
        private int projectId;
        private int tableId;
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

            #region bool ExcludeDelete
            public bool ExcludeDelete
            {
                get
                {
                    return excludeDelete;
                }
                set
                {
                    excludeDelete = value;
                }
            }
            #endregion

            #region bool ExcludeFetchAll
            public bool ExcludeFetchAll
            {
                get
                {
                    return excludeFetchAll;
                }
                set
                {
                    excludeFetchAll = value;
                }
            }
            #endregion

            #region bool ExcludeFind
            public bool ExcludeFind
            {
                get
                {
                    return excludeFind;
                }
                set
                {
                    excludeFind = value;
                }
            }
            #endregion

            #region bool ExcludeInsert
            public bool ExcludeInsert
            {
                get
                {
                    return excludeInsert;
                }
                set
                {
                    excludeInsert = value;
                }
            }
            #endregion

            #region bool ExcludeUpdate
            public bool ExcludeUpdate
            {
                get
                {
                    return excludeUpdate;
                }
                set
                {
                    excludeUpdate = value;
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

            #region int TableId
            public int TableId
            {
                get
                {
                    return tableId;
                }
                set
                {
                    tableId = value;
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
